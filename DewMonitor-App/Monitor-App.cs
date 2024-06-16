using ASCOM.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ASCOM.QAstroDew
{
    public partial class MonitorApp : Form
    {
        private static TraceLogger dataLogger;
        private static readonly string logName = "Q-Astro Dew Monitor";

        private readonly String aObservingID = "ASCOM.QAstroDew.ObservingConditions";
        private ASCOM.DriverAccess.ObservingConditions aObserving;

        private int iTrackBarDisabled = 0;

        enum Status
        {
            CONNECTED,
            CONNECTING,
            DISCONNECTED,
            DISCONNECTING,
            TIMEOUT,
            AWAITINGDATA,
            MANUALON,
            MANUALOFF,
            UPDATEDEW,
            SETUP,
            ERROR
        }

        private const String cConnected = "Connected - Receiving Frequent Updates...";
        private const String cConnecting = "Connecting...";
        private const String cDisconnected = "Disconnected!";
        private const String cDisconnecting = "Disconnecting";
        private const String cAwaitingData = "Connected - Awaiting Data...";
        private const String cSetup = "Setting up Dew Monitor...";
        private const String cError = "Error!!!!";
        private const String cTimeout = "Disconnected! - Connection Failure...";
        private const String cManualOn = "Connected - Switching to Manual Mode...";
        private const String cManualOff = "Connected - Switching to Automatic Mode...";
        private const String cUpdateDew = "Connected - Updating Dew Band Power Setting...";

        private const int TEMP_SENSOR_DISCONNECTED = -127;

        private const int iSensorUpdateTimeout = 120;

        private double sensorUpdateTime = 0;

        private double DewTemp1 = 0;
        private double DewTemp2 = 0;
        private double DewPower1 = 0;
        private double DewPower2 = 0;

        private double Temperature = 0;
        private double Humidity = 0;
        private double DewPoint = 0;

        private bool isConnected = false;

        private int updateInterval = 10000;  // (Milliseconds)

        private bool DewMonConnected
        {
            get { return isConnected; }
            set
            {
                StatusMessage(value ? Status.CONNECTING : Status.DISCONNECTING);

                try
                {
                    aObserving.Connected = value;

                    if (aObserving.Connected)
                    {
                        currenttimeTimer.Start();
                        lblDewBandName1.Text = aObserving.Action("NameDewBand","1") + ":";
                        lblDewBandName2.Text = aObserving.Action("NameDewBand","2") + ":";
                        GetConfigData();
                        GetData();
                        isConnected = true;
                    }
                }
                catch {}

                StatusMessage(isConnected ? Status.CONNECTED : Status.DISCONNECTED);
            }
        }

        private void GetConfigData()
        {
            cfgMinDewBandTmp.Value = ValidateTemp(Convert.ToDouble(aObserving.Action("MinDewBandTemp","")));
            cfgMinDewPoint.Value = ValidateTemp(Convert.ToDouble(aObserving.Action("DewThresholdUpdate", "")));
            cfgTmpDiffBefUpdate.Value = ValidateTemp(Convert.ToDouble(aObserving.Action("TempDiffBeforeUpdate", "")));
            cfgPwrUpdFreq.Value = Convert.ToDouble(aObserving.Action("PowerUpdateInterval", ""));

            string value = aObserving.Action("PowerFixPercentageMode", "");
            if (value == "1")
                cfgDewFixedIncr.Text = "Yes";
            else
                cfgDewFixedIncr.Text = "No";
        }

        private void ResetConfigData()
        {
            cfgMinDewBandTmp.Value = 0;
            cfgMinDewPoint.Value = 0;
            cfgTmpDiffBefUpdate.Value= 0;
            cfgPwrUpdFreq.Value= 0;
            cfgDewFixedIncr.Text = "";
        }

        public MonitorApp()
        {
            InitializeComponent();
            InitialiseUI();
            InitialiseLog();
            ResetObservingData();
        }

        private void InitialiseUI()
        {
            lblCaption.Text += Application.ProductVersion;
            tglDewManual.Enabled = false;
            trackBarDew1.Enabled = false;
            trackBarDew2.Enabled = false;
            dataUpdateTimer.Interval = updateInterval;
        }

        private void StatusMessage(Status eStatus)
        {
            switch (eStatus)
            {
                case Status.CONNECTED:
                    UpdateStatusText(cConnected, MetroFramework.MetroColorStyle.Lime);
                    btnQAConnect.Text = "Disconnect";
                    btnQASetup.Enabled = false;
                    break;
                case Status.CONNECTING:
                    UpdateStatusText(cConnecting, MetroFramework.MetroColorStyle.Orange);
                    break;
                case Status.AWAITINGDATA:
                    UpdateStatusText(cAwaitingData, MetroFramework.MetroColorStyle.Yellow);
                    break;
                case Status.SETUP:
                    UpdateStatusText(cSetup, MetroFramework.MetroColorStyle.Orange);
                    break;
                case Status.DISCONNECTING:
                    UpdateStatusText(cDisconnecting, MetroFramework.MetroColorStyle.Orange);
                    StatusMessage(Status.DISCONNECTED);
                    break;
                case Status.MANUALON:
                    UpdateStatusText(cManualOn, MetroFramework.MetroColorStyle.Orange);
                    break;
                case Status.MANUALOFF:
                    UpdateStatusText(cManualOff, MetroFramework.MetroColorStyle.Orange);
                    break;
                case Status.UPDATEDEW:
                    UpdateStatusText(cUpdateDew, MetroFramework.MetroColorStyle.Orange);
                    break;
                case Status.DISCONNECTED:
                    DisconnectStatus(cDisconnected);
                    break;
                case Status.ERROR:
                    DisconnectStatus(cError);
                    break;
                case Status.TIMEOUT:
                    DisconnectStatus(cTimeout);
                    break;
            }
        }

        private void UpdateStatusText(string statusMessage, MetroFramework.MetroColorStyle statusColour)
        {
            lblStatus.Text = statusMessage;
            lblStatus.Style = statusColour;
            Application.DoEvents();
        }

        private void DisconnectStatus(String statusText)
        {
            dataUpdateTimer?.Stop();

            btnQAConnect.Text = "Connect";
            btnQASetup.Enabled = true;
            ResetObservingData();

            UpdateStatusText(statusText, MetroFramework.MetroColorStyle.Red);
        }

        private void ResetObservingData()
        {
            tglDewManual.Enabled = false;
            lbDigSkyTemp.Value = 0;
            lbDigHumidity.Value = 0;
            lbDigDewPoint.Value = 0;
            lbDigDewTemp1.Value = 0;
            trackBarDew1.Value = 0;
            lblDewPower1.Value = 0;

            lbDigDewTemp2.Value = 0;
            trackBarDew2.Value = 0;
            lblDewPower2.Value = 0;

            ResetConfigData();

            ResetASCOMObject();
        }

        private void ResetASCOMObject()
        {
            isConnected = false;

            aObserving?.Dispose();

            System.Threading.Thread.Sleep(100);    

            aObserving = new ASCOM.DriverAccess.ObservingConditions(aObservingID);

            System.Threading.Thread.Sleep(500);
        }

        private bool GetData()
        {
            bool dataReceived = false;

            if (DewMonConnected)
            {
                StatusMessage(Status.AWAITINGDATA);
                try
                {
                    sensorUpdateTime = aObserving.TimeSinceLastUpdate("temperature");

                    if (!UpdateSensorTime())        //Update time Sensor Time UI and check if Sensor Update Timeout has been exceeded
                    {
                        Temperature = aObserving.Temperature;
                        Humidity = aObserving.Humidity;
                        DewPoint = aObserving.DewPoint;

                        DewTemp1 = ValidateTemp(Convert.ToDouble(aObserving.Action("GetDewTemp", "1")));
                        DewTemp2 = ValidateTemp(Convert.ToDouble(aObserving.Action("GetDewTemp", "2")));
                        DewPower1 = Convert.ToDouble(aObserving.Action("GetDewPower", "1"));
                        DewPower2 = Convert.ToDouble(aObserving.Action("GetDewPower", "2"));

                        dataReceived = true;
                    }
                    StatusMessage(Status.CONNECTED);
                }
                catch
                {
                    StatusMessage(Status.ERROR);
                }
            }

            return dataReceived;
        }

        private void UpdateUI()
        {
            dataUpdateTimer.Stop();

            try
            {
                if (GetData())        //Update time Sensor Time UI and check if Sensor Update Timeout has been exceeded
                {
                    lbDigSkyTemp.Value = Temperature;
                    lbDigHumidity.Value = Humidity;
                    lbDigDewPoint.Value = DewPoint;

                    lbDigDewTemp1.Value = DewTemp1;
                    lblDewPower1.Value = DewPower1;

                    lbDigDewTemp2.Value = DewTemp2;
                    lblDewPower2.Value = DewPower2;

                    trackBarDew1.Value = Convert.ToInt16(DewPower1);
                    trackBarDew2.Value = Convert.ToInt16(DewPower2);

                    string logMsg = aObserving.Temperature.ToString() + "," + aObserving.Humidity.ToString() + "," + aObserving.DewPoint;


                    logMsg = logMsg + "," + DewTemp1.ToString() + "," + DewPower1.ToString();
                    logMsg = logMsg + "," + DewTemp2.ToString() + "," + DewPower2.ToString();

                    DLogger.LogMessage(logName, logMsg);
                    dataUpdateTimer.Start();
                }
                else
                {
                    StatusMessage(Status.TIMEOUT);
                }

            }
            catch
            {
                StatusMessage(Status.ERROR);
            }
        }

        private bool UpdateSensorTime()
        {
            bool timeOut = false;

            if (sensorUpdateTime > iSensorUpdateTimeout)
                timeOut = true;
            else
            {
                lblSnHH.Value = Double.Parse(DateTime.Now.AddSeconds(-1 * sensorUpdateTime).ToString("HH"));
                lblSnMM.Value = Double.Parse(DateTime.Now.AddSeconds(-1 * sensorUpdateTime).ToString("mm"));
                lblSnSS.Value = Double.Parse(DateTime.Now.AddSeconds(-1 * sensorUpdateTime).ToString("ss"));
            }
            return timeOut;
        }

        private void UpdateCurrentTime()
        {
            lblTmHH.Value = Double.Parse(DateTime.Now.ToString("HH"));
            lblTmMM.Value = Double.Parse(DateTime.Now.ToString("mm"));
            lblTmSS.Value = Double.Parse(DateTime.Now.ToString("ss"));
            Application.DoEvents();
        }

        private void BtnQASetup_Click(object sender, EventArgs e)
        {
            if (DewMonConnected)
                System.Windows.Forms.MessageBox.Show("Already connected, just press Connect");
            else
                try
                {
                    StatusMessage(Status.SETUP);
                    aObserving.SetupDialog();
                    StatusMessage(Status.DISCONNECTED);
                }
                catch
                {
                    StatusMessage(Status.ERROR);
                    System.Windows.Forms.MessageBox.Show("Error!!  Please make sure the Dew Monitor is connected via USB and try again.");
                }
        }

        private void BtnQAConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DewMonConnected)
                {
                    StatusMessage(Status.CONNECTING);
                    DewMonConnected = true;

                    if (DewMonConnected)
                    {
                        StatusMessage(Status.AWAITINGDATA);
                        tglDewManual.Enabled = true;
                        dataUpdateTimer.Start();
                    }
                }
                else
                {
                    dataUpdateTimer?.Stop();

                    DewMonConnected = false;
                    StatusMessage(Status.DISCONNECTING);
                }
            }
            catch
            {
                StatusMessage(Status.ERROR);
            }
        }

        private void TglDewManual_CheckedChanged(object sender, EventArgs e)
        {
            int iDewManual = 0;

            if (tglDewManual.Checked)
                iDewManual = 1;

            aObserving.Action("ManualMode", iDewManual.ToString());

            if (iDewManual == 1)
            {
                trackBarDew1.Value = (int)lblDewPower1.Value;
                trackBarDew2.Value = (int)lblDewPower2.Value;

                aObserving.Action("SetDewPower", "1," + trackBarDew1.Value.ToString());
                aObserving.Action("SetDewPower", "2," + trackBarDew2.Value.ToString());
            }

            trackBarDew1.Enabled = tglDewManual.Checked;
            trackBarDew2.Enabled = tglDewManual.Checked;
        }
        private void TrackBarDew1_Scroll(object sender, EventArgs e)
        {
            lblDewPower1.Value = trackBarDew1.Value;
        }

        private void TrackBarDew1_MouseUp(object sender, EventArgs e)
        {
            aObserving.Action("SetDewPower", "1," + trackBarDew1.Value.ToString());
            trackerUpdateTimer.Start();
        }

        private void TrackBarDew2_Scroll(object sender, EventArgs e)
        {
            lblDewPower2.Value = trackBarDew2.Value;
        }

        private void TrackBarDew2_MouseUp(object sender, EventArgs e)
        {
            aObserving.Action("SetDewPower", "2," + trackBarDew2.Value.ToString());
            trackerUpdateTimer.Start();
        }

        private double ValidateTemp(double temp)
        {
            try
            {
                if (temp == TEMP_SENSOR_DISCONNECTED)
                    temp = 0;
            }
            catch (Exception error)
            {
                StatusMessage(Status.ERROR);

                MessageBox.Show("Number Validation - Error", error.Message);

            }
            return temp;
        }

        #region Form Functions

        private void LblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LblClose_Click(object sender, EventArgs e)
        {
            if (DewMonConnected)
            {
                currenttimeTimer.Stop();
                DewMonConnected = false;
            }

            Environment.Exit(0);
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void LblAbout_Click(object sender, EventArgs e)
        {
            using (About about = new About())
                about.ShowDialog();
        }

        #endregion

        #region Timer Functions

        private void dataUpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (DewMonConnected)
                    UpdateUI();
            }
            catch (Exception error)
            {
                StatusMessage(Status.ERROR);
                MessageBox.Show("Dew Monitor - Error", error.Message);
            }
        }

        // Disable the Manual Power Track Bars for 5 seconds after a change what made to the Power setting of one of the Dew Bands.
        // The Power Track Bars are disabled to ensure that the change in Power is send correctly to the Arduino unit.
        private void TrackerUpdateTimer_Tick(object sender, EventArgs e)        // This is a 1 second Timer Tick
        {
            try
            {
                if (iTrackBarDisabled < 5)             // While the Timer has not reached 5 sec, disable the Power Track Bars
                {
                    StatusMessage(Status.UPDATEDEW);
                    iTrackBarDisabled++;

                    trackBarDew1.Enabled = false;
                    trackBarDew2.Enabled = false;
                }
                else                                    // If the 5 seconds have been reached, enable the Power Track Bars, reset & stop the timer.
                {
                    trackBarDew1.Enabled = true;
                    trackBarDew2.Enabled = true;
                    iTrackBarDisabled = 0;
                    trackerUpdateTimer.Stop();
                    StatusMessage(Status.CONNECTED);
                }
            }
            catch { }
        }

        private void CurrenttimeTimer_Tick(object sender, EventArgs e)
        {
            UpdateCurrentTime();
        }

        #endregion

        #region Logging
        private void InitialiseLog()
        {
            //            dLogger.LogMessage(logName, "DateTime,ObsT,Hum,Dew,Pres,Tmp1,Pwr1,Tmp2,Pwr2");
            DLogger.LogMessage(logName, "DateTime,ObsT,Hum,Dew,Tmp1,Pwr1,Tmp2,Pwr2");
        }

        private static TraceLogger DLogger
        {
            get
            {
                if (dataLogger == null)
                {
                    dataLogger = new TraceLogger("", logName)
                    {
                        Enabled = true
                    };
                }
                return dataLogger;
            }
        }

        #endregion

    }


}

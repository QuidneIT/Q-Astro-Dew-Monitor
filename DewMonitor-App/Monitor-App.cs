using ASCOM.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ASCOM.QAstroDew
{
    public partial class MonitorApp : Form
    {
        private static TraceLogger dataLogger;
        private static string logName = "Q-Astro Dew Management";

        private String aObservingID = "ASCOM.QAstroDew.ObservingConditions";
        private ASCOM.DriverAccess.ObservingConditions aObserving;

        private String sLogFile = string.Format("Astro-Q-{0:yyyy-MM-dd_hh-mm-ss-tt}.log", DateTime.Now);
        private String sLogFileLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private int iTrackBarDisabled = 0;

        enum Status
        {
            CONNECTED,
            CONNECTING,
            DISCONNECTED,
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
        private const String cAwaitingData = "Connected - Awaiting Data...";
        private const String cSetup = "Setting up Dew Monitor...";
        private const String cError = "Error!!!!";
        private const String cManualOn = "Connected - Switching to Manual Mode...";
        private const String cManualOff = "Connected - Switching to Automatic Mode...";
        private const String cUpdateDew = "Connected - Updating Dew Band Power Setting...";

        private double sensorUpdateTime = 0;

        private bool bConnected
        {
            get
            {
                try { return aObserving.Connected; }
                catch { return false; }
            }
            set
            {
                try { aObserving.Connected = value; }
                catch { }
            }
        }

        public MonitorApp()
        {
            InitializeComponent();
            InitialiseUI();
            InitialiseLog();
            ResetObservingData();
            currenttimeTimer.Start();
        }

        private void InitialiseUI()
        {
            lblCaption.Text += Application.ProductVersion;
            tglDewManual.Enabled = false;
            trackBarDew1.Enabled = false;
            trackBarDew2.Enabled = false;
//            StatusMessage(Status.DISCONNECTED);
        }

        #region Logging
        private void InitialiseLog()
        {
            dLogger.LogMessage(logName, "DateTime,ObsT,Hum,Dew,Pres,Tmp1,Pwr1,Tmp2,Pwr2");
        }

        private static TraceLogger dLogger
        {
            get
            {
                if (dataLogger == null)
                {
                    dataLogger = new TraceLogger("", logName);
                    dataLogger.Enabled = true;
                }
                return dataLogger;
            }
        }

        #endregion

        private void StatusMessage(Status eStatus)
        {
            switch (eStatus)
            {
                case Status.CONNECTED:
                    lblStatus.Text = cConnected;
                    lblStatus.Style = MetroFramework.MetroColorStyle.Lime;

                    btnQAConnect.Text = "Disconnect";
                    btnQASetup.Enabled = false;
                    break;
                case Status.CONNECTING:
                    lblStatus.Text = cConnecting;
                    lblStatus.Style = MetroFramework.MetroColorStyle.Orange;
                    break;
                case Status.AWAITINGDATA:
                    lblStatus.Text = cAwaitingData;
                    lblStatus.Style = MetroFramework.MetroColorStyle.Yellow;
                    break;
                case Status.SETUP:
//                    ResetObservingData();
                    lblStatus.Text = cSetup;
                    lblStatus.Style = MetroFramework.MetroColorStyle.Orange;
                    aObserving.SetupDialog();

                    break;
                case Status.MANUALON:
                    lblStatus.Text = cManualOn;
                    lblStatus.Style = MetroFramework.MetroColorStyle.Orange;
                    break;
                case Status.MANUALOFF:
                    lblStatus.Text = cManualOff;
                    lblStatus.Style = MetroFramework.MetroColorStyle.Orange;
                    break;
                case Status.UPDATEDEW:
                    lblStatus.Text = cUpdateDew;
                    lblStatus.Style = MetroFramework.MetroColorStyle.Orange;
                    break;
                case Status.DISCONNECTED:
                    lblStatus.Text = cDisconnected;
                    lblStatus.Style = MetroFramework.MetroColorStyle.Red;
                    btnQAConnect.Text = "Connect";
                    btnQASetup.Enabled = true; 
                    ResetObservingData();
                    break;
                case Status.ERROR:
                    lblStatus.Text = cError;
                    lblStatus.Style = MetroFramework.MetroColorStyle.Red;
                    btnQAConnect.Text = "Connect";
                    btnQASetup.Enabled = true;
                    errorHalt();
                    break;
            }
        }
        private void errorHalt()
        {
            ResetObservingData();
        }

        private void ResetObservingData()
        {
            timerUI.Stop();
            bConnected = false;
//            pnlManual.Enabled = false;
//            pnlSetManual.Enabled = false;
            tglDewManual.Enabled = false;
            lbDigSkyTemp.Value = 0;
            lbDigHumidity.Value = 0;
            lbDigDewPoint.Value = 0;
            lbDigPressure.Value = 0;
            lbDigAltitude.Value = 0;

            lbDigDewTemp1.Value = 0;
            trackBarDew1.Value = 0;
            lblDewPower1.Value = 0;

            lbDigDewTemp2.Value = 0;
            trackBarDew2.Value = 0;
            lblDewPower2.Value = 0;

            aObserving = new ASCOM.DriverAccess.ObservingConditions(aObservingID);
            timerUI.Start();
        }

        private void UpdateUI()
        {
            timerUI.Stop();

            try
            {
                updateCurrentTime();

                if (bConnected)
                {
                    lbDigSkyTemp.Value = aObserving.Temperature;
                    lbDigHumidity.Value = aObserving.Humidity;
                    lbDigDewPoint.Value = aObserving.DewPoint;
                    lbDigPressure.Value = aObserving.Pressure;
                    sensorUpdateTime = aObserving.TimeSinceLastUpdate("");

                    updateSensorTime();

                    lbDigAltitude.Value = Convert.ToDouble(aObserving.CommandString("a", false));

                    lbDigDewTemp1.Value = ValidateTemp(Convert.ToDouble(aObserving.CommandString("e1", false)));
                    lblDewPower1.Value = Convert.ToDouble(aObserving.CommandString("o1", false));

                    lbDigDewTemp2.Value = ValidateTemp(Convert.ToDouble(aObserving.CommandString("e2", false)));
                    lblDewPower2.Value = Convert.ToDouble(aObserving.CommandString("o2", false));

                    if (!tglDewManual.Checked)
                    {
                        trackBarDew1.Value = Convert.ToInt16(lblDewPower1.Value);
                        trackBarDew2.Value = Convert.ToInt16(lblDewPower2.Value);
                    }

                    if (aObserving.CommandString("m", false) == "1")
                        tglDewManual.Enabled = true;

                    string logMsg = aObserving.Temperature.ToString() + "," + aObserving.Humidity.ToString() + "," + aObserving.DewPoint + "," + aObserving.Pressure;
                    logMsg = logMsg + "," + aObserving.CommandString("e1", false) + "," + aObserving.CommandString("o1", false);
                    logMsg = logMsg + "," + aObserving.CommandString("e2", false) + "," + aObserving.CommandString("o2", false);

                    dLogger.LogMessage(logName, logMsg);
                    StatusMessage((aObserving.Temperature == 0) ? Status.AWAITINGDATA : Status.CONNECTED);
                    timerUI.Start();
                }
                else
                    StatusMessage(Status.DISCONNECTED);
            }
            catch
            {
                StatusMessage(Status.ERROR);
            }
        }

        private void updateSensorTime()
        {
            lblSnHH.Value = Double.Parse(DateTime.Now.AddSeconds(-1 * sensorUpdateTime).ToString("HH"));
            lblSnMM.Value = Double.Parse(DateTime.Now.AddSeconds(-1 * sensorUpdateTime).ToString("mm"));
            lblSnSS.Value = Double.Parse(DateTime.Now.AddSeconds(-1 * sensorUpdateTime).ToString("ss"));
        }

        private void updateCurrentTime()
        {
            lblTmHH.Value = Double.Parse(DateTime.Now.ToString("HH"));
            lblTmMM.Value = Double.Parse(DateTime.Now.ToString("mm"));
            lblTmSS.Value = Double.Parse(DateTime.Now.ToString("ss"));
        }

        private void btnQASetup_Click(object sender, EventArgs e)
        {
            if (bConnected)
                System.Windows.Forms.MessageBox.Show("Already connected, just press Connect");
            else
                try
                {
                    StatusMessage(Status.SETUP);
                    StatusMessage(Status.DISCONNECTED);
                }
                catch
                {
                    StatusMessage(Status.ERROR);
                    System.Windows.Forms.MessageBox.Show("Error!!  Please make sure the Dew Monitor is connected via USB and try again.");
                }
        }

        private void btnQAConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bConnected)
                {
                    StatusMessage(Status.CONNECTING);
                    bConnected = true;
                    if (bConnected)
                    {
                        StatusMessage(Status.AWAITINGDATA);
//                        pnlManual.Enabled = true;
                        tglDewManual.Enabled = true;
                        timerUI.Start();
                    }
                    else
                        StatusMessage(Status.DISCONNECTED);
                }
                else
                    StatusMessage(Status.DISCONNECTED);
            }
            catch
            {
                StatusMessage(Status.ERROR);
            }
        }

        private void tglDewManual_CheckedChanged(object sender, EventArgs e)
        {
            int iDewManual = 0;

            if (tglDewManual.Checked)
                iDewManual = 1;

            aObserving.CommandString("m" + iDewManual.ToString(), false);

            if (iDewManual == 1)
            {
//                pnlSetManual.Enabled = true;

                trackBarDew1.Value = (int)lblDewPower1.Value;
                trackBarDew2.Value = (int)lblDewPower2.Value;

                aObserving.CommandString("o1" + trackBarDew1.Value.ToString(), false);
                aObserving.CommandString("o2" + trackBarDew2.Value.ToString(), false);
            }
//            else
//                pnlSetManual.Enabled = false;

            trackBarDew1.Enabled = tglDewManual.Checked;
            trackBarDew2.Enabled = tglDewManual.Checked;
        }
        private void trackBarDew1_Scroll(object sender, EventArgs e)
        {
            lblDewPower1.Value = trackBarDew1.Value;
        }

        private void trackBarDew1_MouseUp(object sender, EventArgs e)
        {
            aObserving.CommandString("o1" + trackBarDew1.Value.ToString(), false);
            trackerUpdateTimer.Start();
        }

        private void trackBarDew2_Scroll(object sender, EventArgs e)
        {
            lblDewPower2.Value = trackBarDew2.Value;
        }

        private void trackBarDew2_MouseUp(object sender, EventArgs e)
        {
            aObserving.CommandString("o2" + trackBarDew2.Value.ToString(), false);
            trackerUpdateTimer.Start();
        }

        private double ValidateTemp(double temp)
        {
            try
            {
                if (temp > 80)
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

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
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

        private void lblAbout_Click(object sender, EventArgs e)
        {
            using (About about = new About())
                about.ShowDialog();
        }

        #endregion

        #region Timer Functions

        private void timerUI_Tick(object sender, EventArgs e)
        {
            try
            {
                if (bConnected)
                    UpdateUI();
            }
            catch (Exception error)
            {
                StatusMessage(Status.ERROR);
                MessageBox.Show("Dew Monitor - Error", error.Message);
            }
        }

        private void trackerUpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (iTrackBarDisabled < 5)
                {
                    StatusMessage(Status.UPDATEDEW);
                    iTrackBarDisabled++;

                    trackBarDew1.Enabled = false;
                    trackBarDew2.Enabled = false;
                }
                else
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

        private void currenttimeTimer_Tick(object sender, EventArgs e)
        {
            updateCurrentTime();
        }
    }
    #endregion
}

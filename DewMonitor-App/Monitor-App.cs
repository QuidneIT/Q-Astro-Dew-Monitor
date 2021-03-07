using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Collections;
using ASCOM.DeviceInterface;
using ASCOM.DriverAccess;
using ASCOM.Utilities;
using System.Timers;

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

        public MonitorApp()
        {
            aObserving = new ASCOM.DriverAccess.ObservingConditions(aObservingID);

            InitializeComponent();
            InitialiseUI();
            InitialiseLog();
            ResetObservingData();
            timerUI.Start();
        }

        private void InitialiseUI()
        {
            lblCaption.Text += Application.ProductVersion;
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


        private void ResetObservingData()
        {
            lbDigSkyTemp.Value = 0;
            lbDigHumidity.Value = 0;
            lbDigDewPoint.Value = 0;
            lbDigPressure.Value = 0;
            lbDigAltitude.Value = 0;

            lbDigDewTemp1.Value = 0;
            lbDigDewPower1.Value = 0;
            lbDigDewTemp2.Value = 0;
            lbDigDewPower2.Value = 0;
        }

        private void UpdateUI()
        {
            timerUI.Stop();
            lblQAStatus.Text = (aObserving.Connected) ? "Connected" : "Disconnected";
            lblQAStatus.Style = (aObserving.Connected) ? MetroFramework.MetroColorStyle.Lime : MetroFramework.MetroColorStyle.Red;

            if (aObserving.Connected)
            {
                lbDigSkyTemp.Value = aObserving.Temperature;
                lbDigHumidity.Value = aObserving.Humidity;
                lbDigDewPoint.Value = aObserving.DewPoint;
                lbDigPressure.Value = aObserving.Pressure;

                lbDigAltitude.Value = Convert.ToDouble(aObserving.CommandString("a", false));
                lbDigDewTemp1.Value = ValidateTemp(Convert.ToDouble(aObserving.CommandString("v", false)));
                lbDigDewPower1.Value = Convert.ToDouble(aObserving.CommandString("w", false));

                lbDigDewTemp2.Value = ValidateTemp(Convert.ToDouble(aObserving.CommandString("x", false)));
                lbDigDewPower2.Value = Convert.ToDouble(aObserving.CommandString("y", false));

                string logMsg = aObserving.Temperature.ToString() + "," + aObserving.Humidity.ToString() + "," + aObserving.DewPoint + "," + aObserving.Pressure;
                logMsg = logMsg + "," + aObserving.CommandString("v", false) + "," + aObserving.CommandString("x", false);
                logMsg = logMsg + "," + aObserving.CommandString("w", false) + "," + aObserving.CommandString("y", false);

                dLogger.LogMessage(logName, logMsg);

                lblQAStatus.Text = (aObserving.Temperature == 0) ? "Connected - Awaiting Data.." : "Connected";
            }
            else
                ResetObservingData();

            timerUI.Start();
        }

        private void btnQASetup_Click(object sender, EventArgs e)
        {
            if (aObserving.Connected)
                System.Windows.Forms.MessageBox.Show("Already connected, just press Connect");
            else
                aObserving.SetupDialog();
        }
        
        private void btnQAConnect_Click(object sender, EventArgs e)
        {
            if (!aObserving.Connected)
            {
                lblQAStatus.Text = "Connecting....";
                aObserving.Connected = true;
                lblQAStatus.Text = "Connected - Awaiting Data..";
                timerUI.Start();
            }
            else
            {
                timerUI.Stop();
                aObserving.Connected = false;
                ResetObservingData();
                lblQAStatus.Text = "Disconnected";
            }

            btnQAConnect.Text = (aObserving.Connected) ? "Disconnect" : "Connect";
            btnQASetup.Enabled = !aObserving.Connected;
        }

        private double ValidateTemp(double temp)
        {
            try
            {
                if (temp > 80)
                    temp = 0;
            }
            catch(Exception error)
            {
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
                if (aObserving.Connected)
                {
                    if (aObserving.Connected)
                        UpdateUI();
                }
            }
            catch (Exception error)
            {
                timerUI.Stop();
            }
        }

        #endregion

    }
}

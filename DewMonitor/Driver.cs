// Q-Astro Dew Monitor ASCOM Driver
// For change log see VersionHistory.txt
//
// This driver requires Arduino Code version 2.0


// This is used to define code in the template that is specific to one class implementation
// unused code canbe deleted and this definition removed.
#define ObservingConditions

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;

using ASCOM;
using ASCOM.Astrometry;
using ASCOM.Astrometry.AstroUtils;
using ASCOM.Utilities;
using ASCOM.DeviceInterface;
using System.Globalization;
using System.Collections;
using System.Windows.Forms;

namespace ASCOM.QAstroDew
{
    //
    // Your driver's DeviceID is ASCOM.QAstroDew.ObservingConditions
    //
    // The Guid attribute sets the CLSID for ASCOM.QAstroDew.ObservingConditions
    // The ClassInterface/None addribute prevents an empty interface called
    // _QAstroDew from being created and used as the [default] interface
    //
    // TODO Replace the not implemented exceptions with code to implement the function or
    // throw the appropriate ASCOM exception.
    //

    /// <summary>
    /// ASCOM ObservingConditions Driver for QAstroDew.
    /// </summary>
    [Guid("b4928934-b587-446f-af1a-979c232dce15")]
    [ProgId("ASCOM.QAstroDew.ObservingConditions")]
    [ServedClassName("Q-Astro Dew Management")]
    [ClassInterface(ClassInterfaceType.None)]
    public class ObservingConditions : ReferenceCountedObjectBase, IObservingConditions
    {
        /// <summary>
        /// ASCOM DeviceID (COM ProgID) for this driver.
        /// The DeviceID is used by ASCOM applications to load the driver at runtime.
        /// </summary>
        internal static string driverID = "ASCOM.QAstroDew.ObservingConditions";
        // TODO Change the descriptive string for your driver then remove this line
        /// <summary>
        /// Driver description that displays in the ASCOM Chooser.
        /// </summary>
        private static string driverDescription = "ASCOM ObservingConditions Driver for Q-Astro Dew.";
        private static string driverShortName = "Q-Astro Dew Monitor";
        private static int interfaceVersion = 2;

        /// <summary>
        /// Private variable to hold the connected state
        /// </summary>
        private bool connectedState;

        /// <summary>
        /// Initializes a new instance of the <see cref="QAstro"/> class.
        /// Must be public for COM registration.
        /// </summary>
        public ObservingConditions()
        {
            SharedResources.tl.LogMessage(driverShortName, "Starting initialisation");
            driverID = Marshal.GenerateProgIdForType(this.GetType());
            connectedState = false; // Initialise connected to false
            SharedResources.tl.LogMessage(driverShortName, "Completed initialisation");
        }

        //
        // PUBLIC COM INTERFACE IObservingConditions IMPLEMENTATION
        //

        #region Common properties and methods.

        /// <summary>
        /// Displays the Setup Dialog form.
        /// If the user clicks the OK button to dismiss the form, then
        /// the new settings are saved, otherwise the old values are reloaded.
        /// THIS IS THE ONLY PLACE WHERE SHOWING USER INTERFACE IS ALLOWED!
        /// </summary>
        public void SetupDialog()
        {
            // consider only showing the setup dialog if not connected
            // or call a different dialog if connected
            if (SharedResources.SharedSerial.Connected)
                System.Windows.Forms.MessageBox.Show("Already connected, just press OK");
            else
            {
                using (ServerSetupDialog setupSerial = new ServerSetupDialog())
                    setupSerial.ShowDialog();
            }
        }

        public ArrayList SupportedActions
        {
            get
            {
                var CustomActions = new ArrayList();
                CustomActions.Add("GetDewTemp");
                CustomActions.Add("GetDewPower");
                CustomActions.Add("ManualMode");
                CustomActions.Add("SetDewPower");
                CustomActions.Add("Altitude");

                string msgForLog = "";
                foreach (String act in CustomActions)
                    msgForLog = msgForLog + act + ",";   
                
                SharedResources.tl.LogMessage(driverShortName + " SupportedActions Get", msgForLog);
                return CustomActions;
            }
        }

        public string Action(string actionName, string actionParameters)
        {
            String returnVal = "";

            switch (actionName)
            {
                case "GetDewTemp":
                    if (actionParameters == "1")
                        returnVal = SharedResources.DewTemp1;
                    else
                        returnVal = SharedResources.DewTemp2;
                    break;
                
                case "GetDewPower":
                    if (actionParameters == "1")
                        returnVal = SharedResources.DewPower1;
                    else
                        returnVal = SharedResources.DewPower2;
                    break;
                
                case "ManualMode":
                    if (actionParameters == null)
                        returnVal = SharedResources.DewModeManual;
                    else
                    {
                        SharedResources.DewModeManual = actionParameters;
                        returnVal = SharedResources.DewModeManual;
                    }
                    break;
                
                case "SetDewPower":
                    string heater = actionParameters.Substring(0, actionParameters.IndexOf(','));
                    string value = actionParameters.Substring(actionParameters.IndexOf(',') + 1);
                    if (heater == "1")
                        SharedResources.DewPower1 = value;
                    else
                        SharedResources.DewPower2 = value;
                    break;
                
                case "Altitude":
                    returnVal = SharedResources.Altitude;
                    break;
                
                default:
                    throw new ASCOM.ActionNotImplementedException(driverShortName + " Action " + actionName + " is not implemented by this driver");
//                    break;

            }
            return returnVal;
        }

        public void CommandBlind(string command, bool raw)
        {
            CheckConnected("CommandBlind");
            this.CommandString(command, raw);
        }

        public bool CommandBool(string command, bool raw)
        {
            CheckConnected("CommandBool");
            return !this.CommandString(command, raw).Equals("0");
        }

        public string CommandString(string command, bool raw)
        {
            string response = "";
            CheckConnected("CommandString");
            switch (command[0])
            {
                case 'a':
                    response = SharedResources.Altitude;
                    break;
                case 'm':
                    if (command.Length == 2)
                        SharedResources.DewModeManual = command.Substring(1);
                    else
                        response = SharedResources.DewModeManual;
                    break;
                case 'o':
                    if (command.Length > 2)
                    {
                        if (command[1] == '1')
                            SharedResources.DewPower1 = command.Substring(2);
                        else
                            SharedResources.DewPower2 = command.Substring(2);
                    }
                    else
                    {
                        if (command[1] == '1')
                            response = SharedResources.DewPower1;
                        else
                            response = SharedResources.DewPower2;
                    }
                    break;
                case 'e':
                    if (command[1] == '1')
                        response = SharedResources.DewTemp1;
                    else
                        response = SharedResources.DewTemp2;
                    break;
            }
            return response;
        }

        public void Dispose()
        {
        }

        public bool Connected
        {
            get { return IsConnected; }
            set
            {
                {
                    SharedResources.tl.LogMessage(driverShortName + " Connected Set", value.ToString());
                    if (value == IsConnected)
                        return;

                    if (value)
                    {
                        if (IsConnected) return;
                        SharedResources.tl.LogMessage(driverShortName + "Connected Set", "Connecting to port " + ASCOM.QAstroDew.Properties.Settings.Default.COMPort);
                        SharedResources.Connected = true;
                        connectedState = SharedResources.Connected;
                    }
                    else
                    {
                        connectedState = false;
                        SharedResources.Connected = false;
                        SharedResources.tl.LogMessage(driverShortName + " Switch Connected Set", "Disconnected, " + SharedResources.connections + " connections left");
                    }
                }
            }
        }

        public string Description
        {
            get
            {
                SharedResources.tl.LogMessage(driverShortName + " Description Get", driverDescription);
                return driverDescription;
            }
        }

        public string DriverInfo
        {
            get
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string driverInfo = "Information about the driver itself. Version: " + String.Format(CultureInfo.InvariantCulture, "{0}.{1}", version.Major, version.Minor);
                SharedResources.tl.LogMessage(driverShortName + " DriverInfo Get", driverInfo);
                return driverInfo;
            }
        }

        public string DriverVersion
        {
            get
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string driverVersion = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", version.Major, version.Minor);
                SharedResources.tl.LogMessage(driverShortName + " DriverVersion Get", driverVersion);
                return driverVersion;
            }
        }

        public short InterfaceVersion
        {
            get
            {
                SharedResources.tl.LogMessage(driverShortName + " InterfaceVersion Get", interfaceVersion.ToString());
                return Convert.ToInt16(interfaceVersion);
            }
        }

        public string Name
        {
            get
            {
                SharedResources.tl.LogMessage(driverShortName + " Name Get", driverShortName);
                return driverShortName;
            }
        }

        #endregion

        #region IObservingConditions Implementation

//        private string ASCOMfunction = "o";     //Define that communicate ObservingConditions to Arduino

        /// <summary>
        /// Gets and sets the time period over which observations wil be averaged
        /// </summary>
        /// <remarks>
        /// Get must be implemented, if it can't be changed it must return 0
        /// Time period (hours) over which the property values will be averaged 0.0 =
        /// current value, 0.5= average for the last 30 minutes, 1.0 = average for the
        /// last hour
        /// </remarks>
        public double AveragePeriod
        {
            get
            {
                SharedResources.tl.LogMessage("AveragePeriod", "get - 0");
                return 0;
            }
            set
            {
                SharedResources.tl.LogMessage("AveragePeriod", "set - " + value);
                if (value != 0)
                    throw new InvalidValueException("AveragePeriod", value.ToString(), "0 only");
            }
        }

        /// <summary>
        /// Amount of sky obscured by cloud
        /// </summary>
        /// <remarks>0%= clear sky, 100% = 100% cloud coverage</remarks>
        public double CloudCover
        {
            get
            {
                SharedResources.tl.LogMessage("CloudCover", "get - not implemented");
                throw new PropertyNotImplementedException("CloudCover", false);
            }
        }

        /// <summary>
        /// Atmospheric dew point at the observatory in deg C
        /// </summary>
        /// <remarks>
        /// Normally optional but mandatory if <see cref=" ASCOM.DeviceInterface.IObservingConditions.Humidity"/>
        /// Is provided
        /// </remarks>
        public double DewPoint
        {
            get
            {
                SharedResources.tl.LogMessage(driverShortName + " DewPoint", SharedResources.DewPoint);
                return Convert.ToDouble(SharedResources.DewPoint);
            }
        }

        /// <summary>
        /// Atmospheric relative humidity at the observatory in percent
        /// </summary>
        /// <remarks>
        /// Normally optional but mandatory if <see cref="ASCOM.DeviceInterface.IObservingConditions.DewPoint"/> 
        /// Is provided
        /// </remarks>
        public double Humidity
        {
            get
            {
                SharedResources.tl.LogMessage(driverShortName + " Humidity", SharedResources.Humidity);
                return Convert.ToDouble(SharedResources.Humidity);
            }
        }

        /// <summary>
        /// Atmospheric pressure at the observatory in hectoPascals (mB)
        /// </summary>
        /// <remarks>
        /// This must be the pressure at the observatory and not the "reduced" pressure
        /// at sea level. Please check whether your pressure sensor delivers local pressure
        /// or sea level pressure and adjust if required to observatory pressure.
        /// </remarks>
        public double Pressure
        {
            get
            {
                SharedResources.tl.LogMessage(driverShortName + " Pressure", SharedResources.Pressure);
                return Convert.ToDouble(SharedResources.Pressure);
            }
        }

        /// <summary>
        /// Rain rate at the observatory
        /// </summary>
        /// <remarks>
        /// This property can be interpreted as 0.0 = Dry any positive nonzero value
        /// = wet.
        /// </remarks>
        public double RainRate
        {
            get
            {
                SharedResources.tl.LogMessage("RainRate", "get - not implemented");
                throw new PropertyNotImplementedException("RainRate", false);
            }
        }

        /// <summary>
        /// Forces the driver to immediatley query its attached hardware to refresh sensor
        /// values
        /// </summary>
        public void Refresh()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Provides a description of the sensor providing the requested property
        /// </summary>
        /// <param name="PropertyName">Name of the property whose sensor description is required</param>
        /// <returns>The sensor description string</returns>
        /// <remarks>
        /// PropertyName must be one of the sensor properties, 
        /// properties that are not implemented must throw the MethodNotImplementedException
        /// </remarks>
        public string SensorDescription(string PropertyName)
        {
            switch (PropertyName.Trim().ToLowerInvariant())
            {
                case "averageperiod":
                    return "Average period in hours, immediate values are only available";
                case "dewpoint":
                case "humidity":
                case "pressure":
                case "rainrate":
                case "skybrightness":
                case "skyquality":
                case "starfwhm":
                case "skytemperature":
                case "temperature":
                case "winddirection":
                case "windgust":
                case "windspeed":
                    SharedResources.tl.LogMessage("SensorDescription", PropertyName + " - not implemented");
                    throw new MethodNotImplementedException("SensorDescription(" + PropertyName + ")");
                default:
                    SharedResources.tl.LogMessage("SensorDescription", PropertyName + " - unrecognised");
                    throw new ASCOM.InvalidValueException("SensorDescription(" + PropertyName + ")");
            }
        }

        /// <summary>
        /// Sky brightness at the observatory
        /// </summary>
        public double SkyBrightness
        {
            get
            {
                SharedResources.tl.LogMessage("SkyBrightness", "get - not implemented");
                throw new PropertyNotImplementedException("SkyBrightness", false);
            }
        }

        /// <summary>
        /// Sky quality at the observatory
        /// </summary>
        public double SkyQuality
        {
            get
            {
                SharedResources.tl.LogMessage("SkyQuality", "get - not implemented");
                throw new PropertyNotImplementedException("SkyQuality", false);
            }
        }

        /// <summary>
        /// Seeing at the observatory
        /// </summary>
        public double StarFWHM
        {
            get
            {
                SharedResources.tl.LogMessage("StarFWHM", "get - not implemented");
                throw new PropertyNotImplementedException("StarFWHM", false);
            }
        }

        /// <summary>
        /// Sky temperature at the observatory in deg C
        /// </summary>
        public double SkyTemperature
        {
            get
            {
                SharedResources.tl.LogMessage("SkyTemperature", "get - not implemented");
                throw new PropertyNotImplementedException("SkyTemperature", false);
            }
        }

        /// <summary>
        /// Temperature at the observatory in deg C
        /// </summary>
        public double Temperature
        {
            get
            {
                SharedResources.tl.LogMessage(driverShortName + " Obs Temperature", SharedResources.ObsTemp);
                return Convert.ToDouble(SharedResources.ObsTemp);
            }
        }

        /// <summary>
        /// Provides the time since the sensor value was last updated
        /// </summary>
        /// <param name="PropertyName">Name of the property whose time since last update Is required</param>
        /// <returns>Time in seconds since the last sensor update for this property</returns>
        /// <remarks>
        /// PropertyName should be one of the sensor properties Or empty string to get
        /// the last update of any parameter. A negative value indicates no valid value
        /// ever received.
        /// </remarks>
        public double TimeSinceLastUpdate(string PropertyName)
        {
            // the checks can be removed if all properties have the same time.
            if (!string.IsNullOrEmpty(PropertyName))
            {
                switch (PropertyName.Trim().ToLowerInvariant())
                {
                    // break or return the time on the properties that are implemented
                    case "dewpoint":
                        break;
                    case "humidity":
                        break;
                    case "skytemperature":
                        break;
                    case "temperature":
                        break;
                    case "pressure":
                        break;
                    case "averageperiod":
                        break;
                    case "rainrate":
                    case "skybrightness":
                    case "skyquality":
                    case "starfwhm":
                    case "winddirection":
                    case "windgust":
                    case "windspeed":
                        // throw an exception on the properties that are not implemented
                        SharedResources.tl.LogMessage("TimeSinceLastUpdate", PropertyName + " - not implemented");
                        throw new MethodNotImplementedException("SensorDescription(" + PropertyName + ")");
                    default:
                        SharedResources.tl.LogMessage("TimeSinceLastUpdate", PropertyName + " - unrecognised");
                        throw new ASCOM.InvalidValueException("SensorDescription(" + PropertyName + ")");
                }
            }
            // return the time
            SharedResources.tl.LogMessage(driverShortName + " TimeSinceLastUpdate", SharedResources.LastUpdateTime);
            return Convert.ToDouble(SharedResources.LastUpdateTime);
        }

        /// <summary>
        /// Wind direction at the observatory in degrees
        /// </summary>
        /// <remarks>
        /// 0..360.0, 360=N, 180=S, 90=E, 270=W. When there Is no wind the driver will
        /// return a value of 0 for wind direction
        /// </remarks>
        public double WindDirection
        {
            get
            {
                SharedResources.tl.LogMessage("WindDirection", "get - not implemented");
                throw new PropertyNotImplementedException("WindDirection", false);
            }
        }

        /// <summary>
        /// Peak 3 second wind gust at the observatory over the last 2 minutes in m/s
        /// </summary>
        public double WindGust
        {
            get
            {
                SharedResources.tl.LogMessage("WindGust", "get - not implemented");
                throw new PropertyNotImplementedException("WindGust", false);
            }
        }

        /// <summary>
        /// Wind speed at the observatory in m/s
        /// </summary>
        public double WindSpeed
        {
            get
            {
                SharedResources.tl.LogMessage("WindSpeed", "get - not implemented");
                throw new PropertyNotImplementedException("WindSpeed", false);
            }
        }

        public double DewHeaterTemp(int heater)
        {
            string recTemp = "";

            if (heater == 1)
                recTemp = SharedResources.DewTemp1;
            else
                recTemp = SharedResources.DewTemp2;

            SharedResources.tl.LogMessage(driverShortName + " Dew Heater Temp", recTemp);
            return Convert.ToDouble(recTemp);
        }

        public double DewHeaterPower(int heater)
        {
            string recPower = "";

            if (heater == 1)
                recPower = SharedResources.DewPower1;
            else
                recPower = SharedResources.DewPower2;

            SharedResources.tl.LogMessage(driverShortName + " Dew Heater Power", recPower);
            return Convert.ToDouble(recPower);
        }

        #endregion

        #region private methods

        #region calculate the gust strength as the largest wind recorded over the last two minutes

        // save the time and wind speed values
        private Dictionary<DateTime, double> winds = new Dictionary<DateTime, double>();

        private double gustStrength;

        private void UpdateGusts(double speed)
        {
            Dictionary<DateTime, double> newWinds = new Dictionary<DateTime, double>();
            var last = DateTime.Now - TimeSpan.FromMinutes(2);
            winds.Add(DateTime.Now, speed);
            var gust = 0.0;
            foreach (var item in winds)
            {
                if (item.Key > last)
                {
                    newWinds.Add(item.Key, item.Value);
                    if (item.Value > gust)
                        gust = item.Value;
                }
            }
            gustStrength = gust;
            winds = newWinds;
        }

        #endregion

        #endregion

        #region Private properties and methods
        // here are some useful properties and methods that can be used as required
        // to help with driver development

        /// <summary>
        /// Returns true if there is a valid connection to the driver hardware
        /// </summary>
      private bool IsConnected
        {
            get
            {
                // TODO check that the driver hardware connection exists and is connected to the hardware
                return connectedState;
            }
        }
 
        /// <summary>
        /// Use this function to throw an exception if we aren't connected to the hardware
        /// </summary>
        /// <param name="message"></param>
        private void CheckConnected(string message)
        {
            if (!IsConnected)
            {
                throw new ASCOM.NotConnectedException(message);
            }
        }

        #endregion

    }
}

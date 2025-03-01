//
// ================
// Shared Resources
// ================
//
// This class is a container for all shared resources that may be needed
// by the drivers served by the Local Server. 
//
// NOTES:
//
//	* ALL DECLARATIONS MUST BE STATIC HERE!! INSTANCES OF THIS CLASS MUST NEVER BE CREATED!
//
// Written by:	Bob Denny	29-May-2007
// Modified by Chris Rowland and Peter Simpson to hamdle multiple hardware devices March 2011
//
using System;
using System.Collections.Generic;
using System.Text;
using ASCOM;
using ASCOM.Utilities;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics.PerformanceData;
using System.Runtime.Remoting.Messaging;

namespace ASCOM.QAstroDew
{
    /// <summary>
    /// The resources shared by all drivers and devices, in this example it's a serial port with a shared SendMessage method
    /// an idea for locking the message and handling connecting is given.
    /// In reality extensive changes will probably be needed.
    /// Multiple drivers means that several applications connect to the same hardware device, aka a hub.
    /// Multiple devices means that there are more than one instance of the hardware, such as two focusers.
    /// In this case there needs to be multiple instances of the hardware connector, each with it's own connection count.
    /// </summary>
    public static class SharedResources
    {
        // object used for locking to prevent multiple drivers accessing common code at the same time
        private static readonly object lockObject = new object();

        // Shared serial port. This will allow multiple drivers to use one single serial port.
        private static readonly ASCOM.Utilities.Serial s_sharedSerial = new ASCOM.Utilities.Serial();        // Shared serial port
        private static int s_z = 0;     // counter for the number of connections to the serial port

        private static TraceLogger traceLogger;

        public const string ASCOMfunction = "o";     //Define that communicate ObservingConditions to Arduino

        private const string ASCOMIdentifier = "Q-Astro Dew Monitor";

        private const int SERIAL_CONNECTION_TIMEOUT = 20000;

        //
        // Public access to shared resources
        //
        public static TraceLogger tl
        {
            get
            {
                if (traceLogger == null)
                {
                    traceLogger = new TraceLogger("", "Q-Astro")
                    {
                        Enabled = ASCOM.QAstroDew.Properties.Settings.Default.trace
                    };
                }
                return traceLogger;
            }
        }


        //
        // Public access to shared resources
        //

        #region single serial port connector
        //
        // this region shows a way that a single serial port could be connected to by multiple 
        // drivers.
        //
        // Connected is used to handle the connections to the port.
        //
        // SendMessage is a way that messages could be sent to the hardware without
        // conflicts between different drivers.
        //
        // All this is for a single connection, multiple connections would need multiple ports
        // and a way to handle connecting and disconnection from them - see the
        // multi driver handling section for ideas.
        //

        /// <summary>
        /// Shared serial port
        /// </summary>
        public static ASCOM.Utilities.Serial SharedSerial { get { return s_sharedSerial; } }

        /// <summary>
        /// number of connections to the shared serial port
        /// </summary>
        public static int connections { get { return s_z; } set { s_z = value; } }

        /// <summary>
        /// Example of a shared SendMessage method, the lock
        /// prevents different drivers tripping over one another.
        /// It needs error handling and assumes that the message will be sent unchanged
        /// and that the reply will always be terminated by a "#" character.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// 

        public static string SendMessage(string function, string message)
        {
            try
            {
                lock (lockObject)
                {
                    tl.LogMessage("Q-Astro Dew", "Lock Object");

                    string msg = function + message + "#";

                    if (SharedSerial.Connected && !String.IsNullOrEmpty(msg))
                    {
                        tl.LogMessage("Q-Astro Dew", "Send Msg: " + msg);

                        SharedSerial.ClearBuffers();
                        SharedSerial.Transmit(msg);
                        string strRec = SharedSerial.ReceiveTerminated("#");
                        SharedSerial.ClearBuffers();

                        tl.LogMessage("Q-Astro Dew", "Raw Response Msg: " + strRec);

                        strRec = cleanResponse(strRec);

                        tl.LogMessage("Q-Astro Dew", "Filtered Response Msg: " + strRec);

                        return strRec;
                    }
                    else
                    {
                        tl.LogMessage("Q-Astro Dew", "Not Connected or Empty Send Msg: " + message);
                        return "";
                    }
                }
            }
            catch
            {
                SharedResources.connections = 0;
                SharedResources.Connected = false;
                return "-1";
            }
        }

        private static string cleanResponse(string strRec)
        {
            int startPos = strRec.IndexOf(ASCOMfunction[0]);
            
            strRec = strRec.Substring(startPos+1);
            strRec = strRec.Trim('#');

            return strRec;
        }

        /// <summary>
        /// Example of handling connecting to and disconnection from the
        /// shared serial port.
        /// Needs error handling
        /// the port name etc. needs to be set up first, this could be done by the driver
        /// checking Connected and if it's false setting up the port before setting connected to true.
        /// It could also be put here.
        /// </summary>
        public static bool Connected
        {
            set
            {
                lock (lockObject)
                {
                    if (value)
                    {
                        if (s_z == 0)
                        {
                            SharedSerial.Connected = false;

                            try
                            {
                                SharedSerial.PortName = ASCOM.QAstroDew.Properties.Settings.Default.COMPort;

                                SharedSerial.ReceiveTimeoutMs = 15000;
                                if (SharedSerial.PortName.Length > 0)
                                {
                                    SharedSerial.Speed = ASCOM.Utilities.SerialSpeed.ps9600;
                                    SharedSerial.Handshake = ASCOM.Utilities.SerialHandshake.None;

                                    SharedSerial.Connected = true;
                                    System.Threading.Thread.Sleep(SERIAL_CONNECTION_TIMEOUT);    //Stupid Arduino restarts when opening port - needs to wait

                                    string answer = SharedResources.rawCommand("", "i", true);
                                    if (!answer.Contains(ASCOMIdentifier))
                                    {
                                        MessageBox.Show(ASCOMIdentifier + " device not detected at port " + SharedResources.SharedSerial.PortName, "Device not detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        SharedResources.tl.LogMessage("Connected answer", "Wrong answer " + answer);
                                        SharedSerial.Connected = false;
                                    }
                                    else
                                        SharedSerial.Connected = true;
                                }
                                else
                                {
                                    SharedSerial.Connected = false;
                                    MessageBox.Show(ASCOMIdentifier + " No COM port set", "Please do set a COM port before trying to connect.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (System.IO.IOException exception)
                            {
                                MessageBox.Show(ASCOMIdentifier + " Serial port not opened for " + SharedResources.SharedSerial.PortName, "Invalid port state", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                SharedResources.tl.LogMessage("Serial port not opened", exception.Message);
                                Application.Exit();
                            }
                            catch (System.UnauthorizedAccessException exception)
                            {
                                MessageBox.Show(ASCOMIdentifier + " Access denied to serial port " + SharedResources.SharedSerial.PortName, "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                SharedResources.tl.LogMessage("Access denied to serial port", exception.Message);
                                Application.Exit();
                            }
                            catch (ASCOM.DriverAccessCOMException exception)
                            {
                                MessageBox.Show(ASCOMIdentifier + " ASCOM driver exception: " + exception.Message, "ASCOM driver exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Application.Exit();
                            }
                            catch (System.Runtime.InteropServices.COMException exception)
                            {
                                MessageBox.Show(ASCOMIdentifier + " Serial port read timeout for port " + SharedResources.SharedSerial.PortName, "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                SharedResources.tl.LogMessage("QAstro Serial port read timeout", exception.Message);
                                Application.Exit();
                            }
                        }
                        s_z++;
                    }
                    else
                    {
                        s_z--;
                        if (s_z <= 0)
                        {
                            SharedSerial.Connected = false;
                            s_z = 0;
                            traceLogger.Enabled = false;
                            traceLogger.Dispose();
                            traceLogger = null;
                        }
                    }
                }
            }
            get { return SharedSerial.Connected; }
        }

        public static bool IsConnected()
        {
            return connections > 0 && SharedSerial != null && SharedSerial.Connected;
        }

        #endregion

        #region Multi Driver handling
        // this section illustrates how multiple drivers could be handled,
        // it's for drivers where multiple connections to the hardware can be made and ensures that the
        // hardware is only disconnected from when all the connected devices have disconnected.

        // It is NOT a complete solution!  This is to give ideas of what can - or should be done.
        //
        // An alternative would be to move the hardware control here, handle connecting and disconnecting,
        // and provide the device with a suitable connection to the hardware.
        //
        /// <summary>
        /// dictionary carrying device connections.
        /// The Key is the connection number that identifies the device, it could be the COM port name,
        /// USB ID or IP Address, the Value is the DeviceHardware class
        /// </summary>
        private static Dictionary<string, DeviceHardware> connectedDevices = new Dictionary<string, DeviceHardware>();

        /// <summary>
        /// This is called in the driver Connect(true) property,
        /// it add the device id to the list of devices if it's not there and increments the device count.
        /// </summary>
        /// <param name="deviceId"></param>
        public static void Connect(string deviceId)
        {
            lock (lockObject)
            {
                if (!connectedDevices.ContainsKey(deviceId))
                    connectedDevices.Add(deviceId, new DeviceHardware());
                connectedDevices[deviceId].count++;       // increment the value
            }
        }

        public static void Disconnect(string deviceId)
        {
            lock (lockObject)
            {
                if (connectedDevices.ContainsKey(deviceId))
                {
                    connectedDevices[deviceId].count--;
                    if (connectedDevices[deviceId].count <= 0)
                        connectedDevices.Remove(deviceId);
                }
            }
        }

        public static bool IsConnected(string deviceId)
        {
            if (connectedDevices.ContainsKey(deviceId))
                return (connectedDevices[deviceId].count > 0);
            else
                return false;
        }

        #endregion

        public static string rawCommand(string function, string command)
        {
            return rawCommand(function, command, false);
        }

        public static string rawCommand(string function, string command, bool raw)
        {
            try
            {
                string answer = SharedResources.SendMessage(function, command);
                if (raw)
                {
                    return answer.Trim();
                }
                else
                {
                    return answer.Substring(2).Trim();
                }
            }

            catch (System.TimeoutException e)
            {
                tl.LogMessage("Q-Astro Dew Timeout exception", e.Message);
            }
            catch (ASCOM.Utilities.Exceptions.SerialPortInUseException e)
            {
                tl.LogMessage("Q-Astro Dew Serial port in use exception", "Command: " + command + ", " + e.Message);
            }
            catch (ASCOM.NotConnectedException e)
            {
                tl.LogMessage("Q-Astro Dew Not connected exception", e.Message);
            }
            catch (ASCOM.DriverException e)
            {
                tl.LogMessage("Q-Astro Dew Driver exception", e.Message);
            }

            return String.Empty;
        }
    }

    /// <summary>
    /// Skeleton of a hardware class, all this does is hold a count of the connections,
    /// in reality extra code will be needed to handle the hardware in some way
    /// </summary>
    public class DeviceHardware
    {
        internal int count { set; get; }

        internal DeviceHardware()
        {
            count = 0;
        }
    }

    //#region ServedClassName attribute
    ///// <summary>
    ///// This is only needed if the driver is targeted at  platform 5.5, it is included with Platform 6
    ///// </summary>
    //[global::System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    //public sealed class ServedClassNameAttribute : Attribute
    //{
    //    // See the attribute guidelines at 
    //    //  http://go.microsoft.com/fwlink/?LinkId=85236

    //    /// <summary>
    //    /// Gets or sets the 'friendly name' of the served class, as registered with the ASCOM Chooser.
    //    /// </summary>
    //    /// <value>The 'friendly name' of the served class.</value>
    //    public string DisplayName { get; private set; }
    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="ServedClassNameAttribute"/> class.
    //    /// </summary>
    //    /// <param name="servedClassName">The 'friendly name' of the served class.</param>
    //    public ServedClassNameAttribute(string servedClassName)
    //    {
    //        DisplayName = servedClassName;
    //    }
    //}
    //#endregion
}
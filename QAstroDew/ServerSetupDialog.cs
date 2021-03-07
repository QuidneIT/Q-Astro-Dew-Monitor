using ASCOM.DeviceInterface;
using ASCOM.DriverAccess;
using ASCOM.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ASCOM.QAstroDew
{
    public partial class ServerSetupDialog : Form
    {
        internal List<COMPortInfo> comPorts;
        internal COMPortInfo comPort;
        internal ASCOM.Utilities.Serial serPort;

        public ServerSetupDialog()
        {
            InitializeComponent();
            InitUI();
        }      

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void InitUI()
        {
            this.Text = Application.ProductName + " - " + Application.ProductVersion;
            comPort = new COMPortInfo();
            comPorts = new List<COMPortInfo>();

            comPorts = COMPortInfo.GetCOMPortsInfo();
            
            // set the list of com ports to those that are currently available
            ComPortComboBox.Items.Clear();

            foreach (COMPortInfo cport in comPorts)
                ComPortComboBox.Items.Add(cport.Name);

            // select the current port if possible
            if (comPort != null)
            {
                if (ComPortComboBox.Items.Contains(Properties.Settings.Default.COMPort))
                    ComPortComboBox.SelectedItem = Properties.Settings.Default.COMPort;
            }

            if (ComboHeaters.Items.Contains(Properties.Settings.Default.NrDewHeaters))
                ComboHeaters.SelectedItem = Properties.Settings.Default.NrDewHeaters;
        }

        private void ComPortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            comPort.Name = ComPortComboBox.GetItemText(this.ComPortComboBox.SelectedItem);
        }

        private void btnTestPrt_Click_1(object sender, EventArgs e)
        {

        }
    }
}

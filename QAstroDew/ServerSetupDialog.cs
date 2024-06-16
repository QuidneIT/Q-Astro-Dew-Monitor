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

        public ServerSetupDialog()
        {
            InitializeComponent();
            InitUI();
        }      

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            bool error = ValidateValues();

            if (!error)
            {
                this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
                Properties.Settings.Default.Save();
                Close();
            }
        }

        private void SettingsChanged()
        {
            SettingsChanged(true);
        }

        private void SettingsChanged(bool changed)
        {
            Properties.Settings.Default.ConfigChanged = changed;
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

            chkTrace.Checked = Properties.Settings.Default.trace;

            // select the current port if possible
            if (comPort != null)
            {
                if (ComPortComboBox.Items.Contains(Properties.Settings.Default.COMPort))
                    ComPortComboBox.SelectedItem = Properties.Settings.Default.COMPort;
            }

            txtTempDiffBeforeUpdate.Text = Properties.Settings.Default.TempDiffBeforeUpdate.ToString();
            txtMinDewBandTemp.Text = Properties.Settings.Default.MinDewBandTemp.ToString();
            txtDewThreshold.Text = Properties.Settings.Default.DewThreshold.ToString();
            txtPowerUpdateInterval.Text = Properties.Settings.Default.PowerUpdateInterval.ToString();
            txtDewBandName1.Text = Properties.Settings.Default.NameBand1;
            txtDewBandName2.Text = Properties.Settings.Default.NameBand2;

            if (Properties.Settings.Default.PowerPercentage == 1)
                chkFxedIncreaseRate.Checked = true;
            else
                chkFxedIncreaseRate.Checked = false;

            Application.DoEvents();
        }

        private void ComPortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            comPort.Name = ComPortComboBox.GetItemText(this.ComPortComboBox.SelectedItem);
        }

        private void ChkTrace_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.trace = chkTrace.Checked;
        }

        private bool ValidateValues()
        {
            int intValue;
            bool error = false;

            bool canConvert = int.TryParse(txtDewThreshold.Text, out intValue);
            if (!canConvert)
            {
                intValue = 5;
                txtDewThreshold.Text = intValue.ToString();
                error = true;
            }
            Properties.Settings.Default.DewThreshold = intValue;

            canConvert = int.TryParse(txtMinDewBandTemp.Text, out intValue);
            if (!canConvert)
            {
                intValue = Properties.Settings.Default.DewThreshold + 2;
                txtMinDewBandTemp.Text = intValue.ToString();
                error = true;
            }
            else if (intValue < Properties.Settings.Default.DewThreshold)
            {
                MessageBox.Show("Minimum Dew Band Temperature needs to be equal or higher than the Minimum Dewpoint temperature", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                intValue = Properties.Settings.Default.DewThreshold + 2;
                txtMinDewBandTemp.Text = intValue.ToString();
                error = true;
            }
            Properties.Settings.Default.MinDewBandTemp = intValue;

            canConvert = int.TryParse(txtPowerUpdateInterval.Text, out intValue);
            if (!canConvert)
            {
                intValue = 30;
                txtPowerUpdateInterval.Text = intValue.ToString();
                error = true;
            }
            Properties.Settings.Default.PowerUpdateInterval = intValue;

            canConvert = int.TryParse(txtTempDiffBeforeUpdate.Text, out intValue);
            if (!canConvert)
            {
                intValue = 2;
                txtTempDiffBeforeUpdate.Text = intValue.ToString();
                error = true;
            }
            Properties.Settings.Default.TempDiffBeforeUpdate = intValue;

            Properties.Settings.Default.NameBand1 = txtDewBandName1.Text;
            Properties.Settings.Default.NameBand2 = txtDewBandName2.Text;

            Application.DoEvents();

            SettingsChanged();

            return error;
        }
     
        private void ChkFxedIncreaseRate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFxedIncreaseRate.Checked)
                Properties.Settings.Default.PowerPercentage = 1;
            else
                Properties.Settings.Default.PowerPercentage = 0;
        }
    }
}

namespace ASCOM.QAstroDew
{
    partial class ServerSetupDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()

        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerSetupDialog));
            this.lblHeader = new MetroFramework.Controls.MetroLabel();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnOK = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.toolQASetupStatus = new MetroFramework.Controls.MetroLabel();
            this.ComPortComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtMinDewBandTemp = new System.Windows.Forms.TextBox();
            this.txtPowerUpdateInterval = new System.Windows.Forms.TextBox();
            this.txtDewThreshold = new System.Windows.Forms.TextBox();
            this.txtTempDiffBeforeUpdate = new System.Windows.Forms.TextBox();
            this.chkFxedIncreaseRate = new MetroFramework.Controls.MetroCheckBox();
            this.chkTrace = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.txtDewBandName1 = new System.Windows.Forms.TextBox();
            this.txtDewBandName2 = new System.Windows.Forms.TextBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblHeader.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblHeader.Location = new System.Drawing.Point(63, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(253, 28);
            this.lblHeader.Style = MetroFramework.MetroColorStyle.Lime;
            this.lblHeader.TabIndex = 11;
            this.lblHeader.Text = "Dew Monitor Setup";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHeader.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lblHeader.UseStyleColors = true;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(102, 17);
            this.StatusLabel.Text = "ASCOM QA Setup";
            // 
            // picASCOM
            // 
            this.picASCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = ((System.Drawing.Image)(resources.GetObject("picASCOM.Image")));
            this.picASCOM.Location = new System.Drawing.Point(322, 9);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(48, 56);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picASCOM.TabIndex = 13;
            this.picASCOM.TabStop = false;
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogo.Image = global::ASCOM.QAstroDew.Properties.Resources.QuidneIT_SQR;
            this.picLogo.InitialImage = global::ASCOM.QAstroDew.Properties.Resources.QuidneIT_SQR;
            this.picLogo.Location = new System.Drawing.Point(6, 9);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(51, 56);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 23;
            this.picLogo.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(63, 338);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(122, 31);
            this.btnOK.Style = MetroFramework.MetroColorStyle.Lime;
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(190, 338);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = MetroFramework.MetroColorStyle.Lime;
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // toolQASetupStatus
            // 
            this.toolQASetupStatus.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.toolQASetupStatus.Location = new System.Drawing.Point(6, 377);
            this.toolQASetupStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toolQASetupStatus.Name = "toolQASetupStatus";
            this.toolQASetupStatus.Size = new System.Drawing.Size(364, 22);
            this.toolQASetupStatus.Style = MetroFramework.MetroColorStyle.Lime;
            this.toolQASetupStatus.TabIndex = 27;
            this.toolQASetupStatus.Text = "Q-Astro";
            this.toolQASetupStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolQASetupStatus.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.toolQASetupStatus.UseStyleColors = true;
            // 
            // ComPortComboBox
            // 
            this.ComPortComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ASCOM.QAstroDew.Properties.Settings.Default, "COMPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ComPortComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComPortComboBox.FormattingEnabled = true;
            this.ComPortComboBox.ItemHeight = 23;
            this.ComPortComboBox.Location = new System.Drawing.Point(230, 76);
            this.ComPortComboBox.Name = "ComPortComboBox";
            this.ComPortComboBox.Size = new System.Drawing.Size(102, 29);
            this.ComPortComboBox.Style = MetroFramework.MetroColorStyle.Lime;
            this.ComPortComboBox.TabIndex = 1;
            this.ComPortComboBox.Text = global::ASCOM.QAstroDew.Properties.Settings.Default.COMPort;
            this.ComPortComboBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(40, 137);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(224, 24);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel2.TabIndex = 34;
            this.metroLabel2.Text = "Minimum Dewband Temperature:";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel2.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(74, 193);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(190, 24);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel3.TabIndex = 35;
            this.metroLabel3.Text = "Power Update Interval:";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseStyleColors = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(74, 110);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(190, 24);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel4.TabIndex = 36;
            this.metroLabel4.Text = "Minimum Dewpoint:";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel4.UseStyleColors = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(6, 165);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(258, 24);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel5.TabIndex = 37;
            this.metroLabel5.Text = "Temperature Difference Before Update:";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel5.UseStyleColors = true;
            // 
            // txtMinDewBandTemp
            // 
            this.txtMinDewBandTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinDewBandTemp.Location = new System.Drawing.Point(268, 137);
            this.txtMinDewBandTemp.Margin = new System.Windows.Forms.Padding(2);
            this.txtMinDewBandTemp.Name = "txtMinDewBandTemp";
            this.txtMinDewBandTemp.Size = new System.Drawing.Size(64, 24);
            this.txtMinDewBandTemp.TabIndex = 3;
            // 
            // txtPowerUpdateInterval
            // 
            this.txtPowerUpdateInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPowerUpdateInterval.Location = new System.Drawing.Point(268, 193);
            this.txtPowerUpdateInterval.Margin = new System.Windows.Forms.Padding(2);
            this.txtPowerUpdateInterval.Name = "txtPowerUpdateInterval";
            this.txtPowerUpdateInterval.Size = new System.Drawing.Size(64, 24);
            this.txtPowerUpdateInterval.TabIndex = 5;
            // 
            // txtDewThreshold
            // 
            this.txtDewThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDewThreshold.Location = new System.Drawing.Point(268, 110);
            this.txtDewThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.txtDewThreshold.Name = "txtDewThreshold";
            this.txtDewThreshold.Size = new System.Drawing.Size(64, 24);
            this.txtDewThreshold.TabIndex = 2;
            // 
            // txtTempDiffBeforeUpdate
            // 
            this.txtTempDiffBeforeUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTempDiffBeforeUpdate.Location = new System.Drawing.Point(268, 165);
            this.txtTempDiffBeforeUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.txtTempDiffBeforeUpdate.Name = "txtTempDiffBeforeUpdate";
            this.txtTempDiffBeforeUpdate.Size = new System.Drawing.Size(64, 24);
            this.txtTempDiffBeforeUpdate.TabIndex = 4;
            // 
            // chkFxedIncreaseRate
            // 
            this.chkFxedIncreaseRate.AutoSize = true;
            this.chkFxedIncreaseRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFxedIncreaseRate.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.chkFxedIncreaseRate.Location = new System.Drawing.Point(42, 285);
            this.chkFxedIncreaseRate.Margin = new System.Windows.Forms.Padding(2);
            this.chkFxedIncreaseRate.Name = "chkFxedIncreaseRate";
            this.chkFxedIncreaseRate.Size = new System.Drawing.Size(300, 19);
            this.chkFxedIncreaseRate.TabIndex = 8;
            this.chkFxedIncreaseRate.Text = "Increase Dewband Power in Fixed Increments";
            this.chkFxedIncreaseRate.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkFxedIncreaseRate.CheckedChanged += new System.EventHandler(this.ChkFxedIncreaseRate_CheckedChanged);
            // 
            // chkTrace
            // 
            this.chkTrace.AutoSize = true;
            this.chkTrace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTrace.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.chkTrace.Location = new System.Drawing.Point(40, 308);
            this.chkTrace.Margin = new System.Windows.Forms.Padding(2);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTrace.Size = new System.Drawing.Size(100, 19);
            this.chkTrace.TabIndex = 9;
            this.chkTrace.Text = "Enable Trace";
            this.chkTrace.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkTrace.CheckedChanged += new System.EventHandler(this.ChkTrace_CheckedChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(38, 78);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(190, 24);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel1.TabIndex = 46;
            this.metroLabel1.Text = "COM Port:";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseStyleColors = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(335, 107);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(42, 24);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel6.TabIndex = 47;
            this.metroLabel6.Text = "º";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel6.UseStyleColors = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(335, 132);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(42, 24);
            this.metroLabel7.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel7.TabIndex = 48;
            this.metroLabel7.Text = "º";
            this.metroLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel7.UseStyleColors = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel8.Location = new System.Drawing.Point(335, 161);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(42, 24);
            this.metroLabel8.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel8.TabIndex = 49;
            this.metroLabel8.Text = "º";
            this.metroLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel8.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel8.UseStyleColors = true;
            // 
            // metroLabel9
            // 
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel9.Location = new System.Drawing.Point(336, 195);
            this.metroLabel9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(42, 24);
            this.metroLabel9.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel9.TabIndex = 50;
            this.metroLabel9.Text = "sec";
            this.metroLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel9.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel9.UseStyleColors = true;
            // 
            // metroLabel10
            // 
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel10.Location = new System.Drawing.Point(74, 225);
            this.metroLabel10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(142, 24);
            this.metroLabel10.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel10.TabIndex = 51;
            this.metroLabel10.Text = "Name Dew Band 1:";
            this.metroLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel10.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel10.UseStyleColors = true;
            // 
            // txtDewBandName1
            // 
            this.txtDewBandName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDewBandName1.Location = new System.Drawing.Point(221, 225);
            this.txtDewBandName1.Margin = new System.Windows.Forms.Padding(2);
            this.txtDewBandName1.Name = "txtDewBandName1";
            this.txtDewBandName1.Size = new System.Drawing.Size(111, 24);
            this.txtDewBandName1.TabIndex = 6;
            this.txtDewBandName1.Text = "Dew Band 1";
            // 
            // txtDewBandName2
            // 
            this.txtDewBandName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDewBandName2.Location = new System.Drawing.Point(221, 253);
            this.txtDewBandName2.Margin = new System.Windows.Forms.Padding(2);
            this.txtDewBandName2.Name = "txtDewBandName2";
            this.txtDewBandName2.Size = new System.Drawing.Size(111, 24);
            this.txtDewBandName2.TabIndex = 7;
            this.txtDewBandName2.Text = "Dew Band 2";
            // 
            // metroLabel11
            // 
            this.metroLabel11.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel11.Location = new System.Drawing.Point(74, 253);
            this.metroLabel11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(142, 24);
            this.metroLabel11.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel11.TabIndex = 53;
            this.metroLabel11.Text = "Name Dew Band 2:";
            this.metroLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel11.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel11.UseStyleColors = true;
            // 
            // ServerSetupDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(379, 405);
            this.Controls.Add(this.txtDewBandName2);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.txtDewBandName1);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.chkTrace);
            this.Controls.Add(this.chkFxedIncreaseRate);
            this.Controls.Add(this.txtTempDiffBeforeUpdate);
            this.Controls.Add(this.txtDewThreshold);
            this.Controls.Add(this.txtPowerUpdateInterval);
            this.Controls.Add(this.txtMinDewBandTemp);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.ComPortComboBox);
            this.Controls.Add(this.toolQASetupStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.picASCOM);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerSetupDialog";
            this.Text = "Q-Astro Dew Monitor Setup";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel lblHeader;

        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.PictureBox picASCOM;
        private System.Windows.Forms.PictureBox picLogo;
        private MetroFramework.Controls.MetroButton btnOK;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroLabel toolQASetupStatus;
        private MetroFramework.Controls.MetroComboBox ComPortComboBox;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.TextBox txtMinDewBandTemp;
        private System.Windows.Forms.TextBox txtPowerUpdateInterval;
        private System.Windows.Forms.TextBox txtDewThreshold;
        private System.Windows.Forms.TextBox txtTempDiffBeforeUpdate;
        private MetroFramework.Controls.MetroCheckBox chkFxedIncreaseRate;
        private MetroFramework.Controls.MetroCheckBox chkTrace;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private System.Windows.Forms.TextBox txtDewBandName1;
        private System.Windows.Forms.TextBox txtDewBandName2;
        private MetroFramework.Controls.MetroLabel metroLabel11;
    }
}
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.ComPortComboBox = new MetroFramework.Controls.MetroComboBox();
            this.chkTrace = new MetroFramework.Controls.MetroToggle();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblHeader.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblHeader.Location = new System.Drawing.Point(84, 11);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(276, 34);
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
            this.picASCOM.Location = new System.Drawing.Point(368, 11);
            this.picASCOM.Margin = new System.Windows.Forms.Padding(4);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(64, 69);
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
            this.picLogo.Location = new System.Drawing.Point(8, 11);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(68, 69);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 23;
            this.picLogo.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(84, 148);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 38);
            this.btnOK.Style = MetroFramework.MetroColorStyle.Lime;
            this.btnOK.TabIndex = 24;
            this.btnOK.Text = "OK";
            this.btnOK.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(254, 148);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 38);
            this.btnCancel.Style = MetroFramework.MetroColorStyle.Lime;
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolQASetupStatus
            // 
            this.toolQASetupStatus.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.toolQASetupStatus.Location = new System.Drawing.Point(8, 197);
            this.toolQASetupStatus.Name = "toolQASetupStatus";
            this.toolQASetupStatus.Size = new System.Drawing.Size(424, 27);
            this.toolQASetupStatus.Style = MetroFramework.MetroColorStyle.Lime;
            this.toolQASetupStatus.TabIndex = 27;
            this.toolQASetupStatus.Text = "Q-Astro";
            this.toolQASetupStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolQASetupStatus.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.toolQASetupStatus.UseStyleColors = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(157, 98);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(60, 30);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel1.TabIndex = 31;
            this.metroLabel1.Text = "Trace:";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseStyleColors = true;
            // 
            // ComPortComboBox
            // 
            this.ComPortComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ASCOM.QAstroDew.Properties.Settings.Default, "COMPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ComPortComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComPortComboBox.FormattingEnabled = true;
            this.ComPortComboBox.ItemHeight = 23;
            this.ComPortComboBox.Location = new System.Drawing.Point(84, 54);
            this.ComPortComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.ComPortComboBox.Name = "ComPortComboBox";
            this.ComPortComboBox.Size = new System.Drawing.Size(274, 29);
            this.ComPortComboBox.Style = MetroFramework.MetroColorStyle.Lime;
            this.ComPortComboBox.TabIndex = 29;
            this.ComPortComboBox.Text = global::ASCOM.QAstroDew.Properties.Settings.Default.COMPort;
            this.ComPortComboBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // chkTrace
            // 
            this.chkTrace.Checked = global::ASCOM.QAstroDew.Properties.Settings.Default.trace;
            this.chkTrace.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ASCOM.QAstroDew.Properties.Settings.Default, "trace", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkTrace.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkTrace.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.chkTrace.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.chkTrace.Location = new System.Drawing.Point(224, 106);
            this.chkTrace.Margin = new System.Windows.Forms.Padding(4);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.Size = new System.Drawing.Size(83, 17);
            this.chkTrace.Style = MetroFramework.MetroColorStyle.Lime;
            this.chkTrace.TabIndex = 30;
            this.chkTrace.Text = "Off";
            this.chkTrace.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkTrace.UseStyleColors = true;
            this.chkTrace.CheckedChanged += new System.EventHandler(this.chkTrace_CheckedChanged);
            // 
            // ServerSetupDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(444, 226);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.ComPortComboBox);
            this.Controls.Add(this.chkTrace);
            this.Controls.Add(this.toolQASetupStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.picASCOM);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerSetupDialog";
            this.Text = "Q-Astro Dew Monitor Setup";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroLabel lblHeader;

        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.PictureBox picASCOM;
        private System.Windows.Forms.PictureBox picLogo;
        private MetroFramework.Controls.MetroButton btnOK;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroLabel toolQASetupStatus;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox ComPortComboBox;
        private MetroFramework.Controls.MetroToggle chkTrace;
    }
}
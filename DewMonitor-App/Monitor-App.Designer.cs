namespace ASCOM.QAstroDew
{
    partial class MonitorApp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorApp));
            this.btnQAConnect = new MetroFramework.Controls.MetroButton();
            this.btnQASetup = new MetroFramework.Controls.MetroButton();
            this.lbltxtAstroStatus = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timerUI = new System.Windows.Forms.Timer(this.components);
            this.lblMinimize = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblCaption = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.pnlSetup = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDewHeaters = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbDigDewTemp2 = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lbDigDewTemp1 = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.label20 = new System.Windows.Forms.Label();
            this.pnlObserving = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.lbDigAltitude = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.label22 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lbDigPressure = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lbDigSkyTemp = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lbDigHumidity = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lbDigDewPoint = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lblAbout = new System.Windows.Forms.Label();
            this.pnlSetManual = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.lbl0 = new System.Windows.Forms.Label();
            this.lbl50 = new System.Windows.Forms.Label();
            this.lbl100 = new System.Windows.Forms.Label();
            this.lblDewPower2 = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.trackBarDew2 = new System.Windows.Forms.TrackBar();
            this.lblDew1 = new System.Windows.Forms.Label();
            this.lblDewPower1 = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.trackBarDew1 = new System.Windows.Forms.TrackBar();
            this.pnlManual = new System.Windows.Forms.Panel();
            this.lblManual = new System.Windows.Forms.Label();
            this.tglDewManual = new MetroFramework.Controls.MetroToggle();
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.trackerUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSnSS = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lblSnMM = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lblSnHH = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.currenttimeTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTmSS = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lblTmMM = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lblTmHH = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlSetup.SuspendLayout();
            this.pnlDewHeaters.SuspendLayout();
            this.pnlObserving.SuspendLayout();
            this.pnlSetManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDew2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDew1)).BeginInit();
            this.pnlManual.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQAConnect
            // 
            this.btnQAConnect.Highlight = true;
            this.btnQAConnect.Location = new System.Drawing.Point(253, 45);
            this.btnQAConnect.Name = "btnQAConnect";
            this.btnQAConnect.Size = new System.Drawing.Size(96, 35);
            this.btnQAConnect.Style = MetroFramework.MetroColorStyle.Lime;
            this.btnQAConnect.TabIndex = 3;
            this.btnQAConnect.Text = "Connect";
            this.btnQAConnect.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnQAConnect.Click += new System.EventHandler(this.btnQAConnect_Click);
            // 
            // btnQASetup
            // 
            this.btnQASetup.Highlight = true;
            this.btnQASetup.Location = new System.Drawing.Point(107, 45);
            this.btnQASetup.Name = "btnQASetup";
            this.btnQASetup.Size = new System.Drawing.Size(99, 35);
            this.btnQASetup.Style = MetroFramework.MetroColorStyle.Lime;
            this.btnQASetup.TabIndex = 4;
            this.btnQASetup.Text = "Setup";
            this.btnQASetup.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnQASetup.Click += new System.EventHandler(this.btnQASetup_Click);
            // 
            // lbltxtAstroStatus
            // 
            this.lbltxtAstroStatus.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lbltxtAstroStatus.Location = new System.Drawing.Point(12, 543);
            this.lbltxtAstroStatus.Name = "lbltxtAstroStatus";
            this.lbltxtAstroStatus.Size = new System.Drawing.Size(75, 23);
            this.lbltxtAstroStatus.Style = MetroFramework.MetroColorStyle.Lime;
            this.lbltxtAstroStatus.TabIndex = 1;
            this.lbltxtAstroStatus.Text = "Q-Astro: ";
            this.lbltxtAstroStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbltxtAstroStatus.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lbltxtAstroStatus.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(67, 35);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(39, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "5.5.0";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseStyleColors = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(4, 4);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(187, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Q-Astro Controller";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseStyleColors = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 50);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 486);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 66);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // timerUI
            // 
            this.timerUI.Interval = 5000;
            this.timerUI.Tick += new System.EventHandler(this.timerUI_Tick);
            // 
            // lblMinimize
            // 
            this.lblMinimize.AutoSize = true;
            this.lblMinimize.Location = new System.Drawing.Point(497, 6);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(14, 16);
            this.lblMinimize.TabIndex = 21;
            this.lblMinimize.Text = "-";
            this.lblMinimize.Click += new System.EventHandler(this.lblMinimize_Click);
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Location = new System.Drawing.Point(515, 6);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(16, 16);
            this.lblClose.TabIndex = 22;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Location = new System.Drawing.Point(0, 6);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(203, 16);
            this.lblCaption.TabIndex = 24;
            this.lblCaption.Text = "Q-Astro Dew Monitor Panel - ";
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Black;
            this.label23.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.YellowGreen;
            this.label23.Location = new System.Drawing.Point(169, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(15, 27);
            this.label23.TabIndex = 35;
            this.label23.Text = ":";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSetup
            // 
            this.pnlSetup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSetup.Controls.Add(this.label1);
            this.pnlSetup.Controls.Add(this.btnQASetup);
            this.pnlSetup.Controls.Add(this.btnQAConnect);
            this.pnlSetup.Location = new System.Drawing.Point(70, 35);
            this.pnlSetup.Name = "pnlSetup";
            this.pnlSetup.Size = new System.Drawing.Size(460, 98);
            this.pnlSetup.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Q-Astro Dew Monitor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDewHeaters
            // 
            this.pnlDewHeaters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDewHeaters.Controls.Add(this.label3);
            this.pnlDewHeaters.Controls.Add(this.label4);
            this.pnlDewHeaters.Controls.Add(this.lbDigDewTemp2);
            this.pnlDewHeaters.Controls.Add(this.label6);
            this.pnlDewHeaters.Controls.Add(this.label7);
            this.pnlDewHeaters.Controls.Add(this.label18);
            this.pnlDewHeaters.Controls.Add(this.lbDigDewTemp1);
            this.pnlDewHeaters.Location = new System.Drawing.Point(71, 388);
            this.pnlDewHeaters.Name = "pnlDewHeaters";
            this.pnlDewHeaters.Size = new System.Drawing.Size(304, 104);
            this.pnlDewHeaters.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.YellowGreen;
            this.label3.Location = new System.Drawing.Point(33, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 27);
            this.label3.TabIndex = 46;
            this.label3.Text = "Dew Band 2:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.YellowGreen;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(260, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 27);
            this.label4.TabIndex = 47;
            this.label4.Text = "º";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDigDewTemp2
            // 
            this.lbDigDewTemp2.BackColor = System.Drawing.Color.Black;
            this.lbDigDewTemp2.ForeColor = System.Drawing.Color.Red;
            this.lbDigDewTemp2.Format = "00.0";
            this.lbDigDewTemp2.Location = new System.Drawing.Point(178, 67);
            this.lbDigDewTemp2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDigDewTemp2.Name = "lbDigDewTemp2";
            this.lbDigDewTemp2.Renderer = null;
            this.lbDigDewTemp2.Signed = true;
            this.lbDigDewTemp2.Size = new System.Drawing.Size(80, 27);
            this.lbDigDewTemp2.TabIndex = 45;
            this.lbDigDewTemp2.Value = 0D;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(301, 26);
            this.label6.TabIndex = 32;
            this.label6.Text = "Dew Heater Temps:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.YellowGreen;
            this.label7.Location = new System.Drawing.Point(30, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 27);
            this.label7.TabIndex = 33;
            this.label7.Text = "Dew Band 1:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Black;
            this.label18.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.YellowGreen;
            this.label18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label18.Location = new System.Drawing.Point(260, 29);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(10, 27);
            this.label18.TabIndex = 44;
            this.label18.Text = "º";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDigDewTemp1
            // 
            this.lbDigDewTemp1.BackColor = System.Drawing.Color.Black;
            this.lbDigDewTemp1.ForeColor = System.Drawing.Color.Red;
            this.lbDigDewTemp1.Format = "00.0";
            this.lbDigDewTemp1.Location = new System.Drawing.Point(178, 31);
            this.lbDigDewTemp1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDigDewTemp1.Name = "lbDigDewTemp1";
            this.lbDigDewTemp1.Renderer = null;
            this.lbDigDewTemp1.Signed = true;
            this.lbDigDewTemp1.Size = new System.Drawing.Size(80, 27);
            this.lbDigDewTemp1.TabIndex = 27;
            this.lbDigDewTemp1.Value = 0D;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Black;
            this.label20.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.YellowGreen;
            this.label20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label20.Location = new System.Drawing.Point(261, 21);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(10, 27);
            this.label20.TabIndex = 46;
            this.label20.Text = "º";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlObserving
            // 
            this.pnlObserving.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlObserving.Controls.Add(this.label19);
            this.pnlObserving.Controls.Add(this.lbDigAltitude);
            this.pnlObserving.Controls.Add(this.label22);
            this.pnlObserving.Controls.Add(this.label17);
            this.pnlObserving.Controls.Add(this.lbDigPressure);
            this.pnlObserving.Controls.Add(this.label16);
            this.pnlObserving.Controls.Add(this.label2);
            this.pnlObserving.Controls.Add(this.label5);
            this.pnlObserving.Controls.Add(this.label12);
            this.pnlObserving.Controls.Add(this.label14);
            this.pnlObserving.Controls.Add(this.label15);
            this.pnlObserving.Controls.Add(this.label21);
            this.pnlObserving.Controls.Add(this.label20);
            this.pnlObserving.Controls.Add(this.lbDigSkyTemp);
            this.pnlObserving.Controls.Add(this.lbDigHumidity);
            this.pnlObserving.Controls.Add(this.lbDigDewPoint);
            this.pnlObserving.Location = new System.Drawing.Point(70, 181);
            this.pnlObserving.Name = "pnlObserving";
            this.pnlObserving.Size = new System.Drawing.Size(304, 201);
            this.pnlObserving.TabIndex = 48;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Black;
            this.label19.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.YellowGreen;
            this.label19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label19.Location = new System.Drawing.Point(260, 161);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(36, 26);
            this.label19.TabIndex = 54;
            this.label19.Text = "M";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDigAltitude
            // 
            this.lbDigAltitude.BackColor = System.Drawing.Color.Black;
            this.lbDigAltitude.ForeColor = System.Drawing.Color.Red;
            this.lbDigAltitude.Format = "0000";
            this.lbDigAltitude.Location = new System.Drawing.Point(178, 161);
            this.lbDigAltitude.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDigAltitude.Name = "lbDigAltitude";
            this.lbDigAltitude.Renderer = null;
            this.lbDigAltitude.Signed = false;
            this.lbDigAltitude.Size = new System.Drawing.Size(80, 27);
            this.lbDigAltitude.TabIndex = 53;
            this.lbDigAltitude.Value = 0D;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Black;
            this.label22.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.YellowGreen;
            this.label22.Location = new System.Drawing.Point(88, 161);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(90, 27);
            this.label22.TabIndex = 52;
            this.label22.Text = "Altitude:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Black;
            this.label17.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.YellowGreen;
            this.label17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label17.Location = new System.Drawing.Point(260, 129);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 26);
            this.label17.TabIndex = 51;
            this.label17.Text = "hPa";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDigPressure
            // 
            this.lbDigPressure.BackColor = System.Drawing.Color.Black;
            this.lbDigPressure.ForeColor = System.Drawing.Color.Red;
            this.lbDigPressure.Format = "0000";
            this.lbDigPressure.Location = new System.Drawing.Point(178, 129);
            this.lbDigPressure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDigPressure.Name = "lbDigPressure";
            this.lbDigPressure.Renderer = null;
            this.lbDigPressure.Signed = false;
            this.lbDigPressure.Size = new System.Drawing.Size(80, 27);
            this.lbDigPressure.TabIndex = 50;
            this.lbDigPressure.Value = 0D;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.YellowGreen;
            this.label16.Location = new System.Drawing.Point(88, 129);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 27);
            this.label16.TabIndex = 49;
            this.label16.Text = "Pressure:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.YellowGreen;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(260, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 27);
            this.label2.TabIndex = 48;
            this.label2.Text = "º";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(3, -3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(296, 28);
            this.label5.TabIndex = 31;
            this.label5.Text = "Observatory Conditions:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.YellowGreen;
            this.label12.Location = new System.Drawing.Point(44, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 27);
            this.label12.TabIndex = 38;
            this.label12.Text = "Temperature:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Black;
            this.label14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.YellowGreen;
            this.label14.Location = new System.Drawing.Point(30, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(151, 27);
            this.label14.TabIndex = 40;
            this.label14.Text = "Dew Point:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Black;
            this.label15.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.YellowGreen;
            this.label15.Location = new System.Drawing.Point(88, 98);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 27);
            this.label15.TabIndex = 41;
            this.label15.Text = "Humidity:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Black;
            this.label21.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.YellowGreen;
            this.label21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label21.Location = new System.Drawing.Point(260, 98);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(25, 26);
            this.label21.TabIndex = 47;
            this.label21.Text = "%";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDigSkyTemp
            // 
            this.lbDigSkyTemp.BackColor = System.Drawing.Color.Black;
            this.lbDigSkyTemp.ForeColor = System.Drawing.Color.Red;
            this.lbDigSkyTemp.Format = "00.0";
            this.lbDigSkyTemp.Location = new System.Drawing.Point(178, 29);
            this.lbDigSkyTemp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDigSkyTemp.Name = "lbDigSkyTemp";
            this.lbDigSkyTemp.Renderer = null;
            this.lbDigSkyTemp.Signed = true;
            this.lbDigSkyTemp.Size = new System.Drawing.Size(80, 27);
            this.lbDigSkyTemp.TabIndex = 23;
            this.lbDigSkyTemp.Value = 0D;
            // 
            // lbDigHumidity
            // 
            this.lbDigHumidity.BackColor = System.Drawing.Color.Black;
            this.lbDigHumidity.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDigHumidity.ForeColor = System.Drawing.Color.Red;
            this.lbDigHumidity.Format = "000";
            this.lbDigHumidity.Location = new System.Drawing.Point(197, 98);
            this.lbDigHumidity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDigHumidity.Name = "lbDigHumidity";
            this.lbDigHumidity.Renderer = null;
            this.lbDigHumidity.Signed = false;
            this.lbDigHumidity.Size = new System.Drawing.Size(63, 27);
            this.lbDigHumidity.TabIndex = 26;
            this.lbDigHumidity.Value = 0D;
            // 
            // lbDigDewPoint
            // 
            this.lbDigDewPoint.BackColor = System.Drawing.Color.Black;
            this.lbDigDewPoint.ForeColor = System.Drawing.Color.Red;
            this.lbDigDewPoint.Format = "00.0";
            this.lbDigDewPoint.Location = new System.Drawing.Point(178, 64);
            this.lbDigDewPoint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDigDewPoint.Name = "lbDigDewPoint";
            this.lbDigDewPoint.Renderer = null;
            this.lbDigDewPoint.Signed = true;
            this.lbDigDewPoint.Size = new System.Drawing.Size(80, 27);
            this.lbDigDewPoint.TabIndex = 25;
            this.lbDigDewPoint.Value = 0D;
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Location = new System.Drawing.Point(478, 6);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(14, 16);
            this.lblAbout.TabIndex = 57;
            this.lblAbout.Text = "?";
            this.lblAbout.Click += new System.EventHandler(this.lblAbout_Click);
            // 
            // pnlSetManual
            // 
            this.pnlSetManual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSetManual.Controls.Add(this.label24);
            this.pnlSetManual.Controls.Add(this.lbl0);
            this.pnlSetManual.Controls.Add(this.lbl50);
            this.pnlSetManual.Controls.Add(this.lbl100);
            this.pnlSetManual.Controls.Add(this.lblDewPower2);
            this.pnlSetManual.Controls.Add(this.trackBarDew2);
            this.pnlSetManual.Controls.Add(this.lblDew1);
            this.pnlSetManual.Controls.Add(this.lblDewPower1);
            this.pnlSetManual.Controls.Add(this.trackBarDew1);
            this.pnlSetManual.Location = new System.Drawing.Point(380, 212);
            this.pnlSetManual.Name = "pnlSetManual";
            this.pnlSetManual.Size = new System.Drawing.Size(150, 328);
            this.pnlSetManual.TabIndex = 58;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Black;
            this.label24.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(3, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(149, 26);
            this.label24.TabIndex = 63;
            this.label24.Text = "Dew Power";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl0
            // 
            this.lbl0.BackColor = System.Drawing.Color.Black;
            this.lbl0.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0.ForeColor = System.Drawing.Color.YellowGreen;
            this.lbl0.Location = new System.Drawing.Point(34, 218);
            this.lbl0.Name = "lbl0";
            this.lbl0.Size = new System.Drawing.Size(50, 27);
            this.lbl0.TabIndex = 62;
            this.lbl0.Text = "0%";
            this.lbl0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl50
            // 
            this.lbl50.BackColor = System.Drawing.Color.Black;
            this.lbl50.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl50.ForeColor = System.Drawing.Color.YellowGreen;
            this.lbl50.Location = new System.Drawing.Point(35, 123);
            this.lbl50.Name = "lbl50";
            this.lbl50.Size = new System.Drawing.Size(50, 27);
            this.lbl50.TabIndex = 61;
            this.lbl50.Text = "50%";
            this.lbl50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl100
            // 
            this.lbl100.BackColor = System.Drawing.Color.Black;
            this.lbl100.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl100.ForeColor = System.Drawing.Color.YellowGreen;
            this.lbl100.Location = new System.Drawing.Point(36, 32);
            this.lbl100.Name = "lbl100";
            this.lbl100.Size = new System.Drawing.Size(50, 27);
            this.lbl100.TabIndex = 60;
            this.lbl100.Text = "100%";
            this.lbl100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDewPower2
            // 
            this.lblDewPower2.BackColor = System.Drawing.Color.Black;
            this.lblDewPower2.ForeColor = System.Drawing.Color.Red;
            this.lblDewPower2.Format = "000";
            this.lblDewPower2.Location = new System.Drawing.Point(82, 254);
            this.lblDewPower2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblDewPower2.Name = "lblDewPower2";
            this.lblDewPower2.Renderer = null;
            this.lblDewPower2.Signed = false;
            this.lblDewPower2.Size = new System.Drawing.Size(61, 27);
            this.lblDewPower2.TabIndex = 57;
            this.lblDewPower2.Value = 0D;
            // 
            // trackBarDew2
            // 
            this.trackBarDew2.LargeChange = 10;
            this.trackBarDew2.Location = new System.Drawing.Point(84, 29);
            this.trackBarDew2.Maximum = 100;
            this.trackBarDew2.Name = "trackBarDew2";
            this.trackBarDew2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarDew2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBarDew2.Size = new System.Drawing.Size(56, 216);
            this.trackBarDew2.SmallChange = 10;
            this.trackBarDew2.TabIndex = 56;
            this.trackBarDew2.TickFrequency = 10;
            this.trackBarDew2.Scroll += new System.EventHandler(this.trackBarDew2_Scroll);
            this.trackBarDew2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarDew2_MouseUp);
            // 
            // lblDew1
            // 
            this.lblDew1.BackColor = System.Drawing.Color.Black;
            this.lblDew1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDew1.ForeColor = System.Drawing.Color.YellowGreen;
            this.lblDew1.Location = new System.Drawing.Point(3, 285);
            this.lblDew1.Name = "lblDew1";
            this.lblDew1.Size = new System.Drawing.Size(146, 27);
            this.lblDew1.TabIndex = 55;
            this.lblDew1.Text = "Dew 1 (%) Dew 2";
            this.lblDew1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDewPower1
            // 
            this.lblDewPower1.BackColor = System.Drawing.Color.Black;
            this.lblDewPower1.ForeColor = System.Drawing.Color.Red;
            this.lblDewPower1.Format = "000";
            this.lblDewPower1.Location = new System.Drawing.Point(5, 254);
            this.lblDewPower1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblDewPower1.Name = "lblDewPower1";
            this.lblDewPower1.Renderer = null;
            this.lblDewPower1.Signed = false;
            this.lblDewPower1.Size = new System.Drawing.Size(61, 27);
            this.lblDewPower1.TabIndex = 51;
            this.lblDewPower1.Value = 0D;
            // 
            // trackBarDew1
            // 
            this.trackBarDew1.LargeChange = 10;
            this.trackBarDew1.Location = new System.Drawing.Point(8, 29);
            this.trackBarDew1.Maximum = 100;
            this.trackBarDew1.Name = "trackBarDew1";
            this.trackBarDew1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarDew1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBarDew1.Size = new System.Drawing.Size(56, 218);
            this.trackBarDew1.SmallChange = 10;
            this.trackBarDew1.TabIndex = 2;
            this.trackBarDew1.TickFrequency = 10;
            this.trackBarDew1.Scroll += new System.EventHandler(this.trackBarDew1_Scroll);
            this.trackBarDew1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarDew1_MouseUp);
            // 
            // pnlManual
            // 
            this.pnlManual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlManual.Controls.Add(this.lblManual);
            this.pnlManual.Controls.Add(this.tglDewManual);
            this.pnlManual.Location = new System.Drawing.Point(380, 139);
            this.pnlManual.Name = "pnlManual";
            this.pnlManual.Size = new System.Drawing.Size(150, 67);
            this.pnlManual.TabIndex = 60;
            // 
            // lblManual
            // 
            this.lblManual.BackColor = System.Drawing.Color.Black;
            this.lblManual.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManual.ForeColor = System.Drawing.Color.Red;
            this.lblManual.Location = new System.Drawing.Point(3, 2);
            this.lblManual.Name = "lblManual";
            this.lblManual.Size = new System.Drawing.Size(143, 28);
            this.lblManual.TabIndex = 61;
            this.lblManual.Text = "Manual Dew";
            this.lblManual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tglDewManual
            // 
            this.tglDewManual.AutoSize = true;
            this.tglDewManual.Location = new System.Drawing.Point(35, 34);
            this.tglDewManual.Name = "tglDewManual";
            this.tglDewManual.Size = new System.Drawing.Size(80, 20);
            this.tglDewManual.TabIndex = 60;
            this.tglDewManual.Text = "Off";
            this.tglDewManual.UseVisualStyleBackColor = true;
            this.tglDewManual.CheckedChanged += new System.EventHandler(this.tglDewManual_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblStatus.Location = new System.Drawing.Point(70, 543);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(460, 22);
            this.lblStatus.Style = MetroFramework.MetroColorStyle.Red;
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Disconnected";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lblStatus.UseStyleColors = true;
            // 
            // trackerUpdateTimer
            // 
            this.trackerUpdateTimer.Interval = 1000;
            this.trackerUpdateTimer.Tick += new System.EventHandler(this.trackerUpdateTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblSnSS);
            this.panel1.Controls.Add(this.lblSnMM);
            this.panel1.Controls.Add(this.lblSnHH);
            this.panel1.Location = new System.Drawing.Point(70, 498);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 42);
            this.panel1.TabIndex = 61;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.YellowGreen;
            this.label11.Location = new System.Drawing.Point(240, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(12, 27);
            this.label11.TabIndex = 60;
            this.label11.Text = ":";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.YellowGreen;
            this.label10.Location = new System.Drawing.Point(188, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 27);
            this.label10.TabIndex = 59;
            this.label10.Text = ":";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.YellowGreen;
            this.label9.Location = new System.Drawing.Point(7, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 27);
            this.label9.TabIndex = 58;
            this.label9.Text = "Latest Update:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSnSS
            // 
            this.lblSnSS.BackColor = System.Drawing.Color.Black;
            this.lblSnSS.ForeColor = System.Drawing.Color.Red;
            this.lblSnSS.Format = "00";
            this.lblSnSS.Location = new System.Drawing.Point(250, 5);
            this.lblSnSS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblSnSS.Name = "lblSnSS";
            this.lblSnSS.Renderer = null;
            this.lblSnSS.Signed = false;
            this.lblSnSS.Size = new System.Drawing.Size(40, 27);
            this.lblSnSS.TabIndex = 53;
            this.lblSnSS.Value = 0D;
            // 
            // lblSnMM
            // 
            this.lblSnMM.BackColor = System.Drawing.Color.Black;
            this.lblSnMM.ForeColor = System.Drawing.Color.Red;
            this.lblSnMM.Format = "00";
            this.lblSnMM.Location = new System.Drawing.Point(198, 5);
            this.lblSnMM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblSnMM.Name = "lblSnMM";
            this.lblSnMM.Renderer = null;
            this.lblSnMM.Signed = false;
            this.lblSnMM.Size = new System.Drawing.Size(40, 27);
            this.lblSnMM.TabIndex = 52;
            this.lblSnMM.Value = 0D;
            // 
            // lblSnHH
            // 
            this.lblSnHH.BackColor = System.Drawing.Color.Black;
            this.lblSnHH.ForeColor = System.Drawing.Color.Red;
            this.lblSnHH.Format = "00";
            this.lblSnHH.Location = new System.Drawing.Point(147, 5);
            this.lblSnHH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblSnHH.Name = "lblSnHH";
            this.lblSnHH.Renderer = null;
            this.lblSnHH.Signed = false;
            this.lblSnHH.Size = new System.Drawing.Size(40, 27);
            this.lblSnHH.TabIndex = 51;
            this.lblSnHH.Value = 0D;
            // 
            // currenttimeTimer
            // 
            this.currenttimeTimer.Interval = 1000;
            this.currenttimeTimer.Tick += new System.EventHandler(this.currenttimeTimer_Tick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblTmSS);
            this.panel2.Controls.Add(this.lblTmMM);
            this.panel2.Controls.Add(this.lblTmHH);
            this.panel2.Location = new System.Drawing.Point(70, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 37);
            this.panel2.TabIndex = 62;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Black;
            this.label25.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.YellowGreen;
            this.label25.Location = new System.Drawing.Point(240, 4);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(12, 27);
            this.label25.TabIndex = 68;
            this.label25.Text = ":";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.YellowGreen;
            this.label13.Location = new System.Drawing.Point(188, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(12, 27);
            this.label13.TabIndex = 67;
            this.label13.Text = ":";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.YellowGreen;
            this.label8.Location = new System.Drawing.Point(10, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 27);
            this.label8.TabIndex = 66;
            this.label8.Text = "Current Time:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTmSS
            // 
            this.lblTmSS.BackColor = System.Drawing.Color.Black;
            this.lblTmSS.ForeColor = System.Drawing.Color.Red;
            this.lblTmSS.Format = "00";
            this.lblTmSS.Location = new System.Drawing.Point(250, 3);
            this.lblTmSS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTmSS.Name = "lblTmSS";
            this.lblTmSS.Renderer = null;
            this.lblTmSS.Signed = false;
            this.lblTmSS.Size = new System.Drawing.Size(40, 27);
            this.lblTmSS.TabIndex = 65;
            this.lblTmSS.Value = 0D;
            // 
            // lblTmMM
            // 
            this.lblTmMM.BackColor = System.Drawing.Color.Black;
            this.lblTmMM.ForeColor = System.Drawing.Color.Red;
            this.lblTmMM.Format = "00";
            this.lblTmMM.Location = new System.Drawing.Point(198, 3);
            this.lblTmMM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTmMM.Name = "lblTmMM";
            this.lblTmMM.Renderer = null;
            this.lblTmMM.Signed = false;
            this.lblTmMM.Size = new System.Drawing.Size(40, 27);
            this.lblTmMM.TabIndex = 64;
            this.lblTmMM.Value = 0D;
            // 
            // lblTmHH
            // 
            this.lblTmHH.BackColor = System.Drawing.Color.Black;
            this.lblTmHH.ForeColor = System.Drawing.Color.Red;
            this.lblTmHH.Format = "00";
            this.lblTmHH.Location = new System.Drawing.Point(147, 3);
            this.lblTmHH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTmHH.Name = "lblTmHH";
            this.lblTmHH.Renderer = null;
            this.lblTmHH.Signed = false;
            this.lblTmHH.Size = new System.Drawing.Size(40, 27);
            this.lblTmHH.TabIndex = 63;
            this.lblTmHH.Value = 0D;
            // 
            // MonitorApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(539, 576);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlManual);
            this.Controls.Add(this.pnlSetManual);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.lblMinimize);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lbltxtAstroStatus);
            this.Controls.Add(this.pnlObserving);
            this.Controls.Add(this.pnlDewHeaters);
            this.Controls.Add(this.pnlSetup);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MonitorApp";
            this.Text = "Q-Astro Environment";
            this.TransparencyKey = System.Drawing.Color.Pink;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlSetup.ResumeLayout(false);
            this.pnlDewHeaters.ResumeLayout(false);
            this.pnlObserving.ResumeLayout(false);
            this.pnlSetManual.ResumeLayout(false);
            this.pnlSetManual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDew2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDew1)).EndInit();
            this.pnlManual.ResumeLayout(false);
            this.pnlManual.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel lbltxtAstroStatus;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnQAConnect;
        private MetroFramework.Controls.MetroButton btnQASetup;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timerUI;
        private System.Windows.Forms.Label lblMinimize;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel pnlSetup;
        private System.Windows.Forms.Panel pnlDewHeaters;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label20;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigDewTemp1;
        private System.Windows.Forms.Panel pnlObserving;
        private System.Windows.Forms.Label label5;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigHumidity;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigDewPoint;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label12;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigSkyTemp;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigDewTemp2;
        private System.Windows.Forms.Label label17;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigPressure;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigAltitude;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel pnlSetManual;
        private System.Windows.Forms.Label lblDew1;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lblDewPower1;
        private System.Windows.Forms.TrackBar trackBarDew1;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lblDewPower2;
        private System.Windows.Forms.TrackBar trackBarDew2;
        private System.Windows.Forms.Label lbl0;
        private System.Windows.Forms.Label lbl50;
        private System.Windows.Forms.Label lbl100;
        private System.Windows.Forms.Panel pnlManual;
        private System.Windows.Forms.Label lblManual;
        private MetroFramework.Controls.MetroToggle tglDewManual;
        private MetroFramework.Controls.MetroLabel lblStatus;
        private System.Windows.Forms.Timer trackerUpdateTimer;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lblSnSS;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lblSnMM;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lblSnHH;
        private System.Windows.Forms.Timer currenttimeTimer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lblTmSS;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lblTmMM;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lblTmHH;
    }
}


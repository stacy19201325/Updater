namespace Updater
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnMain = new System.Windows.Forms.Button();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pbTotal = new System.Windows.Forms.ProgressBar();
            this.lblNews = new System.Windows.Forms.Label();
            this.ftbNews = new System.Windows.Forms.RichTextBox();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.btnForcePatch = new System.Windows.Forms.Button();
            this.lblPatchLevel = new System.Windows.Forms.Label();
            this.lblSettingsTitle = new System.Windows.Forms.Label();
            this.btnSWG = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpClose = new System.Windows.Forms.GroupBox();
            this.chkMin = new System.Windows.Forms.CheckBox();
            this.chkClose = new System.Windows.Forms.CheckBox();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnFolder = new System.Windows.Forms.Button();
            this.lblFolder = new System.Windows.Forms.Label();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.lblStatusLast = new System.Windows.Forms.Label();
            this.lblStatusUptime = new System.Windows.Forms.Label();
            this.lblStatusMax = new System.Windows.Forms.Label();
            this.lblStatusOnline = new System.Windows.Forms.Label();
            this.lblStatusEnum = new System.Windows.Forms.Label();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.lblSpacer4 = new System.Windows.Forms.Label();
            this.lblForums = new System.Windows.Forms.Label();
            this.lblSpacer3 = new System.Windows.Forms.Label();
            this.lblSpacer2 = new System.Windows.Forms.Label();
            this.lblAbout = new System.Windows.Forms.Label();
            this.lblSpacer1 = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblSettings = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.grpClose.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMain
            // 
            this.btnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.btnMain.Enabled = false;
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMain.Font = new System.Drawing.Font("Castellar", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.Location = new System.Drawing.Point(559, 488);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(150, 50);
            this.btnMain.TabIndex = 1;
            this.btnMain.Text = "WAIT";
            this.btnMain.UseVisualStyleBackColor = false;
            this.btnMain.UseWaitCursor = true;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // picMain
            // 
            this.picMain.Image = ((System.Drawing.Image)(resources.GetObject("picMain.Image")));
            this.picMain.Location = new System.Drawing.Point(12, 12);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(533, 151);
            this.picMain.TabIndex = 2;
            this.picMain.TabStop = false;
            this.picMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picMain_MouseMove);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pbTotal);
            this.pnlMain.Controls.Add(this.lblNews);
            this.pnlMain.Controls.Add(this.ftbNews);
            this.pnlMain.Location = new System.Drawing.Point(13, 170);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(532, 368);
            this.pnlMain.TabIndex = 3;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            this.pnlMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseMove);
            // 
            // pbTotal
            // 
            this.pbTotal.Location = new System.Drawing.Point(3, 341);
            this.pbTotal.Name = "pbTotal";
            this.pbTotal.Size = new System.Drawing.Size(526, 20);
            this.pbTotal.TabIndex = 3;
            this.pbTotal.Visible = false;
            // 
            // lblNews
            // 
            this.lblNews.AutoSize = true;
            this.lblNews.Font = new System.Drawing.Font("Castellar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNews.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblNews.Location = new System.Drawing.Point(4, 4);
            this.lblNews.Name = "lblNews";
            this.lblNews.Size = new System.Drawing.Size(62, 19);
            this.lblNews.TabIndex = 0;
            this.lblNews.Text = "NEWS:";
            // 
            // ftbNews
            // 
            this.ftbNews.BackColor = System.Drawing.Color.Black;
            this.ftbNews.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ftbNews.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ftbNews.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ftbNews.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.ftbNews.Location = new System.Drawing.Point(8, 26);
            this.ftbNews.Name = "ftbNews";
            this.ftbNews.ReadOnly = true;
            this.ftbNews.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.ftbNews.Size = new System.Drawing.Size(521, 309);
            this.ftbNews.TabIndex = 1;
            this.ftbNews.Text = "";
            this.ftbNews.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ftbNews_MouseMove);
            this.ftbNews.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ftbNews_MouseWheel);
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.btnForcePatch);
            this.pnlSettings.Controls.Add(this.lblPatchLevel);
            this.pnlSettings.Controls.Add(this.lblSettingsTitle);
            this.pnlSettings.Controls.Add(this.btnSWG);
            this.pnlSettings.Controls.Add(this.btnOK);
            this.pnlSettings.Controls.Add(this.grpClose);
            this.pnlSettings.Controls.Add(this.txtFolder);
            this.pnlSettings.Controls.Add(this.btnFolder);
            this.pnlSettings.Controls.Add(this.lblFolder);
            this.pnlSettings.Location = new System.Drawing.Point(13, 170);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(532, 368);
            this.pnlSettings.TabIndex = 4;
            this.pnlSettings.Visible = false;
            this.pnlSettings.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSettings_Paint);
            this.pnlSettings.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlSettings_MouseMove);
            // 
            // btnForcePatch
            // 
            this.btnForcePatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.btnForcePatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForcePatch.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForcePatch.Location = new System.Drawing.Point(405, 307);
            this.btnForcePatch.Name = "btnForcePatch";
            this.btnForcePatch.Size = new System.Drawing.Size(125, 30);
            this.btnForcePatch.TabIndex = 11;
            this.btnForcePatch.Text = "Verify File Integrity";
            this.btnForcePatch.UseVisualStyleBackColor = false;
            this.btnForcePatch.Click += new System.EventHandler(this.btnForcePatch_Click);
            // 
            // lblPatchLevel
            // 
            this.lblPatchLevel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatchLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblPatchLevel.Location = new System.Drawing.Point(399, 341);
            this.lblPatchLevel.Name = "lblPatchLevel";
            this.lblPatchLevel.Size = new System.Drawing.Size(130, 23);
            this.lblPatchLevel.TabIndex = 10;
            this.lblPatchLevel.Text = "Patch: ";
            this.lblPatchLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSettingsTitle
            // 
            this.lblSettingsTitle.AutoSize = true;
            this.lblSettingsTitle.Font = new System.Drawing.Font("Castellar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblSettingsTitle.Location = new System.Drawing.Point(3, 4);
            this.lblSettingsTitle.Name = "lblSettingsTitle";
            this.lblSettingsTitle.Size = new System.Drawing.Size(95, 19);
            this.lblSettingsTitle.TabIndex = 9;
            this.lblSettingsTitle.Text = "SETTINGS:";
            // 
            // btnSWG
            // 
            this.btnSWG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.btnSWG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSWG.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSWG.Location = new System.Drawing.Point(8, 114);
            this.btnSWG.Name = "btnSWG";
            this.btnSWG.Size = new System.Drawing.Size(125, 30);
            this.btnSWG.TabIndex = 8;
            this.btnSWG.Text = "Client Settings";
            this.btnSWG.UseVisualStyleBackColor = false;
            this.btnSWG.Click += new System.EventHandler(this.btnSWG_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(3, 342);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "Save";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // grpClose
            // 
            this.grpClose.Controls.Add(this.chkMin);
            this.grpClose.Controls.Add(this.chkClose);
            this.grpClose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.grpClose.Location = new System.Drawing.Point(8, 58);
            this.grpClose.Name = "grpClose";
            this.grpClose.Size = new System.Drawing.Size(297, 50);
            this.grpClose.TabIndex = 6;
            this.grpClose.TabStop = false;
            this.grpClose.Text = "On Client Launch";
            // 
            // chkMin
            // 
            this.chkMin.AutoSize = true;
            this.chkMin.Location = new System.Drawing.Point(137, 20);
            this.chkMin.Name = "chkMin";
            this.chkMin.Size = new System.Drawing.Size(136, 23);
            this.chkMin.TabIndex = 1;
            this.chkMin.Text = "Minimize Updater";
            this.chkMin.UseVisualStyleBackColor = true;
            this.chkMin.CheckStateChanged += new System.EventHandler(this.chkMin_CheckedChanged);
            // 
            // chkClose
            // 
            this.chkClose.AutoSize = true;
            this.chkClose.Location = new System.Drawing.Point(7, 20);
            this.chkClose.Name = "chkClose";
            this.chkClose.Size = new System.Drawing.Size(117, 23);
            this.chkClose.TabIndex = 0;
            this.chkClose.Text = "Close Updater";
            this.chkClose.UseVisualStyleBackColor = true;
            this.chkClose.CheckedChanged += new System.EventHandler(this.chkClose_CheckedChanged);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(114, 32);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(191, 20);
            this.txtFolder.TabIndex = 5;
            // 
            // btnFolder
            // 
            this.btnFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.btnFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolder.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolder.Location = new System.Drawing.Point(311, 31);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(75, 23);
            this.btnFolder.TabIndex = 4;
            this.btnFolder.Text = "Browse...";
            this.btnFolder.UseVisualStyleBackColor = false;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblFolder.Location = new System.Drawing.Point(4, 31);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(104, 19);
            this.lblFolder.TabIndex = 3;
            this.lblFolder.Text = "TarkinII Folder:";
            // 
            // pnlNav
            // 
            this.pnlNav.Controls.Add(this.lblStatusLast);
            this.pnlNav.Controls.Add(this.lblStatusUptime);
            this.pnlNav.Controls.Add(this.lblStatusMax);
            this.pnlNav.Controls.Add(this.lblStatusOnline);
            this.pnlNav.Controls.Add(this.lblStatusEnum);
            this.pnlNav.Controls.Add(this.lblStatusTitle);
            this.pnlNav.Controls.Add(this.lblSpacer4);
            this.pnlNav.Controls.Add(this.lblForums);
            this.pnlNav.Controls.Add(this.lblSpacer3);
            this.pnlNav.Controls.Add(this.lblSpacer2);
            this.pnlNav.Controls.Add(this.lblAbout);
            this.pnlNav.Controls.Add(this.lblSpacer1);
            this.pnlNav.Controls.Add(this.lblExit);
            this.pnlNav.Controls.Add(this.lblSettings);
            this.pnlNav.Location = new System.Drawing.Point(559, 12);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(150, 470);
            this.pnlNav.TabIndex = 9;
            this.pnlNav.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlNav_Paint);
            this.pnlNav.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlNav_MouseMove);
            // 
            // lblStatusLast
            // 
            this.lblStatusLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblStatusLast.Location = new System.Drawing.Point(2, 445);
            this.lblStatusLast.Name = "lblStatusLast";
            this.lblStatusLast.Size = new System.Drawing.Size(144, 23);
            this.lblStatusLast.TabIndex = 22;
            this.lblStatusLast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusUptime
            // 
            this.lblStatusUptime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusUptime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblStatusUptime.Location = new System.Drawing.Point(3, 422);
            this.lblStatusUptime.Name = "lblStatusUptime";
            this.lblStatusUptime.Size = new System.Drawing.Size(144, 23);
            this.lblStatusUptime.TabIndex = 21;
            this.lblStatusUptime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusMax
            // 
            this.lblStatusMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblStatusMax.Location = new System.Drawing.Point(2, 399);
            this.lblStatusMax.Name = "lblStatusMax";
            this.lblStatusMax.Size = new System.Drawing.Size(144, 23);
            this.lblStatusMax.TabIndex = 20;
            this.lblStatusMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusOnline
            // 
            this.lblStatusOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusOnline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblStatusOnline.Location = new System.Drawing.Point(2, 376);
            this.lblStatusOnline.Name = "lblStatusOnline";
            this.lblStatusOnline.Size = new System.Drawing.Size(144, 23);
            this.lblStatusOnline.TabIndex = 19;
            this.lblStatusOnline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusEnum
            // 
            this.lblStatusEnum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusEnum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblStatusEnum.Location = new System.Drawing.Point(3, 353);
            this.lblStatusEnum.Name = "lblStatusEnum";
            this.lblStatusEnum.Size = new System.Drawing.Size(144, 23);
            this.lblStatusEnum.TabIndex = 18;
            this.lblStatusEnum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusTitle
            // 
            this.lblStatusTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblStatusTitle.Location = new System.Drawing.Point(2, 330);
            this.lblStatusTitle.Name = "lblStatusTitle";
            this.lblStatusTitle.Size = new System.Drawing.Size(144, 23);
            this.lblStatusTitle.TabIndex = 17;
            this.lblStatusTitle.Text = "Server Status";
            this.lblStatusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSpacer4
            // 
            this.lblSpacer4.Font = new System.Drawing.Font("Castellar", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpacer4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblSpacer4.Location = new System.Drawing.Point(3, 151);
            this.lblSpacer4.Name = "lblSpacer4";
            this.lblSpacer4.Size = new System.Drawing.Size(144, 23);
            this.lblSpacer4.TabIndex = 16;
            // 
            // lblForums
            // 
            this.lblForums.Font = new System.Drawing.Font("Castellar", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForums.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblForums.Location = new System.Drawing.Point(3, 59);
            this.lblForums.Name = "lblForums";
            this.lblForums.Size = new System.Drawing.Size(144, 23);
            this.lblForums.TabIndex = 15;
            this.lblForums.Text = "Forums";
            this.lblForums.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblForums.Click += new System.EventHandler(this.lblForums_Click);
            this.lblForums.MouseLeave += new System.EventHandler(this.lblForums_MouseLeave);
            this.lblForums.MouseHover += new System.EventHandler(this.lblForums_MouseHover);
            // 
            // lblSpacer3
            // 
            this.lblSpacer3.Font = new System.Drawing.Font("Castellar", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpacer3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblSpacer3.Location = new System.Drawing.Point(3, 128);
            this.lblSpacer3.Name = "lblSpacer3";
            this.lblSpacer3.Size = new System.Drawing.Size(144, 23);
            this.lblSpacer3.TabIndex = 14;
            // 
            // lblSpacer2
            // 
            this.lblSpacer2.Font = new System.Drawing.Font("Castellar", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpacer2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblSpacer2.Location = new System.Drawing.Point(3, 82);
            this.lblSpacer2.Name = "lblSpacer2";
            this.lblSpacer2.Size = new System.Drawing.Size(144, 23);
            this.lblSpacer2.TabIndex = 13;
            // 
            // lblAbout
            // 
            this.lblAbout.Font = new System.Drawing.Font("Castellar", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblAbout.Location = new System.Drawing.Point(3, 105);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(144, 23);
            this.lblAbout.TabIndex = 12;
            this.lblAbout.Text = "About";
            this.lblAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAbout.MouseLeave += new System.EventHandler(this.lblAbout_MouseLeave);
            this.lblAbout.MouseHover += new System.EventHandler(this.lblAbout_MouseHover);
            // 
            // lblSpacer1
            // 
            this.lblSpacer1.Font = new System.Drawing.Font("Castellar", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpacer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblSpacer1.Location = new System.Drawing.Point(3, 36);
            this.lblSpacer1.Name = "lblSpacer1";
            this.lblSpacer1.Size = new System.Drawing.Size(144, 23);
            this.lblSpacer1.TabIndex = 11;
            // 
            // lblExit
            // 
            this.lblExit.Font = new System.Drawing.Font("Castellar", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblExit.Location = new System.Drawing.Point(3, 189);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(144, 23);
            this.lblExit.TabIndex = 10;
            this.lblExit.Text = "Exit";
            this.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            this.lblExit.MouseLeave += new System.EventHandler(this.lblExit_MouseLeave);
            this.lblExit.MouseHover += new System.EventHandler(this.lblExit_MouseHover);
            // 
            // lblSettings
            // 
            this.lblSettings.Font = new System.Drawing.Font("Castellar", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblSettings.Location = new System.Drawing.Point(3, 13);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(144, 23);
            this.lblSettings.TabIndex = 9;
            this.lblSettings.Text = "Settings";
            this.lblSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSettings.Click += new System.EventHandler(this.lblSettings_Click);
            this.lblSettings.MouseLeave += new System.EventHandler(this.lblSettings_MouseLeave);
            this.lblSettings.MouseHover += new System.EventHandler(this.lblSettings_MouseHover);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(721, 550);
            this.ControlBox = false;
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.picMain);
            this.Controls.Add(this.btnMain);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "TarkinII Updater";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.grpClose.ResumeLayout(false);
            this.grpClose.PerformLayout();
            this.pnlNav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblNews;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.GroupBox grpClose;
        private System.Windows.Forms.CheckBox chkMin;
        private System.Windows.Forms.CheckBox chkClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Label lblSpacer3;
        private System.Windows.Forms.Label lblSpacer2;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Label lblSpacer1;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.Label lblSpacer4;
        private System.Windows.Forms.Label lblForums;
        private System.Windows.Forms.Button btnSWG;
        private System.Windows.Forms.Label lblSettingsTitle;
        private System.Windows.Forms.RichTextBox ftbNews;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Label lblStatusLast;
        private System.Windows.Forms.Label lblStatusUptime;
        private System.Windows.Forms.Label lblStatusMax;
        private System.Windows.Forms.Label lblStatusOnline;
        private System.Windows.Forms.Label lblStatusEnum;
        private System.Windows.Forms.Label lblPatchLevel;
        private System.Windows.Forms.Button btnForcePatch;
        private System.Windows.Forms.ProgressBar pbTotal;
    }
}


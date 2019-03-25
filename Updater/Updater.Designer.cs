//Copyright 2017 Steven Helm

//This file is part of Updater.

//Updater is free software: you can redistribute it and/or modify
//it under the terms of the GNU Affero General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//Updater is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//GNU Affero General Public License for more details.

//You should have received a copy of the GNU Affero General Public License
//along with Updater.If not, see<http://www.gnu.org/licenses/>.

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnMain = new System.Windows.Forms.Button();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.fileStatus = new System.Windows.Forms.Label();
            this.pbTotal = new System.Windows.Forms.ProgressBar();
            this.ftbNews = new System.Windows.Forms.RichTextBox();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.btnIgnoreReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ignoreInput = new System.Windows.Forms.TextBox();
            this.btnIgnoreSave = new System.Windows.Forms.Button();
            this.btnFtpGetURL = new System.Windows.Forms.Button();
            this.btnFtpReset = new System.Windows.Forms.Button();
            this.ftpInput = new System.Windows.Forms.TextBox();
            this.btnFtpInput = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLauncherSettings = new System.Windows.Forms.Button();
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.grpClose.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMain
            // 
            this.btnMain.BackColor = System.Drawing.Color.Transparent;
            this.btnMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMain.BackgroundImage")));
            this.btnMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMain.Enabled = false;
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMain.Font = new System.Drawing.Font("PT Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.btnMain.Location = new System.Drawing.Point(559, 485);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(150, 56);
            this.btnMain.TabIndex = 1;
            this.btnMain.Text = "Welcome";
            this.btnMain.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnMain.UseVisualStyleBackColor = false;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // picMain
            // 
            this.picMain.Image = ((System.Drawing.Image)(resources.GetObject("picMain.Image")));
            this.picMain.Location = new System.Drawing.Point(12, 12);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(533, 212);
            this.picMain.TabIndex = 2;
            this.picMain.TabStop = false;
            this.picMain.Click += new System.EventHandler(this.picMain_Click);
            this.picMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picMain_MouseMove);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.fileStatus);
            this.pnlMain.Controls.Add(this.pbTotal);
            this.pnlMain.Controls.Add(this.ftbNews);
            this.pnlMain.Location = new System.Drawing.Point(12, 230);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(533, 305);
            this.pnlMain.TabIndex = 3;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            this.pnlMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseMove);
            // 
            // fileStatus
            // 
            this.fileStatus.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(193)))), ((int)(((byte)(63)))));
            this.fileStatus.Location = new System.Drawing.Point(9, 268);
            this.fileStatus.Name = "fileStatus";
            this.fileStatus.Size = new System.Drawing.Size(518, 30);
            this.fileStatus.TabIndex = 4;
            this.fileStatus.Text = "Idle . . .";
            this.fileStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.fileStatus, "Launcher status. Working indicates that the file is being checked or downloaded.");
            this.fileStatus.Click += new System.EventHandler(this.lblFileStatus_Click);
            // 
            // pbTotal
            // 
            this.pbTotal.BackColor = System.Drawing.Color.Black;
            this.pbTotal.Location = new System.Drawing.Point(313, 268);
            this.pbTotal.Name = "pbTotal";
            this.pbTotal.Size = new System.Drawing.Size(214, 24);
            this.pbTotal.TabIndex = 3;
            this.pbTotal.Visible = false;
            // 
            // ftbNews
            // 
            this.ftbNews.AccessibleDescription = "Tarkin\'s Reveng News Feed";
            this.ftbNews.AccessibleName = "NewsFeed";
            this.ftbNews.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.ftbNews.BackColor = System.Drawing.Color.Black;
            this.ftbNews.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ftbNews.DetectUrls = false;
            this.ftbNews.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ftbNews.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.ftbNews.Location = new System.Drawing.Point(8, 6);
            this.ftbNews.Name = "ftbNews";
            this.ftbNews.ReadOnly = true;
            this.ftbNews.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ftbNews.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.ftbNews.Size = new System.Drawing.Size(519, 256);
            this.ftbNews.TabIndex = 1;
            this.ftbNews.Text = "";
            this.ftbNews.TextChanged += new System.EventHandler(this.ftbNews_TextChanged);
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.btnIgnoreReset);
            this.pnlSettings.Controls.Add(this.label2);
            this.pnlSettings.Controls.Add(this.ignoreInput);
            this.pnlSettings.Controls.Add(this.btnIgnoreSave);
            this.pnlSettings.Controls.Add(this.btnFtpGetURL);
            this.pnlSettings.Controls.Add(this.btnFtpReset);
            this.pnlSettings.Controls.Add(this.ftpInput);
            this.pnlSettings.Controls.Add(this.btnFtpInput);
            this.pnlSettings.Controls.Add(this.label1);
            this.pnlSettings.Controls.Add(this.btnLauncherSettings);
            this.pnlSettings.Controls.Add(this.btnForcePatch);
            this.pnlSettings.Controls.Add(this.lblPatchLevel);
            this.pnlSettings.Controls.Add(this.lblSettingsTitle);
            this.pnlSettings.Controls.Add(this.btnSWG);
            this.pnlSettings.Controls.Add(this.btnOK);
            this.pnlSettings.Controls.Add(this.grpClose);
            this.pnlSettings.Controls.Add(this.txtFolder);
            this.pnlSettings.Controls.Add(this.btnFolder);
            this.pnlSettings.Controls.Add(this.lblFolder);
            this.pnlSettings.Location = new System.Drawing.Point(13, 230);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(532, 308);
            this.pnlSettings.TabIndex = 4;
            this.pnlSettings.Visible = false;
            this.pnlSettings.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSettings_Paint);
            this.pnlSettings.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlSettings_MouseMove);
            // 
            // btnIgnoreReset
            // 
            this.btnIgnoreReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.btnIgnoreReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIgnoreReset.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgnoreReset.Location = new System.Drawing.Point(311, 222);
            this.btnIgnoreReset.Name = "btnIgnoreReset";
            this.btnIgnoreReset.Size = new System.Drawing.Size(110, 27);
            this.btnIgnoreReset.TabIndex = 21;
            this.btnIgnoreReset.Tag = "CV";
            this.btnIgnoreReset.Text = "Reset Default";
            this.toolTip1.SetToolTip(this.btnIgnoreReset, "Reset the file ignore list to default.");
            this.btnIgnoreReset.UseVisualStyleBackColor = false;
            this.btnIgnoreReset.Click += new System.EventHandler(this.btnIgnoreReset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.label2.Location = new System.Drawing.Point(8, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "File Ignore List:";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ignoreInput
            // 
            this.ignoreInput.Location = new System.Drawing.Point(9, 226);
            this.ignoreInput.Name = "ignoreInput";
            this.ignoreInput.Size = new System.Drawing.Size(229, 20);
            this.ignoreInput.TabIndex = 19;
            this.toolTip1.SetToolTip(this.ignoreInput, resources.GetString("ignoreInput.ToolTip"));
            this.ignoreInput.TextChanged += new System.EventHandler(this.ignoreInput_TextChanged);
            // 
            // btnIgnoreSave
            // 
            this.btnIgnoreSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.btnIgnoreSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIgnoreSave.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgnoreSave.Location = new System.Drawing.Point(244, 223);
            this.btnIgnoreSave.Name = "btnIgnoreSave";
            this.btnIgnoreSave.Size = new System.Drawing.Size(61, 26);
            this.btnIgnoreSave.TabIndex = 18;
            this.btnIgnoreSave.Text = "Save";
            this.btnIgnoreSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.btnIgnoreSave, "Save the changes you\'ve made to the file ignore list.");
            this.btnIgnoreSave.UseVisualStyleBackColor = false;
            this.btnIgnoreSave.Click += new System.EventHandler(this.btnIgnoreSave_Click);
            // 
            // btnFtpGetURL
            // 
            this.btnFtpGetURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.btnFtpGetURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFtpGetURL.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFtpGetURL.Location = new System.Drawing.Point(427, 178);
            this.btnFtpGetURL.Name = "btnFtpGetURL";
            this.btnFtpGetURL.Size = new System.Drawing.Size(73, 27);
            this.btnFtpGetURL.TabIndex = 17;
            this.btnFtpGetURL.Text = "Update";
            this.toolTip1.SetToolTip(this.btnFtpGetURL, "Grab the latest patch server address from the Tarkin\'s Revenge website.");
            this.btnFtpGetURL.UseVisualStyleBackColor = false;
            this.btnFtpGetURL.Click += new System.EventHandler(this.btnFtpGetURL_Click);
            // 
            // btnFtpReset
            // 
            this.btnFtpReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.btnFtpReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFtpReset.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFtpReset.Location = new System.Drawing.Point(312, 178);
            this.btnFtpReset.Name = "btnFtpReset";
            this.btnFtpReset.Size = new System.Drawing.Size(110, 27);
            this.btnFtpReset.TabIndex = 16;
            this.btnFtpReset.Tag = "CV";
            this.btnFtpReset.Text = "Reset Default";
            this.toolTip1.SetToolTip(this.btnFtpReset, "Reset the server address to the one that\'s build into the Launcher program.");
            this.btnFtpReset.UseVisualStyleBackColor = false;
            this.btnFtpReset.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // ftpInput
            // 
            this.ftpInput.Location = new System.Drawing.Point(9, 181);
            this.ftpInput.Name = "ftpInput";
            this.ftpInput.Size = new System.Drawing.Size(229, 20);
            this.ftpInput.TabIndex = 15;
            this.toolTip1.SetToolTip(this.ftpInput, "This is the location on the internet where the Launcher will download updates fro" +
        "m.\nIf required, you may may type a different address in here and save it using t" +
        "he Save button.");
            this.ftpInput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnFtpInput
            // 
            this.btnFtpInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.btnFtpInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFtpInput.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFtpInput.Location = new System.Drawing.Point(244, 178);
            this.btnFtpInput.Name = "btnFtpInput";
            this.btnFtpInput.Size = new System.Drawing.Size(61, 26);
            this.btnFtpInput.TabIndex = 14;
            this.btnFtpInput.Text = "Save";
            this.btnFtpInput.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.btnFtpInput, "Save the address to your Launcher settings file.");
            this.btnFtpInput.UseVisualStyleBackColor = false;
            this.btnFtpInput.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.label1.Location = new System.Drawing.Point(5, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Patch Server:";
            this.toolTip1.SetToolTip(this.label1, "This is the location on the internet where the Launcher will download updates fro" +
        "m.\nIf required, you may may type a different address in here and save it using t" +
        "he Save button.");
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnLauncherSettings
            // 
            this.btnLauncherSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.btnLauncherSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLauncherSettings.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLauncherSettings.Location = new System.Drawing.Point(171, 114);
            this.btnLauncherSettings.Name = "btnLauncherSettings";
            this.btnLauncherSettings.Size = new System.Drawing.Size(134, 30);
            this.btnLauncherSettings.TabIndex = 12;
            this.btnLauncherSettings.Text = "Launcher Settings";
            this.toolTip1.SetToolTip(this.btnLauncherSettings, "Open the settings file for the Tarkin\'s Revenge Launcher.");
            this.btnLauncherSettings.UseVisualStyleBackColor = false;
            this.btnLauncherSettings.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnForcePatch
            // 
            this.btnForcePatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.btnForcePatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForcePatch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForcePatch.Location = new System.Drawing.Point(417, 272);
            this.btnForcePatch.Name = "btnForcePatch";
            this.btnForcePatch.Size = new System.Drawing.Size(109, 28);
            this.btnForcePatch.TabIndex = 11;
            this.btnForcePatch.Tag = "";
            this.btnForcePatch.Text = "Force Update";
            this.toolTip1.SetToolTip(this.btnForcePatch, "Pressing this button will cause the launcher to check your game folder\nand downlo" +
        "ad any new, broken, or missing files.");
            this.btnForcePatch.UseVisualStyleBackColor = false;
            this.btnForcePatch.Click += new System.EventHandler(this.btnForcePatch_Click);
            // 
            // lblPatchLevel
            // 
            this.lblPatchLevel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatchLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPatchLevel.Location = new System.Drawing.Point(220, 226);
            this.lblPatchLevel.Name = "lblPatchLevel";
            this.lblPatchLevel.Size = new System.Drawing.Size(130, 23);
            this.lblPatchLevel.TabIndex = 10;
            this.lblPatchLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSettingsTitle
            // 
            this.lblSettingsTitle.AutoSize = true;
            this.lblSettingsTitle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblSettingsTitle.Location = new System.Drawing.Point(3, 4);
            this.lblSettingsTitle.Name = "lblSettingsTitle";
            this.lblSettingsTitle.Size = new System.Drawing.Size(105, 18);
            this.lblSettingsTitle.TabIndex = 9;
            this.lblSettingsTitle.Text = "SETTINGS:";
            // 
            // btnSWG
            // 
            this.btnSWG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.btnSWG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSWG.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSWG.Location = new System.Drawing.Point(8, 114);
            this.btnSWG.Name = "btnSWG";
            this.btnSWG.Size = new System.Drawing.Size(125, 30);
            this.btnSWG.TabIndex = 8;
            this.btnSWG.Text = "Game Settings";
            this.toolTip1.SetToolTip(this.btnSWG, "Open the game settings program.");
            this.btnSWG.UseVisualStyleBackColor = false;
            this.btnSWG.Click += new System.EventHandler(this.btnSWG_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(11, 268);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "Close";
            this.toolTip1.SetToolTip(this.btnOK, "Close the settings window.");
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // grpClose
            // 
            this.grpClose.Controls.Add(this.chkMin);
            this.grpClose.Controls.Add(this.chkClose);
            this.grpClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.chkMin.Size = new System.Drawing.Size(134, 18);
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
            this.chkClose.Size = new System.Drawing.Size(116, 18);
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
            this.toolTip1.SetToolTip(this.txtFolder, "Location on the computer where the game is installed.");
            // 
            // btnFolder
            // 
            this.btnFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.btnFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolder.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolder.Location = new System.Drawing.Point(311, 31);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(75, 23);
            this.btnFolder.TabIndex = 4;
            this.btnFolder.Text = "Browse...";
            this.toolTip1.SetToolTip(this.btnFolder, "Press this button to choose set the where the game is installed.");
            this.btnFolder.UseVisualStyleBackColor = false;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblFolder.Location = new System.Drawing.Point(2, 32);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(111, 18);
            this.lblFolder.TabIndex = 3;
            this.lblFolder.Text = "Game Folder:";
            this.lblFolder.Click += new System.EventHandler(this.lblFolder_Click);
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
            this.pnlNav.Size = new System.Drawing.Size(150, 467);
            this.pnlNav.TabIndex = 9;
            this.pnlNav.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlNav_Paint);
            this.pnlNav.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlNav_MouseMove);
            // 
            // lblStatusLast
            // 
            this.lblStatusLast.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblStatusLast.Location = new System.Drawing.Point(2, 435);
            this.lblStatusLast.Name = "lblStatusLast";
            this.lblStatusLast.Size = new System.Drawing.Size(144, 23);
            this.lblStatusLast.TabIndex = 22;
            this.lblStatusLast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusUptime
            // 
            this.lblStatusUptime.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusUptime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblStatusUptime.Location = new System.Drawing.Point(3, 412);
            this.lblStatusUptime.Name = "lblStatusUptime";
            this.lblStatusUptime.Size = new System.Drawing.Size(144, 23);
            this.lblStatusUptime.TabIndex = 21;
            this.lblStatusUptime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusMax
            // 
            this.lblStatusMax.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblStatusMax.Location = new System.Drawing.Point(2, 382);
            this.lblStatusMax.Name = "lblStatusMax";
            this.lblStatusMax.Size = new System.Drawing.Size(144, 23);
            this.lblStatusMax.TabIndex = 20;
            this.lblStatusMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusOnline
            // 
            this.lblStatusOnline.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusOnline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblStatusOnline.Location = new System.Drawing.Point(2, 349);
            this.lblStatusOnline.Name = "lblStatusOnline";
            this.lblStatusOnline.Size = new System.Drawing.Size(144, 23);
            this.lblStatusOnline.TabIndex = 19;
            this.lblStatusOnline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusEnum
            // 
            this.lblStatusEnum.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusEnum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblStatusEnum.Location = new System.Drawing.Point(3, 326);
            this.lblStatusEnum.Name = "lblStatusEnum";
            this.lblStatusEnum.Size = new System.Drawing.Size(144, 23);
            this.lblStatusEnum.TabIndex = 18;
            this.lblStatusEnum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusTitle
            // 
            this.lblStatusTitle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblStatusTitle.Location = new System.Drawing.Point(2, 303);
            this.lblStatusTitle.Name = "lblStatusTitle";
            this.lblStatusTitle.Size = new System.Drawing.Size(144, 23);
            this.lblStatusTitle.TabIndex = 17;
            this.lblStatusTitle.Text = "Server Status";
            this.lblStatusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSpacer4
            // 
            this.lblSpacer4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpacer4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblSpacer4.Location = new System.Drawing.Point(3, 151);
            this.lblSpacer4.Name = "lblSpacer4";
            this.lblSpacer4.Size = new System.Drawing.Size(144, 23);
            this.lblSpacer4.TabIndex = 16;
            // 
            // lblForums
            // 
            this.lblForums.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblSpacer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpacer3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblSpacer3.Location = new System.Drawing.Point(3, 128);
            this.lblSpacer3.Name = "lblSpacer3";
            this.lblSpacer3.Size = new System.Drawing.Size(144, 23);
            this.lblSpacer3.TabIndex = 14;
            // 
            // lblSpacer2
            // 
            this.lblSpacer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpacer2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblSpacer2.Location = new System.Drawing.Point(3, 82);
            this.lblSpacer2.Name = "lblSpacer2";
            this.lblSpacer2.Size = new System.Drawing.Size(144, 23);
            this.lblSpacer2.TabIndex = 13;
            // 
            // lblAbout
            // 
            this.lblAbout.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblAbout.Location = new System.Drawing.Point(3, 105);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(144, 23);
            this.lblAbout.TabIndex = 12;
            this.lblAbout.Text = "About";
            this.lblAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAbout.Click += new System.EventHandler(this.lblAbout_Click);
            this.lblAbout.MouseLeave += new System.EventHandler(this.lblAbout_MouseLeave);
            this.lblAbout.MouseHover += new System.EventHandler(this.lblAbout_MouseHover);
            // 
            // lblSpacer1
            // 
            this.lblSpacer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpacer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblSpacer1.Location = new System.Drawing.Point(3, 36);
            this.lblSpacer1.Name = "lblSpacer1";
            this.lblSpacer1.Size = new System.Drawing.Size(144, 23);
            this.lblSpacer1.TabIndex = 11;
            // 
            // lblExit
            // 
            this.lblExit.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblSettings.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.Text = "Tarkin\'s Revenge Launcher";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
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
        private System.Windows.Forms.Label fileStatus;
        private System.Windows.Forms.Button btnLauncherSettings;
        private System.Windows.Forms.TextBox ftpInput;
        private System.Windows.Forms.Button btnFtpInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFtpReset;
        private System.Windows.Forms.Button btnFtpGetURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ignoreInput;
        private System.Windows.Forms.Button btnIgnoreSave;
        private System.Windows.Forms.Button btnIgnoreReset;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}


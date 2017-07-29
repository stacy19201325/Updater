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
            this.lblSettings = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMain
            // 
            this.btnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMain.Font = new System.Drawing.Font("Castellar", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.Location = new System.Drawing.Point(551, 169);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(150, 50);
            this.btnMain.TabIndex = 1;
            this.btnMain.Text = "PLAY";
            this.btnMain.UseVisualStyleBackColor = false;
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
            // lblSettings
            // 
            this.lblSettings.AutoSize = true;
            this.lblSettings.Font = new System.Drawing.Font("Castellar", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblSettings.Location = new System.Drawing.Point(586, 12);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(70, 13);
            this.lblSettings.TabIndex = 0;
            this.lblSettings.Text = "Settings";
            this.lblSettings.Click += new System.EventHandler(this.lblSettings_Click);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Font = new System.Drawing.Font("Castellar", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(192)))), ((int)(((byte)(63)))));
            this.lblExit.Location = new System.Drawing.Point(662, 12);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(39, 13);
            this.lblExit.TabIndex = 1;
            this.lblExit.Text = "Exit";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(721, 233);
            this.ControlBox = false;
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblSettings);
            this.Controls.Add(this.picMain);
            this.Controls.Add(this.btnMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "TarkinII Updater";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.Label lblExit;
    }
}


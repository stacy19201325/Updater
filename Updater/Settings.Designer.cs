namespace Updater
{
    partial class Settings
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
            this.lblFolder = new System.Windows.Forms.Label();
            this.btnFolder = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.grpClose = new System.Windows.Forms.GroupBox();
            this.chkClose = new System.Windows.Forms.CheckBox();
            this.chkMin = new System.Windows.Forms.CheckBox();
            this.grpClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(12, 9);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(78, 13);
            this.lblFolder.TabIndex = 0;
            this.lblFolder.Text = "TarkinII Folder:";
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(234, 4);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(75, 23);
            this.btnFolder.TabIndex = 1;
            this.btnFolder.Text = "Browse...";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(96, 6);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(132, 20);
            this.txtFolder.TabIndex = 2;
            // 
            // grpClose
            // 
            this.grpClose.Controls.Add(this.chkMin);
            this.grpClose.Controls.Add(this.chkClose);
            this.grpClose.Location = new System.Drawing.Point(12, 32);
            this.grpClose.Name = "grpClose";
            this.grpClose.Size = new System.Drawing.Size(297, 50);
            this.grpClose.TabIndex = 3;
            this.grpClose.TabStop = false;
            this.grpClose.Text = "On Client Launch";
            // 
            // chkClose
            // 
            this.chkClose.AutoSize = true;
            this.chkClose.Location = new System.Drawing.Point(7, 20);
            this.chkClose.Name = "chkClose";
            this.chkClose.Size = new System.Drawing.Size(93, 17);
            this.chkClose.TabIndex = 0;
            this.chkClose.Text = "Close Updater";
            this.chkClose.UseVisualStyleBackColor = true;
            this.chkClose.CheckedChanged += new System.EventHandler(this.chkClose_CheckedChanged);
            // 
            // chkMin
            // 
            this.chkMin.AutoSize = true;
            this.chkMin.Location = new System.Drawing.Point(107, 20);
            this.chkMin.Name = "chkMin";
            this.chkMin.Size = new System.Drawing.Size(107, 17);
            this.chkMin.TabIndex = 1;
            this.chkMin.Text = "Minimize Updater";
            this.chkMin.UseVisualStyleBackColor = true;
            this.chkMin.CheckedChanged += new System.EventHandler(this.chkMin_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 157);
            this.Controls.Add(this.grpClose);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.lblFolder);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Activated += new System.EventHandler(this.Settings_Activated);
            this.grpClose.ResumeLayout(false);
            this.grpClose.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.GroupBox grpClose;
        private System.Windows.Forms.CheckBox chkClose;
        private System.Windows.Forms.CheckBox chkMin;
    }
}
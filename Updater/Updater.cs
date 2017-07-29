using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Updater
{
    public partial class frmMain : Form
    {

        //Variable for bypassing program close messagebox
        bool Bypass = false;

        //Allow us to move the form
        private const int WMNCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int WMNCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WMNCHITTEST:
                    base.WndProc(ref m);
                    if ((int)m.Result == HTCLIENT)
                        m.Result = (IntPtr)HTCAPTION;
                    return;
            }
            base.WndProc(ref m);
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Bypass == false)
            {
                if (DialogResult.No == MessageBox.Show("Do you want to exit the updater?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    e.Cancel = true;
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            //Open the Tarkin client.
            Process procTarkin = new Process();

            procTarkin.StartInfo.FileName = Properties.Settings.Default.setFolder + "\\SWGEmu.exe";
            procTarkin.StartInfo.WorkingDirectory = Properties.Settings.Default.setFolder;

            procTarkin.Start();

            //Minimize Updater
            if (Properties.Settings.Default.setMinimized == true)
            {
                this.WindowState = FormWindowState.Minimized;
            }

            //Close Updater
            if (Properties.Settings.Default.setClosed == true)
            {
                Bypass = true;
                Application.Exit();
            }

        }

        private void picMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WMNCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblSettings_Click(object sender, EventArgs e)
        {
            Settings Settings = new Settings();

            Settings.Show();
        }
    }
}

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
using System.Xml;
using System.Net;
using System.Text.RegularExpressions;

namespace Updater
{
    public partial class frmMain : Form
    {

        #region Form Movers

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

        //Allow us to move the form by clicking a control on the form
        private void picMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WMNCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void pnlNav_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WMNCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void pnlSettings_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WMNCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void pnlMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WMNCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void ftbNews_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WMNCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Let's set the folder location from Resources
            txtFolder.Text = Properties.Settings.Default.setFolder;

            //Let's also set the checkbox options for Client launch
            chkClose.Checked = Properties.Settings.Default.setClosed;
            chkMin.Checked = Properties.Settings.Default.setMinimized;

            //Pull in News
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            XmlDocument RSSNews = new XmlDocument();
            RSSNews.Load("https://tarkin.org/index.php?/forum/4-announcements.xml/");

            XmlNodeList RSSNewsNodes = RSSNews.SelectNodes("rss/channel/item");
            StringBuilder RSSNewsData = new StringBuilder();

            foreach (XmlNode RSSNode in RSSNewsNodes)
            {
                XmlNode RSSSubNode = RSSNode.SelectSingleNode("title");
                string TitleElement = RSSSubNode != null ? RSSSubNode.InnerText : "";

                RSSSubNode = RSSNode.SelectSingleNode("description");
                string NewsElement = RSSSubNode != null ? RSSSubNode.InnerText : "";

                //Clean news up.
                NewsElement = Regex.Replace(NewsElement, "\t", "");
                TitleElement = Regex.Replace(TitleElement, "\t", "");
                NewsElement = Regex.Replace(NewsElement, "\n", "");
                TitleElement = Regex.Replace(TitleElement, "\n", "");
                NewsElement = Regex.Replace(NewsElement, "<.*?>", String.Empty);
                TitleElement = Regex.Replace(TitleElement, "<.*?>", String.Empty);

                RSSNewsData.Append(TitleElement + "\n" + NewsElement + "\n\n");
            }

            //Output News!
            ftbNews.Text = RSSNewsData.ToString();

            //Check Patch Level and force to update if there is a patch

        }

        public frmMain()
        {
            InitializeComponent();
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
                Application.Exit();
            }

        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblSettings_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = false;
            pnlSettings.Visible = true;
        }

        private void lblForums_Click(object sender, EventArgs e)
        {
            Process.Start("https://tarkin.org");
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            //Allow the user to select a new folder
            FolderBrowserDialog fbdFolder = new FolderBrowserDialog();

            if (fbdFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFolder.Text = fbdFolder.SelectedPath;

                //Let's save the Settings
                Properties.Settings.Default.setFolder = fbdFolder.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void chkClose_CheckedChanged(object sender, EventArgs e)
        {
            //See if the user checked a box and unselect the other if they did
            if (chkClose.Checked == true)
            {
                chkMin.Checked = false;

                //Also, let's save the Settings
                Properties.Settings.Default.setClosed = true;
                Properties.Settings.Default.setMinimized = false;
                Properties.Settings.Default.Save();
            }
        }

        private void chkMin_CheckedChanged(object sender, EventArgs e)
        {
            //See if the user checked a box and unselect the other if they did
            if (chkMin.Checked == true)
            {
                chkClose.Checked = false;

                //Also, let's save the Settings
                Properties.Settings.Default.setMinimized = true;
                Properties.Settings.Default.setClosed = false;
                Properties.Settings.Default.Save();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = true;
            pnlSettings.Visible = false;
        }

        private void pnlNav_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.FromArgb(160, 252, 192, 63), ButtonBorderStyle.Solid);
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.FromArgb(160, 252, 192, 63), ButtonBorderStyle.Solid);
        }

        private void pnlSettings_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.FromArgb(160, 252, 192, 63), ButtonBorderStyle.Solid);
        }

        private void btnSWG_Click(object sender, EventArgs e)
        {
            //Open the SWG Settings.
            Process procTarkin = new Process();

            procTarkin.StartInfo.FileName = Properties.Settings.Default.setFolder + "\\SWGEmu_Setup.exe";
            procTarkin.StartInfo.WorkingDirectory = Properties.Settings.Default.setFolder;

            procTarkin.Start();
        }

        private void ftbNews_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == 120)
            {
                SendKeys.Send("{PGUP}");
            }
            else if (e.Delta == -120)
            {
                SendKeys.Send("{PGDN}");
            }

        }

    }

}

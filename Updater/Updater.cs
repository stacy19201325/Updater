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
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography;
using System.Threading;

namespace Updater
{
    public partial class frmMain : Form
    {

        #region frmMain
        public frmMain()
        {
            InitializeComponent();
        }//Done

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Let's set the folder location from Resources
            txtFolder.Text = Properties.Settings.Default.setFolder;

            //Let's also set the checkbox options for Client launch
            chkClose.Checked = Properties.Settings.Default.setClosed;
            chkMin.Checked = Properties.Settings.Default.setMinimized;

            //Pull in News
            GetNews();

            //Output Server Status
            ServerStatus();

            //Set patch level
            lblPatchLevel.Text = "Patch: " + Properties.Settings.Default.patchLevel;
        }//Done

        private void frmMain_Activated(object sender, EventArgs e)
        {
            //Initialize the worker
            this.CheckPatchWorker = new BackgroundWorker();
            this.CheckPatchWorker.DoWork += new DoWorkEventHandler(CheckPatch);
            this.CheckPatchWorker.ProgressChanged += new ProgressChangedEventHandler(CheckPatchProgress);
            this.CheckPatchWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CheckPatchDone);

            //Check Patch Level and force to update if there is a patch
            this.CheckPatchWorker.RunWorkerAsync();
        }//Done
        #endregion

        #region Globals
        //Let's make a background worker for check patch so the main thread does not stop
        private BackgroundWorker CheckPatchWorker;

        //Let's make a background worker for download patch so the main thread does not stop
        private BackgroundWorker DownloadPatchWorker;
        #endregion

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

        #endregion

        #region UI Visual Elements

        private void lblSettings_MouseHover(object sender, EventArgs e)
        {
            lblSettings.ForeColor = Color.FromArgb(160, 255, 255, 255);
        }

        private void lblSettings_MouseLeave(object sender, EventArgs e)
        {
            lblSettings.ForeColor = Color.FromArgb(160, 252, 192, 63);
        }

        private void lblForums_MouseHover(object sender, EventArgs e)
        {
            lblForums.ForeColor = Color.FromArgb(160, 255, 255, 255);
        }

        private void lblForums_MouseLeave(object sender, EventArgs e)
        {
            lblForums.ForeColor = Color.FromArgb(160, 252, 192, 63);
        }

        private void lblAbout_MouseHover(object sender, EventArgs e)
        {
            lblAbout.ForeColor = Color.FromArgb(160, 255, 255, 255);
        }

        private void lblAbout_MouseLeave(object sender, EventArgs e)
        {
            lblAbout.ForeColor = Color.FromArgb(160, 252, 192, 63);
        }

        private void lblExit_MouseHover(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.FromArgb(160, 255, 255, 255);
        }

        private void lblExit_MouseLeave(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.FromArgb(160, 252, 192, 63);
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

        #endregion

        #region Buttons

        private void btnMain_Click(object sender, EventArgs e)
        {
            //Decide whether the button is Play or Update
            if (btnMain.Text == "UPDATE")
            {
                //Initialize the worker
                this.DownloadPatchWorker = new BackgroundWorker();
                this.DownloadPatchWorker.DoWork += new DoWorkEventHandler(DownloadPatch);
                this.DownloadPatchWorker.ProgressChanged += new ProgressChangedEventHandler(DownloadPatchProgress);
                this.DownloadPatchWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DownloadPatchDone);

                //Check Patch Level and force to update if there is a patch
                this.DownloadPatchWorker.RunWorkerAsync();
            }
            else if (btnMain.Text == "PLAY")
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

        }//Add Logic on error to force download

        private void btnForcePatch_Click(object sender, EventArgs e)
        {
            //Initialize the worker
            this.CheckPatchWorker = new BackgroundWorker();
            this.CheckPatchWorker.DoWork += new DoWorkEventHandler(CheckPatch);
            this.CheckPatchWorker.ProgressChanged += new ProgressChangedEventHandler(CheckPatchProgress);
            this.CheckPatchWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CheckPatchDone);

            //Check Patch Level and force to update if there is a patch
            this.CheckPatchWorker.RunWorkerAsync();
        }//Done

        private void btnFolder_Click(object sender, EventArgs e)
        {
            //Lets make a variable to test whether the user changed the folder
            String previousFolder = txtFolder.Text;

            //Allow the user to select a new folder
            FolderBrowserDialog fbdFolder = new FolderBrowserDialog();

            if (fbdFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFolder.Text = fbdFolder.SelectedPath;

                //Let's save the Settings
                Properties.Settings.Default.setFolder = fbdFolder.SelectedPath;
                Properties.Settings.Default.Save();
            }

            //Check to see if the variable has changed
            if (previousFolder != Properties.Settings.Default.setFolder)
            {
                //Initialize the worker
                this.CheckPatchWorker = new BackgroundWorker();
                this.CheckPatchWorker.DoWork += new DoWorkEventHandler(CheckPatch);
                this.CheckPatchWorker.ProgressChanged += new ProgressChangedEventHandler(CheckPatchProgress);
                this.CheckPatchWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CheckPatchDone);

                //Check Patch Level and force to update if there is a patch
                this.CheckPatchWorker.RunWorkerAsync();
            }

        }//Done

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }//Done

        private void lblSettings_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = false;
            pnlSettings.Visible = true;
        }//Done

        private void lblForums_Click(object sender, EventArgs e)
        {
            Process.Start("https://tarkin.org");
        }//Done

        private void btnOK_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = true;
            pnlSettings.Visible = false;
        }//Done

        private void btnSWG_Click(object sender, EventArgs e)
        {
            //Open the SWG Settings.
            Process procTarkin = new Process();

            procTarkin.StartInfo.FileName = Properties.Settings.Default.setFolder + "\\SWGEmu_Setup.exe";
            procTarkin.StartInfo.WorkingDirectory = Properties.Settings.Default.setFolder;

            procTarkin.Start();
        }//Done

        #endregion

        #region Methods
        private void CheckPatch(object sender, DoWorkEventArgs e)
        {
            //Set the main and forcepatch buttons so they will not touch.
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Text = "WAIT"; }));
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.UseWaitCursor = true; }));
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Enabled = false; }));
            btnForcePatch.Invoke(new MethodInvoker(delegate { btnForcePatch.UseWaitCursor = true; }));
            btnForcePatch.Invoke(new MethodInvoker(delegate { btnForcePatch.Enabled = false; }));

            //Force the user to the News panel and resize the news box
            pnlSettings.Invoke(new MethodInvoker(delegate { pnlSettings.Visible = false; }));
            pnlMain.Invoke(new MethodInvoker(delegate { pnlMain.Visible = true; }));

            //First thing is first, let's download the patch file to the user's machine
            DownloadFile("/PatchData.csv");

            //First, let's check the number of lines in server and set to serverFileCount.
            Properties.Settings.Default.serverFileCount = File.ReadLines(Properties.Settings.Default.setFolder + "\\PatchData.csv").Count() - 1;

            //Now, let's take the very first line and compare it to our patchLevel setting
            StreamReader patchCheck = new StreamReader(Properties.Settings.Default.setFolder + "\\PatchData.csv");

            String clientPatchLevel = patchCheck.ReadLine();
            patchCheck.Close();

            //Check patch level
            if (clientPatchLevel == Properties.Settings.Default.patchLevel)
            {
                //Patch level is correct. Allow user to play.
                btnMain.Invoke(new MethodInvoker(delegate { btnMain.Text = "PLAY"; }));
            }
            else
            {
                //We need to patch before the user can play
                btnMain.Invoke(new MethodInvoker(delegate { btnMain.Text = "UPDATE"; }));
            }
        }

        private void CheckPatchProgress(object sender, ProgressChangedEventArgs e)
        {

        }

        private void CheckPatchDone(object sender, RunWorkerCompletedEventArgs e)
        {
            //Turn the main button back on
            btnMain.UseWaitCursor = false;
            btnMain.Enabled = true;
        }

        private void DownloadPatch(object sender, DoWorkEventArgs e)
        {
            //Set the main and force patch buttons so they will not touch.
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Text = "WAIT"; }));
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.UseWaitCursor = true; }));
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Enabled = false; }));
            btnForcePatch.Invoke(new MethodInvoker(delegate { btnForcePatch.UseWaitCursor = true; }));
            btnForcePatch.Invoke(new MethodInvoker(delegate { btnForcePatch.Enabled = false; }));

            //Force the user to the News panel and resize the news box
            pnlSettings.Invoke(new MethodInvoker(delegate { pnlSettings.Visible = false; }));
            pnlMain.Invoke(new MethodInvoker(delegate { pnlMain.Visible = true; }));
            ftbNews.Invoke(new MethodInvoker(delegate { ftbNews.Height = 309; }));
            pbTotal.Invoke(new MethodInvoker(delegate { pbTotal.Visible = true; }));
            pbTotal.Invoke(new MethodInvoker(delegate { pbTotal.Value = 0; }));

            //Create some vars
            DirectoryInfo clientDir = new DirectoryInfo(Properties.Settings.Default.setFolder);
            StreamReader patchReader = new StreamReader(Properties.Settings.Default.setFolder + "\\PatchData.csv");

            FileInfo[] clientFiles = clientDir.GetFiles("*.*", SearchOption.AllDirectories);
            List<String> serverFiles = new List<String>();

            //Read past the first line so we ignore the patch info
            patchReader.ReadLine();

            //Iterate through the PatchData.csv and save off the data in a list
            while (!patchReader.EndOfStream)
            {
                //Set the csv to the serverFiles List.
                serverFiles.Add(patchReader.ReadLine());
            }

            //Set Total progressbar maximum to twice serverFileCount
            pbTotal.Invoke(new MethodInvoker(delegate { pbTotal.Maximum = Properties.Settings.Default.serverFileCount * 2; }));

            //First, loop through server list and set a value for name and file size.
            foreach (String serverSearch in serverFiles.ToList())
            {
                //Split the data from the CSV by comma.
                String[] serverData = serverSearch.Split(',');
                String serverFileName = serverData[0];
                long serverFileLength = Convert.ToInt64(serverData[1]);
                String serverHash = serverData[2];
                bool actionFlag = false;

                //Loop through the client array and try and find a name match, then check the file size
                foreach (FileInfo clientSearch in clientFiles)
                {
                    String clientFileName = clientSearch.FullName.Replace(Properties.Settings.Default.setFolder, "");
                    long clientFileLength = clientSearch.Length;

                    if (serverFileName == clientFileName)
                    {
                        //Match is found, check the file length, ignore if equal
                        if (serverFileLength == clientFileLength)
                        {
                            //File match found with same file size. Keep on directory list to check CRC. Set flag.
                            actionFlag = true;
                            break;
                        }
                        else
                        {
                            //File match with different file size. Download file from server. Remove file from server list. Set flag.
                            File.Delete(clientSearch.FullName);

                            DownloadFile(serverFileName);

                            serverFiles.Remove(serverSearch);
                            pbTotal.Invoke(new MethodInvoker(delegate { pbTotal.Increment(1); }));
                            actionFlag = true;
                            break;
                        }
                    }
                }
                //No match was found. We need to download the server file. Remove file from server list
                if (actionFlag == false)
                {
                    DownloadFile(serverFileName);

                    serverFiles.Remove(serverSearch);
                    pbTotal.Invoke(new MethodInvoker(delegate { pbTotal.Increment(1); }));
                }
                //Advance the progress bar for total
                pbTotal.Invoke(new MethodInvoker(delegate { pbTotal.Increment(1); }));
            }

            //Now, we have checked filenames and filesizes. Let's check CRCs.
            foreach (String serverSearch in serverFiles.ToList())
            {
                String[] serverData = serverSearch.Split(',');
                String serverFileName = serverData[0];
                String serverHash = serverData[2];

                //Loop through clients to find the filename match
                foreach (FileInfo clientSearch in clientFiles)
                {
                    String clientFileHash;
                    String clientFileName = clientSearch.FullName.Replace(Properties.Settings.Default.setFolder, "");

                    if (serverFileName == clientFileName)
                    {
                        //Match found, create CRC from clientfile.
                        using (var md5 = MD5.Create())
                        {
                            using (var stream = File.OpenRead(clientSearch.FullName))
                            {
                                clientFileHash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", String.Empty);
                            }
                        }

                        //Compare server and client hash
                        if (serverHash == clientFileHash)
                        {
                            //Match found. Delete server entry.
                            serverFiles.Remove(serverSearch);
                            break;
                        }
                        else
                        {
                            //Match not found. Download file from server.
                            File.Delete(clientSearch.FullName);

                            DownloadFile(serverFileName);

                            serverFiles.Remove(serverSearch);
                        }

                    }
                }
                //Advance the progress bar for total
                pbTotal.Invoke(new MethodInvoker(delegate { pbTotal.Increment(1); }));
            }

            //Finally, lets call the method to update the patch number
            UpdatePatchVersion();

            //Patch level is correct. Allow user to play.
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Text = "PLAY"; }));
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.UseWaitCursor = false; }));
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Enabled = true; }));

            //Hide progress bars and extend news panel
            ftbNews.Invoke(new MethodInvoker(delegate { ftbNews.Height = 339; }));
            pbTotal.Invoke(new MethodInvoker(delegate { pbTotal.Visible = false; }));
        }

        private void DownloadPatchProgress(object sender, ProgressChangedEventArgs e)
        {

        }

        private void DownloadPatchDone(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void DownloadFile(string Filename)
        {
            //Create FTP Connector
            WebClient ftpTarkin = new WebClient();
            ftpTarkin.Credentials = new NetworkCredential("anonymous@ravenwoodgaming.com", "");

            //Download the file
            ftpTarkin.DownloadFile(new Uri("ftp://ftp.ravenwoodgaming.com/Tarkin" + Filename), Properties.Settings.Default.setFolder + Filename.Replace("/", "\\"));
        }

        private void UpdatePatchVersion()
        {
            //Let's take the very first line and set it to our patchLevel setting
            StreamReader patchCheck = new StreamReader(Properties.Settings.Default.setFolder + "\\PatchData.csv");
            Properties.Settings.Default.patchLevel = patchCheck.ReadLine();
            patchCheck.Close();
        }

        private void GetNews()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            //Grab data from announcement forums
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
        }

        private void ServerStatus()
        {
            // Create a TcpClient.
            TcpClient stsClient = new TcpClient("23.111.128.52", 44455);

            //This is required to be sent to the server so it will generate a response
            String stsSend = "\n";
            // Translate the response into ASCII and store it as a Byte array.
            Byte[] stsASCII = System.Text.Encoding.ASCII.GetBytes(stsSend);

            // Get a client stream for reading and writing.
            NetworkStream stsStream = stsClient.GetStream();

            // Send the message to the connected TcpServer. 
            stsStream.Write(stsASCII, 0, stsASCII.Length);

            // Buffer to store the response bytes.
            stsASCII = new Byte[512];

            // String to store the response ASCII representation.
            String stsData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stsStream.Read(stsASCII, 0, stsASCII.Length);
            stsData = System.Text.Encoding.ASCII.GetString(stsASCII, 0, bytes);

            // Close everything.
            stsStream.Close();
            stsClient.Close();

            //Unpack the XML in stsData
            String[] stsDataElements = Regex.Replace(stsData, "<.*?>", String.Empty).Split('\n');

            //Fix Uptime
            String Uptime = stsDataElements[11];
            Double uptimeSeconds;
            Double.TryParse(Uptime, out uptimeSeconds);
            uptimeSeconds = uptimeSeconds * -1;
            TimeSpan tsUptime = DateTime.Now - DateTime.Now.AddSeconds(uptimeSeconds);


            Uptime = tsUptime.Days.ToString() + " days " + tsUptime.Hours.ToString() + " hours";

            //Fix Updated
            String Updated = stsDataElements[12];
            Double updatedSeconds;
            Double.TryParse(Updated, out updatedSeconds);

            //Convert Milliseconds to Seconds
            updatedSeconds = updatedSeconds / 1000;

            System.DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            Epoch = Epoch.AddSeconds(updatedSeconds).ToLocalTime();

            Updated = Epoch.ToShortTimeString().ToString();

            //Set Labels
            if (stsDataElements[3] == "up")
            {
                lblStatusEnum.Text = "Status: Up";
                lblStatusOnline.Text = "Online: " + stsDataElements[5];
                lblStatusMax.Text = "Max: " + stsDataElements[6];
                lblStatusUptime.Text = "Uptime: " + Uptime;
                lblStatusLast.Text = "Updated: " + Updated;
            }
            else
            {
                lblStatusEnum.Text = "Status: Down";
                lblStatusOnline.Text = "";
                lblStatusMax.Text = "";
                lblStatusUptime.Text = "";
                lblStatusLast.Text = "";
            }

        }

        #endregion

    }

}

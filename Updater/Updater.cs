//Copyright 2017 Steven Helm
// Redesigned and upgraded by R. Bassett Jr. (Tatwi) 2019

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
using System.Configuration;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Updater
{
    public partial class frmMain : Form
    {
        #region frmMain
        public frmMain()
        {
            InitializeComponent();

            // Disable mouse over highlight on main button, because it makes a white background on the rounded image.
            btnMain.FlatAppearance.MouseOverBackColor = btnMain.BackColor;
            btnMain.FlatAppearance.MouseDownBackColor = pnlMain.BackColor;
            btnMain.BackColorChanged += (s, e) => {
                btnMain.FlatAppearance.MouseOverBackColor = btnMain.BackColor;
            };

        }//Done

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Show patch server address in settings menu
            ftpInput.Text = Properties.Settings.Default.patchServerURL;

            // Show ignore list in settings menu
            ignoreInput.Text = Properties.Settings.Default.ignoreList;

            //Let's set the previous folder
            //Let's set the folder location from Resources
            txtFolder.Text = Properties.Settings.Default.setFolder;

            //Let's also set the checkbox options for Client launch
            chkClose.Checked = Properties.Settings.Default.setClosed;
            chkMin.Checked = Properties.Settings.Default.setMinimized;

            //Pull in News
            GetNews();

            //Output Server Status
            Task.Factory.StartNew(() => ServerStatus());

            //Before we start, let's make SURE the user isn't crazy and that a folder ACTUALLY exists
            if (Properties.Settings.Default.setFolder == "" || !Directory.Exists(Properties.Settings.Default.setFolder))
            {
                //Lets make a variable to test whether the user changed the folder
                String previousFolder = txtFolder.Text;

                //Allow the user to select a new folder
                FolderBrowserDialog fbdFolder = new FolderBrowserDialog();
                fbdFolder.Description = "PLEASE SELECT AN INSTALL DIRECTORY";

                if (fbdFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtFolder.Text = fbdFolder.SelectedPath;

                    //Let's save the Settings
                    Properties.Settings.Default.setFolder = fbdFolder.SelectedPath;

                    // Try getting most recent patch server address (can be http, https, ftp)
                    string ftpAddress = getWebString(Properties.Settings.Default.ftpUpdateURL);

                    if (ftpAddress.Contains("No Data found"))
                    {
                        Properties.Settings.Default.ftpUpdateURL = ftpAddress;
                    }

                    // Create local settings file
                    saveSettings();
                }
            }

            // Check for update, patch if required
            CheckForUpdates();
        }//Done
        #endregion

        #region Globals
        //Let's make a background worker for check patch so the main thread does not stop
        private BackgroundWorker CheckPatchWorker;

        //Let's make a background worker for download patch so the main thread does not stop
        private BackgroundWorker DownloadPatchWorker;

        // Make a process for the settings program so we can force the user to use on the first setup
        Process procSettings = new Process();

        // Track error state when downloading files
        public bool downloadError = false;

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
            /* Commented out, because this prevented selecting the text in the news window, which as annoying.
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WMNCLBUTTONDOWN, HTCAPTION, 0);
            }
            */
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

        delegate void SetTextCallback(string text);

        private void SetFileStatus(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.fileStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetFileStatus);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.fileStatus.Text = text;
            }
        }

        #endregion

        #region Buttons

        private void btnMain_Click(object sender, EventArgs e)
        {
            // Decide whether the button is Play, Update, or Settings
            if (btnMain.Text == "Update")
            {
                //Initialize patch download worker
                this.DownloadPatchWorker = new BackgroundWorker();
                this.DownloadPatchWorker.DoWork += new DoWorkEventHandler(DownloadPatch);
                this.DownloadPatchWorker.ProgressChanged += new ProgressChangedEventHandler(DownloadPatchProgress);
                this.DownloadPatchWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DownloadPatchDone);

                // Start actually patching files
                this.DownloadPatchWorker.RunWorkerAsync();
            }
            else if (btnMain.Text == "Play")
            {
                //Open the Tarkin client.
                Process procTarkin = new Process();

                procTarkin.StartInfo.FileName = Properties.Settings.Default.setFolder + "\\SWGEmu.exe";
                procTarkin.StartInfo.WorkingDirectory = Properties.Settings.Default.setFolder;

                //Let's wrap this in a try/catch in case there is a file missing
                try
                {
                    procTarkin.Start();
                }
                catch (Exception Error)
                {
                    MessageBox.Show("SWGEmu.exe was not found. Please go to Settings, press the Force Update button, and then click the Update button to download any missing or corrupt files.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

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
            else if (btnMain.Text == "Settings") {
                openSettings();

                int screenW = SystemInformation.VirtualScreen.Width;
                int screenH = SystemInformation.VirtualScreen.Height;


                MessageBox.Show("Before running the game, please set your screen resolution on the Graphics tab of the settings program.\n\nThanks!\n\nYour desktop resolution is: " + screenW + " x " + screenH, "Settings Help",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Wait for the user to close the game settings program before allowing them to play
                while (!procSettings.HasExited)
                {
                    btnMain.Text = ". . .";
                }

                btnMain.Text = "Play";

                // Set first install false in local settings file so this prompt won't happen again
                Properties.Settings.Default.firstInstall = "false";
                saveSettings();
            }
        }

        private void btnForcePatch_Click(object sender, EventArgs e)
        {
            // Reset download file error state
            downloadError = false;

            // Delete last file so patcher will recheck all files
            Console.WriteLine("Force Update deleting file: " + Properties.Settings.Default.lastFileInList);
            string lastFile = Properties.Settings.Default.setFolder + Properties.Settings.Default.lastFileInList;
            if (File.Exists(lastFile))
                File.Delete(lastFile);

            // Force the main button to say Update by checking for updates
            CheckForUpdates();

            // Update local settings file
            saveSettings();

        }//Done

        private void btnFolder_Click(object sender, EventArgs e)
        {
            //Lets make a variable to test whether the user changed the folder
            String previousFolder = txtFolder.Text;

            //Allow the user to select a new folder
            FolderBrowserDialog fbdFolder = new FolderBrowserDialog();
            fbdFolder.Description = "PLEASE SELECT AN INSTALL DIRECTORY";

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
            Process.Start(Properties.Settings.Default.forumURL);
        }//Done

        private void btnOK_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = true;
            pnlSettings.Visible = false;
        }//Done

        private void btnSWG_Click(object sender, EventArgs e)
        {
            openSettings();
        }//Done

        #endregion

        #region Methods

        // Run the game settings program
        private void openSettings()
        {
            String SettingsFile = Properties.Settings.Default.setFolder + "\\SWGEmu_Setup.exe";

            if (File.Exists(@SettingsFile))
            {
                //Open the SWG Settings.
                procSettings.StartInfo.FileName = Properties.Settings.Default.setFolder + "\\SWGEmu_Setup.exe";
                procSettings.StartInfo.WorkingDirectory = Properties.Settings.Default.setFolder;
                procSettings.Start();
            }
        }

        private void saveSettings()
        {
            // Save defaults to file that user can over-ride later by editing the text file
            // File located in C:\Users\%USERNAME%\AppData\Local\Microsoft\TarkinII_Launcher.exe_Url_<file_hash>\
            Properties.Settings.Default.patchServerURL = Properties.Settings.Default.patchServerURL;
            Properties.Settings.Default.ftpUser = Properties.Settings.Default.ftpUser;
            Properties.Settings.Default.newsURL = Properties.Settings.Default.newsURL;
            Properties.Settings.Default.forumURL = Properties.Settings.Default.forumURL;
            Properties.Settings.Default.aboutURL = Properties.Settings.Default.aboutURL;
            Properties.Settings.Default.statusURL = Properties.Settings.Default.statusURL;
            Properties.Settings.Default.statusPort = Properties.Settings.Default.statusPort;
            Properties.Settings.Default.ftpUpdateURL = Properties.Settings.Default.ftpUpdateURL;
            Properties.Settings.Default.ignoreList = Properties.Settings.Default.ignoreList;
            Properties.Settings.Default.lastFileInList = Properties.Settings.Default.lastFileInList;

            Properties.Settings.Default.Save();
        }

        static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
        static string getWebString(string url)
        {
            Console.WriteLine("Fetching sting data from: " + url);

            //Create Web Connector
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
            WebClient Client = new WebClient();
            Client.Headers.Add("User-Agent: Other");

            string content = "No data found.";

            try
            {
                content = Client.DownloadString(url);
            }
            catch (Exception)
            {
                // Prevents error message for end user
                Console.WriteLine("Failed to fetch data from: " + url);
            }

            //Close the WebClient
            Client.Dispose();

            return content;
        }

        // Run the patch checker workers async
        private void CheckForUpdates()
        {
            this.CheckPatchWorker = new BackgroundWorker();
            this.CheckPatchWorker.DoWork += new DoWorkEventHandler(CheckPatch);
            this.CheckPatchWorker.ProgressChanged += new ProgressChangedEventHandler(CheckPatchProgress);
            this.CheckPatchWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CheckPatchDone);

            // Start running the workers
            this.CheckPatchWorker.RunWorkerAsync();

            //Wait for it to complete.
            while (CheckPatchWorker.IsBusy)
            {
                Application.DoEvents();
            }
        }

        // See if we need a patch, if so make button say Update
        private void CheckPatch(object sender, DoWorkEventArgs e)
        {
            //Set the main and forcepatch buttons so they will not touch.
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Text = ". . . ."; }));
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Enabled = false; }));
            btnForcePatch.Invoke(new MethodInvoker(delegate { btnForcePatch.Enabled = false; }));

            //Force the user to the News panel
            pnlSettings.Invoke(new MethodInvoker(delegate { pnlSettings.Visible = false; }));
            pnlMain.Invoke(new MethodInvoker(delegate { pnlMain.Visible = true; }));

            // Tell user we're connecting to the patch server
            SetFileStatus("Connecting to patch server...");

            // Delete of patch data file 
            if (File.Exists(path: Properties.Settings.Default.setFolder + "\\PatchData.csv"))
            {
                File.Delete(path: Properties.Settings.Default.setFolder + "\\PatchData.csv");
            }

            // Download new patch data file
            DownloadFile("/PatchData.csv");

            // Set status to default after successfully connecting to the patch server
            SetFileStatus("Idle...");

            // See if client needs to be updated
            try
            {
                // Read the file
                string sPatchData = File.ReadAllText(path: Properties.Settings.Default.setFolder + "\\PatchData.csv");
                sPatchData.Trim();
                string sCleaned = Regex.Replace(sPatchData, @"\t|\n|\r", "");
                sPatchData = sCleaned;

                // Put string into array
                string[] patchDataArray = sPatchData.Split(',');

                // Make the array into 1 list per item
                List<string> fileNames = new List<string>();
                List<string> fileSums = new List<string>();

                for (int i = 0; i < patchDataArray.Length -1; i++)
                {
                    if (i % 2 == 0)
                    {
                        fileNames.Add(patchDataArray[i]);
                    }
                    else
                    {
                        fileSums.Add(patchDataArray[i]);
                    }
                }

                Console.WriteLine("First file: " + fileNames[0] + "   " + fileSums[0]);
                Console.WriteLine("Final file: " + fileNames[fileNames.Count - 1] + "   " + fileSums[fileNames.Count - 1]);

                Properties.Settings.Default.lastFileInList = fileNames[fileNames.Count - 1];

                bool needUptate = false;

                Console.WriteLine("Seeing if file exists: " + fileNames[fileNames.Count - 1]);

                // Has the last file in the list been downloaded already?
                if (!File.Exists(path: Properties.Settings.Default.setFolder + fileNames[fileNames.Count - 1]))
                {
                    needUptate = true;
                    Console.WriteLine("File not found: " + fileNames[fileNames.Count - 1]);
                }

                // Does the first file in the list exist?
                if (!needUptate)
                {
                    Console.WriteLine("Seeing if file exists: " + fileNames[0]);

                    if (!File.Exists(path: Properties.Settings.Default.setFolder + fileNames[0]))
                    {
                        needUptate = true;
                        Console.WriteLine("File not found: " + fileNames[0]);
                    }

                }

                // Is the first file in the list up to date?
                if (!needUptate)
                {
                    String existingFileMD5 = CalculateMD5(Properties.Settings.Default.setFolder + fileNames[0]);

                    Console.WriteLine("MD5 Compare for first file in list (local   server): " + existingFileMD5.ToUpper() + "  " + fileSums[0].ToUpper());

                    if (existingFileMD5.ToUpper() != fileSums[0].ToUpper())
                        needUptate = true;
                }

                // Let user play
                if (!needUptate)
                {
                    btnMain.Invoke(new MethodInvoker(delegate { btnMain.Text = "Play"; }));
                } 
                else
                {
                    btnMain.Invoke(new MethodInvoker(delegate { btnMain.Text = "Update"; }));
                }

            }
            catch (Exception)
            {
                // Connection must have failed before downloading the patch info files
                Console.WriteLine("Error in the try/catch of the CheckPatch function.");
                return;
            }
        }

        private void CheckPatchProgress(object sender, ProgressChangedEventArgs e)
        {
            // Nothing needs to be done here at the moment
        }

        private void CheckPatchDone(object sender, RunWorkerCompletedEventArgs e)
        {
            //Turn the main and force buttons back on
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Enabled = true; }));
            btnForcePatch.Invoke(new MethodInvoker(delegate { btnForcePatch.Enabled = true; }));
        }

        private void DownloadPatch(object sender, DoWorkEventArgs e)
        {
            // Create sub directories if they are missing
            Directory.CreateDirectory(path: Properties.Settings.Default.setFolder + "\\miles");
            Directory.CreateDirectory(path: Properties.Settings.Default.setFolder + "\\string\\en");

            //Set the main and force patch buttons so they will not touch.
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Text = "Updating..."; }));
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Enabled = false; }));
            btnForcePatch.Invoke(new MethodInvoker(delegate { btnForcePatch.Enabled = false; }));

            //Force the user to the News panel
            pnlSettings.Invoke(new MethodInvoker(delegate { pnlSettings.Visible = false; }));
            pnlMain.Invoke(new MethodInvoker(delegate { pnlMain.Visible = true; }));

            //Create some vars
            DirectoryInfo clientDir = new DirectoryInfo(Properties.Settings.Default.setFolder);

            // Read the file
            string sPatchData = File.ReadAllText(path: Properties.Settings.Default.setFolder + "\\PatchData.csv");
            sPatchData.Trim();
            string sCleaned = Regex.Replace(sPatchData, @"\t|\n|\r", "");
            sPatchData = sCleaned;

            // Put string into array
            string[] patchDataArray = sPatchData.Split(',');

            // Make the array into 1 list per item
            List<string> fileNames = new List<string>();
            List<string> fileSums = new List<string>();

            for (int i = 0; i < patchDataArray.Length; i++)
            {
                if (i % 2 == 0)
                {
                    fileNames.Add(patchDataArray[i]);
                }
                else
                {
                    fileSums.Add(patchDataArray[i]);
                }
            }

            // Make an array of files names from the client directory
            FileInfo[] tmpFI = clientDir.GetFiles("*.*", SearchOption.AllDirectories);
            string[] localFiles = tmpFI.Select(f => f.Name).ToArray();

            // debug
            for (int i = 0; i < localFiles.Count(); i++)
            {
                localFiles[i] = "/" + localFiles[i];
                Console.WriteLine("File Array: " + localFiles[i]);
            }

            // Some files to exclude if they already exist
            string exludes = Properties.Settings.Default.ignoreList;

            string localFileSum = "";

            string downloadThis = @"";

            // Download the files in the list
            for (int i= 0; i < fileNames.Count; i++)
            {
                // Format file name for download in case we need it
                downloadThis =  fileNames[i];
                SetFileStatus("Working (" + i + "/" + fileNames.Count + "): " + downloadThis.TrimStart('/'));

                // Skip files on the excluded list after they're already on the computer
                if (File.Exists(path: Properties.Settings.Default.setFolder + "\\" + fileNames[i]) && exludes.Contains(downloadThis.TrimStart('/')))
                    continue;

                // If fileName exist on client then compare fileName's md5 to sever's md5 for that file
                    if (localFiles.Contains(fileNames[i]))
                {
                    // Get the MD5 for the local file
                    using (var md5 = MD5.Create())
                    {
                        using (var stream = File.OpenRead(path: Properties.Settings.Default.setFolder + "\\" + fileNames[i]))
                        {
                            localFileSum = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", String.Empty);
                        }
                    }

                    // debug
                    Console.WriteLine("MD5 Comp: " + fileNames[i].ToUpper() + " L: " + localFileSum + " S: " + fileSums[i].ToUpper());

                    // If the MD5 sums don't match, redownload the file
                    if (localFileSum.ToUpper() != fileSums[i].ToUpper())
                    {
                        File.Delete(path: Properties.Settings.Default.setFolder + "\\" + fileNames[i]);
                        DownloadFile(downloadThis);
                    }
                }
                else
                {
                    // File not found, download it
                    DownloadFile(downloadThis);
                }

                // Status Text
                SetFileStatus("Idle. . ." + fileNames[i].ToUpper());
            }
        }

        private void DownloadPatchProgress(object sender, ProgressChangedEventArgs e)
        {
            // A progress bar could be added here some day...
        }

        private void DownloadPatchDone(object sender, RunWorkerCompletedEventArgs e)
        {
            //Allow user to play.
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Text = "Play"; }));

            // Force Update button if there was a file error while downloading
            if (downloadError)
            {
                btnMain.Invoke(new MethodInvoker(delegate { btnMain.Text = "Update"; }));
                downloadError = false; // Reset to try downloading again
            }

            // Force player to open game settings on the fist run
            if (Properties.Settings.Default.firstInstall == "true")
                btnMain.Text = "Settings";

            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Enabled = true; }));
            btnForcePatch.Invoke(new MethodInvoker(delegate { btnForcePatch.Enabled = true; }));
        }

        private void DownloadFile(string Filename)
        {
            if (Filename == "")
                return;

            // Format file name
            string savedFileName = Properties.Settings.Default.setFolder + Filename.Replace("/", "\\");

            //Create Web Connector
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
            WebClient Client = new WebClient();
            Client.Headers.Add("User-Agent: Other");

            // Use ftp credentials if needed
            if (Properties.Settings.Default.patchServerURL.Contains("ftp:")) 
                Client.Credentials = new NetworkCredential("anonymous", "");

            //Download the file
            try
            {
                Client.DownloadFile(Properties.Settings.Default.patchServerURL + Filename, savedFileName);
            }
            catch (WebException e)
            {
                MessageBox.Show("A file was missing or unavailable. This can happen when the patch server is down or the file can't be found on the server. Check the patch server address in the Settings menu and try using the Force Update button.\n\nError:\n\n" + e + "\n\nwhen attempting to download " + Filename, "Connection Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Unable to download: " + Filename);

                downloadError = true;

                SetFileStatus("Error connecting to patch server. Check address in Settings.");

                throw e;
            }

            //Close the WebClient
            Client.Dispose();

            Console.WriteLine("Now Downloading: " + savedFileName);
        }

        private void GetNews()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            //Grab data from announcement forums
            XmlDocument RSSNews = new XmlDocument();
            RSSNews.Load(Properties.Settings.Default.newsURL);

            XmlNodeList RSSNewsNodes = RSSNews.SelectNodes("rss/channel/item");
            StringBuilder RSSNewsData = new StringBuilder();

            // Box heading
            RSSNewsData.Append("NEWS: \n\n");

            foreach (XmlNode RSSNode in RSSNewsNodes)
            {
                XmlNode RSSSubNode = RSSNode.SelectSingleNode("title");
                string TitleElement = RSSSubNode != null ? RSSSubNode.InnerText : "";

                RSSSubNode = RSSNode.SelectSingleNode("description");
                string NewsElement = RSSSubNode != null ? RSSSubNode.InnerText : "";

                // Skip this entry if there isn't any data to show
                if (NewsElement == "")
                    continue;

                RSSSubNode = RSSNode.SelectSingleNode("pubDate");
                string PublishDate = RSSSubNode != null ? RSSSubNode.InnerText : "";
                PublishDate = PublishDate.Substring(0, 17);

                //Clean news up.
                NewsElement = Regex.Replace(NewsElement, "\t", "");
                TitleElement = Regex.Replace(TitleElement, "\t", "");
                NewsElement = Regex.Replace(NewsElement, "\n\n\n\n\n", "");
                NewsElement = Regex.Replace(NewsElement, "\n\n\n\n", "");
                NewsElement = Regex.Replace(NewsElement, "\n\n\n", "");
                NewsElement = Regex.Replace(NewsElement, "\n\n", "");
                TitleElement = Regex.Replace(TitleElement, "\n", "");
                NewsElement = Regex.Replace(NewsElement, "<.*?>", String.Empty);
                TitleElement = Regex.Replace(TitleElement, "<.*?>", String.Empty);

                String TitleUnderline = "\n-------------------------------------\n";
                RSSNewsData.Append(TitleElement + TitleUnderline + PublishDate + "\n" + NewsElement + "\n\n\n");
            }

            //Output News!
            ftbNews.Text = RSSNewsData.ToString();
        }

        private void ServerStatus()
        {
            // Tell user we're checking
            lblStatusEnum.Invoke(new MethodInvoker(delegate { lblStatusEnum.Text = "Checking..."; }));

            // tarkinlogin.ddns.net
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            System.Net.ServicePointManager.Expect100Continue = false;

            try
            {
                using (TcpClient tcpClient = new TcpClient(Properties.Settings.Default.statusURL, Int32.Parse(Properties.Settings.Default.statusPort)))
                using (NetworkStream ns = tcpClient.GetStream())
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    sw.AutoFlush = true;
                    sw.WriteLine("\n");

                    Byte[] stsASCII = new Byte[512];
                    String stsData = String.Empty;
                    Int32 bytes = ns.Read(stsASCII, 0, stsASCII.Length);
                    stsData = System.Text.Encoding.ASCII.GetString(stsASCII, 0, bytes);

                    //ftbNews.Text = stsData; // debugging

                    sw.Close();
                    ns.Close();
                    tcpClient.Close();

                    ParseStatusXML(stsData);
                }
            }
            catch (ArgumentNullException e)
            {
                lblStatusEnum.Invoke(new MethodInvoker(delegate { lblStatusEnum.Text = "Status: Down"; }));
            }
            catch (SocketException e)
            {
                lblStatusEnum.Invoke(new MethodInvoker(delegate { lblStatusEnum.Text = "Status: Down"; }));
            }   
        }

        private void ParseStatusXML(String stsData)
        {
            //Unpack the XML in stsData
            String[] stsDataElements = Regex.Replace(stsData, "<.*?>", String.Empty).Split('\n');

            //Fix Uptime
            String Uptime = stsDataElements[11];
            Double uptimeSeconds;
            Double.TryParse(Uptime, out uptimeSeconds);
            uptimeSeconds = uptimeSeconds * -1;
            TimeSpan tsUptime = DateTime.Now - DateTime.Now.AddSeconds(uptimeSeconds);

            Uptime = tsUptime.Days.ToString() + "D " + tsUptime.Hours.ToString() + "H";

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

        #region Misc Elements
        private void ftbNews_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNews_Click(object sender, EventArgs e)
        {

        }

        private void lblAbout_Click(object sender, EventArgs e)
        {
            if (pnlMain.Visible == false)
                return;

            if (lblAbout.Text == "News")
            {
                lblAbout.Text = "About";
                GetNews();
            }
            else
            {
                lblAbout.Text = "News";

                // Get current about info
                string aboutMessage = getWebString(Properties.Settings.Default.aboutURL);

                if (aboutMessage.Contains("No data found"))
                {
                    ftbNews.Text = "TARKIN'S REVENGE: \n\nA Star Wars Galaxies server, based upon SWGEmu's Core3 / Engine3. Roleplay-friendly, with a focus on quality of life, we are not your average glowbat zone.\n\n" +
                       "Credits Current and Former Staff:\n--------------------------------" +
                       "\nKinshi\n First and foremost, founder of the original SWGCanon / Tarkin, for the foundation upon which we have built Tarkin's Revenge (especially NPC Player Cities, but so many more contributions, far too numerous to list them all - including most of the vision and principles by which we operate. We would not exist without Kinshi's vision), along with Skolten, our web dev, as well as Wol, Gurgi, and Zetlaux, who served as staff and code contributors on dugeons and screenplays during Tarkin's original run." +
                       "\n\nLiakhara(Github: stacy19201325)\n For merging original tarkin_scripts and TarkinII / Core3 with current SWGEmu code, craftable factional armors, craftable CU / NGE weapons, vast amounts of client asset implementation, many dungeon revamps, SUI menu to choose combat mission levels, Jedi and faction trophies, custom DNA naming, many camp changes, world snapshot changes, recycler changes, Star Tours Adventure Service, custom color palettes, most other Post - Tarkin II contributions so far." +
                       "\n\nParadymShift(Github: Spartan5150)\n For networking, hardware, and forum management, as well as world snapshot editing, and community relations." +
                       "\n\nTatwi\n For the contributions he made through the various iterations of Tarkin: / tarkin command, houseplop, medical services terminals, skill training NPCs, hunting mission revamp, mission terminal renaming, new player email, CA / AA to drop with one stat only, pitch / roll / yaw, and various other quality of life improvements." +
                       "\n\nDevereux(Github: Trakaa)\n For fixes correcting decrimenting of manufacturing schematics, making mind heal work on stims, recoloring armor with multiple palettes, making current resource list export in a format compatible with swgcraft, on Tarkin II." +
                       "\n\nTaylaria\n For some work on mobile templates on Tarkin II." +
                       "\n\nSealGunma\n For our knee-jerk hatred of Fixer, thanks to crashing our server repeatedly due to a screenplay bug on Tarkin II." +
                       "\n\n\nSources and inspiration from other servers:" +
                       "\nBorrie\n For Wall Pack and Windmill." +
                       "\n\nHalyn\n For his comments in ModtheGalaxy chat for slicing locked briefcases." +
                       "\n\nToxic\n For contributions of galaxy - wide invites, unstick command, and changes to / move on Tarkin II as well as inspiration to make a SUI window upon character creation to describe the server." +
                       "\n\nMost likely Red as orginator for CA / AA being named after the stat - modified and contributed by Tatwi, modified again by Liakhara as it exists in its current state on Tarkin's Revenge." +
                       "\n\nUnsure: Serverwide announcements of important events like pvp kills, new server joins, etc.We encountered this playing on Remastered and used this idea here on Tarkin's Revenge, but I don't believe the idea originated there.Let us know if you know for certain where this idea originated.";

                }
                else
                {
                    ftbNews.Text = aboutMessage;
                }
            }
            
            
        }

        private void lblFileStatus_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Settings file path
            var settingsPath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;

            Process.Start("notepad.exe", settingsPath);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Save user input address to local settings file
        private void button1_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.patchServerURL = ftpInput.Text;
            Properties.Settings.Default.Save();
        }

        // Set default address in local settings file
        private void button1_Click_2(object sender, EventArgs e)
        {
            Properties.Settings.Default.patchServerURL = "https://tarkinswg.com/tre/patch";
            ftpInput.Text = Properties.Settings.Default.patchServerURL;
            Properties.Settings.Default.Save();
        }

        // Grab the latest patch server address 
        private void btnFtpGetURL_Click(object sender, EventArgs e)
        {
            ftpInput.Text = getWebString(Properties.Settings.Default.ftpUpdateURL);
        }

        // Enable copying of text in the news window
        private void ftbNews_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("News box clicked!");

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            { 
                
                ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
                MenuItem menuItem = new MenuItem("Copy");
                menuItem.Click += new EventHandler(CopyAction);
                contextMenu.MenuItems.Add(menuItem);
                ftbNews.ContextMenu = contextMenu;

                Console.WriteLine("Right click up!");
            }
        }

        void CopyAction(object sender, EventArgs e)
        {
            Clipboard.SetText(ftbNews.SelectedText);
        }

        private void lblFolder_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ignoreInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void ignoreInput_Click(object sender, EventArgs e)
        {
           
        }

        // Reset ignore list
        private void btnIgnoreReset_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ignoreList = "options.cfg swgemu.cfg user.cfg swgemu_machineoptions.iff";
            ignoreInput.Text = Properties.Settings.Default.ignoreList;
            Properties.Settings.Default.Save();
        }

        // Save ignore list
        private void btnIgnoreSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ignoreList = ignoreInput.Text;
            Properties.Settings.Default.Save();
        }

        private void picMain_Click(object sender, EventArgs e)
        {

        }
    }
    #endregion
}

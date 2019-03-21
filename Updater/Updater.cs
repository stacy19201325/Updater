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
            //Let's set the previous folder 
            
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
                    Properties.Settings.Default.patchLevel = null;
                    Properties.Settings.Default.serverFileCount = 0;
                    Properties.Settings.Default.Save();
                }
            }

            //Initialize the worker
            this.CheckPatchWorker = new BackgroundWorker();
            this.CheckPatchWorker.DoWork += new DoWorkEventHandler(CheckPatch);
            this.CheckPatchWorker.ProgressChanged += new ProgressChangedEventHandler(CheckPatchProgress);
            this.CheckPatchWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CheckPatchDone);

            //Check Patch Level and force to update if there is a patch
            this.CheckPatchWorker.RunWorkerAsync();

            //Wait for it to complete.
            while (CheckPatchWorker.IsBusy)
            {
                Application.DoEvents();
            }
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

                //Let's wrap this in a try/catch in case there is a file missing
                try
                {
                    procTarkin.Start();
                }
                catch (Exception Error)
                {
                    if (Error.Message == "The system cannot find the file specified")
                    {
                        //Initialize the worker
                        this.DownloadPatchWorker = new BackgroundWorker();
                        this.DownloadPatchWorker.DoWork += new DoWorkEventHandler(DownloadPatch);
                        this.DownloadPatchWorker.ProgressChanged += new ProgressChangedEventHandler(DownloadPatchProgress);
                        this.DownloadPatchWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DownloadPatchDone);

                        //There was no exe. Run the patch Download.
                        this.DownloadPatchWorker.RunWorkerAsync();
                    }                               
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

        }//Add Logic on error to force download

        private void btnForcePatch_Click(object sender, EventArgs e)
        {
            // Delete last file so patcher will recheck all files
            File.Delete(path: Properties.Settings.Default.setFolder + "\\string\\en\\test_motd.stf");

            //Initialize the worker
            this.CheckPatchWorker = new BackgroundWorker();
            this.CheckPatchWorker.DoWork += new DoWorkEventHandler(CheckPatch);
            this.CheckPatchWorker.ProgressChanged += new ProgressChangedEventHandler(CheckPatchProgress);
            this.CheckPatchWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CheckPatchDone);

            //Check Patch Level and force to update if there is a patch
            this.CheckPatchWorker.RunWorkerAsync();

            //Wait for it to complete.
            while (CheckPatchWorker.IsBusy)
            {
                Application.DoEvents();
            }

            /*Initialize the worker
            this.DownloadPatchWorker = new BackgroundWorker();
            this.DownloadPatchWorker.DoWork += new DoWorkEventHandler(DownloadPatch);
            this.DownloadPatchWorker.ProgressChanged += new ProgressChangedEventHandler(DownloadPatchProgress);
            this.DownloadPatchWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DownloadPatchDone);

            //Check Patch Level and force to update if there is a patch
            this.DownloadPatchWorker.RunWorkerAsync();

            while (DownloadPatchWorker.IsBusy)
            {
                Application.DoEvents();
            }
            */
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
            Process.Start("http://tarkinswg.com");
        }//Done

        private void btnOK_Click(object sender, EventArgs e)
        {
            pnlMain.Visible = true;
            pnlSettings.Visible = false;
        }//Done

        private void btnSWG_Click(object sender, EventArgs e)
        {
            String SettingsFile = Properties.Settings.Default.setFolder + "\\SWGEmu_Setup.exe";

            if (File.Exists(@SettingsFile))
            {
                //Open the SWG Settings.
                Process procTarkin = new Process();
                procTarkin.StartInfo.FileName = Properties.Settings.Default.setFolder + "\\SWGEmu_Setup.exe";
                procTarkin.StartInfo.WorkingDirectory = Properties.Settings.Default.setFolder;
                procTarkin.Start();
            }
        }//Done

        #endregion

        #region Methods

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

            var md5 = MD5.Create();

            // First download the MD5 sum of the current server patch file
            if (File.Exists(path: Properties.Settings.Default.setFolder + "\\PatchData.MD5"))
            {
                File.Delete(path: Properties.Settings.Default.setFolder + "\\PatchData.MD5");
            }
            DownloadFile("/PatchData.MD5");

            // Get MD5 sum of PatchData.csv on the server
            StreamReader patchFileMD5 = new StreamReader(Properties.Settings.Default.setFolder + "\\PatchData.MD5");
            String serverFileHash = patchFileMD5.ReadLine();
            patchFileMD5.Close();
            serverFileHash = serverFileHash.Trim(); // remove white spaces that prevent pattern matching

            String clientFileHash = "na";

            // If player has PatchData.csv, get its MD5 sum
            if (File.Exists(path: Properties.Settings.Default.setFolder + "\\PatchData.csv"))
            {
                clientFileHash = CalculateMD5(Properties.Settings.Default.setFolder + "\\PatchData.csv");
            }

            // Check for the final file in the download list to confirm they have completed downloading at least once in the past
            bool hasFinishedDownloadBefore = false;
            if (File.Exists(path: Properties.Settings.Default.setFolder + "\\string\\en\\test_motd.stf"))
            {
                hasFinishedDownloadBefore = true;
            }

                // Compare client and server patch file hash
                if (clientFileHash == serverFileHash && hasFinishedDownloadBefore == true)
            {
                //Patch level is correct. Allow user to play.
                btnMain.Invoke(new MethodInvoker(delegate { btnMain.Text = "PLAY"; }));
            }
            else
            {
                //We need to patch before the user can play
                File.Delete(path: Properties.Settings.Default.setFolder + "\\PatchData.csv");
                DownloadFile("/PatchData.csv");

                btnMain.Invoke(new MethodInvoker(delegate { btnMain.Text = "UPDATE"; }));
            }
        }

        private void CheckPatchProgress(object sender, ProgressChangedEventArgs e)
        {

        }

        private void CheckPatchDone(object sender, RunWorkerCompletedEventArgs e)
        {
            //Turn the main and force buttons back on
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.UseWaitCursor = false; }));
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Enabled = true; }));
            btnForcePatch.Invoke(new MethodInvoker(delegate { btnForcePatch.UseWaitCursor = false; }));
            btnForcePatch.Invoke(new MethodInvoker(delegate { btnForcePatch.Enabled = true; }));
        }

        private void DownloadPatch(object sender, DoWorkEventArgs e)
        {
            // Create sub directories if they are missing
            Directory.CreateDirectory(path: Properties.Settings.Default.setFolder + "\\miles");
            Directory.CreateDirectory(path: Properties.Settings.Default.setFolder + "\\string\\en");

            //Set the main and force patch buttons so they will not touch.
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Text = "WAIT"; }));
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.UseWaitCursor = true; }));
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Enabled = false; }));
            btnForcePatch.Invoke(new MethodInvoker(delegate { btnForcePatch.UseWaitCursor = true; }));
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
            string exludes = "feet";

            string localFileSum = "";

            string downloadThis = @"";

            // Download the files in the list
            for (int i= 0; i < fileNames.Count; i++)
            {
                // Format file name for download in case we need it
                downloadThis =  fileNames[i];
                SetFileStatus("Working (" + i + "/" + fileNames.Count + "): " + downloadThis.TrimStart('/'));

                // If fileName exist on client then compare fileName's md5 to sever's md5 for that file
                if (localFiles.Contains(fileNames[i]) && !exludes.Contains(fileNames[i]))
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

        /*
        private void DownloadPatchOLD(object sender, DoWorkEventArgs e)
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
            ftbNews.Invoke(new MethodInvoker(delegate { ftbNews.Height = 310; }));
            pbTotal.Invoke(new MethodInvoker(delegate { pbTotal.Visible = true; }));
            pbTotal.Invoke(new MethodInvoker(delegate { pbTotal.Value = 0; }));

            //Create some vars
            DirectoryInfo clientDir = new DirectoryInfo(Properties.Settings.Default.setFolder);

            StreamReader patchReader = new StreamReader(Properties.Settings.Default.setFolder + "\\PatchData.csv");

            FileInfo[] clientFiles = clientDir.GetFiles("*.*", SearchOption.AllDirectories);
            List<String> serverFiles = new List<String>();

            String excludeFile = "\\user.cfg,\\options.cfg,\\swgemu_machineoptions.iff";

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
                        if (serverFileLength == clientFileLength || excludeFile.Contains(clientFileName))
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
                long serverFileLength = Convert.ToInt64(serverData[1]);
                String serverHash = serverData[2];

                //Loop through clients to find the filename match
                foreach (FileInfo clientSearch in clientFiles)
                {
                    String clientFileHash;
                    String clientFileName = clientSearch.FullName.Replace(Properties.Settings.Default.setFolder, "");

                    //Fall through IF the client and server name matches EXCEPT for the exclude
                    if (serverFileName == clientFileName && !excludeFile.Contains(serverFileName))
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
        }
        */

        private void DownloadPatchProgress(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void DownloadPatchDone(object sender, RunWorkerCompletedEventArgs e)
        {
            //Show progress bars 
            pbTotal.Invoke(new MethodInvoker(delegate { pbTotal.Visible = false; }));

            //Patch level is correct. Allow user to play.
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Text = "PLAY"; }));
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.UseWaitCursor = false; }));
            btnMain.Invoke(new MethodInvoker(delegate { btnMain.Enabled = true; }));
            btnForcePatch.Invoke(new MethodInvoker(delegate { btnForcePatch.UseWaitCursor = false; }));
            btnForcePatch.Invoke(new MethodInvoker(delegate { btnForcePatch.Enabled = true; }));

            //Call the update patch version method
            UpdatePatchVersion();

        }

        private void DownloadFile(string Filename)
        {
            if (Filename == "")
                return;

            //Create FTP Connector
            WebClient ftpTarkin = new WebClient();
            ftpTarkin.Credentials = new NetworkCredential("anonymous", "");

            string savedFileName = Properties.Settings.Default.setFolder + Filename.Replace("/", "\\");

            Console.WriteLine("Now Downloading: " + savedFileName);

            //Download the file
            ftpTarkin.DownloadFile(@"ftp://192.168.0.55" + Filename, savedFileName);

            //Close the WebClient
            ftpTarkin.Dispose();
        }

        private void UpdatePatchVersion()
        {
            //Let's take the very first line and set it to our patchLevel setting
            StreamReader patchCheck = new StreamReader(Properties.Settings.Default.setFolder + "\\PatchData.csv");
            Properties.Settings.Default.patchLevel = patchCheck.ReadLine();
            Properties.Settings.Default.Save();
            patchCheck.Close();
            lblPatchLevel.Text = Properties.Settings.Default.patchLevel;
        }

        private void GetNews()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            //Grab data from announcement forums
            XmlDocument RSSNews = new XmlDocument();
            RSSNews.Load("http://tarkinswg.com/index.php?/discover/all.xml/");

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
            // tarkinlogin.ddns.net
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            System.Net.ServicePointManager.Expect100Continue = false;

            try
            {
                using (TcpClient tcpClient = new TcpClient("tarkinlogin.ddns.net", 44455))
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
                lblStatusEnum.Text = "Status: Down";
            }
            catch (SocketException e)
            {
                lblStatusEnum.Text = "Status: Down";
            }
        }

        private void ParseStatusXML(String stsData)
        {
            
            // Original code to get data from server
            //// Create a TcpClient.
            //TcpClient stsClient = new TcpClient("login.swgemu.com", 44455);

            ////This is required to be sent to the server so it will generate a response
            //String stsSend = "\n";
            //// Translate the response into ASCII and store it as a Byte array.
            //Byte[] stsASCII = System.Text.Encoding.ASCII.GetBytes(stsSend);

            //// Get a client stream for reading and writing.
            //NetworkStream stsStream = stsClient.GetStream();

            //// Send the message to the connected TcpServer. 
            //stsStream.Write(stsASCII, 0, stsASCII.Length);

            //// Buffer to store the response bytes.
            //stsASCII = new Byte[512];

            //// String to store the response ASCII representation.
            //String stsData = String.Empty;

            //// Read the first batch of the TcpServer response bytes.
            //Int32 bytes = stsStream.Read(stsASCII, 0, stsASCII.Length);
            //stsData = System.Text.Encoding.ASCII.GetString(stsASCII, 0, bytes);

            //// Close everything.
            //stsStream.Close();
            //stsClient.Close(); 

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

        private void ftbNews_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNews_Click(object sender, EventArgs e)
        {

        }

        private void lblAbout_Click(object sender, EventArgs e)
        {
            if (lblAbout.Text == "News")
            {
                lblAbout.Text = "About";
                GetNews();
            }
            else
            {
                lblAbout.Text = "News";
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
            
            
        }

        private void lblFileStatus_Click(object sender, EventArgs e)
        {

        }
    }

}

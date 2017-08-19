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
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UpdaterPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo patchDir = new DirectoryInfo(Directory.GetCurrentDirectory());

            String startDir = Directory.GetCurrentDirectory();

            FileInfo[] patchFiles = patchDir.GetFiles("*.*", SearchOption.AllDirectories);

            String patchData;
            String patchFileHash;
            String patchFileName;
            long patchFileSize;

            StreamWriter output = new StreamWriter(Directory.GetCurrentDirectory() + "\\PatchData.csv");

            foreach (FileInfo patchSearch in patchFiles.ToList())
            {
                //We need to exclude the UpdaterPrep and the csv if exists as well as the ui.log
                if (patchSearch.Name != "UpdaterPrep.exe" && patchSearch.Name != "PatchData.csv" && patchSearch.Name != "ui.log" && ! patchSearch.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    //Let's get the MD5 of the current file
                    using (var md5 = MD5.Create())
                    {
                        using (var stream = File.OpenRead(patchSearch.FullName))
                        {
                            patchFileHash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", String.Empty);
                        }
                    }

                    //Grab the file name
                    patchFileName = patchSearch.FullName.Replace(startDir, "");

                    //Grab the file size
                    patchFileSize = patchSearch.Length;

                    //Write the data to the string
                    patchData = patchFileName + "," + patchFileSize + "," + patchFileHash;

                    //Write the string to file
                    output.WriteLine(patchData);
                }

            }

            //Close out
            output.Close();        

        }
    }
}

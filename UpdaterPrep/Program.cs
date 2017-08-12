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

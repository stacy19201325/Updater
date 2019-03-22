These files must be on the patch server for the launcher to function. 

### PatchData.csv

- Contains the list of files that must be downloaded as well as MD5 sums of each file.
- EVERY TIME you add/remove/modify an entry in this file you MUST generate a new MD5 sum for the files you change, including this file.

### PatchData.MD5

- This file contains the MD5 sum for the above file.
- The patcher downloads this file and checks the MD5 sum inside it against the MD5 sum of PatchData.csv on the player's computer. If they don't match, the player must patch! The current PatchData.csv file will then be downloaded and patching will ensue.

### Generating an MD5 Sum in Windows

- Very easy to generate using the command prompt
- Start > Run > cmd.exe
- Type: CertUtil -hashfile C:\TEMP\MyDataFile.img MD5
- Copy/Paste the generate output to your desired location
  
MD5 sums look like this: 21e77bcbe81c83284aeea5127c197718  
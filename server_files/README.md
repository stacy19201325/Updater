The following file must be on the patch server for the launcher to function. 

### PatchData.csv

- Contains the list of files that must be downloaded as well as MD5 sums of each file.
- Comma separate value format.
- Add new entries on the TOP of this file.
- EVERY TIME you add/modify a file, you MUST generate a new MD5 sum and put it in this file.
- This file is downloaded by the pactcher every time the patcher is run.


### Generating an MD5 Sum in Windows

- Very easy to generate using the command prompt
- Start > Run > cmd.exe
- Type: CertUtil -hashfile C:\TEMP\MyDataFile.img MD5
- Copy/Paste the generate output to your desired location
  
MD5 sums look like this: 21e77bcbe81c83284aeea5127c197718  

Alternatively, you can use a utility such as [HashMyFiles](http://www.nirsoft.net) to has single files or whole directories of files.
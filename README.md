# Tarkin's Revenge Updater
**Version 2.0** - March 2019  

This program is designed to keep the client files for the Tarkin's Revenge server up to date.

## Using The Updater

- Download the updater from the [current_release](./current_release) directory in this repo.
- Make a new folder on your computer, such as C:\TarkinII and put the Tarkin updater into the folder.
- Double click the updater (Tarkin's Revenge Launcher.exe )and point it to the folder you made above. Windows 10 may give you a warning in a big window with the only button might be Don't Run. Should this occur, there is a link in the lower right of the box that will present you with a "Run Anyway" button when you click it. You'll only see this message the first time you run the program.
- The updater will begin downloading your files when you press the Update button.
- Wait until the download is complete and then press the Play button to play the game.
- Right click the updater and choose "Pin to Start Menu" or create a link to it where you happen to find convenient.

## Tips and Tricks

- If the game doesn't work properly, you can force the patcher to repair your files by going to the Setting page and clicking the Force Update button and then the Update button.
- If you get a pop-up message indicating that the download server can't be located, you can go to the Settings page and try using the Update or Reset Default buttons for the download link (url). After you've done that, press Force Update and then the Update button. If that doesn't get the downloads going and the server status show the server is online, then check the forum or Discord for more help.

## Requirements

- Windows Vista/7/8/10 32bit or 63bit
- Microsoft .Net Framework 4.5.2
- The Internet

## Features

- Downloads files over http, https, and anonymous ftp.
- Client-side over-rides for almost all important settings.
- Build in, easy to use file exclude/ignore list.
- On first installation, prompts to set resolution.
- It's a very small program.

## How It Works
On the server are bunch of the files that the client needs. Every so often some of the files on server will change or more files will be added, so the client need to be kept informed of the changes. This is where a file on the server called PatchData.csv comes into play - it's an upto date list of all the files in client would need. The patcher checks this file when it starts.  

To speed things along a bit, the server also host a file called PatchData.MD5. The patcher downloads this file first. If the client already has the file, the patcher will deleted and download it again. Inside this file is the "cryptographic file hash", hence forth referred to as an "MD5 sum", of the PatchData.csv file. The patcher downloads this files, opens it, and reads the sum. Provided that PatchData.csv is already on the client's computer, the patcher will generate an MD5 sum for it and then compare it to the one it just read from the PatchData.MD5 that was located on the server. This only takes a moment and if the sums match, then the client is already up to date and the player can play the game.  

Should the sums not match, the patcher will then delete the local PatchData.csv and download it again. After this the patcher will read all the file names and MD5 sums contained in PatchData.csv into arrays, after which which it will generate new MD5 sums for all client files and compare them, on at a time, against the sums it read from PatchData.csv. Any missing files are downloaded and any files whose sums fail the matching process will be deleted and downloaded again.  Once all files have been downloaded, the patcher presents the player with the Play button, which they may click to launch the game.  

The patcher is able to download files from either a web server (http) or an anonymous ftp server by simply setting the URL to either. I didn't test it with secure ftp.  

Note: The above description (and *all* other documentation found here) applies to version 2.0+ of the patcher and that the "UpdaterPrep" program is not used any longer.

## About Programming

- Microsoft Visual Studio 2017
- C# / Windows Forms project

On the programming side of Version 2, I (Tatwi) did my best to slam the functionality and visual appeal into patcher using the horrid nightmares that are the above noted programming monstrosities. By no means am I experienced with either Visual Studio or C# or even Windows Forms for that matter, but that's what I had to deal with on short notice, so I dealt. JavaScript/C++/Lua/Python/Bash are more my thing, ya dig? :)  

Anyway, logic wise the program is setup in such a way that all of the important values can be over-ridden using the user.config file that is stored in the following location:  

C:\Users\Rob\AppData\Local\Microsoft\Tarkin's_Revenge_Launcher_<file hash>  

where <file hash> looks like so, p30lcfd3m4zsqhdjmcuuez2dvsp2nxf1. The only exception to this at the moment is the value "/string/en/test_motd.stf", which the patcher associates with the final file in the list to download. 

On the settings page of the patcher there is a button that will open up the settings file, where you can manually edit the values. Simply change the values you want, save the file, close the patcher, and relaunch it. There is also an area where you are able to type in the download url and save it to your setting file (this was handy while I was working on Version 2, making it easy to toggle between my web server and ftp server).  

Information on how to use PatchData.csv and PatchData.MD5 can be found in the [server_files](./server_files) directory. Patcher also pulls an xml formated RSS feed and a text based "about page", both of which are customizable in the client settings file. A copy of the configuration is located in [App.config](./Updater/App.config).  

## Credits

- **Version 1:**  [Steven Helm](https://github.com/Trakaa) (Trakaa) - 2017
- **Version 2:** [R. Bassett Jr.](https://github.com/Tatwi) (Tatwi) - 2019
- **Art:** [Skolten](https://tarkinswg.com/index.php?/profile/7-skolten/)

## Maintained By

- [R. Bassett Jr.](https://github.com/Tatwi) (Tatwi)

## Future Updates
- Tidying and fixes only; This here beast be functionally complete!
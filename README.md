# MupenUtilities<img src="https://github.com/Aurumaker72/MupenUtilities/blob/main/Resources/mupengreen.png" align="right" />
![Badge1](https://img.shields.io/github/downloads/Aurumaker72/MupenUtilities/latest/total?label=Latest%20Release&logoColor=green) ![Badge2](https://img.shields.io/github/last-commit/Aurumaker72/MupenUtilities?label=Latest%20Commit) ![Badge3](https://img.shields.io/github/license/Aurumaker72/MupenUtilities?label=License) ![Badge3](https://img.shields.io/badge/Maintained-yes-green) ![Badge4](https://img.shields.io/github/repo-size/Aurumaker72/MupenUtilities?label=Repo%20size)


## ⚙️ Feature-rich Utility application for Mupen64 ⚙️</b> 


![](https://raw.githubusercontent.com/Aurumaker72/MupenUtilities/multicontroller/app.PNG)
`M64 Editor 2021 Refurbished Epic Edition`

## M64
The data of any M64 file is presented in a simple interface.
To change the data, select Read-write mode by clicking on the upper left checkbox.

You can save a modified copy of the selected M64 by clicking the bottom left button "Save M64"

### Header
You can view and edit all meaningful M64 Header data such as
- Rerecords
- Plugin names
- Author
- Description
- Controller Flags
  - Enabled
  - Mempak
  - Rumblepak
- All else...


### Input
You can view and edit all M64 Inputs on each frame in a clean, interactive TASInput style interface.
Modifying the controller flags is possible too, for example enabling or disabling a controller, its' mempak and rumblepak

### Hex Viewer
View any byte (offset) of the selected movie as hexadecimal string.

This opens up limitless possibilities of finding data in a movie file.

### Frame Control
You can seek back and forth, reverse playback, step frames and more intuitive controls.

Playing the movie back in real-time (30 FPS) is also possible.

### Replacement
Same as M64 Editors' "Replacement" feature. Allows you to replace any sequence of frames from one movie to another. 

### TAS Studio
You can view all inputs in a neatly arranged and compacter grid. 

This is useful for those who don't want to waste time skimming through the movie

### Advanced
Dump a movie's raw input data to a file.

Change the raw input value at any frame in a debug menu located under "More" button.

Get the raw input value at any frame in a dialog located under "More" button. 

## Savestate

### RDRAM
View and edit savestates' RDRAM section. You can save and block special addresses to make it easier to remember what goes where.

## Mupen [WIP]
Hook into mupen64 process memory and view some data like version string.

### __Mupen hook might be unbearably slow or not work on some systems!__

## Requirements
__Using__
- M64, ST or Mupen exe
- OS newer than Windows 7
- more than 1 GB RAM
__Building__
- Visual Studio 2019
- WinSDK 10
- VS .NET C# Packages

*Will be autoinstalled by Visual Studio*

- Octokit
- NRG Winforms Control pack

## Building
To build your own Mupen Utilities executable:
- [Download](https://github.com/Aurumaker72/MupenUtilities/zipball/main) the repository
- If needed, [Unblock](https://4sysops.com/wp-content/uploads/2015/01/Unblock-in-File-Explorer.png) the zip archive
- Unzip/Unpack the archive
- Double click on the .sln file
- On the top, select "Release x86" [target](http://ladydebug.com/blog/myimages/dotnetcore-framework/applicationpropertiesdotnetcore.png)
- Press CTRL+B
- Wait for the build to finish

In the bin/x86/Release folder you will find a MupenUtilities executable and the required dlls.

## Other
🌐This program automatically checks for updates when internet is connected.

⚠️This program accesses other program's memory and might be marked as unsafe. 

🥚There is a easter egg in the TAS Studio utility dialog

🧵This program is multithreaded

🎛️This program does not fully support more than one controller

🖌️This application has themes

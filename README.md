## 🛑 Please refer to my continuation of MupenUtilities, [MupenToolkit](https://github.com/Aurumaker72/MupenToolkit)
### This project is not actively maintained due to technical reasons, however, [MupenToolkit](https://github.com/Aurumaker72/MupenToolkit) is. 

-
-
-
-

# MupenUtilities<img src="https://github.com/Aurumaker72/MupenUtilities/blob/main/Resources/mupengreen.png" align="right" />
[![s](https://forthebadge.com/images/badges/not-a-bug-a-feature.svg)](https://forthebadge.com) [![the](https://forthebadge.com/images/badges/no-ragrets.svg)](https://forthebadge.com) [![aaa](https://forthebadge.com/images/badges/you-didnt-ask-for-this.svg)](https://forthebadge.com)

[![Release](https://img.shields.io/github/v/release/Aurumaker72/MupenUtilities?label=Release)](https://github.com/Aurumaker72/MupenUtilities/releases)
![Badge2](https://img.shields.io/github/last-commit/Aurumaker72/MupenUtilities?label=Latest%20Commit) ![Badge3](https://img.shields.io/github/license/Aurumaker72/MupenUtilities?label=License) ![Badge3](https://img.shields.io/badge/Maintained-partial-orange) 



## ⚙️ Feature-rich Utility application for Mupen64 ⚙️</b> 
### [Usage Guide](https://github.com/Aurumaker72/MupenUtilities/blob/main/usage.md) 
[Troubleshooting Guide](https://github.com/Aurumaker72/MupenUtilities/blob/main/troubleshooting.md)

 ⚠️ *This program has had time for stability fixes, but it is still very unstable. Please report any instabilities or bugs and I will try my best, with my limited time, to fix them.* ⚠️

![](https://github.com/Aurumaker72/MupenUtilities/blob/main/showcase.PNG)


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
View any byte- or offset range of the selected movie interpreted in different datatypes.

### Frame Control
You can seek back and forth, reverse playback, step frames and more intuitive controls. Press backslash for frame advance.

Playing the movie back in real-time (30 FPS) is also possible.

### Replacement ⚠️*WIP*
Same as M64 Editors' "Replacement" feature. Allows you to replace any sequence of frames from one movie to another. 

### TAS Studio
You can view and edit all inputs in a neatly arranged and compact grid, where every 2nd row has another background color for clarity.
Please note that TAS Studio can be used in a "live" mode, where it dynamically updates based on movie data changes and allows you to directly input from TAS Studio to the movie by dragging, clicking, etc..., but also includes a "static" mode, where it merely displays the original movie data.

### Advanced
Convert RNG Values to Indicies, modify Savestates, modify values bytewise, change the CRC.

### Input Analysis
View processed statistics and data about your movies' input sets controller-wise.

## Combo

### General
Everything but "Replacement" is also available for [combo files](https://github.com/mkdasher/mupen64-rr-lua-/blob/master/tasinput_plugin/src/DefDI.cpp#L1549).

## Savestate

### RDRAM
View and edit savestates' RDRAM section. You can save and block special addresses to make it easier to remember what goes where.

### Game
View and edit some simple game variables.

Supported Games:
- Super Mario 64 USA 1

## Mupen
Hook into Mupen64 process memory and view some data like version string.
Keep in mind that this Mupen hook is very slow and might not work on some systems.

## Requirements

__Using__
- M64, ST or Mupen exe
- OS newer than Windows 7
- more than 1 GB RAM

__Building__

- Visual Studio 2019 or newer
- WinSDK 10
- VS .NET C# Packages

You may need to manually [link](https://www.webucator.com/article/how-to-add-references-to-your-visual-studio-projec/) the following libraries.
You can find the respective dll's for these libraries in the latest MupenUtilities release folder.
- [CircularProgressBar](https://github.com/falahati/CircularProgressBar)
- [Octokit](https://www.nuget.org/packages/Octokit/)
- ~~MRG.Controls.UI~~
- *ICSharpCode.SharpZipLib*

## Building

* You may need to manually set the /unsafe compiler flag.

To build your own Mupen Utilities executable:
- [Download](https://github.com/Aurumaker72/MupenUtilities/zipball/main) the repository
- If needed, [Unblock](https://4sysops.com/wp-content/uploads/2015/01/Unblock-in-File-Explorer.png) the zip archive
- Unzip/Unpack the archive
- Double click on the .sln file
- On the top, select "Release x86" [target](http://ladydebug.com/blog/myimages/dotnetcore-framework/applicationpropertiesdotnetcore.png)
- Press CTRL+B
- Wait for the build to finish

In the bin/x86/Release folder you will find a MupenUtilities executable and the required dlls.

**Important:** Do not separate the dlls and executable.

## Other
-This program automatically checks for updates when internet is connected, so expect longer start-up times with slow internet

-This program accesses other program's memory and might be marked as unsafe

-There is a easter egg in the TAS Studio utility dialog

-This program is multithreaded

-This application supports themes

-This application features a special exception handler which allows fast reporting of bugs

-I do not have all the time in the world to maintain this, and began this project with less knowledge than now, so expect bad code

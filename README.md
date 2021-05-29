# MupenUtilities
### __This app is work in progress! Expect bugs which can heavily impact usability__
![MupenUtilities](https://raw.githubusercontent.com/Aurumaker72/MupenUtilities/input-roll/screenshot1.PNG "Mupen64 Utilities")<br>
Utility app for [Mupen64](https://github.com/mkdasher/mupen64-rr-lua-/)<br>
This can be seen as a continuation of the M64 Editor by [mkdasher](https://github.com/mkdasher/)

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
- all else...

### Input
You can view and edit all M64 Inputs on each frame in a clean, interactive TASInput style interface.
Modifying the controller flags is possible too, for example enabling or disabling a controller, its' mempak and rumblepak

### Hex Viewer
View any byte (offset) of the selected movie as hexadecimal string.

This opens up limitless possibilities of finding data in a movie file.

##### Frame Control
You can seek back and forth, reverse playback, step frames and more intuitive controls.

Playing the movie back in real-time (30 FPS) is also possible.

##### Replacement
Same as M64 Editors' "Replacement" feature. Allows you to replace any sequence of input frames from one movie to another. 

The N64 may or may not poll inputs a lot of times within a frame so only use this if you know exactly what you're doing.

### TAS Studio
You can view all inputs in a neatly arranged and compacter grid. 

This is useful for those who don't want to waste time skimming through the movie

### Advanced
You can dump a movie's raw input data to a file.
You can change the raw input value at any frame in a debug menu located under "More" button.

## Other
This program checks for updates

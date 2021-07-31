# Mupen Utilities User Guide
 
### How to load a M64
- Start Mupen Utilities
- Click on the "M64" radio button
- Right beside it, press the button labeled "Browse M64"
- Navigate and select your M64 file

The program will immediately start loading the movie file after selection. Wait for the loading process to finish and the dialog to expand.
If a warning appears or any text turns red, your M64 might be corrupted. Use the M64 diagnostic tool to check if your movie is corrupted. 

_Example Image_
<img src="https://github.com/Aurumaker72/MupenUtilities/blob/main/mupenutilities-1.PNG" align="right" />

### How to edit a M64
- With a M64 loaded, turn on Read-write mode by unchecking "Read-only"
- You can edit buttons by either clicking on TAS Studio cells or the checkboxes.
- You can edit joystick by either moving the joystick while holding down leftclick or by manually typing joystick coordinates into the X and Y fields and pressing enter.

On how to save your edited M64, visit [How to save a M64](###how-to-save-a-m64)  

### How to save a M64
- With a M64 loaded, click either the "Save" or "Save As" buttons at the bottom.

### How to view statistics about your M64
- With a M64 loaded, click on the "More" button inside the "Input" group box.

### How to replace (hex) two M64s together

<img src="https://github.com/Aurumaker72/MupenUtilities/blob/main/mupenutilities-2.PNG" align="left" />

- At the top, click on the "Replacement" radiobutton and then on the button named "Replacement" next to it.
- Select your Source and Target movies by clicking the respective "Browse" button. The output movie is optional; leave it empty for the output to be placed in the same folder with the program or select a path for it to be saved there.
- Select the range of frames from which you want to replace (e.g from frame 4 to frame 9)
- Click "Go" to start the process.

Enable the "Replace all" checkbox to completely copy the source movie inputs to the target movie. 

Erase from original will erase the selected range (from->to) from the original movie file. This option directly overwrites the file, so make sure to make a backup

The copy mode dictates how the inputs get copied from one movie to another.
- Default - Use the recommended settings. Dont change this unless you know what you are doing
- Assign - Simple copy
- OR - Perform a bitwise OR on the source
- AND - Perform a bitwise AND on the source
- XOR - Perform a bitwise XOR on the source
- The 'NOT' checkbox is a modifier which, when checked, performs a bitwise NOT on the source before all other operations.
- The 'Erase from original' checkbox is a modifier which, when checked, deletes the From-To frame data from the original movie.

#### Troubleshooting replacement
"Identical Paths" - The source and target movie are the same

"Invalid Path" - The source or target path/file does not exist

"Target movie is shorter than source movie" - The target movie is not big enough to fit the source movie

"Integer parsing error" - The text in the "From frame" or "To frame" textboxes isn't a number

**"Invalid from/to value"** is a vague error and can mean

- Begin frame value is larger than end frame value.

- End frame value is larger than movie.

- Frame values are equal.

- Frame value is negative.


### How to find the first button/joystick value in a movie
Do you want to find the first frame at which a specific button or joystick combination is held?
- With a M64 loaded, open the Input Analysis dialog by clicking on "More" and then on "Input Analysis"
- Switch to the tab "Finder"
- Choose your button/joystick
- Press "Go"

### Rundown of "More" context menu
This menu changes with each update, but I'll try to keep this section relevant.
- Simple Mode: toggles between a simple view with less controls and the full view

- Input Analysis: opens the [Input Analysis](###how-to-find-the-first-button/joystick-value-in-a-movie) dialog

- Movie Diagnostic: opens the Movie Diagnostic dialog and automatically performs all checks

- Expert Tools: opens the Expert Tools dialog where you can view and edit movie data byte by byte

- Get Input: shows a messagebox explaining how to understand a input data sample and shows you the data in a nice format

- Themes: opens a dropdown where you can select themes

- Antialiased Joystick: enables or disables antialiasing on the joystick drawing

- Aggressive Override: when enabled, calls input-related functions more often and prevents weird edge cases from happening. **It is VERY recommended you keep this on**

- Joystick Keyboard: when enabled, allows you to control the joystick using WASD, arrow keys

- Generate Telemetry Data: generates a big file with many informations about your Mupen Utilities session and prompts you to send it to me. I appreciate this :)

- Dump Movie: Dumps all movie input data to a file

- Load CRC database: Loads CRC database from crc.txt located in the same folder as the executable

 Acceptable format: `crc 12345678`. The text after crc should be a hex string
 
 You can find the recommended resource here: https://github.com/libretro/libretro-database/blob/master/metadat/no-intro/Nintendo%20-%20Nintendo%2064.dat
 
- Debug: Crash - Throws a exception and should cause the Mupen Utilities exception window to pop up

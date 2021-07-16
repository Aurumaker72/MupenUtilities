# Mupen Utilities User Guide
 
### How to load a M64
- Start Mupen Utilities
- Click on the "M64" radio button
- Right beside it, press the button labeled "Browse M64"
- Navigate and select your M64 file

The program will immediately start loading the movie file after selection. Wait for the loading process to finish and the dialog to expand.
If a warning appears or any text turns red, your M64 might be corrupted. Use the M64 diagnostic tool to check if your movie is corrupted. 

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

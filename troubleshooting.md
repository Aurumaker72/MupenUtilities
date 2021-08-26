# Mupen Utilities Troubleshooting Guide
 
### TASStudio is slow
If you are experiencing major slowdown due to TASStudio's loading, right click TASStudio and disable "Live TAS Studio" and "Reload on controller change"

Please note that the latter option will make TASStudio unusable on multicontroller movies and the first option will make TASStudio not respond to in-app input changes in the movie.

### Joystick is slow
If you are experiencing lag when dragging the joystick, click the "More..." button in the Input groupbox and disable "Antialiased Joystick"

### Joystick doesn't work
If your joystick shows this,

![](https://github.com/Aurumaker72/MupenUtilities/blob/main/bwJoystick.png)

select another theme and restart the program.
<details>
  <summary>Why?</summary>
 This means the GDI+ drawing routine of the joystick has failed. A fix for this is unknown as of now but i'm looking into it.
 
 Anytime the gray MupenUtilities logo is visible, it means something has failed.
</details>

### Can't type in textboxes

*This issue should be resolved on >1.9*

If you are experiencing focus loss and unresponsiveness when typing in textboxes, click the "More..." button in the Input groupbox and disable "Joystick Keyboard"

### Unpausing/seeking through movie lags
Get a better computer. But first test your PC using [TimerBench](https://www.overclockers.at/articles/timerbench-ein-benchmark-fuer-windows-timer)

### Desyncs
Please scan your movie using the Movie Diagnostic tool under "More..." and "Movie Diagnostic".

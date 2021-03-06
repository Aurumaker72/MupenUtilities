using System;

namespace MupenUtils.Helpers
{
    public static class TipProvider
    {
        public static Random rng = new Random();
        public static string[] tips =
        {
            "Right click the selector buttons will enable Autodetect mode",
            "Press backslash to frame advance",
            "Right click on the joystick to make it follow your mouse",
            "Pressing Escape on the X and Y textboxes will unfocus them",
            "\'Sticky\' will make your inputs stay on the next frame",
            "\'Dump Inputs\' will dump all input data to a file",
            "Try pressing \'Page up\' and \'Page down\' on the trackbar",
            "Check for updates with the button below",
            "Text will turn red if the program deems the property suspicious",
            "\'Set Input\' will allow you to set the raw input data for a frame",
            "Right click TAS Studio to get a useful menu",
            "\'CTRL+H\' on TAS Studio to get a useful menu",
            "Some dialogs are disabled until loading a m64",
            "\'F11\' and \'ALT+ENTER\' will toggle fullscreen mode",
            "Mupen64 can cause file access conflicts with Mupen Utilities",
            "There is an easter egg in the TAS Studio Utility dialog",
            "Debug target builds will print information to console",
            "The bit arhitecture is displayed in status bar",
            "Non-plaintext values are displayed in hexadecimal",
            "Some values are unmodifiable",
            "The \"More\" button has useful dialogs",
            "\'Simple Mode\' disables some technical features to make usage simpler",
            "Drag and drop is supported",
            "Right clicking the \'New Tip\' button will show all tips",
            "CTRL+Scroll in TAS Studio will zoom in and out",
            "Sending the debug log upon a crash helps me fix bugs",
            "\'Live TAS Studio\' will keep TAS Studio up-to-date with your latest inputs",
            "Most modifiable settings are saved to config",
            "Right click the movie trackbar to change its properties",
            "Press \'F1\' to toggle Encoding Mode",
            "Scroll on the X, Y and Angle textboxes for the joystick to change them",
            "Use the M64 Diagnostic tool under \'More\' to diagnose movies which act weird",
            "Press space to pause/unpause playback",
            "Press \'F5\', \'F6\' to begin and end a region respectively"
        };

        public static string GetRandomTip()
        {
            return tips[rng.Next(0, tips.Length)];
        }
    }
}

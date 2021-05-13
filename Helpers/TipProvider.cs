using System;

namespace MupenUtils.Helpers
{
    public static class TipProvider
    {
        public static Random rng = new Random();
        public static string[] tips =
        {
            "Right click the M64 radio button to bypass the file filter",
            "Press backslash to frame advance",
            "Right click on the joystick to make it follow your mouse",
            "Pressing Escape on the X and Y textboxes will unfocus them",
            "\'Sticky\' will make your inputs stay on the next frame",
            "\'Dump Inputs\' will dump all input data to a file",
            "Try pressing \'Page up\' and \'Page down\' on the trackbar",
            "Check for updates with the button below",
            "You are on version " + MainForm.PROGRAM_VERSION,
            "Labels will turn red if the program deems the property incompatible",
            "\'Set Input\' will allow you to set the raw input data for a frame",
            "Right click TAS Studio to get a useful menu",
            "\'CTRL+H\' on TAS Studio to get a useful menu",
            "Some dialogs are disabled until loading a m64",
            "\'F11\' and \'ALT+ENTER\' will toggle fullscreen mode",
        };
        public static string GetRandomTip()
        {
            return tips[rng.Next(0,tips.Length)];
        }
    }
}

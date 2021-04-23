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
            "Scrolling on the joystick will move it",
            "You can\'t write letters in some textboxes",
            "Clicking on the Mupen Utilities logo will open the repo in your browser",
            "If the Mupen Utilities window turns gray\nand all controls are hidden your input file is corrupted",
            "Press this text to copy the current tip",
            "Press \'All tips\' to show all tips"
        };
        public static string GetRandomTip()
        {
            return tips[rng.Next(0,tips.Length)];
        }
    }
}

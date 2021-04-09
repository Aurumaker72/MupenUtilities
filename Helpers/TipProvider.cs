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
            "Pressing Escape on the X and Y textboxes will unfocus them"
        };
        public static string GetRandomTip()
        {
            return tips[rng.Next(0,tips.Length)];
        }
    }
}

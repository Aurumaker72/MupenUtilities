using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ExtensionMethods
{
    public static int LowWord(this int number) => number & 0x0000FFFF;
    public static int LowWord(this int number, int newValue) => (int)((number & 0xFFFF0000) + (newValue & 0x0000FFFF));
    public static int HighWord(this int number) => (int)(number & 0xFFFF0000);
    public static int HighWord(this int number, int newValue) => (number & 0x0000FFFF) + (newValue << 16);

    public static int Clamp(int value, int min, int max) => (value < min) ? min : (value > max) ? max : value;
}
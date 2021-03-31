using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ExtensionMethods
{
    public static int LowWord(this int number)
    { return number & 0x0000FFFF; }
    public static int LowWord(this int number, int newValue)
    { return (int)((number & 0xFFFF0000) + (newValue & 0x0000FFFF)); }
    public static int HighWord(this int number)
    { return (int)(number & 0xFFFF0000); }
    public static int HighWord(this int number, int newValue)
    { return (number & 0x0000FFFF) + (newValue << 16); }
}
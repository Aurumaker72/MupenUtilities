using System;
using System.Collections.Generic;
using System.IO;
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

    public static void AdjustY(ref sbyte value) {
        if (value > -1) value--;
        else value++;
    }
    public static bool ValidStringInt(string str, int min, int max)
    {
        if(str.Length == 0||String.IsNullOrEmpty(str)||String.IsNullOrWhiteSpace(str))return false;
        foreach(char c in str){if(c<'0'||c>'9')return false;}
        int r=Int32.Parse(str);
        if (r>=min&&r<=max)
        return true;
        return false;
    }
    public static bool ValidStringSByte(string str)
    {
        if(str.Length == 0||String.IsNullOrEmpty(str)||String.IsNullOrWhiteSpace(str))return false;
        foreach(char c in str){if(c<'0'||c>'9')return false;}
        int r=int.Parse(str);
        if (r>sbyte.MaxValue||r<sbyte.MinValue)return false;
        return true;
    }
    public static string ByteArrayToString(byte[] ba)
    {
        StringBuilder hex = new StringBuilder(ba.Length * 2);
         foreach (byte b in ba)
             hex.AppendFormat("{0:x2}", b);
        
         return "0x" + hex.ToString().ToUpper();
         
    }
    public static string StringASCII(string str)
    {
        return ASCIIEncoding.ASCII.GetString(ASCIIEncoding.UTF8.GetBytes(str));
    }
    public static byte[] StringBytes(string str)
    {
        return ASCIIEncoding.ASCII.GetBytes(str);
    }
    public static int BoolToInt(bool value)
    {
        if (value) return 1;
        return 0;
    }
    public static bool IntToBool(int value)
    {
        return value != 0;
    }
    public static void SetBit(ref int value, bool bitval, int bitpos)
    {
        if (!bitval)value&=~(1<<bitpos);else value|=1<<bitpos;
    }
    public static bool ValidPath(string path, bool allowRelativePaths = false)
    {
        bool isValid = true;
    
        try
        {
            string fullPath = Path.GetFullPath(path);
            if (allowRelativePaths)
            {
                isValid = Path.IsPathRooted(path);
            }
            else
            {
                string root = Path.GetPathRoot(path);
                isValid = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
            }
        }
        catch{isValid = false;}
    
        return isValid;
    }
}
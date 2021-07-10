using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public static class ExtensionMethods
{
    public static int LowWord(this int number) => number & 0x0000FFFF;
    public static int LowWord(this int number, int newValue) => (int)((number & 0xFFFF0000) + (newValue & 0x0000FFFF));
    public static int HighWord(this int number) => (int)(number & 0xFFFF0000);
    public static int HighWord(this int number, int newValue) => (number & 0x0000FFFF) + (newValue << 16);

    public static int Clamp(int value, int min, int max) => (value < min) ? min : (value > max) ? max : value;
    //public static void AdjustY(ref sbyte value) {
    //    if (value > -1) value--;
    //    else value++;
    //}

    public unsafe static void SetByte(int* val, byte b, int pos) {
        *val &= ~((int)0xff << (8 * pos)); 
        *val |= ((int)b << (8 * pos)); 
    }

    public static bool ValidStringInt(string str, int min, int max)
    {
        if (str.Length == 0 || String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str)) return false;
        foreach (char c in str) { if (c < '0' || c > '9') return false; }
        int r = Int32.Parse(str);
        if (r >= min && r <= max)
            return true;
        return false;
    }

    public static byte[] ReadAllBytes(Stream stream)
    {
        using (var ms = new MemoryStream())
        {
            stream.CopyTo(ms);
            return ms.ToArray();
        }
    }

    public static bool ValidHexStringInt(string str, int min, int max)
    {
        //str = str.ToUpper();

        if (str.Length == 0 || String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str) || !Regex.IsMatch(str, @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z")) return false;

        int r;



        if (str.Contains("x"))
            r = Convert.ToInt32(str, 16);
        else
            r = Int32.Parse(str);

        if (r >= min && r <= max)
            return true;
        return false;
    }
    public static bool ValidStringSByte(string str)
    {
        if (str.Length == 0 || String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str)) return false;
        foreach (char c in str) { if (c < '0' || c > '9') return false; }
        int r = int.Parse(str);
        if (r > sbyte.MaxValue || r < sbyte.MinValue) return false;
        return true;
    }
    public static Image ImageFromBytes(byte[] dataArr)
    {
        using (var ms = new MemoryStream(dataArr))
        {
            return Image.FromStream(ms);
        }
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
    public static void SetBit(ref uint value, bool bitval, int bitpos)
    {
        if (!bitval) value &= ~((UInt32)1 << bitpos); else value |= (UInt32)1 << bitpos;
    }
    public static void SetBit(ref int value, bool bitval, int bitpos)
    {
        if (!bitval) value &= ~(1 << bitpos); else value |= 1 << bitpos;
    }
    public static int SetBitAlt(int value, int bitpos, bool flag)
    {
        if(!flag) return (value & ~bitpos);
        else return (value | bitpos);
    }
    public static bool GetBit(int value, int bitpos)
    {
        return 1 == ((value >> bitpos) & 1);
    }
    public static bool GetBit(uint value, int bitpos)
    {
        return 1 == ((value >> bitpos) & 1);
    }
    public static bool Button(uint value, int bitpos)
    {
        return (value & (int)Math.Pow(2, bitpos)) != 0;
    }
    public static bool Button(int value, int bitpos)
    {
        return (value & (int)Math.Pow(2, bitpos)) != 0;
    }
    public static int IndexOfOccurence(this string s, string match, int occurence)
    {
        int i = 1;
        int index = -1;

        while (i <= occurence && (index = s.IndexOf(match, index + 1)) != -1)
        {
            if (i == occurence)
                return index;

            i++;
        }

        return -1;
    }
    public static byte[] Combine(byte[] first, byte[] second)
    {
        byte[] ret = new byte[first.Length + second.Length];
        Buffer.BlockCopy(first, 0, ret, 0, first.Length);
        Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
        return ret;
    }
    public static string CharsToString(char[] b)
    {
        var sb = new StringBuilder();
        foreach (var c in b)
        {
            sb.Append(c);
        }

        return sb.ToString();
    }
    public static int GetByte(int val, int bytepos)
    {
        return (val >> (8*bytepos)) & 0xFF;
    }
    public static void SetDoubleBuffered(System.Windows.Forms.Control c)
    {
        //https://stackoverflow.com/questions/76993/how-to-double-buffer-net-controls-on-a-form
        if (System.Windows.Forms.SystemInformation.TerminalServerSession)
            return;

        System.Reflection.PropertyInfo aProp =
              typeof(System.Windows.Forms.Control).GetProperty(
                    "DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);

        aProp.SetValue(c, true, null);
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
        catch { isValid = false; }

        return isValid;
    }

    public static void FullScreen(Form form)
    {
        if (form.FormBorderStyle == FormBorderStyle.Sizable)
        {
            form.WindowState = FormWindowState.Normal;
            form.FormBorderStyle = FormBorderStyle.None;
            form.WindowState = FormWindowState.Maximized;
        }
        else
        {
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            form.WindowState = FormWindowState.Normal;
        }
    }
    public static void ForAllControls(this Control parent, Action<Control> action)
    {
        foreach (Control c in parent.Controls)
        {
            action(c);
            ForAllControls(c, action);
        }
    }
    //https://stackoverflow.com/questions/16556848/merging-2-images-using-c-sharp
    public static Bitmap SetImageOpacity(Image image, float opacity)
    {
        try
        {
            //create a Bitmap the size of the image provided  
            Bitmap bmp = new Bitmap(image.Width, image.Height);

            //create a graphics object from the image  
            using (Graphics gfx = Graphics.FromImage(bmp))
            {

                //create a color matrix object  
                ColorMatrix matrix = new ColorMatrix();

                //set the opacity  
                matrix.Matrix33 = opacity;

                //create image attributes  
                ImageAttributes attributes = new ImageAttributes();

                //set the color(opacity) of the image  
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                //now draw the image  
                gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }
        catch (Exception ex)
        {

            return null;
        }
    }
    public static string UnsafeAsciiBytesToString(byte[] buffer, int offset, int length)
    {
        unsafe
        {
            fixed (byte* pAscii = buffer)
            {
                return new String((sbyte*)pAscii, offset, length);
            }
        }
    }
}
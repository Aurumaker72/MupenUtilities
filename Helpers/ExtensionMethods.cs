using ICSharpCode.SharpZipLib.GZip;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public static class ExtensionMethods
{
    [DllImport("shell32.dll", SetLastError = true)]
    public static extern int SHOpenFolderAndSelectItems(IntPtr pidlFolder, uint cidl, [In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl, uint dwFlags);

    [DllImport("shell32.dll", SetLastError = true)]
    public static extern void SHParseDisplayName([MarshalAs(UnmanagedType.LPWStr)] string name, IntPtr bindingContext, [Out] out IntPtr pidl, uint sfgaoIn, [Out] out uint psfgaoOut);

#if BIGENDIAN
        public static readonly bool IsLittleEndian /* = false */;
#else
    public static readonly bool IsLittleEndian = true;
#endif

    public static int LowWord(this int number) => number & 0x0000FFFF;
    public static int LowWord(this int number, int newValue) => (int)((number & 0xFFFF0000) + (newValue & 0x0000FFFF));
    public static int HighWord(this int number) => (int)(number & 0xFFFF0000);
    public static int HighWord(this int number, int newValue) => (number & 0x0000FFFF) + (newValue << 16);

    public static bool Eof(Stream s)
    {
        return (s.Position + 1 > s.Length);
    }
    public static int Clamp(int value, int min, int max)
    {
        return (value < min) ? min : (value > max) ? max : value;
    }
    //public static void AdjustY(ref sbyte value) {
    //    if (value > -1) value--;
    //    else value++;
    //}

    // https://stackoverflow.com/questions/334630/opening-a-folder-in-explorer-and-selecting-a-file/334645
    public static void OpenFolderAndSelectItem(string folderPath, string file)
    {
        IntPtr nativeFolder;
        uint psfgaoOut;
        SHParseDisplayName(folderPath, IntPtr.Zero, out nativeFolder, 0, out psfgaoOut);

        if (nativeFolder == IntPtr.Zero)
        {
            // Log error, can't find folder
            return;
        }

        IntPtr nativeFile;
        SHParseDisplayName(Path.Combine(folderPath, file), IntPtr.Zero, out nativeFile, 0, out psfgaoOut);

        IntPtr[] fileArray;
        if (nativeFile == IntPtr.Zero)
        {
            // Open the folder without the file selected if we can't find the file
            fileArray = new IntPtr[0];
        }
        else
        {
            fileArray = new IntPtr[] { nativeFile };
        }

        SHOpenFolderAndSelectItems(nativeFolder, (uint)fileArray.Length, fileArray, 0);

        Marshal.FreeCoTaskMem(nativeFolder);
        if (nativeFile != IntPtr.Zero)
        {
            Marshal.FreeCoTaskMem(nativeFile);
        }
    }

    public unsafe static void SetByte(int* val, byte b, int pos)
    {
        *val &= ~((int)0xff << (8 * pos));
        *val |= ((int)b << (8 * pos));
    }
    public static void Memset(byte[] array, byte value)
    {
        if (array == null)
        {
            throw new ArgumentNullException("array");
        }

        int block = 32, index = 0;
        int length = Math.Min(block, array.Length);

        //Fill the initial array
        while (index < length)
        {
            array[index++] = value;
        }

        length = array.Length;
        while (index < length)
        {
            Buffer.BlockCopy(array, 0, array, index, Math.Min(block, length - index));
            index += block;
            block *= 2;
        }
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

    // stolen from ms

    // Converts an array of bytes into a short.  
    public static unsafe short ToInt16(byte[] value, uint startIndex)
    {
        fixed (byte* pbyte = &value[startIndex])
        {
            if (startIndex % 2 == 0)
            { // data is aligned 
                return *((short*)pbyte);
            }
            else
            {
                if (IsLittleEndian)
                {
                    return (short)((*pbyte) | (*(pbyte + 1) << 8));
                }
                else
                {
                    return (short)((*pbyte << 8) | (*(pbyte + 1)));
                }
            }
        }

    }
    public static string HKLM_GetString(string path, string key)
    {
        try
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
            if (rk == null) return "";
            return (string)rk.GetValue(key);
        }
        catch { return ""; }
    }
    public static int[] ByteArrToIntArr(byte[] buf)
    {
        int[] intArr = new int[buf.Length / 4];
        int offset = 0;
        for (int i = 0; i < intArr.Length; i++)
        {
            intArr[i] = (buf[3 + offset] & 0xFF) | ((buf[2 + offset] & 0xFF) << 8) |
                        ((buf[1 + offset] & 0xFF) << 16) | ((buf[0 + offset] & 0xFF) << 24);
            offset += 4;
        }
        return intArr;
    }
    public static string FriendlyName()
    {
        string ProductName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
        string CSDVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
        if (ProductName != "")
        {
            return (ProductName.StartsWith("Microsoft") ? "" : "Microsoft ") + ProductName +
                        (CSDVersion != "" ? " " + CSDVersion : "");
        }
        return "";
    }
    public static byte[] Compress(byte[] input)
    {
        MemoryStream mem = new MemoryStream(input);
        GZipOutputStream gs = new GZipOutputStream(mem);
        gs.Write(input, 0, input.Length);

        gs.Flush(); gs.Close(); mem.Flush(); mem.Close();

        return mem.ToArray();
    }
    public static byte[] Compress2(byte[] input)
    {
        using (var result = new MemoryStream())
        {
            var lengthBytes = BitConverter.GetBytes(input.Length);
            result.Write(lengthBytes, 0, 4);

            using (var compressionStream = new GZipStream(result,
                CompressionMode.Compress))
            {
                compressionStream.Write(input, 0, input.Length);
                compressionStream.Flush();

            }
            return result.ToArray();
        }
    }
    public static void Resize<T>(this List<T> list, int sz, T c = default(T))
    {
        int cur = list.Count;
        if (sz < cur)
            list.RemoveRange(sz, cur - sz);
        else if (sz > cur)
            list.AddRange(Enumerable.Repeat(c, sz - cur));
    }
    public static byte[] Decompress(byte[] compressed)
    {
        using (MemoryStream memory = new MemoryStream(compressed))
        {
            using (var gzipStream = new GZipInputStream(memory))
            {
                using (MemoryStream unzip = new MemoryStream())
                {
                    gzipStream.CopyTo(unzip);
                    return unzip.GetBuffer();
                }
            }
        }
    }
    public static byte[] Decompress2(byte[] gzip)
    {
        // Create a GZIP stream with decompression mode.
        // ... Then create a buffer and write into while reading from the GZIP stream.
        using (GZipStream stream = new GZipStream(new MemoryStream(gzip),
            CompressionMode.Decompress))
        {
            const int size = 4096;
            byte[] buffer = new byte[size];
            using (MemoryStream memory = new MemoryStream())
            {
                int count = 0;
                do
                {
                    count = stream.Read(buffer, 0, size);
                    if (count > 0)
                    {
                        memory.Write(buffer, 0, count);
                    }
                }
                while (count > 0);
                return memory.ToArray();
            }
        }
    }
    public static byte[] ReadFully(Stream input)
    {
        byte[] buffer = new byte[16 * 1024];
        using (MemoryStream ms = new MemoryStream())
        {
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }
    }
    public static int[] AllIndexesOf(string str, string substr, bool ignoreCase = false)
    {
        if (string.IsNullOrWhiteSpace(str) ||
            string.IsNullOrWhiteSpace(substr))
        {
            throw new ArgumentException("String or substring is not specified.");
        }

        var indexes = new List<int>();
        int index = 0;

        while ((index = str.IndexOf(substr, index, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)) != -1)
        {
            indexes.Add(index++);
        }

        return indexes.ToArray();
    }
    public static string FormatBytes(long bytes)
    {
        string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
        int i;
        double dblSByte = bytes;
        for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
        {
            dblSByte = bytes / 1024.0;
        }

        return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
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
    public static string ByteArrayToString(ulong b)
    {
        byte[] ba = BitConverter.GetBytes(b);
        StringBuilder hex = new StringBuilder(ba.Length * 2);
        foreach (byte by in ba)
            hex.AppendFormat("{0:x2}", by);

        return "0x" + hex.ToString().ToUpper();

    }
    public static string ByteArrayToString(uint b)
    {
        byte[] ba = BitConverter.GetBytes(b);
        StringBuilder hex = new StringBuilder(ba.Length * 2);
        foreach (byte by in ba)
            hex.AppendFormat("{0:x2}", by);

        return "0x" + hex.ToString().ToUpper();

    }
    public static string ByteArrayToString(int b)
    {
        byte[] ba = BitConverter.GetBytes(b);
        StringBuilder hex = new StringBuilder(ba.Length * 2);
        foreach (byte by in ba)
            hex.AppendFormat("{0:x2}", by);

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
        if (!flag) return (value & ~bitpos);
        else return (value | bitpos);
    }
    public static bool GetBit(int value, int bitpos)
    {
        return 1 == ((value >> bitpos) & 1);
    }
    public static bool GetBit(ulong value, int bitpos)
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
    public static int ReverseInt(int num)
    {
        for (int result = 0; ; result = result * 10 + num % 10, num /= 10) if (num == 0) return result;
        return 0x083964;
    }
    public static ulong Reverse(this ulong value)
    {
        return (value & 0x00000000000000FFUL) << 56 | (value & 0x000000000000FF00UL) << 40 |
               (value & 0x0000000000FF0000UL) << 24 | (value & 0x00000000FF000000UL) << 8 |
               (value & 0x000000FF00000000UL) >> 8 | (value & 0x0000FF0000000000UL) >> 24 |
               (value & 0x00FF000000000000UL) >> 40 | (value & 0xFF00000000000000UL) >> 56;
    }
    public static string NumberToWords(int number)
    {
        if (number == 0)
            return "zero";

        if (number < 0)
            return "minus " + NumberToWords(Math.Abs(number));

        string words = "";

        if ((number / 1000000) > 0)
        {
            words += NumberToWords(number / 1000000) + " million ";
            number %= 1000000;
        }

        if ((number / 1000) > 0)
        {
            words += NumberToWords(number / 1000) + " thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += NumberToWords(number / 100) + " hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
                words += "and ";

            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsMap[number % 10];
            }
        }

        return words;
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
    public static int GetByteBig(int val, int bytepos)
    {
        return (val >> (8 * bytepos)) & 0xFF;
    }
    public static sbyte GetSByte(int val, int bytepos)
    {
        return (sbyte)((val >> (8 * bytepos)) & 0xFF);
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
        catch (Exception)
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

    public static int DropDownWidth(ComboBox myCombo)
    {
        int maxWidth = 0, temp = 0;
        foreach (var obj in myCombo.Items)
        {
            temp = TextRenderer.MeasureText(obj.ToString(), myCombo.Font).Width;
            if (temp > maxWidth)
            {
                maxWidth = temp;
            }
        }
        return maxWidth;
    }

}
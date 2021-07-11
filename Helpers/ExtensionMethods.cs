using ICSharpCode.SharpZipLib.GZip;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
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

    public static int Clamp(int value, int min, int max) => (value < min) ? min : (value > max) ? max : value;
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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;

namespace MupenUtils
{
    public static class DataHelper
    {
        public static List<UInt32> validCrcs = new List<uint>()
        {
            0x03048DE6,
            0x11FB579B,
            0xDD801954,
            0x5CF7952A,
            0xA1E15117,
            0xBC9FF5F2,
            0x3CE60709,
            0x42C43204,
            0x587DD983,
            0x2AF50883,
            0x6395C475,
            0xA2DCF689,
            0x7FE024C9,
            0x4246EE14,
            0x7FF42FD0,
            0xC0345565,
            0x3B53519F,
            0x35958F55,
            0x08287CC8,
            0xF42BB75F,
            0xCDF26D67,
            0x356736C7,
            0xE96779FA,
            0xB2F04090,
            0x45A91CB1,
            0x7976248C,
            0xEB97929E,
            0xDD2DF6D9,
            0xFAA6B083,
            0x6787E212,
            0x0248F6C3,
            0x032625B0,
            0x5D9696DF,
            0x4711A9DC,
            0x6CED6472,
            0x26450AAB,
            0x434389C1,
            0x2BCEE11C,
            0xDA98A5D3,
            4281031267,
            0xC76319D8,
        };

        public static short GetMovieStartupTypeIndex(string stype)
        {
            short type;
            switch (stype)
            {
                case "Snapshot":
                    type = 1;
                    break;
                case "Power on":
                    type = 2;
                    break;
                case "EEPROM":
                    type = 4;
                    break;
                default:
                    type = short.MaxValue; // this is sort of compatible with mupen
                    break;
            }
            return type;
        }
        public static string GetMovieStartupType(ushort stype)
        {
            string type;
            switch (stype)
            {
                case 1:
                    type = "Snapshot";
                    break;
                case 2:
                    type = "Power on";
                    break;
                case 4:
                    type = "EEPROM";
                    break;
                default:
                    type = "Unknown";
                    break;
            }
            return type;
        }

        // Country Code
        public static ushort GetCountryCodeFromComboIndex(int comboIndex)
        {
            byte[] ccode = new byte[2];
            byte code = 0;
            ccode[1] = 0;

            switch (comboIndex)
            {
                case 0:
                    code = 0;
                    break;
                case 1:
                    code = (byte)'7';
                    break;
                case 2:
                    code = 0x41;
                    break;
                case 3:
                    code = 0x44;
                    break;
                case 4:
                    code = 0x45;
                    break;
                case 5:
                    code = 0x46;
                    break;
                case 6:
                    code = (byte)'I';
                    break;
                case 7:
                    code = 0x4A;
                    break;
                case 8:
                    code = (byte)'S';
                    break;
                case 9:
                    code = 0x55;
                    break;
                case 10:
                    code = 0x50;
                    break;
                case 11:
                    code = 0x77;
                    break;
            }
            
            ccode[0] = code;
            return BitConverter.ToUInt16(ccode, 0);
        }

        // [0] String
        // [1] Image
        // [2] Combobox Index
        public static object[] GetCountryResource(ushort ccode)
        {
            string code = "Error";
            Image image = MupenUtilities.Properties.Resources.unknown;
            int index = 0;

            switch (ccode & 0xFF)
            {
                /* Demo */
                case 0:
                    code = "Demo";
                    image = MupenUtilities.Properties.Resources.demo;
                    index = 0;
                    break;
                case '7':
                    // piece of shit incorrectly sized bitmap
                    Bitmap final = new Bitmap(MupenUtilities.Properties.Resources.n64beta);
                    Graphics gfx = Graphics.FromImage(final);
                    gfx.DrawImage(final, 0, 0, MupenUtilities.Properties.Resources.usa.Width, MupenUtilities.Properties.Resources.usa.Height);
                    code = "Beta";
                    image = final;
                    index = 1;
                    break;

                case 0x41:
                    {
                        // let's be fancy and merge the images
                        code = "USA/Japan";
                        Bitmap first = new Bitmap(MupenUtilities.Properties.Resources.usa);
                        Bitmap second = ExtensionMethods.SetImageOpacity(MupenUtilities.Properties.Resources.japan, 0.5f);
                        Bitmap result = new Bitmap(Math.Max(first.Width, second.Width), Math.Max(first.Height, second.Height));
                        Console.WriteLine(first.Width);
                        Graphics g = Graphics.FromImage(result);
                        g.DrawImageUnscaled(first, 0, 0);
                        g.DrawImageUnscaled(second, 0, 0);

                        image = result;
                        index = 2;
                    }
                    break;

                /* Germany */
                case 0x44:
                    code = "German";
                    image = MupenUtilities.Properties.Resources.germany;
                    index = 3;
                    break;

                /* USA */
                case 0x45:
                case 0x60:
                    code = "USA";
                    image = MupenUtilities.Properties.Resources.usa;
                    index = 4;
                    break;

                /* France */
                case 0x46:
                    code = "France";
                    image = MupenUtilities.Properties.Resources.france;
                    index = 5;
                    break;

                /* Italy */
                case 'I':
                    code = "Italy";
                    image = MupenUtilities.Properties.Resources.italy;
                    index = 6;
                    break;

                /* Japan */
                case 0x4A:
                    code = "Japan";
                    image = MupenUtilities.Properties.Resources.japan;
                    index = 7;
                    break;

                case 'S':	/* Spain */
                    code = "Spain";
                    image = MupenUtilities.Properties.Resources.spain;
                    index = 8;
                    break;

                /* Australia */
                case 0x55:
                case 0x59:
                    code = "Australia";
                    image = MupenUtilities.Properties.Resources.austral;
                    index = 9;
                    break;

                case 0x50:
                case 0x58:
                case 0x20:
                case 0x21:
                case 0x38:
                case 0x70:
                    code = "Europe";
                    image = MupenUtilities.Properties.Resources.europe;
                    index = 10;
                    break;

                default:
                    code = "Unknown (" + ccode + ")";
                    index = 11;
                    break;
            }
            Bitmap bmp = new Bitmap(image);
            bmp.MakeTransparent(Color.White);
            image = bmp;
            return new object[] { code, image, index };
        }

        
        public static List<(uint Crc, string GameName, int ComboIndex)> GetCRCs()
        {
            List<(UInt32 Crc, string GameName, int ComboIndex)> CRCTuples = new List<(uint Crc, string GameName, int ComboIndex)>();
            CRCTuples.Add((0x03048DE6, "Super Mario 64 Europe 1", 2));
            CRCTuples.Add((0x11FB579B, "Super Mario 64 Europe 2", 3));
            CRCTuples.Add((0xDD801954, "Super Mario 64 Japan 1", 4));
            CRCTuples.Add((0x5CF7952A, "Super Mario 64 Japan 2", 5));
            CRCTuples.Add((0xA1E15117, "Super Mario 64 Japan Rev3 1", 6));
            CRCTuples.Add((0xA1E15117, "Super Mario 64 Japan Rev3 2", 7));
            CRCTuples.Add((0x3CE60709, "Super Mario 64 USA 1", 8));
            CRCTuples.Add((0x42C43204, "Super Mario 64 USA 2", 9));
            CRCTuples.Add((0xFF2B5A63, "Super Mario 64 USA 3", 10));
            CRCTuples.Add((0x34133275, "YAMA", 11));
            return CRCTuples;
        }

        public static string GetFriendlyValue(int value)
        {
            string final = "";

            byte[] joy = BitConverter.GetBytes(value);

            for (int i = 0; i < MainForm.inputStructNames.Length - 2; i++)
            {
                // loop through all buttons
                Debug.WriteLine(value.ToString("X2"));
                if (ExtensionMethods.GetBit(value, i))
                {
                    final += MainForm.inputStructNames[i] + " ";
                }
            }

            if ((sbyte)joy[2] != 0)
                final += "\nJoy X " + ((sbyte)joy[2]).ToString();

            if ((sbyte)-joy[3] != 0)
                final += "\nJoy Y " + ((sbyte)-joy[3]).ToString() + "\n";

            return final;

        }


        public static void PopulateCRCsFromFile()
        {
            if (!File.Exists(@"crc.txt"))
            {
                System.Windows.Forms.MessageBox.Show("crc.txt couldn't be found");
                return;
            }
            string data = File.ReadAllText(@"crc.txt");
            for (int i = 0; i < data.Length; i++)
            {

                // this is so slow and stupid lol

                if (data[i] == 'c' &&
                  data[i + 1] == 'r' &&
                  data[i + 2] == 'c')
                {
                    // found crc field
                    StringBuilder sb = new StringBuilder()
                        .Append(data[i + 4])
                        .Append(data[i + 5])
                        .Append(data[i + 6])
                        .Append(data[i + 7])
                        .Append(data[i + 8])
                        .Append(data[i + 9])
                        .Append(data[i + 10])
                        .Append(data[i + 11]);

                    //char[] chrs = sb.ToString().ToCharArray();

                    validCrcs.Add(uint.Parse(sb.ToString(), System.Globalization.NumberStyles.HexNumber));
                }
            }
        }
    }
}

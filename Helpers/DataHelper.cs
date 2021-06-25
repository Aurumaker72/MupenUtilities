using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    type = short.MaxValue;
                    break;
            }
            return type;
        }
        public static string GetMovieStartupType(short stype)
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
        public static string GetCountryCode(ushort ccode)
        {
            string code = "Error";
            switch (ccode & 0xFF)
            {
                /* Demo */
                case 0:
                    code = "Demo";
                    break;
                case '7':
                    code = "Beta";
                    break;

                case 0x41:
                    code = "USA/Japan";
                    break;

                /* Germany */
                case 0x44:
                    code = "German";
                    break;

                /* USA */
                case 0x45:
                case 0x60:
                    code = "USA";
                    break;

                /* France */
                case 0x46:
                    code = "France";
                    break;

                /* Italy */
                case 'I':
                    code = "Italy";
                    break;

                /* Japan */
                case 0x4A:
                    code = "Japan";
                    break;

                case 'S':	/* Spain */
                    code = "Spain";
                    break;

                /* Australia */
                case 0x55:
                case 0x59:
                    code = "Australia";
                    break;

                case 0x50:
                case 0x58:
                case 0x20:
                case 0x21:
                case 0x38:
                case 0x70:
                    code = "Europe";
                    break;

                default:
                    code = "Unknown (" + ccode + ")";
                    break;
            }
            return code;
        }

        public static string GetFriendlyValue(int value)
        {
            string final = "";

            byte[] joy = BitConverter.GetBytes(value);

            for (int i = 0; i < MainForm.inputStructNames.Length-2; i++)
            {
                // loop through all buttons
                Debug.WriteLine(value.ToString("X2"));
                if(ExtensionMethods.GetBit(value,i))
                {
                    final += MainForm.inputStructNames[i] + " ";
                }
            }

            if((sbyte)joy[2] != 0)
            final += "\nJoy X " + ((sbyte)joy[2]).ToString();

            if((sbyte)-joy[3] != 0)
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

                if(data[i] == 'c' &&
                  data[i+1] == 'r' &&
                  data[i+2] == 'c')
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

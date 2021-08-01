using MupenUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MupenUtilities.Forms
{
    public partial class MovieDiagnosticForm : Form
    {
        public static string warnText = "An automatic movie diagnostic was performed\r\nbecause your movie contains suspicious properties";

        public struct MovieStruct
        {
            public ulong magic;        // M64\0x1a
            public ulong version;  // 3
            public ulong uid;      // used to match savestates to a particular movie

            public ulong length_vis; // number of "frames" in the movie
            public ulong rerecord_count;
            public byte vis_per_second; // "frames" per second
            public byte num_controllers;
            public ushort reserved1;
            public ulong length_samples;

            public ushort startFlags; // should equal 2 if the movie is from a clean start
            public ushort reserved2;
            public ulong controllerFlags;
            public ulong reservedFlags;

            public string oldAuthorInfo;
            public string oldDescription;
            public string romNom; // internal rom name
            public ulong romCRC;
            public ushort romCountry;
            public string reservedBytes;
            public string videoPluginName;
            public string soundPluginName;
            public string inputPluginName;
            public string rspPluginName;
            public string authorInfos; // utf8-encoded
            public string description; // utf8-encoded

            
        }
        public List<int> inputs = new List<int>();
        public MovieDiagnosticForm()
        {
            InitializeComponent();
        }

        private void MovieDiagnosticForm_Shown(object sender, EventArgs e)
        {
            this.Text = MainForm.PROGRAM_NAME + " - Movie Diagnostic Tool";

            if (MainForm.UsageType != MainForm.UsageTypes.M64)
                warnText = "No M64 is loaded";

            lbl_info.Text = warnText;

            
            

            DoChecks();
        }

        string GetCheck(bool condition, string failmessage)
        {
            return condition ? ("PASS") : ("FAIL " + failmessage);
        }


        void DoChecks()
        {
            if (MainForm.Path == null || MainForm.UsageType == MainForm.UsageTypes.Combo) return;

            lbl_info.Visible = false;
            lb_Checks.Items.Clear();

            FileStream fs = new FileStream(MainForm.Path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            MovieStruct movieData;

            movieData.magic = br.ReadUInt32();
            movieData.version = br.ReadUInt32();
            movieData.uid = br.ReadUInt32();
            movieData.length_vis = br.ReadUInt32();
            movieData.rerecord_count = br.ReadUInt32();
            movieData.vis_per_second = br.ReadByte();
            movieData.num_controllers = br.ReadByte();
            br.ReadBytes(2);
            movieData.length_samples = br.ReadUInt32();
            movieData.startFlags = br.ReadUInt16();
            br.ReadBytes(2);
            movieData.controllerFlags = br.ReadUInt32();
            br.ReadBytes(160);
            br.ReadBytes(32);
            movieData.romCRC = br.ReadUInt32();
            movieData.romCountry = br.ReadUInt16();
            br.ReadBytes(56);
            br.ReadBytes(64 * 4);
            br.ReadBytes(222);
            br.ReadBytes(256);

            bool failedInputTest = false;

            br.BaseStream.Seek(1024, SeekOrigin.Begin);
            ulong findx = 0;
            while (findx < movieData.length_samples)
            {
                if (br.BaseStream.Position + 4 > fs.Length)
                {
                    findx++;
                    continue;
                }

                inputs.Add(br.ReadInt32());
                
                findx++;
            }
            for (ulong i = 0; i < movieData.length_samples; i++)
            {
                try
                {
                    if (inputs[(int)i] != 0) ;
                }
                catch(ArgumentOutOfRangeException e)
                {
                    failedInputTest = true;
                }
            }


            //////////////////////////////////////////////
            string[] checks = new string[8];
            int successfulChecks = 0, failedChecks = 0;

            lb_Checks.Items.Add( (checks[0] = GetCheck(movieData.magic == 0x4D36341A || movieData.magic == 439629389, "Malformed magic cookie"                                                                                                                       )).ToString());
            lb_Checks.Items.Add( (checks[1] = GetCheck(movieData.version == 3, "Old version"                                                                                                                                                                         )).ToString());
            lb_Checks.Items.Add( (checks[2] = GetCheck(movieData.num_controllers > 0 && movieData.num_controllers < 4, "Illegal controllers amount"                                                                                                                  )).ToString());
            lb_Checks.Items.Add( (checks[3] = GetCheck(!DataHelper.GetMovieStartupType(movieData.startFlags).Contains("Unknown"), "Invalid movie startup type"                                                                                                )).ToString());
            lb_Checks.Items.Add( (checks[4] = GetCheck(!ExtensionMethods.GetBit(movieData.controllerFlags, 1) && !ExtensionMethods.GetBit(movieData.controllerFlags, 2) && !ExtensionMethods.GetBit(movieData.controllerFlags, 3), "Unsupported controller activated")).ToString());
            lb_Checks.Items.Add((checks[5] = GetCheck(!failedInputTest, "Frame-Input value Mismatch")).ToString());
            lb_Checks.Items.Add((checks[6] = GetCheck(movieData.vis_per_second > 10 && movieData.vis_per_second <= 60, "Non-standard VI/s")).ToString());
            lb_Checks.Items.Add((checks[7] = GetCheck(movieData.length_vis > 0, "Not enough VIs")).ToString());

            foreach (var a in checks)
            {
                if (a.Equals("PASS")) successfulChecks++;
            }
            failedChecks = checks.Length - successfulChecks;
            if (failedChecks == 0)
            {
                lbl_Result.ForeColor = Color.DarkGreen;
                lbl_Result.Text = "All checks passed";
            }
            else
            {
                lbl_Result.ForeColor = Color.Red;
                char[] a = ExtensionMethods.NumberToWords(failedChecks).ToCharArray();
                a[0] = char.ToUpper(a[0]);

                if (failedChecks == 1) lbl_Result.Text = "One check failed";
                else if (failedChecks == checks.Length) lbl_Result.Text = "All checks failed";
                else lbl_Result.Text = new string(a) + " checks failed";
            }


            br.Close();
            fs.Close();

            lbl_info.Visible = true;
        }
    


        private void btn_Recalc_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void lb_Checks_MouseClick(object sender, MouseEventArgs e)
        {
            if (lb_Checks.SelectedItems.Count > 0)
                MessageBox.Show("Check Number " + lb_Checks.SelectedIndex.ToString() + " - " + lb_Checks.SelectedItems[0].ToString());
        }

        private void btn_Continue_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

using MupenUtilities.Helpers;
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
using static MupenUtilities.Helpers.M64;

namespace MupenUtilities.Forms
{
    public partial class MovieDiagnosticForm : Form
    {
        public static string warnText = "An automatic movie diagnostic was performed\r\nbecause your movie contains suspicious properties";

        
        public List<int> inputs = new List<int>();

        int timesContinued = 0;

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

            MovieStruct movieData;
            movieData = M64.ParseMovie(MainForm.Path).Item1;

            bool failedInputTest = false;

            FileStream fs = new FileStream(MainForm.Path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            br.BaseStream.Seek(M64.HEADER_LENGTH, SeekOrigin.Begin);
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
            lb_Checks.Items.Add((checks[4] = GetCheck(!failedInputTest, "Frame-Input value Mismatch")).ToString());
            lb_Checks.Items.Add((checks[5] = GetCheck(movieData.vis_per_second > 10 && movieData.vis_per_second <= 60, "Non-standard VI/s")).ToString());
            lb_Checks.Items.Add((checks[6] = GetCheck(movieData.length_vis > 0, "Not enough VIs")).ToString());
            lb_Checks.Items.Add((checks[7] = GetCheck(!movieData.soundPluginName.Contains("Azimer"), "Bad Audio Plugin")).ToString());
            
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
            if (!warnText.Contains("requested"))
            {
                timesContinued++;
                if (timesContinued == 1) btn_Continue.Text = "Ignore";
                if (timesContinued > 1) MainForm.ignoreIllegalDesync = true;
            }
            this.Hide();
        }
    }
}

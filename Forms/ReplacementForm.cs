using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MupenUtils.Forms
{
    public partial class ReplacementForm : Form
    {
        const string HELP_COPYMODES = "From source - The begin of the region in the source m64.\nTo source - the end of the region in the source m64.\nFrom target - The begin of the region in the second m64.\nTo target - The end of the region in the second m64.\nUpon pressing \'Go\', the 1st m64\'s region (from source -> to source) will get copied into the 2nd m64\'s region.\nWhen leaving Output empty, the resulting m64 will be put in the same folder as this executable.";
        const int INPUT_BEGIN = 1024;

        string pathSource = string.Empty;
        string pathTarget = string.Empty;
        string pathOutput = string.Empty;
        public static List<int> inputSrc = new List<int>();

        bool generateNew = false;
        bool autofill = true;

        enum ReplaceModes
        {
            Frame,
            Byte,
        };
        ReplaceModes ReplaceMode = ReplaceModes.Frame;
        bool ReplaceUseNOT = false;

        public static int fromSrc = 0;
        public static int toSrc = 0;
        public static int fromTrg = 0;
        public static int toTrg = 0;
        public static bool useExternalData = false;

        bool lockAll = false;

        public ReplacementForm()
        {
            InitializeComponent();
            this.Text = MainForm.PROGRAM_NAME + " - Replacement";

            this.MinimumSize = gpBox_Repl_Replacement.Size;

            foreach (var item in Enum.GetValues(typeof(ReplaceModes)))
            {
                cmb_Mode.Items.Add(item);
            }
            cmb_Mode.SelectedIndex = 0;
        }
        private void ReplacementForm_Shown(object sender, EventArgs e)
        {

            if (ExtensionMethods.ValidPath(MupenUtilities.Properties.Settings.Default.LastPathReplaceSrc))
                txt_Repl_Src.Text = MupenUtilities.Properties.Settings.Default.LastPathReplaceSrc;

            if (ExtensionMethods.ValidPath(MupenUtilities.Properties.Settings.Default.LastPathReplaceTrg))
                txt_Repl_Trg.Text = MupenUtilities.Properties.Settings.Default.LastPathReplaceTrg;

            //txt_Repl_FFrom_Src.Text = fromSrc.ToString();
            //txt_Repl_Fto_Src.Text = to.ToString();
        }

        private void btn_Repl_BrowseSrc_Click(object sender, EventArgs e)
        {
            lbl_Repl_Status.Text = "Choosing file";

            object[] res = UIHelper.OpenFileDialog("Select Source M64");
            if ((string)res[0] != "FAIL" && (bool)res[1])
                pathSource = (string)res[0];

            txt_Repl_Src.Text = pathSource;
            lbl_Repl_Status.Text = "Idle";
            MupenUtilities.Properties.Settings.Default.LastPathReplaceSrc = pathSource;
            MupenUtilities.Properties.Settings.Default.Save();

        }

        private void btn_Repl_BrowseTrg_Click(object sender, EventArgs e)
        {

            lbl_Repl_Status.Text = "Choosing file";

            object[] res = UIHelper.OpenFileDialog("Select Target M64");
            if ((string)res[0] != "FAIL" && (bool)res[1])
                pathTarget = (string)res[0];

            txt_Repl_Trg.Text = pathTarget;
            lbl_Repl_Status.Text = "Idle";
            MupenUtilities.Properties.Settings.Default.LastPathReplaceTrg = pathTarget;
            MupenUtilities.Properties.Settings.Default.Save();

        }


        private void btn_Repl_Go_Click(object sender, EventArgs e)
        {
            Replace();
        }

        void Replace()
        {
            if (lockAll) return;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            lbl_Repl_Status.Text = "Replacing";

            byte[] src;
            byte[] trg;
            int basef = -1;

            if (ExtensionMethods.ValidPath(MupenUtilities.Properties.Settings.Default.LastPathReplaceSrc))
            {
                pathSource = txt_Repl_Src.Text = MupenUtilities.Properties.Settings.Default.LastPathReplaceSrc;
            }
            if (ExtensionMethods.ValidPath(MupenUtilities.Properties.Settings.Default.LastPathReplaceTrg))
            {
                pathTarget = txt_Repl_Trg.Text = MupenUtilities.Properties.Settings.Default.LastPathReplaceTrg;
            }


            if (string.IsNullOrEmpty(pathSource) || string.IsNullOrWhiteSpace(pathSource) || string.IsNullOrEmpty(pathTarget) || string.IsNullOrWhiteSpace(pathTarget) || !File.Exists(pathSource) || !File.Exists(pathTarget))
            {
                lbl_Repl_Status.Text = "Failed";
                lbl_Substatus.Text = "Invalid path";
                return;
            }

            src = File.ReadAllBytes(pathSource);
            trg = File.ReadAllBytes(pathTarget);

            //if (trg.Length < src.Length)
            //{
            //    lbl_Repl_Status.Text = "Failed";
            //    lbl_Substatus.Text = "Target movie file is shorter than source movie";
            //    return;
            //}



            if (!useExternalData || !autofill)
            {

                try
                {
                    fromSrc = Int32.Parse(txt_Repl_FFrom_Src.Text);
                    toSrc = Int32.Parse(txt_Repl_Fto_Src.Text);
                    fromTrg = Int32.Parse(txt_Repl_Base_Trg.Text);

                    if (!autofill)
                        toTrg = Int32.Parse(txt_Repl_Fto_Trg.Text);
                    else
                        toTrg = fromTrg + toSrc;

                }
                catch
                {
                    lbl_Repl_Status.Text = "Failed";
                    lbl_Substatus.Text = "Integer parsing error";
                    return;
                }
            }

            

            if (ReplaceMode == ReplaceModes.Frame)
            {
                //MessageBox.Show("use Byte logic mode and do the maths yourself");
                fromSrc *= 4;
                toSrc *= 4;
                fromTrg *= 4;
                toTrg *= 4;
            }

            fromSrc += 1024;
            toSrc += 1024;
            fromTrg += 1024;
            toTrg += 1024;


            if (fromSrc < 0          ||
               toSrc   > src.Length ||
               toSrc-fromSrc < 1    ||
               fromTrg < 0          ||
               toTrg   > src.Length ||
               toSrc-fromSrc < 1
               )
            {
                lbl_Repl_Status.Text = "Failed";
                lbl_Substatus.Text = "Invalid from/to/base value. ";
                if(fromSrc < 0)
                    lbl_Substatus.Text += "\nFrom source is too small. ";
                if(toSrc > src.Length)
                    lbl_Substatus.Text += "\nTo source is too big. ";
                if(toSrc <= fromSrc)
                    lbl_Substatus.Text += "\nThe to source is lesser or equal to from source.";

                if (fromTrg < 0)
                    lbl_Substatus.Text += "\nFrom target is too small. ";
                if (toTrg > trg.Length)
                    lbl_Substatus.Text += "\nTo target is too big. ";
                if (toTrg <= fromTrg)
                    lbl_Substatus.Text += "\nThe to target is lesser or equal to from target.";

                return;
            }
            

            Buffer.BlockCopy(src, fromSrc, trg, fromTrg, toTrg - fromTrg);
            


            string finalPath = pathOutput;

            if (pathOutput == string.Empty)
                finalPath = Path.GetFileNameWithoutExtension(pathTarget) + "-replaced.m64";

            File.WriteAllBytes(finalPath, trg);

            stopwatch.Stop();

            lbl_Repl_Status.Text = "Finished";
            lbl_Substatus.Text = "Saved at " + finalPath + "\nFinished in " + stopwatch.ElapsedMilliseconds.ToString() + "ms";
        }

        

        private void cmb_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReplaceMode = (ReplaceModes)cmb_Mode.SelectedIndex;
        }

        private void btn_HelpMode_Click(object sender, EventArgs e)
        {
            MessageBox.Show(HELP_COPYMODES, this.Text);
        }

        private void txt_Output_TextChanged(object sender, EventArgs e)
        {
            lockAll = false;

            pathOutput = txt_Output.Text;
            PathSanity();

        }

        void PathSanity()
        {
            if (!ExtensionMethods.ValidPath(pathOutput))
            {
                lbl_Repl_Status.Text = "Error";
                lbl_Substatus.Text = "The output path is not valid.";
                lockAll = true;
            }
            if (pathOutput.Equals(pathTarget, StringComparison.InvariantCultureIgnoreCase))
            {
                lbl_Repl_Status.Text = "Error";
                lbl_Substatus.Text = "The output path will overwrite the target path.\nThis behaviour is not allowed and therefore\nyou can not start replacement.";
                lockAll = true;
            }
            if (pathOutput.Equals(pathSource, StringComparison.InvariantCultureIgnoreCase))
            {
                lbl_Repl_Status.Text = "Error";
                lbl_Substatus.Text = "The output path will overwrite the source path.\nThis behaviour is not allowed and therefore\nyou can not start replacement.";
                lockAll = true;
            }
        }
        private void btn_BrowseOut_Click(object sender, EventArgs e)
        {

            lbl_Repl_Status.Text = "Choosing output";

            object[] res = UIHelper.SaveFileDialog("Select Output", "M64 Files (*.m64)|*.m64|All files (*.*)|*.*");
            if ((string)res[0] != "FAIL" && (bool)res[1])
                pathOutput = (string)res[0];

            txt_Output.Text = pathOutput;
            lbl_Repl_Status.Text = "Idle";

            PathSanity();

        }

        private void chk_Autofill_CheckedChanged(object sender, EventArgs e)
        {
            autofill ^= true;
            txt_Repl_Fto_Trg.ReadOnly = autofill;
        }

        private void genericRegionTextChange(object sender, EventArgs e)
        {
            if (!autofill) return; // dame tu fuck you

            lbl_Repl_Status.Text = "";
            lbl_Substatus.Text = "";

            try
            {
                fromSrc = Int32.Parse(txt_Repl_FFrom_Src.Text);
                toSrc = Int32.Parse(txt_Repl_Fto_Src.Text);
                fromTrg = Int32.Parse(txt_Repl_Base_Trg.Text);

                if (toSrc > fromSrc)
                    toTrg = toSrc - fromSrc + fromTrg;
                else
                {
                    lbl_Repl_Status.Text = "Autofill fail";
                    lbl_Substatus.Text = "Invalid region";
                }
            }
            catch
            {
                lbl_Repl_Status.Text = "Autofill fail";
                lbl_Substatus.Text = "Integer parsing error";
                return;
            }

            txt_Repl_Fto_Trg.Text = toTrg.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MupenUtils.Forms
{
    public partial class ReplacementForm : Form
    {
        const string HELP_COPYMODES = "The copy mode dictates how the inputs get copied from one movie to another.\nDefault - Simple copy\nAssign - Simple copy\nOR - Perform a bitwise OR on the source\nAND - Perform a bitwise AND on the source\nXOR - Perform a bitwise XOR on the source\nThe \'NOT\' checkbox is a modifier which, when checked, performs a bitwise NOT on the source before all other operations.";

        string pathSource = string.Empty;
        string pathTarget = string.Empty;
        string pathOutput = string.Empty;
        public static List<int> inputSrc = new List<int>();

        bool generateNew = false;
        
        enum ReplaceModes
        {
            Default,
            Assign,
            Or,
            And,
            Xor
        };
        ReplaceModes ReplaceMode = ReplaceModes.Assign;
        bool ReplaceUseNOT = false;

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


        }

        private void btn_Repl_BrowseSrc_Click(object sender, EventArgs e)
        {
            btn_Repl_Go.Enabled = pathSource != pathTarget;
            lbl_Repl_Status.Text = "Choosing file";

            object[] res = UIHelper.OpenFileDialog("Select Source M64");
            if ((string)res[0] != "FAIL" && (bool)res[1])
                pathSource = (string)res[0];

            txt_Repl_Src.Text = pathSource;
            lbl_Repl_Status.Text = "Idle";
            MupenUtilities.Properties.Settings.Default.LastPathReplaceSrc = pathSource;
            MupenUtilities.Properties.Settings.Default.Save();

            if (pathSource == pathTarget)
                lbl_Repl_Status.Text = "Identical paths";
        }

        private void btn_Repl_BrowseTrg_Click(object sender, EventArgs e)
        {
            btn_Repl_Go.Enabled = pathSource != pathTarget;

            lbl_Repl_Status.Text = "Choosing file";

            object[] res = UIHelper.OpenFileDialog("Select Target M64");
            if ((string)res[0] != "FAIL" && (bool)res[1])
                pathTarget = (string)res[0];

            txt_Repl_Trg.Text = pathTarget;
            lbl_Repl_Status.Text = "Idle";
            MupenUtilities.Properties.Settings.Default.LastPathReplaceTrg = pathTarget;
            MupenUtilities.Properties.Settings.Default.Save();

            if (pathSource == pathTarget)
                lbl_Repl_Status.Text = "Identical paths";
        }


        private void btn_Repl_Go_Click(object sender, EventArgs e)
        {
            Replace();
        }

        void Replace()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            ReplaceUseNOT = chk_Invert.Checked;

            lbl_Repl_Status.Text = "Replacing";

            byte[] src;
            byte[] trg;

            if (ExtensionMethods.ValidPath(MupenUtilities.Properties.Settings.Default.LastPathReplaceSrc))
            {
                pathSource = txt_Repl_Src.Text = MupenUtilities.Properties.Settings.Default.LastPathReplaceSrc;
            }
            if (ExtensionMethods.ValidPath(MupenUtilities.Properties.Settings.Default.LastPathReplaceTrg))
            {
                pathTarget = txt_Repl_Trg.Text = MupenUtilities.Properties.Settings.Default.LastPathReplaceTrg;
            }


            if (string.IsNullOrEmpty(pathSource) || string.IsNullOrWhiteSpace(pathSource) || string.IsNullOrEmpty(pathTarget) || string.IsNullOrWhiteSpace(pathTarget))
            {
                
                lbl_Repl_Status.Text = "Failed";
                lbl_Substatus.Text = "Invalid path";
                return;
            }
            src = File.ReadAllBytes(pathSource);
            trg = File.ReadAllBytes(pathTarget);

            if (trg.Length < src.Length)
            {
                lbl_Repl_Status.Text = "Failed";
                lbl_Substatus.Text = "Target movie is shorter than source movie";
                return;
            }

            const int INPUT_BEGIN = 1024;

            int from = 0;
            int to = 0;
            try
            {
                from = Int32.Parse(txt_Repl_FFrom.Text);
                to = Int32.Parse(txt_Repl_Fto.Text);
            }
            catch
            {
                lbl_Repl_Status.Text = "Failed";
                lbl_Substatus.Text = "Integer parsing error";
            }
            if (chk_Repl_All.Checked)
            {
                to = src.Length;
            }
            if (to - from < 0 || from >= to || to > src.Length)
            {
                lbl_Repl_Status.Text = "Failed";
                lbl_Substatus.Text = "Invalid from/to value. ";

                if(from > to || to-from<0)
                    lbl_Substatus.Text += "\nBegin frame value is larger than end frame value. ";
                if(to > src.Length)
                    lbl_Substatus.Text += "\nEnd frame value is larger than movie. ";
                if(from == to)
                    lbl_Substatus.Text += "\nFrame values are equal. ";

                return;
            }

            switch (ReplaceMode)
            {
                case ReplaceModes.Default:
                    for (int i = INPUT_BEGIN + from; i < to; i++)
                        trg[i] = src[i];
                    break;
                case ReplaceModes.Assign:
                    if (ReplaceUseNOT)
                    {
                        for (int i = INPUT_BEGIN + from; i < to; i++)
                            trg[i] = src[i];
                    }
                    else
                    {
                        for (int i = INPUT_BEGIN + from; i < to; i++)
                            trg[i] = (byte)~(src[i]);
                    }
                    break;
                case ReplaceModes.Or:
                    if (ReplaceUseNOT)
                    {
                        for (int i = INPUT_BEGIN + from; i < to; i++)
                            trg[i] |= src[i];
                    }
                    else
                    {
                        for (int i = INPUT_BEGIN + from; i < to; i++)
                            trg[i] |= (byte)~(src[i]);
                    }
                    break;
                case ReplaceModes.And:
                    if (ReplaceUseNOT)
                    {
                        for (int i = INPUT_BEGIN + from; i < to; i++)
                            trg[i] &= src[i];
                    }
                    else
                    {
                        for (int i = INPUT_BEGIN + from; i < to; i++)
                            trg[i] &= (byte)~(src[i]);
                    }
                    break;
                case ReplaceModes.Xor:
                    if (ReplaceUseNOT)
                    {
                        for (int i = INPUT_BEGIN + from; i < to; i++)
                            trg[i] ^= src[i];
                    }
                    else
                    {
                        for (int i = INPUT_BEGIN + from; i < to; i++)
                            trg[i] ^= (byte)~(src[i]);
                    }
                    break;
                default:
                    MessageBox.Show("Replace mode not found. Try again with another mode combination.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }


            string finalPath = pathOutput;

            if(pathOutput == string.Empty)
            finalPath = Path.GetFileNameWithoutExtension(pathTarget) + "-replaced.m64";

            File.WriteAllBytes(finalPath, trg);

            if (chk_EraseOrig.Checked)
            {
                for (int i = INPUT_BEGIN + from; i < to; i++)
                    src[i] = 0;
                File.WriteAllBytes(pathSource, src);
                
            }

            stopwatch.Stop();

            lbl_Repl_Status.Text = "Finished";
            lbl_Substatus.Text = "Saved at " + finalPath + "\nFinished in " + stopwatch.ElapsedMilliseconds.ToString() + "ms";
            if (chk_EraseOrig.Checked)
                lbl_Substatus.Text += "\nNuked " + (to-from) + " frames in source movie.";
        }

        private void chk_Repl_All_CheckedChanged(object sender, EventArgs e)
        {
            lbl_Repl_FFrom.Enabled = lbl_Repl_Fto.Enabled = txt_Repl_FFrom.Enabled = txt_Repl_Fto.Enabled = !chk_Repl_All.Checked;
        }

        private void cmb_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReplaceMode = (ReplaceModes)cmb_Mode.SelectedIndex;
            chk_EraseOrig.Enabled = chk_Invert.Enabled = ReplaceMode != ReplaceModes.Default;
            
        }

        private void btn_HelpMode_Click(object sender, EventArgs e)
        {
            MessageBox.Show(HELP_COPYMODES, this.Text);
        }

        private void txt_Output_TextChanged(object sender, EventArgs e)
        {
            if (ExtensionMethods.ValidPath(txt_Output.Text))
                pathOutput = txt_Output.Text;
        }

        private void btn_BrowseOut_Click(object sender, EventArgs e)
        {
            
            lbl_Repl_Status.Text = "Choosing output";

            object[] res = UIHelper.SaveFileDialog("Select Output");
            if ((string)res[0] != "FAIL" && (bool)res[1])
                pathOutput = (string)res[0];

            txt_Output.Text = pathOutput;
            lbl_Repl_Status.Text = "Idle";

        }

        private void txt_Repl_FFrom_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

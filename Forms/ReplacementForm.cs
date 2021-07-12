using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MupenUtils.Forms
{
    public partial class ReplacementForm : Form
    {
        const string HELP_COPYMODES = "The copy mode dictates how the inputs get copied from one movie to another.\nDefault - Simple copy\nAssign - Simple copy\nOR - Perform a bitwise OR on the source\nAND - Perform a bitwise AND on the source\nXOR - Perform a bitwise XOR on the source\nThe \'Not (~)\' checkbox is a modifier which, when checked, performs a bitwise NOT on the source before all other operations.";

        string pathSource = string.Empty;
        string pathTarget = string.Empty;
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
                
                lbl_Repl_Status.Text = "Failed (invalid path)";
                return;
            }
            src = File.ReadAllBytes(pathSource);
            trg = File.ReadAllBytes(pathTarget);

            if (trg.Length < src.Length)
            {
                lbl_Repl_Status.Text = "Target movie is too short";
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
                lbl_Repl_Status.Text = "Failed int parse";
            }
            if (chk_Repl_All.Checked)
            {
                to = src.Length;
            }
            if(to-from < 0 || from >= to || to > src.Length)
            {
                lbl_Repl_Status.Text = "Invalid from/to";
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
                    MessageBox.Show("error");
                    break;
            }


            string finalPath;
            finalPath = Path.GetFileNameWithoutExtension(pathTarget) + "-replaced.m64";



            File.WriteAllBytes(finalPath, trg);

            stopwatch.Stop();
            lbl_Repl_Status.Text = "Finished in " + stopwatch.ElapsedMilliseconds.ToString() + "ms";
        }

        private void chk_Repl_All_CheckedChanged(object sender, EventArgs e)
        {
            lbl_Repl_FFrom.Enabled = lbl_Repl_Fto.Enabled = txt_Repl_FFrom.Enabled = txt_Repl_Fto.Enabled = !chk_Repl_All.Checked;
        }

        private void cmb_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReplaceMode = (ReplaceModes)cmb_Mode.SelectedIndex;
            chk_Invert.Enabled = ReplaceMode != ReplaceModes.Default;
        }

        private void gp_Repl_Commands_Enter(object sender, EventArgs e)
        {

        }

        private void btn_HelpMode_Click(object sender, EventArgs e)
        {
            MessageBox.Show(HELP_COPYMODES, this.Text);
        }

        private void ReplacementForm_Load(object sender, EventArgs e)
        {

        }
    }
}

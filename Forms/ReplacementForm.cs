﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MupenUtils.Forms
{
    public partial class ReplacementForm : Form
    {
        string pathSource = string.Empty;
        string pathTarget = string.Empty;
        public static List<int> inputSrc = new List<int>();

        bool generateNew = false;

        public ReplacementForm()
        {
            InitializeComponent();
            this.Text = MainForm.PROGRAM_NAME + " - Replacement";

            this.MinimumSize = gpBox_Repl_Replacement.Size;
        }
        private void ReplacementForm_Shown(object sender, EventArgs e)
        {
            //foreach (Control ctl in this.Controls)
            //    ctl.Enabled = MainForm.FileLoaded;

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
            lbl_Repl_Status.Text = "Replacing";

            byte[] src;
            byte[] trg;

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
            if(to-from < 0 || from >= to)
            {
                lbl_Repl_Status.Text = "Invalid from/to";
                return;
            }

            for (int i = INPUT_BEGIN+from; i < to; i++)
            {
                trg[i] = src[i];
            }

            lbl_Repl_Status.Text = "Idle";



            File.WriteAllBytes(pathTarget + "-targetted.m64", trg);



        }

        private void chk_Repl_All_CheckedChanged(object sender, EventArgs e)
        {
            lbl_Repl_FFrom.Enabled = lbl_Repl_Fto.Enabled = txt_Repl_FFrom.Enabled = txt_Repl_Fto.Enabled = !chk_Repl_All.Checked;
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

            if (ExtensionMethods.ValidPath(Properties.Settings.Default.LastPathReplaceSrc))
                txt_Repl_Src.Text = Properties.Settings.Default.LastPathReplaceSrc;
            
            if (ExtensionMethods.ValidPath(Properties.Settings.Default.LastPathReplaceTrg))
                txt_Repl_Trg.Text = Properties.Settings.Default.LastPathReplaceTrg;
        }

        private void btn_Repl_BrowseSrc_Click(object sender, EventArgs e)
        {
            lbl_Repl_Status.Text = "Choosing file";

            object[] res = UIHelper.OpenFileDialog("Select Source M64");
            if((string)res[0] != "FAIL" && (bool)res[1])
                pathSource = (string)res[0];

            txt_Repl_Src.Text = pathSource;
            lbl_Repl_Status.Text = "Idle";
            Properties.Settings.Default.LastPathReplaceSrc = pathSource;
            Properties.Settings.Default.Save();

            if (pathSource == pathTarget)
                lbl_Repl_Status.Text = "Identical paths";
        }

        private void btn_Repl_BrowseTrg_Click(object sender, EventArgs e)
        {
            lbl_Repl_Status.Text = "Choosing file";

            object[] res = UIHelper.OpenFileDialog("Select Target M64");
             if((string)res[0] != "FAIL" && (bool)res[1])
                pathTarget = (string)res[0];

             txt_Repl_Trg.Text = pathTarget;
            lbl_Repl_Status.Text = "Idle";
            Properties.Settings.Default.LastPathReplaceTrg = pathTarget;
            Properties.Settings.Default.Save();

             if (pathSource == pathTarget)
                lbl_Repl_Status.Text = "Identical paths";
        }
        
        private void chk_Repl_Trg_CheckedChanged(object sender, EventArgs e)
        {
            btn_Repl_BrowseTrg.Enabled = txt_Repl_Trg.Enabled = generateNew = chk_Repl_Trg.Checked;
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

            if(trg.Length < src.Length)
            {
                lbl_Repl_Status.Text = "Target file too small";
                return;
            }

            const int basePosition = 1024; // input begin (byte)

            int from = 0;
            int to = 0;
            try
            {
                from = Int32.Parse(txt_Repl_FFrom.Text);
                to = Int32.Parse(txt_Repl_Fto.Text);
            }
            catch
            {
                lbl_Repl_Status.Text = "Failed (from/to)";
            }

            
            //if (!ExtensionMethods.ValidStringInt(txt_Repl_FFrom.Text, 0, src.Length / 4 - 1024/*length of input data*/))
            //{
            //    lbl_Repl_Status.Text = "Failed (OOB)";
            //    return;
            //}
            //
            //if (!ExtensionMethods.ValidStringInt(txt_Repl_Fto.Text, 0, src.Length / 4 - 1024/*length of input data*/))
            //{
            //    lbl_Repl_Status.Text = "Failed (OOB)";
            //    return;
            //}

            if (chk_Repl_All.Checked)
            {
                from = basePosition;
                to = src.Length;
            }
            else
            {
                from -= 1024;
            }
            
            for (int i = from; i < to; i++)
            {
                lbl_Repl_Status.Text = "Copying " + i;
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

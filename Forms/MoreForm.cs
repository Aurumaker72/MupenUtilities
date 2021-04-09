using MupenUtils.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MupenUtils
{
    public partial class MoreForm : Form
    {
        public MoreForm()
        {
            InitializeComponent();
            this.Text = MainForm.PROGRAM_NAME + " - More";
            
        }

        private void btn_More_NewTip_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_More_Tip.Text = TipProvider.GetRandomTip();
        }

        private void pb_More_Logo_MouseDown(object sender, MouseEventArgs e)
        {
            Process.Start("https://github.com/Aurumaker72/MupenUtilities");
        }

        private void Llbl_More_Mupen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/mkdasher/mupen64-rr-lua-/");
        }

        private void Llbl_More_Resources_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.reddit.com/r/SM64TAS/comments/9ek1o5/resources_master_thread/");
        }

        private void Llbl_More_MupenCringe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://tasvideos.org/EmulatorResources/Mupen.html");
        }
    }
}

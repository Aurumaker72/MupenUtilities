using MupenUtils.Helpers;
using MupenUtils.Networking;
using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace MupenUtils
{
    public partial class MoreForm : Form
    {
        UpdateNotifier updateNotifier = new UpdateNotifier();
        public byte versionResult = MainForm.UPDATE_UNKNOWN;
        public static string allTips = string.Empty;

        public MoreForm()
        {
            InitializeComponent();
            this.Text = MainForm.PROGRAM_NAME + " - More";

            if(!updateNotifier.CheckForInternetConnection())
            {
                btn_More_CheckUpdates.Enabled = false;
                btn_More_CheckUpdates.Text = "No Internet";
            }
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

        private void btn_More_CheckUpdates_Click(object sender, EventArgs e)
        {
            if (versionResult == MainForm.UPDATE_UNKNOWN)
            versionResult = updateNotifier.GetGithubVersion();
            if (versionResult == MainForm.UPDATE_CLIENT_AHEAD || versionResult == MainForm.UPDATE_EQUAL)
            {
                MessageBox.Show("You are up to date!",MainForm.PROGRAM_NAME + " - Up to date");
            }else if (versionResult == MainForm.UPDATE_CLIENT_OUTDATED && MessageBox.Show("Your " + MainForm.PROGRAM_NAME + " is outdated. Do you want to download the latest release?", MainForm.PROGRAM_NAME + " - Outdated!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Process.Start("https://github.com/Aurumaker72/MupenUtilities/zipball/main");
            }
        }

        private void event_NewTip(object sender, MouseEventArgs e)
        {
           lbl_More_Tip.Text = TipProvider.GetRandomTip();
        }

        private void event_AllTips(object sender, MouseEventArgs e)
        {
            if (allTips == string.Empty)
            {
                allTips = ExtensionMethods.ArrStrFormatted(TipProvider.tips);
            }

            MessageBox.Show(allTips, MainForm.PROGRAM_NAME + " - All tips");
        }

        private void lbl_More_Tip_MouseDown(object sender, MouseEventArgs e)
        {
            System.Windows.Clipboard.SetText(lbl_More_Tip.Text);
        }
    }
}

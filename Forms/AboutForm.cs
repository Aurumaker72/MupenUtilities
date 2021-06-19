using MupenUtils.Helpers;
using MupenUtils.Networking;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MupenUtils
{
    public partial class MoreForm : Form
    {
        UpdateNotifier updateNotifier = new UpdateNotifier();
        public byte versionResult = MainForm.UPDATE_UNKNOWN;

        public MoreForm()
        {
            InitializeComponent();
            this.Text = MainForm.PROGRAM_NAME + " - More";

            if (!updateNotifier.CheckForInternetConnection())
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
            updateNotifier.CheckForUpdates(versionResult, false);
        }

        private void event_NewTip(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                lbl_More_Tip.Text = TipProvider.GetRandomTip();
            else
            {
                string str = string.Empty;
                for (int i = 0; i < TipProvider.tips.Length; i++) str += (i) + " | " + TipProvider.tips[i] + '\n';


                MessageBox.Show(str, MainForm.PROGRAM_NAME + " - All tips");
            }
        }

        private void Llbl_More_ReportBug_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Aurumaker72/MupenUtilities/issues/new?assignees=&labels=bug&template=bug_report.md&title=Bug+report");
        }

        private void Llbl_More_FeatureSuggestIssue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Aurumaker72/MupenUtilities/issues/new?assignees=&labels=enhancement&template=feature_request.md&title=Feature+request");
        }
    }
}

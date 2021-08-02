using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MupenUtils.Forms
{
    public partial class ExceptionForm : Form
    {
        public static Exception mException;
        string mPath;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.Style &= 0x00C00000;
                return myCp;
            }
        }
        
        public ExceptionForm()
        {
            InitializeComponent();
            TopMost = true;
        }

        private void llbl_Issues_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Aurumaker72/MupenUtilities/issues/new?assignees=&labels=&template=exception-with-crash-log.md&title=Mupen+Utilities+Exception");
        }

        private void btn_Continue_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_CrashLog_Click(object sender, EventArgs e)
        {
            if (btn_CrashLog.Text == "Open Crash Log")
                Process.Start(mPath);

            mPath = MainForm.MExcept(mException, false);
            btn_CrashLog.Text = "Open Crash Log";

        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            MainForm.MExcept(mException, false);
            Application.Exit();
        }
        private void FocusLost(object sender, EventArgs e)
        {
            this.Focus();
        }
        private void ExceptionForm_Shown(object sender, EventArgs e)
        {

            this.Text = ProductName + " " + MainForm.PROGRAM_VERSION + " - Exception";



            btn_CrashLog.Text = "Dump Crash Log";
            btn_CrashLog.ForeColor = Color.Black;
        }

        private void btn_OpenCrashLog_Click(object sender, EventArgs e)
        {

        }

        private void pb_LogoBad_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pb_LogoBad_MouseLeave(object sender, EventArgs e)
        {
        }
    }
}

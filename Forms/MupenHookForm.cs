using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MupenUtils.Forms
{
    public partial class MupenHookForm : Form
    {
        public static bool loading = false;
        public struct MupenDataStruct
        {
            public bool CONFIRMED;

            public string MUPEN_NAME;
            public string PROCESS_NAME;
        }
        public static MupenDataStruct MupenData;
        public static int searched = 0;

        public MupenHookForm()
        {
            InitializeComponent();
            this.Text = MainForm.PROGRAM_NAME + " - Mupen64 Hook";
            if (!MainForm.standardBitArh) this.Text += " (?)";
        }

        private void MupenHookForm_Shown(object sender, EventArgs e)
        {

            lbl_ProcName.Text += MupenData.PROCESS_NAME;
            lbl_NameVer.Text += MupenData.MUPEN_NAME;
            if (!MupenData.CONFIRMED)
            {
                MessageBox.Show(String.Format("Searched process memory {0} times and the mupen64 name string could\'nt be found.\nVersions older than 1.0.5 are not supported", searched), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Hide();
                return;
            }
            lbl_Name.Text += MupenData.MUPEN_NAME.Remove(MupenData.MUPEN_NAME.Length - 5);
            lbl_Ver.Text += MupenData.MUPEN_NAME.Remove(0, MainForm.MUPEN_SPLIT.Length + 1);
        }

        private void MupenHookForm_Load(object sender, EventArgs e)
        {

        }



        private void btn_Stop_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_Retry_Click(object sender, EventArgs e)
        {
            MainForm.rehookMupen = true;
            this.Hide();
        }

        private void btn_SaveLog_Click(object sender, EventArgs e)
        {
            const string PATH = @"mupen_info.log";
            string exStr = "";
            exStr += "--- Mupen64 Basic Information Dump ---" + "\n";
            exStr += "Process Name: " + MupenData.PROCESS_NAME + "\n";
            exStr += "Name: " + MupenData.MUPEN_NAME + "\n";
            exStr += "--- end ---" + "\n";
            File.WriteAllText(PATH, exStr);
            Process.Start(PATH);
        }
    }
}

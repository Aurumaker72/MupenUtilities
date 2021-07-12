using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using MRG.Controls.UI;
using MupenUtilities.Helpers;

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
                MessageBox.Show("The mupen64 name string could\'nt be found.\nVersions older than 1.0.4 are not supported", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
    }
}

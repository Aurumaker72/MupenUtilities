using System;
using System.Windows.Forms;

namespace MupenUtils.Forms
{
    public partial class ControllerFlagsForm : Form
    {

        int selectedController = 1;


        public ControllerFlagsForm()
        {
            InitializeComponent();
            this.Text = "Controller Flags";
        }

        private void ControllerFlagsForm_Shown(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
                ctl.Enabled = MainForm.FileLoaded;

            if (MainForm.FileLoaded)
            {
                cbox_Cflg_ControllerSelect.SelectedIndex = 0;
                MainForm.notifiedReupdateControllerFlags = true;
            }
        }

        private void cbox_Cflg_ControllerSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedController = cbox_Cflg_ControllerSelect.SelectedIndex + 1;

            int offset = selectedController - 1;
            chk_Cflg_Present.Checked = ExtensionMethods.GetBit(MainForm.ControllerFlags, offset);

            offset = 4;
            if (selectedController != 1)
                offset += selectedController - 1;
            chk_Cflg_Mempak.Checked = ExtensionMethods.GetBit(MainForm.ControllerFlags, offset);

            offset = 8;
            if (selectedController != 1)
                offset += selectedController - 1;

            chk_Cflg_Rumblepak.Checked = ExtensionMethods.GetBit(MainForm.ControllerFlags, offset);
        }

        private void chk_Cflg_Present_CheckedChanged(object sender, EventArgs e)
        {
            ExtensionMethods.SetBit(ref MainForm.ControllerFlags, chk_Cflg_Present.Checked, selectedController - 1);
        }

        private void chk_Cflg_Mempak_CheckedChanged(object sender, EventArgs e)
        {
            int offset = 4;
            if (selectedController != 1)
                offset += selectedController - 1;

            ExtensionMethods.SetBit(ref MainForm.ControllerFlags, chk_Cflg_Mempak.Checked, offset);
        }

        private void chk_Cflg_Rumblepak_CheckedChanged(object sender, EventArgs e)
        {
            int offset = 8;
            if (selectedController != 1)
                offset += selectedController - 1;

            ExtensionMethods.SetBit(ref MainForm.ControllerFlags, chk_Cflg_Rumblepak.Checked, offset);
        }
    }
}

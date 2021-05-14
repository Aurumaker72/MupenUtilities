using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MupenUtils.Forms
{
    public partial class TASStudioMoreForm : Form
    {
        int selectedFrame = 0;

        public TASStudioMoreForm()
        {
            InitializeComponent();
            this.Text = "TAS Studio - Commands";
            this.MinimumSize = gp_TasStudio_Help.Size;

            btn_TasStudio_EasterEggObunga.BackColor = btn_TasStudio_EasterEggObunga.ForeColor = Color.FromKnownColor(KnownColor.Control);

        }

        private void TASStudioMoreForm_Shown(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
                ctl.Enabled = MainForm.FileLoaded;
        }

        private void txt_TasStudio_Frame_TextChanged(object sender, EventArgs e)
        {
            
            string txt = txt_TasStudio_Frame.Text;

            if(txt == "Invalid") {txt = "0"; txt_TasStudio_Frame.Text = txt;}

            if (ExtensionMethods.ValidStringInt(txt, 0, MainForm.inputList.Count))
                selectedFrame = Int32.Parse(txt);
            else
                txt = "Invalid";
            
            txt_TasStudio_Frame.Text = txt;


        }

        private void btn_TasStudio_Goto_Click(object sender, EventArgs e)
        {
            MainForm.forceGoto = true;
            selectedFrame = ExtensionMethods.Clamp(selectedFrame - 1, 0, MainForm.inputList.Count);
            MainForm.markedGoToFrame = selectedFrame;
        }

        private void btn_TasStudio_EasterEggObunga_Click(object sender, EventArgs e)
        {

            foreach (Control ctl in this.Controls)
            {
                ctl.BackgroundImage = Properties.Resources.obunga;
                ctl.Text = "Obunga";
            }
            this.WindowState = FormWindowState.Maximized;
            for (int i = 0; i < 50; i++)
            this.Text = this.Text + "Obunga";
        }

    }
}

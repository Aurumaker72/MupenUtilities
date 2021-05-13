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
            MainForm.markedGoToFrame = selectedFrame;
        }

    }
}

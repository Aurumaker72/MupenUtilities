using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MupenUtils.Forms
{
    public partial class AdvancedDebugForm : Form
    {
        byte[] file;

        int selectedFrame = 0;

        long selectedByte = 0;

        public AdvancedDebugForm()
        {
            InitializeComponent();
            this.Text = MainForm.PROGRAM_NAME + " - Misc. Tools";

        }

        private void txt_Debug_Uvalue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MainForm.inputList[selectedFrame] = Int32.Parse(txt_Debug_Uvalue.Text);
            }
            catch { }
        }

        private void txt_Debug_Frame_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ExtensionMethods.ValidStringInt(txt_Debug_Frame.Text, 0, MainForm.inputList.Count))
                    selectedFrame = Int32.Parse(txt_Debug_Frame.Text);
            }
            catch { }
        }

        private void btn_Debug_Random_Click(object sender, EventArgs e)
        {
            MainForm.inputList[selectedFrame] = new Random().Next(0, Int32.MaxValue);
            txt_Debug_Uvalue.Text = MainForm.inputList[selectedFrame].ToString();
        }

        private void AdvancedDebugForm_Shown_1(object sender, EventArgs e)
        {
            foreach(Control ctl in Controls)
                ctl.Enabled = MainForm.FileLoaded;

            if (MainForm.FileLoaded)
            {
                //for(int i=0;i<file.Length;i++)file[i]=0;
                file = File.ReadAllBytes(MainForm.Path);
            }
        }

        private void txt_Debug_Nthbyte_TextChanged(object sender, EventArgs e)
        {
            if(ExtensionMethods.ValidStringInt(txt_Debug_Nthbyte.Text, 0, file.Length))
            {
                selectedByte = Int32.Parse(txt_Debug_Nthbyte.Text);
                txt_Debug_Nthbyte.Text = selectedByte.ToString();
                txt_Debug_Value.Text = file[selectedByte].ToString();
                txt_Debug_HexByte.Text =  file[selectedByte].ToString("X2");
            }

        }

        private void txt_Debug_Value_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void gp_Debug_Hex_Enter(object sender, EventArgs e)
        {

        }
    }
}

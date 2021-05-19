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
    public partial class AdvancedDebugForm : Form
    {
        int selectedFrame = 0;

        public AdvancedDebugForm()
        {
            InitializeComponent();
            this.Text = MainForm.PROGRAM_NAME + " - Debug Set Input";

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

        private void AdvancedDebugForm_Shown(object sender, EventArgs e)
        {

        }

        private void btn_Debug_Random_Click(object sender, EventArgs e)
        {
            MainForm.inputList[selectedFrame] = new Random().Next(0, Int32.MaxValue);
            txt_Debug_Uvalue.Text = MainForm.inputList[selectedFrame].ToString();
        }
    }
}

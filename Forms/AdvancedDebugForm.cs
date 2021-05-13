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
        }

        private void txt_Debug_Uvalue_TextChanged(object sender, EventArgs e)
        {
            MainForm.inputList[selectedFrame] = Int32.Parse(txt_Debug_Uvalue.Text);
        }

        private void txt_Debug_Frame_TextChanged(object sender, EventArgs e)
        {
            if (ExtensionMethods.ValidStringInt(txt_Debug_Frame.Text, 0, MainForm.inputList.Count))
                selectedFrame = Int32.Parse(txt_Debug_Frame.Text);
        }
    }
}

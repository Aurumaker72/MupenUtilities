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
        public AdvancedDebugForm()
        {
            InitializeComponent();
        }

        private void txt_Debug_Uvalue_TextChanged(object sender, EventArgs e)
        {
            MainForm.inputList[MainForm.frame] = Int32.Parse(txt_Debug_Uvalue.Text);
        }
    }
}

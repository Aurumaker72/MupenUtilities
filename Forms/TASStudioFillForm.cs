using MupenUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MupenUtilities.Forms
{
    public partial class TASStudioFillForm : Form
    {
        public TASStudioFillForm()
        {
            InitializeComponent();
            this.Text = MainForm.PROGRAM_NAME + " - TASStudio Region Fill Utility";
            
            for (int i = 0; i < MainForm.inputStructNames.Length-2; i++)
                cmb_Buttons.Items.Add(MainForm.inputStructNames[i]);

            cmb_Buttons.SelectedIndex = 0;

        }

        private void TASStudioFillForm_Shown(object sender, EventArgs e)
        {
            
        }

        private void btn_Go_Click(object sender, EventArgs e)
        {
            MainForm.fillbIndex = cmb_Buttons.SelectedIndex;
            MainForm.forceFill = true;
            this.Hide();
        }
    }
}

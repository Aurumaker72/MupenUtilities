using MupenUtils.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MupenUtils
{
    public partial class MoreForm : Form
    {
        public MoreForm()
        {
            InitializeComponent();
        }

        private void btn_More_NewTip_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_More_Tip.Text = TipProvider.GetRandomTip();
        }
    }
}

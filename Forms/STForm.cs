using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MupenUtils.Forms
{
    public partial class STForm : Form
    {
        public static byte[] savestateRDRAM = new byte[8388608];
        public static Thread stLoadThread;
        public static int selectedOffset = 0;
        public static List<int> disallowedOffsets = new List<int>();

        public STForm()
        {
            InitializeComponent();
            this.Text = MainForm.PROGRAM_NAME + " - Savestate Inspector";
        }

        private void STForm_Shown(object sender, EventArgs e)
        {
            gp_st.Invoke((MethodInvoker)(() => panel_st.Dock = DockStyle.Fill));
            panel_st.Invoke((MethodInvoker)(() => panel_st.Dock = DockStyle.None));
            panel_st.Invoke((MethodInvoker)(() => panel_st.Visible = false));

        }

        private void txt_rdramoffset_TextChanged(object sender, EventArgs e)
        {
            txt_rdramoffset.ForeColor = Color.Black;
            lbl_live.ForeColor = Color.Black;
            txt_RDRAM.ForeColor = Color.Black;
            int tmp = selectedOffset;

            if(ExtensionMethods.ValidStringInt(txt_rdramoffset.Text, 0, savestateRDRAM.Length))
                selectedOffset = int.Parse(txt_rdramoffset.Text);

            for(int i = 0; i < disallowedOffsets.Count; i++)
            {
                if(selectedOffset == disallowedOffsets[i])
                {
                    txt_rdramoffset.ForeColor = Color.Red;
                    lbl_live.ForeColor = Color.Red;
                    txt_RDRAM.ForeColor = Color.Red;
                    selectedOffset = tmp;
                    return;
                }
            }

            txt_RDRAM.Clear();
            txt_RDRAM.Text = savestateRDRAM[selectedOffset].ToString("X2");

            
        }

        private void btn_RDRAMOffsetHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The RDRAM offset is the base savestate offset (0) plus the RDRAM section offset (432).\nRDRAM begins at byte 432 and ends at byte 8389040.\nThe value inputted in the textbox is relative to the region of RDRAM");
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string final = selectedOffset.ToString("X2") + " | " + savestateRDRAM[selectedOffset].ToString("X2");

            foreach (string s in ls_SAVED.Items)
                if (s == final) return;

            ls_SAVED.Items.Add(final);
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            ls_SAVED.Items.RemoveAt(ls_SAVED.SelectedIndex);
        }

        private void btn_Disallow_Click(object sender, EventArgs e)
        {
            ls_SAVED.Items.Remove(selectedOffset.ToString("X2") + " | " + savestateRDRAM[selectedOffset].ToString("X2"));

            for(int i=0;i<disallowedOffsets.Count;i++)if(selectedOffset==disallowedOffsets[i])disallowedOffsets.RemoveAt(i);

            disallowedOffsets.Add(selectedOffset);
        }
    }
}

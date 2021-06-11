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
using System.IO;

namespace MupenUtils.Forms
{
    public partial class STForm : Form
    {
        public static List<byte> savestate = new List<byte>();

        public static byte[] savestateRDRAM = new byte[8388608];

        public static Thread stLoadThread;
        public static int selectedOffset = 0;
        public static List<int> disallowedOffsets = new List<int>();

        public static string Path;

        public STForm()
        {
            InitializeComponent();
            this.Text = MainForm.PROGRAM_NAME + " - Savestate Inspector";
        }

        private void STForm_Shown(object sender, EventArgs e)
        {
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

            //txt_RDRAM.Clear();
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
            if(ls_SAVED.SelectedIndex != -1)
            ls_SAVED.Items.RemoveAt(ls_SAVED.SelectedIndex);
        }

        private void btn_Disallow_Click(object sender, EventArgs e)
        {
            ls_SAVED.Items.Remove(selectedOffset.ToString("X2") + " | " + savestateRDRAM[selectedOffset].ToString("X2"));

            for(int i=0;i<disallowedOffsets.Count;i++)if(selectedOffset==disallowedOffsets[i])disallowedOffsets.RemoveAt(i);

            disallowedOffsets.Add(selectedOffset);
        }

        private void txt_Edit_TextChanged(object sender, EventArgs e)
        {
            txt_Edit.ForeColor = Color.Black;


            
            if(txt_Edit.Text.Length > 4 || selectedOffset == 0 || !ExtensionMethods.ValidHexStringInt(txt_Edit.Text, 0, byte.MaxValue)){txt_Edit.ForeColor = Color.Red;return;}
            for (int i = 0; i < disallowedOffsets.Count; i++) if (selectedOffset == disallowedOffsets[i]){txt_Edit.ForeColor = Color.Red;return;}

            byte final = 0;

            

            if (txt_Edit.Text.Contains("x"))
                final = Convert.ToByte(txt_Edit.Text, 16);
            else
                final = byte.Parse(txt_Edit.Text);

            savestateRDRAM[selectedOffset] = final;
            txt_RDRAM.Text = savestateRDRAM[selectedOffset].ToString("X2");
        }

        private void btn_SaveST_Click(object sender, EventArgs e)
        {
            byte[] st = savestate.ToArray();

            FileStream fs = File.Open(Path, FileMode.OpenOrCreate);
            BinaryWriter br = new BinaryWriter(fs);
            br.Write(st, 0, 0x1A0);
            br.Write(savestateRDRAM);
            br.Write(st, 0x8001B0, st.Length);

            br.Flush();  br.Close(); fs.Close();

            MessageBox.Show(String.Format("Dumped {0} bytes savestate at {1}", st.Length, Path));
        }
    }
}

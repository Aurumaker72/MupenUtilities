using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MupenUtils.Forms
{
    public partial class STForm : Form
    {
        public static byte[] savestate = new byte[10496988];

        public static Thread stLoadThread;
        public static int selectedOffset = 0;
        public static List<int> disallowedOffsets = new List<int>();

        public static string Path;

        public const uint COINS_COUNT_ADDRESS = 0x0033B3CA;
        public const uint STARS_COUNT_ADDRESS = 0x0033B3C8;
        public const uint LIVES_COUNT_ADDRESS = 0x0033B3CE;
        public const uint COINS_DISPLAY_ADDRESS = 0x0033B410;
        public const uint STARS_DISPLAY_ADDRESS = 0x0033B416;
        public const uint LIVES_DISPLAY_ADDRESS = 0x0033B412;
        public const uint HEALTH_ADDRESS = 0x0033B3CD;

        short coins;
        short stars;
        sbyte lives;
        sbyte health;

        public STForm()
        {
            InitializeComponent();
            this.Text = MainForm.PROGRAM_NAME + " - Savestate Inspector";
        }

        private void STForm_Shown(object sender, EventArgs e)
        {
            cmb_Editmode.Items.Clear();
            cmb_Editmode.Items.Add("Full");
            cmb_Editmode.Items.Add("RDRAM");
            cmb_Editmode.Items.Add("Super Mario 64 USA");

            cmb_Editmode.SelectedIndex = 0;


        }

        #region RDRAM utility
        private void txt_rdramoffset_TextChanged(object sender, EventArgs e)
        {
            txt_rdramoffset.ForeColor = Color.Black;
            lbl_live.ForeColor = Color.Black;
            txt_RDRAM.ForeColor = Color.Black;
            int tmp = selectedOffset;

            if (ExtensionMethods.ValidStringInt(txt_rdramoffset.Text, 0, 8388608))
                selectedOffset = int.Parse(txt_rdramoffset.Text);

            for (int i = 0; i < disallowedOffsets.Count; i++)
            {
                if (selectedOffset == disallowedOffsets[i])
                {
                    txt_rdramoffset.ForeColor = Color.Red;
                    lbl_live.ForeColor = Color.Red;
                    txt_RDRAM.ForeColor = Color.Red;
                    selectedOffset = tmp;
                    return;
                }
            }

            //txt_RDRAM.Clear();
            txt_RDRAM.Text = savestate[0x1B0 + selectedOffset].ToString("X2");


        }

        private void btn_RDRAMOffsetHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The RDRAM offset is the base savestate offset (0) plus the RDRAM section offset (432).\nRDRAM begins at byte 432 and ends at byte 8389040.\nThe value inputted in the textbox is relative to the region of RDRAM");
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string final = selectedOffset.ToString("X2") + " | " + savestate[0x1B0 + selectedOffset].ToString("X2");

            foreach (string s in ls_SAVED.Items)
                if (s == final) return;

            ls_SAVED.Items.Add(final);
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (ls_SAVED.SelectedIndex != -1)
                ls_SAVED.Items.RemoveAt(ls_SAVED.SelectedIndex);
        }
        private void btn_Disallow_Click(object sender, EventArgs e)
        {
            ls_SAVED.Items.Remove(selectedOffset.ToString("X2") + " | " + savestate[0x1B0+selectedOffset].ToString("X2"));
            for (int i = 0; i < disallowedOffsets.Count; i++) if (selectedOffset == disallowedOffsets[i]) disallowedOffsets.RemoveAt(i);
            disallowedOffsets.Add(selectedOffset);
        }

        private void txt_Edit_TextChanged(object sender, EventArgs e)
        {
            txt_Edit.ForeColor = Color.Black;



            if (txt_Edit.Text.Length > 4 || selectedOffset == 0 || !ExtensionMethods.ValidHexStringInt(txt_Edit.Text, 0, byte.MaxValue)) { txt_Edit.ForeColor = Color.Red; return; }
            for (int i = 0; i < disallowedOffsets.Count; i++) if (selectedOffset == disallowedOffsets[i]) { txt_Edit.ForeColor = Color.Red; return; }

            byte final = 0;



            if (txt_Edit.Text.Contains("x"))
                final = Convert.ToByte(txt_Edit.Text, 16);
            else
                final = byte.Parse(txt_Edit.Text);

            savestate[0x1B0+selectedOffset] = final;
            txt_RDRAM.Text = savestate[0x1B0+selectedOffset].ToString("X2");
        }
        #endregion

        #region SM64
        void SM64Load()
        {
            coins = ExtensionMethods.ToInt16(savestate.ToArray(), COINS_COUNT_ADDRESS);
            stars = ExtensionMethods.ToInt16(savestate.ToArray(), STARS_COUNT_ADDRESS);
            lives = (sbyte)savestate.ToArray()[LIVES_COUNT_ADDRESS];
            health = (sbyte)savestate.ToArray()[HEALTH_ADDRESS];

            nud_Coins.Value = coins;
            nud_Stars.Value = stars;
            nud_Lives.Value = lives;
            nud_Health.Value = health;
        }   


        void SM64Push()
        {
            coins = (short)nud_Coins.Value;
            stars = (short)nud_Stars.Value;
            lives = (sbyte)nud_Lives.Value;
            health = (sbyte)nud_Health.Value;
            Buffer.BlockCopy(BitConverter.GetBytes(coins), 0, savestate, (int)COINS_COUNT_ADDRESS, BitConverter.GetBytes(coins).Length);
            Buffer.BlockCopy(BitConverter.GetBytes(stars), 0, savestate, (int)STARS_COUNT_ADDRESS, BitConverter.GetBytes(stars).Length);
            savestate[LIVES_COUNT_ADDRESS] = (byte)lives;
            savestate[HEALTH_ADDRESS] = (byte)health;
        }
        #endregion

        private void btn_SaveST_Click(object sender, EventArgs e)
        {
            SM64Push();

            byte[] st = savestate.ToArray();

            long oldSize = st.Length;
            
            // compress st array
            st = ExtensionMethods.Compress(st);

            FileStream fs = File.Open(Path, FileMode.OpenOrCreate);
            BinaryWriter br = new BinaryWriter(fs);
            br.Write(st);

            br.Flush(); br.Close(); fs.Close();


            MessageBox.Show(String.Format("Dumped savestate at {0}\nUncompressed size: {1}\nCompressed size: {2}", Path,
                ExtensionMethods.FormatBytes(oldSize),
                ExtensionMethods.FormatBytes(st.Length)));

        }

        private void cmb_Editmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Editmode.SelectedIndex == 0)
            {
                gp_RDRAM.Show();
                gp_Values.Show();
                SM64Load();
            }
            else if (cmb_Editmode.SelectedIndex == 1)
            {
                gp_RDRAM.Show();
                gp_Values.Hide();
            }
            else if (cmb_Editmode.SelectedIndex == 2)
            {
                gp_RDRAM.Hide();
                gp_Values.Show();
                SM64Load();
            }
        }

        
    }
}

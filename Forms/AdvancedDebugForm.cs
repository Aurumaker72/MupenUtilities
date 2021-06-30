using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MupenUtils.Forms
{
    public partial class AdvancedDebugForm : Form
    {
        byte[] file;

        int selectedFrame = 0;

        long selByte1;
        long selByte2;

        bool rangeMode;
        bool ignoreNUL;

        public AdvancedDebugForm()
        {
            InitializeComponent();
            this.Text = MainForm.PROGRAM_NAME + " - Misc. Tools";
            txt_Encoded.Multiline = true;
            txt_Encoded.ScrollBars = ScrollBars.Vertical;
            txt_Encoded.WordWrap = true;
        }

        private void txt_Debug_Uvalue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MainForm.inputLists[MainForm.selectedController][selectedFrame] = Int32.Parse(txt_Debug_Uvalue.Text);
            }
            catch { }
        }

        private void txt_Debug_Frame_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ExtensionMethods.ValidStringInt(txt_Debug_Frame.Text, 0, MainForm.inputLists[MainForm.selectedController].Count))
                    selectedFrame = Int32.Parse(txt_Debug_Frame.Text);
            }
            catch { }
        }

        private void btn_Debug_Random_Click(object sender, EventArgs e)
        {
            MainForm.inputLists[MainForm.selectedController][selectedFrame] = new Random().Next(0, Int32.MaxValue);
            txt_Debug_Uvalue.Text = MainForm.inputLists[MainForm.selectedController][selectedFrame].ToString();
        }

        private void AdvancedDebugForm_Shown_1(object sender, EventArgs e)
        {
            foreach (Control ctl in Controls)
                ctl.Enabled = MainForm.FileLoaded;

            if (MainForm.FileLoaded)
            {
                //for(int i=0;i<file.Length;i++)file[i]=0;
                file = File.ReadAllBytes(MainForm.Path);
            }
        }

        private void txt_Debug_Nthbyte_TextChanged(object sender, EventArgs e)
        {
            if (ExtensionMethods.ValidStringInt(txt_Debug_Bytefrom.Text, 0, file.Length))
            {
                selByte1 = Int32.Parse(txt_Debug_Bytefrom.Text);
                txt_Debug_Bytefrom.Text = selByte1.ToString();
                txt_Debug_Value.Text = file[selByte1].ToString();
                txt_Debug_HexByte.Text = file[selByte1].ToString("X2");
                if (rangeMode)
                {
                    UpdateEncoded();
                }
            }

        }
        private void txt_Debug_Byteto_TextChanged(object sender, EventArgs e)
        {
            if (ExtensionMethods.ValidStringInt(txt_Debug_Byteto.Text, 0, file.Length))
            {
                selByte2 = Int32.Parse(txt_Debug_Byteto.Text);
                txt_Debug_Byteto.Text = selByte2.ToString();
                //txt_Debug_Value.Text = file[selByte1].ToString();
                //txt_Debug_HexByte.Text = file[selByte1].ToString("X2");
                UpdateEncoded();
            }
        }
        private void chk_RangeMode_CheckedChanged(object sender, EventArgs e)
        {
            rangeMode ^= true;
            txt_Debug_Byteto.Visible  = 
            gp_Range.Visible          = rangeMode;

            lbl_Debug_Value.Visible   =
            txt_Debug_Value.Visible   =
            txt_Debug_HexByte.Visible =
            !rangeMode;

            if (rb_ASCII.Checked || rb_UTF8.Checked)
                ignoreNUL = false;
            chk_Ignorenulterm.Checked = ignoreNUL;
        }

        void UpdateEncoded()
        {
            List<byte> bytes = new List<byte>();

            for (long i = selByte1; i < selByte2; i++)
                bytes.Add(file[i]);


            string encoded = "Encode failed";
            // toarray exists but we need a workaround because of obscure practices by bitconverter class
            byte[] bytesArr = new byte[bytes.Count];
            bytesArr = bytes.ToArray();

            if (rb_Integer.Checked)
            {
                if (bytesArr.Length > 8)
                {
                    encoded = "Too big section\r\nTry a smaller range";
                }
                else if(bytesArr.Length < 8)
                {
                    encoded = "Too small section\r\nTry a bigger range";
                }
                else
                {
                    // lol this is
                    try
                    {
                        encoded = BitConverter.ToUInt64(bytesArr, 0).ToString();
                    }
                    catch
                    {
                        try
                        {
                            encoded = BitConverter.ToInt64(bytesArr, 0).ToString();
                        }
                        catch { }
                    }
                }
            }
            else if (rb_HexStr.Checked)
            {
                encoded = ExtensionMethods.ByteArrayToString(bytesArr);
            }
            else if (rb_UTF8.Checked)
            {
                if (ignoreNUL)
                    for (int i = 0; i < bytesArr.Length; i++)
                        if (bytesArr[i] == 0)
                            bytesArr[i] = (byte)'0';

                // we run into a dilemma
                // how to ignore nul terminator?
                encoded = System.Text.Encoding.UTF8.GetString(bytesArr);
                
            }
            else if (rb_ASCII.Checked)
            {

                if (ignoreNUL)
                    for (int i = 0; i < bytesArr.Length; i++)
                        if (bytesArr[i] == 0)
                            bytesArr[i] = (byte)'0';

                encoded = System.Text.Encoding.ASCII.GetString(bytesArr);

            }
            txt_Encoded.Text = encoded;

        }

        private void changedEncodeType(object sender, MouseEventArgs e)
        {
            UpdateEncoded();
        }

        private void chk_Ignorenulterm_CheckedChanged(object sender, EventArgs e)
        {
            ignoreNUL ^= true;
            UpdateEncoded();
        }
    }
}

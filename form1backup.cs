using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MupenUtils
{
    public partial class MainForm : Form
    {
        
        string Path;
        bool FileLoaded = true;

        // M64 Data as Strings
        string Magic;
        string Version;
        string UID;
        string VIs;
        string RRs;
        string Controllers;
        string StartType;
        string VideoPlugin;
        string InputPlugin;
        string AudioPlugin;
        string RSPPlugin;

        string Name; // Name = m64 file name (path)
        string Author;
        string Description;

        public MainForm()
        {
            InitializeComponent();
            InitUI();
        }

        public static string ByteArrayToString(byte[] ba)
        {
           StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);

            return "0x" + hex.ToString().ToUpper();
            
        }
        
        void InitUI()
        {
            st_Status1.Text = "";
            rb_M64sel.Checked = true;
        }

        void ShowStatus(string Message)
        {
            st_Status1.Text = Message;
            new Thread(() =>
               {
               Thread.Sleep(2000);
               st_Status1.Text = ""; // This is NOT thread-safe. HOW DOES THIS NOT CRASH?!?!?! 
               }).Start();
        }
        private void btn_PathSel_MouseClick(object sender, MouseEventArgs e)
        {
            ShowStatus("Selecting movie...");
            object[] result = UIHelper.ShowFileDialog(false);
            if ((string)result[0] == "FAIL" && (bool)result[1] == false)
            {
                ShowStatus("Cancelled movie selection");
                return;
            }

            Path = txt_Path.Text = (string)result[0];
            FileLoaded = true;

            if (rb_M64sel.Checked)
                LoadM64();
            else if (rb_STsel.Checked)
                LoadST();
        }

        void LoadM64()
        {
            ShowStatus("Loading M64");
            BinaryReader br = new BinaryReader(File.Open(Path, FileMode.Open));

            // Read header
            Magic = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            txt_misc_Magic.Text = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            txt_misc_Version.Text = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            txt_misc_UID.Text = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));

            //00C 4-byte little-endian unsigned int: number of frames (vertical interrupts)
            //010 4-byte little-endian unsigned int: rerecord count
            //014 1-byte unsigned int: frames (vertical interrupts) per second
            //015 1-byte unsigned int: number of controllers
            txt_VIs.Text = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            txt_RR.Text = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            br.ReadByte(); // frames (vertical interrupts) per second ---- SEEK 1 BYTE FORWARD (DUMMY)
            txt_CTRLS.Text = ByteArrayToString(BitConverter.GetBytes(br.ReadByte()));
            br.ReadBytes(2); // reserved --- Seek 2 bytes forward (dummy)
            br.ReadInt32(); // input samples --- Seek 4 bytes forward (dummy)
            Int16 movieStartupType = br.ReadInt16();
            switch (movieStartupType)
            {
                case 1:
                    txt_StartType.Text = "Snapshot";
                    break;
                case 2:
                    txt_StartType.Text = "Power on";

                    break;
                case 3:
                    txt_StartType.Text = "EEPROM";
                    break;
                default:
                    txt_StartType.Text = "Unknown";
                    break;
            }


            br.ReadInt16(); // reserved -- seek 2 bytes forward (dummy)
            br.ReadInt32(); // controller flags
            br.ReadBytes(160); // reserved
            br.ReadBytes(32); // rom name
            br.ReadUInt32();// crc32
            br.ReadInt16(); // country code
            br.ReadBytes(56); // reserved

            /*
            64-byte ASCII string: name of video plugin used when recording, directly from plugin
            64-byte ASCII string: name of sound plugin used when recording, directly from plugin
            64-byte ASCII string: name of input plugin used when recording, directly from plugin
            64-byte ASCII string: name of rsp plugin used when recording, directly from plugin
            222-byte UTF-8 string: author name info
            256-byte UTF-8 string: author movie description info
            */
            ASCIIEncoding ascii = new ASCIIEncoding();
            txt_videoplugin.Text = ascii.GetString(br.ReadBytes(64));
            txtbox_Audioplugin.Text = ascii.GetString(br.ReadBytes(64));
            txt_inputplugin.Text = ascii.GetString(br.ReadBytes(64));
            txt_Rsp.Text = ascii.GetString(br.ReadBytes(64));

            ShowStatus("Loaded M64");
        }

        void LoadST()
        {
            // WIP...
            ShowStatus("ST Loading not implemented yet");
        }

        private void rb_M64sel_MouseDown(object sender, MouseEventArgs e)
        {
            if(!txt_Path.ReadOnly)
            txt_Path.ReadOnly = true;
            ShowStatus("Type: M64");
        }
        private void rb_STsel_MouseDown(object sender, MouseEventArgs e)
        {
            if(!txt_Path.ReadOnly)
            txt_Path.ReadOnly = true;
            ShowStatus("Type: Savestate");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

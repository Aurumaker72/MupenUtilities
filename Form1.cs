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
        string VIsecond;
        string RRs;
        string Controllers;
        string StartType;
        string RomName;
        string Crc32;
        string RomCountry;
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
            object[] result = UIHelper.ShowFileDialog(true, rb_M64sel.Checked);
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
            ASCIIEncoding ascii = new ASCIIEncoding();
            UTF8Encoding utf8 = new UTF8Encoding();
            BinaryReader br = new BinaryReader(File.Open(Path, FileMode.Open));

            // Read header
            Magic = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            Version = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            UID = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));

            //00C 4-byte little-endian unsigned int: number of frames (vertical interrupts)
            //010 4-byte little-endian unsigned int: rerecord count
            //014 1-byte unsigned int: frames (vertical interrupts) per second
            //015 1-byte unsigned int: number of controllers
            VIs = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            RRs = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            VIsecond = ByteArrayToString(BitConverter.GetBytes(br.ReadByte())); // frames (vertical interrupts) per second ---- SEEK 1 BYTE FORWARD (DUMMY)
            
            Controllers = ByteArrayToString(BitConverter.GetBytes(br.ReadByte()));
            br.ReadBytes(2); // reserved --- Seek 2 bytes forward (dummy)
            br.ReadInt32(); // input samples --- Seek 4 bytes forward (dummy)
            Int16 movieStartupType = br.ReadInt16();
            switch (movieStartupType)
            {
                case 1:
                    StartType = "Snapshot";
                    break;
                case 2:
                    StartType = "Power on";
                    break;
                case 4:
                    StartType = "EEPROM";
                    break;
                default:
                    StartType = "Unknown";
                    break;
            }


            br.ReadInt16(); // reserved -- seek 2 bytes forward (dummy)
            br.ReadInt32(); // controller flags
            br.ReadBytes(160); // reserved
            RomName = ascii.GetString(br.ReadBytes(32)); // rom name
            Crc32 = br.ReadUInt32().ToString();// crc32
            
            Int16 romCountry = br.ReadInt16(); // country code
            br.ReadBytes(56); // reserved
            switch(romCountry&0xFF)
	        {
	        /* Demo */
	        case 0:
                    RomCountry = "Demo";
	        	break;

	        case '7':
                    RomCountry = "Beta";
	        	break;

	        case 0x41:
                    RomCountry = "USA/Japan";
	        	break;

	        /* Germany */
	        case 0x44:
                    RomCountry = "German";
	        	break;

	        /* USA */
	        case 0x45:
                case 0x60:
                    RomCountry = "USA";
	        	break;

	        /* France */
	        case 0x46:
                    RomCountry = "France";
	        	break;

	        /* Italy */
	        case 'I':
                    RomCountry = "Italy";
	        	break;

	        /* Japan */
	        case 0x4A:
                    RomCountry = "Japan";
	        	break;

	        case 'S':	/* Spain */
                    RomCountry = "Spain";
	        	break;

	        /* Australia */
	        case 0x55:
	        case 0x59:
                    RomCountry = "Australia";
	        	break;

            case 0x50:
            case 0x58:
	        case 0x20:
	        case 0x21:
	        case 0x38:
	        case 0x70:
                    RomCountry = "Europe";
	        	break;

	        default:
                    RomCountry = "Unknown (" + romCountry + ")";
	        	break;
	        }
            /*
            64-byte ASCII string: name of video plugin used when recording, directly from plugin
            64-byte ASCII string: name of sound plugin used when recording, directly from plugin
            64-byte ASCII string: name of input plugin used when recording, directly from plugin
            64-byte ASCII string: name of rsp plugin used when recording, directly from plugin
            222-byte UTF-8 string: author name info
            256-byte UTF-8 string: author movie description info
            */
            VideoPlugin = ascii.GetString(br.ReadBytes(64));
            AudioPlugin = ascii.GetString(br.ReadBytes(64));
            InputPlugin = ascii.GetString(br.ReadBytes(64));
            RSPPlugin = ascii.GetString(br.ReadBytes(64));

            Name = System.IO.Path.GetFileNameWithoutExtension(Path);
            Author = utf8.GetString(br.ReadBytes(222));
            Description = utf8.GetString(br.ReadBytes(256));

            br.Close(); // destroy handle

            /*Set Controls*/
            txt_misc_Magic.Text = Magic;
            txt_misc_Version.Text = Version;
            txt_misc_UID.Text = UID;

            txt_VIs.Text = VIs;
            txt_RR.Text = RRs;
            txt_CTRLS.Text = Controllers;
            txt_StartType.Text = StartType;
            //RomName
            txt_videoplugin.Text = VideoPlugin;
            txt_inputplugin.Text = InputPlugin;
            txtbox_Audioplugin.Text = AudioPlugin;
            txt_Rsp.Text = RSPPlugin;

            txt_Rom.Text = RomName;
            txt_Crc.Text = Crc32;
            txt_RomCountry.Text = RomCountry;

            txt_PathName.Text = Name;
            txt_Author.Text = Author;
            txt_Desc.Text = Description;

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


    }
}

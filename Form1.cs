using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        UInt32 VIs;
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
        int Samples;

        string M64Name; // Name = m64 file name (path)
        string Author;
        string Description;

        public CheckBox[] controllerbuttons;
        List<int> inputList = new List<int>();
        int frame;

        public MainForm()
        {
            InitializeComponent();
            InitUI();
            InitController();
        }

        public static string ByteArrayToString(byte[] ba)
        {
           StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);

            return "0x" + hex.ToString().ToUpper();
            
        }
        
        void InitController()
        {
            controllerbuttons = new CheckBox[] {
            chk_Right,  // R_DPAD
            chk_Left,   // L_DPAD
            chk_Down,   // D_DPAD
            chk_Up,     // U_DPAD
            Chk_start,  // START_BUTTON
            chk_Z,      // Z_TRIG
            chk_B,      // B_BUTTON    
            chk_A,      // A_BUTTON    


            chk_Cright, // R_CBUTTON
            chk_Cleft,  // L_CBUTTON    
            chk_Cdown,  //D_CBUTTON    
            chk_Up,     //U_CBUTTON    
            
            
            
            chk_R,      //R_TRIG
            chk_L       //L_TRIG
        };

        }
        void InitUI()
        {
            st_Status1.Text = "";
            rb_M64sel.Checked = true;
            EnableM64View(false,true);
        }

        void ShowStatus(string msg)
        {
            st_Status1.Text = msg;
            new Thread(() =>
               {
               Thread.Sleep(2000);
               st_Status1.Text = ""; // This is NOT thread-safe. HOW DOES THIS NOT CRASH?!?!?! 
               }).Start();
        }
        void RedControl(Control ctrl)
        {
            Color tempcolor = ctrl.ForeColor;
            ctrl.ForeColor = Color.Red;
            new Thread(() =>
               {
               Thread.Sleep(1000);
               ctrl.ForeColor = tempcolor;
               }).Start();
        }
        void EnableM64View(bool flag, bool change)
        {
            Size s;
            FileLoaded = flag;
            if (flag)
            {
                gp_M64.Show();
                s = new Size(687, 483);
            } 
            else
            {
                gp_M64.Hide();
               s = new Size(360+btn_Override.Width+20, 150);
            }
            this.Size = s;
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

            if (rb_M64sel.Checked){
                LoadM64();}
            else if (rb_STsel.Checked){
                LoadST();}
        }

        string GetMovieStartupType(short stype)
        {
            string type;
            switch (stype)
            {
                case 1:
                    type = "Snapshot";
                    break;
                case 2:
                    type = "Power on";
                    break;
                case 4:
                    type = "EEPROM";
                    break;
                default:
                    type = "Unknown";
                    break;
            }
            return type;
        }
        string GetCountryCode(short ccode)
        {
            string code = "Error";
            switch(ccode&0xFF)
	        {
	        /* Demo */
	        case 0:
                    code = "Demo";
	        	break;
	        case '7':
                    code = "Beta";
	        	break;

	        case 0x41:
                    code = "USA/Japan";
	        	break;

	        /* Germany */
	        case 0x44:
                    code = "German";
	        	break;

	        /* USA */
	        case 0x45:
                case 0x60:
                    code = "USA";
	        	break;

	        /* France */
	        case 0x46:
                    code = "France";
	        	break;

	        /* Italy */
	        case 'I':
                    code = "Italy";
	        	break;

	        /* Japan */
	        case 0x4A:
                    code = "Japan";
	        	break;

	        case 'S':	/* Spain */
                    code = "Spain";
	        	break;

	        /* Australia */
	        case 0x55:
	        case 0x59:
                    code = "Australia";
	        	break;

            case 0x50:
            case 0x58:
	        case 0x20:
	        case 0x21:
	        case 0x38:
	        case 0x70:
                    code = "Europe";
	        	break;

	        default:
                    code = "Unknown (" + ccode + ")";
	        	break;
	        }
            return code;
        }
        void LoadM64()
        {
            ShowStatus("Loading M64");

            // Check for suspicious properties
            long len = new FileInfo(Path).Length;
            if(len < 1028 || !System.IO.Path.GetExtension(Path).Equals(".m64",StringComparison.InvariantCultureIgnoreCase))
            {
                ShowStatus("Invalid M64");
                txt_Path.Text = Path = string.Empty;
                this.ActiveControl = null;
                RedControl(btn_PathSel);
                EnableM64View(false,true);
                return;
            }
            EnableM64View(true,true);
            ASCIIEncoding ascii = new ASCIIEncoding();
            UTF8Encoding utf8 = new UTF8Encoding();
            BinaryReader br = new BinaryReader(File.Open(Path, FileMode.Open));

            
            // Read header
            Magic = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            Version = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            UID = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            VIs = br.ReadUInt32();//ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            RRs = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            br.ReadByte(); // frames (vertical interrupts) per second ---- SEEK 1 BYTE FORWARD (DUMMY)
            Controllers = ByteArrayToString(BitConverter.GetBytes(br.ReadByte()));
            br.ReadBytes(2); // reserved --- Seek 2 bytes forward (dummy)
            Samples = br.ReadInt32(); // input samples --- Seek 4 bytes forward (dummy)
            StartType = GetMovieStartupType(br.ReadInt16());

            br.ReadInt16(); // reserved -- seek 2 bytes forward (dummy)
            br.ReadInt32(); // controller flags -- seek 4 bytes forward (dummy)
            br.ReadBytes(160); // reserved -- seek 160 bytes forward (dummy)
            RomName = ascii.GetString(br.ReadBytes(32)); // rom name
            Crc32 = br.ReadUInt32().ToString();// crc32
            
            RomCountry = GetCountryCode(br.ReadInt16()); // Country code
            br.ReadBytes(56); // reserved -- seek 56 bytes forward (dummy)

            
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

            // Load inputs
            // We need a buffer to check if end of file reached
            Debug.WriteLine("VI/s:" + VIs);
            UInt32 frames = VIs / 2;
            for (int i = 0; i <= frames; i++)
            {
                Debug.WriteLine("--- Sample " + i + "/" + frames + " ---");
                inputList.Add(br.ReadInt32());
            }


            br.Close(); // destroy handle

            /*Set Controls*/
            txt_misc_Magic.Text = Magic;
            txt_misc_Version.Text = Version;
            txt_misc_UID.Text = UID;

            txt_VIs.Text = ascii.GetString(BitConverter.GetBytes(VIs));
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


        private void btn_Override_MouseDown(object sender, MouseEventArgs e)
        {
            if (FileLoaded)
            {
                EnableM64View(false, false);
                btn_Override.Text = "Expand";
            }
            else
            {
                EnableM64View(true, false);
                btn_Override.Text = "Collapse";
            }
        }







        int GetChkboxes()
        {
            int value = 0;
            for (int i = 0; i < controllerbuttons.Length; i++)
            {
                if (controllerbuttons[i].Checked)
                {
                    value |= (int)Math.Pow(2, i);
                }
            }
            return value;
        }
        void SetChkboxes(int value)
        {
            for (int i = 0; i < controllerbuttons.Length; i++)
            {
                controllerbuttons[i].Checked = Convert.ToBoolean(value & (int)Math.Pow(2, i));
            }
        }
        void StepFrame()
        {
            frame++;
            lbl_FrameSelected.Text = "Frame " + frame;
            SetChkboxes(inputList[frame]);
        }
        private void btn_FrameFront_Click(object sender, EventArgs e)
        {
            StepFrame();
        }
    }
}

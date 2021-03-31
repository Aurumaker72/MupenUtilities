using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MupenUtils
{
    public partial class MainForm : Form
    {
        #region Vars

        const string M64_LOADED_TEXT = "M64 Loaded";
        const string M64_LOADING_TEXT = "M64 Loading";
        const string M64_FAILED_TEXT = "M64 Invalid";
        const string M64_SELECTED_TEXT = "Type: M64";
        const string ST_SELECTED_TEXT = "Type: ST";

        string Path;
        bool FileLoaded = false;
        bool loopInputs = true;
        bool bypassTypeCheck = false;
        bool forwardsPlayback = true;

        // M64 Data as Strings
        string Magic;
        string Version;
        string UID;
        UInt32 VIs;
        UInt32 frames;
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

        public CheckBox[] controllerButtonsChk;
        List<int> inputList = new List<int>();
        int frame;
        System.Windows.Forms.Timer stepFrameTimer = new System.Windows.Forms.Timer();

        #endregion

        #region Setup

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
            controllerButtonsChk = new CheckBox[] {
            chk_Right,  // R_DPAD              (CONTROL)
            chk_Left,   // L_DPAD              (CONTROL)
            chk_Down,   // D_DPAD              (CONTROL)
            chk_Up,     // U_DPAD              (CONTROL)

            Chk_start,  // START_BUTTON        (CONTROL)
            chk_Z,      // Z_TRIG              (CONTROL)
            chk_B,      // B_BUTTON            (CONTROL)
            chk_A,      // A_BUTTON            (CONTROL)

            chk_Cright, // R_CBUTTON           (CONTROL)
            chk_Cleft,  // L_CBUTTON           (CONTROL)
            chk_Cdown,  //D_CBUTTON            (CONTROL)
            chk_Up,     //U_CBUTTON            (CONTROL)

            chk_R,      //R_TRIG               (CONTROL)
            chk_L,       //L_TRIG               (CONTROL)

            chk_RESERVED1,    // RESERVED!!! (CONTROL)
            chk_RESERVED2     // RESERVED!!! (CONTROL)
        };

            stepFrameTimer.Tick += new EventHandler(AdvanceInputAuto);
            stepFrameTimer.Interval = 32; // 30 fps
            stepFrameTimer.Stop();
        }
        
        void InitUI()
        {
            st_Status1.Text = st_Status2.Text = "";
            rb_M64sel.Checked = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            st_Status.Visible = false;
            gp_M64.Visible = false;
            gp_Path.Dock = DockStyle.Fill;

            EnableM64View(false,true);
        }

        #endregion

        #region UI

        void ShowStatus(string msg, ToolStripStatusLabel ctl)
        {
            ctl.Text = msg;
            new Thread(() =>
               {
               Thread.Sleep(1000);
               ctl.GetCurrentParent().Invoke((MethodInvoker)(() => ctl.Text = string.Empty));
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

            this.SuspendLayout();
            gp_M64.Visible = flag;
            s = flag ? new Size(1005,580) : new Size(360+btn_Override.Width+20, 150);
            this.FormBorderStyle = FileLoaded ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle;
            gp_Path.Dock = FileLoaded ? DockStyle.Top : DockStyle.Fill;
            st_Status.Visible = FileLoaded;

            this.Size = s;
            this.ResumeLayout();
        }

        #endregion

        #region I/O

        void LoadM64()
        {
            ShowStatus(M64_LOADING_TEXT,st_Status1);
            this.Text = M64_LOADING_TEXT;
            // Check for suspicious properties
            long len = new FileInfo(Path).Length;
            if (!bypassTypeCheck && (len < 1028 || !System.IO.Path.GetExtension(Path).Equals(".m64", StringComparison.InvariantCultureIgnoreCase)))
            {
                ShowStatus("Invalid M64", st_Status1);
                txt_Path.Text = Path = string.Empty;
                this.ActiveControl = null;
                RedControl(btn_PathSel);
                EnableM64View(false, true);
                return;
            }
            ASCIIEncoding ascii = new ASCIIEncoding();
            UTF8Encoding utf8 = new UTF8Encoding();
            FileStream fs = File.Open(Path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            
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
            StartType = DataHelper.GetMovieStartupType(br.ReadInt16());

            br.ReadInt16(); // reserved -- seek 2 bytes forward (dummy)
            br.ReadInt32(); // controller flags -- seek 4 bytes forward (dummy)
            br.ReadBytes(160); // reserved -- seek 160 bytes forward (dummy)
            RomName = ascii.GetString(br.ReadBytes(32)); // rom name
            Crc32 = br.ReadUInt32().ToString();// crc32
            
            RomCountry = DataHelper.GetCountryCode(br.ReadInt16()); // Country code
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
            frames = VIs / 2;
            NetworkStream nstr = br.BaseStream as NetworkStream;
            for (int i = 0; i <= frames; i++)
            {
                if (br.BaseStream.Position + 4 > fs.Length) continue;
                Debug.WriteLine("--- Sample " + i + "/" + frames + " ---");
                inputList.Add(br.ReadInt32());
            }

            br.Close(); // destroy handle

            /*Set Controls*/
            txt_misc_Magic.Text = Magic;
            txt_misc_Version.Text = Version;
            txt_misc_UID.Text = UID;

            txt_VIs.Text = ByteArrayToString(BitConverter.GetBytes(VIs));
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


            
            EnableM64View(true,true);
            ShowStatus(M64_LOADED_TEXT,st_Status1);
            this.Text = M64_LOADED_TEXT;
        }
        void LoadST()
        {
            // WIP...
            ShowStatus("ST Loading not implemented yet",st_Status1);
        }
        #endregion

        #region Input & Frames

        int GetChkboxes()
        {
            int value = 0;
            for (int i = 0; i < controllerButtonsChk.Length; i++)
            {
                if (controllerButtonsChk[i].Checked)
                {
                    value |= (int)Math.Pow(2, i);
                }
            }
            return value;
        }

        void SetInput(int value)
        {
            int numbuttons = controllerButtonsChk.Length; // wip
            for (int i = 0; i < numbuttons; i++)
            {
                //Debug.WriteLine("Checkbox index " + i + " | Value AND: " + (value & (int)Math.Pow(2, i)));
                controllerButtonsChk[i].Checked = (value & (int)Math.Pow(2, i)) != 0;
            }
            chk_restart.Checked = chk_RESERVED1.Checked && chk_RESERVED2.Checked;
            chk_restart.ForeColor = chk_restart.Checked ? Color.Orange : Color.Black;
            int joystick = 16&ExtensionMethods.LowWord(value);
            Debug.WriteLine("[FRAME] " + frame + " " + "After doing lowword computing | Joystick ushort = " + joystick.ToString());
            sbyte joystickX = (sbyte)(joystick >> 8);
            sbyte joystickY = (sbyte)(joystick & 0x00FF);
            txt_joyX.Text = joystickX.ToString();
            txt_joyY.Text = joystickY.ToString();
            //Debug.WriteLine("[FRAME] " + frame + " " + "--- WORD: " + joystick.ToString() + " --- X/Y " + joystickX.ToString() + " " + joystickY.ToString());
            
        }

        bool checkAllowedStep(int stepAmount)
        {
            if(frame >= frames || frame <= 0 || frame >= inputList.Count)
            {
                if(!loopInputs)
                frame = (int)frames;
                else
                {
                    if(frame >= frames)
                    {
                        frame = 0;
                    }else if(frame <= 0)
                    {
                        frame = (int)frames-1;
                    }
                }
                lbl_FrameSelected.Text = "Frame " + frame;
                return false;
            }
            return true;
        }

        void StepFrame(int stepAmount)
        {
            frame += stepAmount;
            if (!checkAllowedStep(stepAmount)) return;
            lbl_FrameSelected.Text = "Frame " + frame;
            lbl_FrameSelected.ForeColor = Color.Black;
            SetInput(inputList[frame]);
        }
        #endregion

        #region Event Handlers

        private void btn_PathSel_MouseClick(object sender, MouseEventArgs e)
        {
            ShowStatus("Selecting movie...",st_Status1);
            object[] result = UIHelper.ShowFileDialog(true, rb_M64sel.Checked);
            if ((string)result[0] == "FAIL" && (bool)result[1] == false)
            {
                ShowStatus("Cancelled movie selection",st_Status1);
                return;
            }

            Path = txt_Path.Text = (string)result[0];

            if (rb_M64sel.Checked){
                LoadM64();}
            else if (rb_STsel.Checked){
                LoadST();}
        }
        private void rb_M64sel_MouseDown(object sender, MouseEventArgs e)
        {
            bypassTypeCheck = e.Button != MouseButtons.Left;
            btn_PathSel.ForeColor = bypassTypeCheck ? Color.Orange : Color.Black;
            btn_PathSel.Text = e.Button==MouseButtons.Left ? "Browse M64" : "Browse Any";
        }
        private void rb_STsel_MouseDown(object sender, MouseEventArgs e)
        {
            bypassTypeCheck = e.Button != MouseButtons.Left;
            btn_PathSel.ForeColor = bypassTypeCheck ? Color.Orange : Color.Black;
            btn_PathSel.Text = e.Button==MouseButtons.Left ? "Browse ST" : "Browse Any";
        }
        private void btn_Override_MouseDown(object sender, MouseEventArgs e)
        {
            EnableM64View(!FileLoaded, false);
            btn_Override.Text = FileLoaded ? "v" : "^";
        }
        private void btn_FrameFront_Click(object sender, EventArgs e)
        {
            StepFrame(1);
        }
        private void btn_FrameFront2_Click(object sender, EventArgs e)
        {
            StepFrame(2);
        }
        private void btn_FrameBack_Click(object sender, EventArgs e)
        {
            StepFrame(-1);
        }
        private void btn_FrameBack2_Click(object sender, EventArgs e)
        {
            StepFrame(-2);
        }
        void AdvanceInputAuto(object obj, EventArgs e)
        {
            if(forwardsPlayback)
            StepFrame(1);
            else
            StepFrame(-1);
        }
        private void btn_PlayPause_Click(object sender, EventArgs e)
        {
            // Toggle timer
            stepFrameTimer.Enabled = !stepFrameTimer.Enabled;
            btn_PlayPause.Text = stepFrameTimer.Enabled ? "| |" : ">";
        }
        private void btn_Loop_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            loopInputs = !loopInputs;
            btn_Loop.Text = loopInputs ? "➡️" : "🔁";
        }
        private void btn_PlayDirection_Click(object sender, EventArgs e)
        {
            forwardsPlayback = !forwardsPlayback;
            btn_PlayDirection.Text = forwardsPlayback ? ">" : "<";
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
#if DEBUG
            Debug.WriteLine("Window Resize (W/H) " + Width + " " + Height);
#endif
        }






        #endregion
    }
}

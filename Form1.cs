﻿using System;
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
        bool m64ThreadRunning = false;
        bool readOnly = true;

        // M64 Data as Strings
        string Magic;
        string Version;
        Int32 UID;
        UInt32 VIs; // vis
        byte VI_s; // vi/s
        UInt32 frames;
        UInt32 RRs;
        byte Controllers;
        Int16 StartType;
        string RomName;
        UInt32 Crc32;
        UInt16 RomCountry;
        string VideoPlugin;
        string InputPlugin;
        string AudioPlugin;
        string RSPPlugin;
        UInt32 Samples;
        UInt32 ControllerFlags;

        string M64Name; // Name = m64 file name (path)
        string Author;
        string Description;

        public CheckBox[] controllerButtonsChk;
        List<int> inputList = new List<int>();
        List<int> SAVE_inputList = new List<int>();
        int frame;
        System.Windows.Forms.Timer stepFrameTimer = new System.Windows.Forms.Timer();

        // Joystick input
        //int JOY_Relx, JOY_Rely, JOY_Absx, JOY_Absy;
        Point JOY_Rel, JOY_Abs, JOY_middle;
        bool JOY_mouseDown, JOY_followMouse;
        const int JOY_clampDif = 4;

        #endregion

        #region Setup

        public MainForm()
        {
            InitializeComponent();
            InitController();
            InitUI();
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

            JOY_middle.X = pb_JoystickPic.Width / 2;
            JOY_middle.Y = pb_JoystickPic.Height / 2;
        }
        
        void InitUI()
        {
            st_Status1.Text = st_Status2.Text = "";
            rb_M64sel.Checked = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            st_Status.Visible = false;
            gp_M64.Visible = false;
            gp_Path.Dock = DockStyle.Fill;
            JOY_Abs = new Point(pb_JoystickPic.Width / 2, pb_JoystickPic.Height / 2);
            UpdateReadOnly();
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
               if(ctl.GetCurrentParent()!=null)
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
            if(change) FileLoaded = flag;

            this.SuspendLayout();
            gp_M64.Visible = flag;
            s = flag ? new Size(1005,580) : new Size(360+btn_Override.Width+20, 150);
            this.FormBorderStyle = flag ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle;
            gp_Path.Dock = flag ? DockStyle.Top : DockStyle.Fill;
            st_Status.Visible = flag;
            this.MaximizeBox = flag;
            if (!flag) this.WindowState = FormWindowState.Normal;
            this.Size = s;
            this.ResumeLayout();
        }

        private void ShowStatus_ThreadSafe(string txt)
        {
            st_Status1.GetCurrentParent().Invoke((MethodInvoker)(() => st_Status1.Text = txt));
            Thread.Sleep(1000);
            st_Status1.GetCurrentParent().Invoke((MethodInvoker)(() => st_Status1.Text = string.Empty));
        }
        private void EnableM64View_ThreadSafe(bool flag)
        {
            Size s;
            FileLoaded = flag;
            gp_M64.Invoke((MethodInvoker)(() => gp_M64.Visible = flag));
            s = flag ? new Size(1005, 580) : new Size(360 + btn_Override.Width + 20, 150);
            this.Invoke((MethodInvoker)(() => this.FormBorderStyle = flag ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle));
            gp_Path.Invoke((MethodInvoker)(() => gp_Path.Dock = flag ? DockStyle.Top : DockStyle.Fill));
            st_Status.Invoke((MethodInvoker)(() => gp_Path.Visible = flag));
            this.Invoke((MethodInvoker)(() => this.MaximizeBox = flag));
            if (!flag) this.Invoke((MethodInvoker)(() => this.WindowState = FormWindowState.Normal));
            this.Invoke((MethodInvoker)(() => this.Size = s));
            
        }

        #endregion

        #region I/O

        void ReadM64()
        {
            m64ThreadRunning = true;
            // Check for suspicious properties
            long len = new FileInfo(Path).Length;
            if (!bypassTypeCheck && (/*len < 1028 || */!System.IO.Path.GetExtension(Path).Equals(".m64", StringComparison.InvariantCultureIgnoreCase) || String.IsNullOrEmpty(Path) || String.IsNullOrWhiteSpace(Path)))
            {
                ShowStatus_ThreadSafe(M64_FAILED_TEXT);
                // set status

                txt_Path.Invoke((MethodInvoker)(() => txt_Path.Text = string.Empty));
                // clear path textbox

                this.Invoke((MethodInvoker)(() => this.ActiveControl = null));
                // clear active control


                EnableM64View_ThreadSafe(false);
                // set m64 style

                m64ThreadRunning = false;
                return;
            }
            ASCIIEncoding ascii = new ASCIIEncoding();
            UTF8Encoding utf8 = new UTF8Encoding();
            FileStream fs = File.Open(Path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);


            // Read header
            Magic = ExtensionMethods.ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            Version = ExtensionMethods.ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            UID = br.ReadInt32();
            VIs = br.ReadUInt32();//ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            RRs = br.ReadUInt32();
            VI_s = br.ReadByte(); // frames (vertical interrupts) per second ---- SEEK 1 BYTE FORWARD (DUMMY)
            Controllers = br.ReadByte();
            br.ReadBytes(2); // reserved --- Seek 2 bytes forward (dummy)
            Samples = br.ReadUInt32(); // input samples --- Seek 4 bytes forward (dummy)
            StartType = br.ReadInt16();//DataHelper.GetMovieStartupType(br.ReadInt16());

            br.ReadInt16(); // reserved -- seek 2 bytes forward (dummy)
            ControllerFlags = br.ReadUInt32(); // controller flags -- seek 4 bytes forward (dummy)
            br.ReadBytes(160); // reserved -- seek 160 bytes forward (dummy)
            RomName = ascii.GetString(br.ReadBytes(32)); // rom name
            Crc32 = br.ReadUInt32();// crc32

            RomCountry = br.ReadUInt16();//.GetCountryCode(br.ReadInt16()); // Country code
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

            M64Name = System.IO.Path.GetFileNameWithoutExtension(Path);
            Author = utf8.GetString(br.ReadBytes(222));
            Description = utf8.GetString(br.ReadBytes(256));

            // Load inputs
            // We need a buffer to check if end of file reached
            Debug.WriteLine("VI/s:" + VIs);
            frames = VIs / 2;
            int findx = 0;
            while(findx <= frames)
            {
                if (br.BaseStream.Position + 4 > fs.Length) {
                    findx++;
                    continue;
                }
#if DEBUG
                Debug.WriteLine("--- Sample " + findx + "/" + frames + " ---");
#endif
                inputList.Add(br.ReadInt32());
                findx++;
            }
            SAVE_inputList = inputList; // copy




            br.Close(); // destroy handle

            /*Set Controls*/
            txt_misc_Magic.Invoke((MethodInvoker)(() => txt_misc_Magic.Text = Magic));
            txt_misc_Version.Invoke((MethodInvoker)(() => txt_misc_Version.Text = Version));
            txt_misc_UID.Invoke((MethodInvoker)(() => txt_misc_UID.Text = UID.ToString()));

            txt_VIs.Invoke((MethodInvoker)(() => txt_VIs.Text = VIs.ToString()));
            txt_RR.Invoke((MethodInvoker)(() => txt_RR.Text = RRs.ToString()));
            txt_CTRLS.Invoke((MethodInvoker)(() => txt_CTRLS.Text = Controllers.ToString()));
            txt_StartType.Invoke((MethodInvoker)(() => txt_StartType.Text = DataHelper.GetMovieStartupType(StartType)));

            txt_videoplugin.Invoke((MethodInvoker)(() => txt_videoplugin.Text = VideoPlugin));
            txt_inputplugin.Invoke((MethodInvoker)(() => txt_inputplugin.Text = InputPlugin));
            txtbox_Audioplugin.Invoke((MethodInvoker)(() => txtbox_Audioplugin.Text = AudioPlugin));
            txt_Rsp.Invoke((MethodInvoker)(() => txt_Rsp.Text = RSPPlugin));

            txt_Rom.Invoke((MethodInvoker)(() => txt_Rom.Text = RomName));
            txt_Crc.Invoke((MethodInvoker)(() => txt_Crc.Text = Crc32.ToString()));
            txt_RomCountry.Invoke((MethodInvoker)(() => txt_RomCountry.Text = DataHelper.GetCountryCode(RomCountry)));

            txt_PathName.Invoke((MethodInvoker)(() => txt_PathName.Text = M64Name));
            txt_Author.Invoke((MethodInvoker)(() => txt_Author.Text = Author));
            txt_Desc.Invoke((MethodInvoker)(() => txt_Desc.Text = Description));

            EnableM64View_ThreadSafe(true);

            ShowStatus_ThreadSafe(M64_LOADED_TEXT);

            m64ThreadRunning = false; 
        }

        void WriteM64()
        {
            if (!FileLoaded) return;
            File.Delete(Path + "-modified.m64");
            FileStream fs = File.Open(Path+"-modified.m64", FileMode.OpenOrCreate);
            BinaryWriter br = new BinaryWriter(fs);

            byte[] zeroar1 = new byte[160]; byte[] zeroar2 = new byte[56];
            Array.Clear(zeroar1, 0, zeroar1.Length); 
            Array.Clear(zeroar2, 0, zeroar2.Length);

            UID = Int32.Parse(txt_misc_UID.Text);
            VIs = UInt32.Parse(txt_VIs.Text);
            RRs = UInt32.Parse(txt_RR.Text);
            Controllers = byte.Parse(txt_CTRLS.Text);
            RomName = txt_Rom.Text;
            VideoPlugin = txt_videoplugin.Text;
            AudioPlugin = txtbox_Audioplugin.Text;
            InputPlugin = txt_inputplugin.Text;
            RSPPlugin = txt_Rsp.Text;
            Author = txt_Author.Text;
            Description = txt_Desc.Text;

            br.Write((Int32)1295397914); // Int32 - Magic (4D36341A)
            br.Write((UInt32)3); // UInt32 - Version number (3)
            br.Write(UID); // UInt32 - UID
            br.Write((UInt32)VIs); // UInt32 - VIs
            br.Write((UInt32)RRs); // UInt32 - RRs
            br.Write(VI_s); // Byte - VI/s
            br.Write(Controllers); // Byte - Controllers
            br.Write((Int16)0); // 2 Bytes - RESERVED
            br.Write(Samples); // UInt32 - Input Samples
            br.Write(StartType); // UInt16 - Movie start type
            br.Write((Int16)0); // 2 bytes - RESERVED
            br.Write(ControllerFlags); // UInt32 - Controller Flags
            br.Write(zeroar1,0,zeroar1.Length); // 160 bytes - RESERVED
            byte[] romname = new byte[32];
            romname = ASCIIEncoding.ASCII.GetBytes(RomName);
            Array.Resize(ref romname, 32);
            br.Write(romname, 0, 32);
            br.Write(Crc32);
            br.Write(RomCountry);
            br.Write(zeroar2,0,zeroar2.Length); // 56 bytes - RESERVED

            
            byte[] gfx = new byte[64];
            byte[] audio = new byte[64];
            byte[] input = new byte[64];
            byte[] rsp = new byte[64];
            byte[] author = new byte[222];
            byte[] desc = new byte[256];
            
            gfx =    ASCIIEncoding.ASCII.GetBytes(VideoPlugin);
            audio =  ASCIIEncoding.ASCII.GetBytes(AudioPlugin);
            input =  ASCIIEncoding.ASCII.GetBytes(InputPlugin);
            rsp =    ASCIIEncoding.ASCII.GetBytes(RSPPlugin);
            author = ASCIIEncoding.ASCII.GetBytes(Author);
            desc =   ASCIIEncoding.ASCII.GetBytes(Description);
            
            Array.Resize(ref gfx, 64);
            Array.Resize(ref audio, 64);
            Array.Resize(ref input, 64);
            Array.Resize(ref rsp, 64);
            Array.Resize(ref author, 222);
            Array.Resize(ref desc, 256);
            
            br.Write(gfx,0,64);
            br.Write(audio,0,64);
            br.Write(input,0,64);
            br.Write(rsp,0,64);
            br.Write(author,0,222);
            br.Write(desc,0,256);
            for (int i = 0; i < SAVE_inputList.Count/4; i++)
            {
            br.Write(inputList[i]);
            }
            br.Flush();
            br.Close();
            MessageBox.Show("Finished");
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
        void SetInput(int frame)
        {
            if (!FileLoaded) 
                return;
            int value = SAVE_inputList[frame]; // get value at that frame 
            for (int i = 0; i < controllerButtonsChk.Length; i++)
            {
                int button = ExtensionMethods.BoolToInt(controllerButtonsChk[i].Checked);
                button = button << (32 - i);
                value |= button;
                Debug.WriteLine("BUTTON Value loop: " + (value).ToString());
            }
            byte[] joydata = BitConverter.GetBytes(inputList[frame]);
            joydata[2] = (byte)JOY_Rel.X;
            joydata[3] = (byte)JOY_Rel.Y;

            value |= BitConverter.ToInt32(joydata,0);
            Debug.WriteLine("JOYSTICK Value after calculations end: " + (value |= BitConverter.ToInt32(joydata, 0)).ToString());

            SAVE_inputList[frame] = value;
            if (!readOnly)
                inputList[frame] = SAVE_inputList[frame];
        }
        void GetInput(int value)
        {
            int numbuttons = controllerButtonsChk.Length;
            for (int i = 0; i < numbuttons; i++)
            {
                controllerButtonsChk[i].Checked = (value & (int)Math.Pow(2, i)) != 0;
            }
            byte[] data = BitConverter.GetBytes(value);
            sbyte joystickX = (sbyte)data[2];
            sbyte joystickY = (sbyte)data[3];

            txt_joyX.Text = joystickX.ToString();
            txt_joyY.Text = joystickY.ToString();
            UpdateJoystickValues(RelativeToAbsolute(new Point(joystickX,joystickY)), false);
            chk_restart.Checked = chk_RESERVED1.Checked && chk_RESERVED2.Checked;
            chk_restart.ForeColor = chk_restart.Checked ? Color.Orange : Color.Black;
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
            //frame += stepAmount;
            //if (!checkAllowedStep(stepAmount)) return;
            //lbl_FrameSelected.Text = "Frame " + frame;
            //lbl_FrameSelected.ForeColor = Color.Black;
            //SetInput(inputList[frame]);


            SetFrame(frame + stepAmount);
        }
        void SetFrame(int targetframe)
        {
            frame = targetframe;
            if (!checkAllowedStep(targetframe)) return;
            lbl_FrameSelected.Text = "Frame " + frame;
            lbl_FrameSelected.ForeColor = Color.Black;
            txt_Frame.Text = frame.ToString();
            GetInput(inputList[frame]);
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

            Properties.Settings.Default.LastPath = Path;
            Properties.Settings.Default.Save();

            if (rb_M64sel.Checked){
                Thread m64load = new Thread ( () => ReadM64() );
                m64load.Start();
                }
            else if (rb_STsel.Checked){
                LoadST();}
        }
        private void btn_Last_MouseClick(object sender, MouseEventArgs e)
        {
            Path = Properties.Settings.Default.LastPath;
             if (rb_M64sel.Checked){
                Thread m64load = new Thread ( () => ReadM64() );

                m64load.Start();
                }
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
            btn_PlayPause.Text = stepFrameTimer.Enabled ? "| |" : forwardsPlayback ? "|>" : "<|";
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
            btn_PlayPause.Text = stepFrameTimer.Enabled ? "| |" : forwardsPlayback ? "|>" : "<|";
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
#if DEBUG
            Debug.WriteLine("Window Resize (W/H) " + Width + " " + Height);
#endif
           // this.MinimumSize = F  ileLoaded ? new Size(980, 480) : new Size(0, 0);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m64ThreadRunning)
            {
                e.Cancel =
                    MessageBox.Show("The m64 loading thread is still running. Are you sure you want to close the program? (might cause issues)",
                    "Thread running",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.No;
                return;
            }
        }

        private void txt_Frame_KeyDown(object sender, KeyEventArgs e)
        {
            if(ExtensionMethods.ValidStringInt(txt_Frame.Text, 0, (int)frames) && e.KeyCode == Keys.Enter)
            {
                SetFrame(Int32.Parse(txt_Frame.Text));
            }
        }

        private void txt_joyX_KeyDown(object sender, KeyEventArgs e)
        {
            if(ExtensionMethods.ValidStringByte(txt_Frame.Text, -127, 127) && e.KeyCode == Keys.Enter)
            {
                UpdateJoystickValues(RelativeToAbsolute(new Point(byte.Parse(txt_joyX.Text),byte.Parse(txt_joyY.Text))), false);
            }
        }

        private void txt_joyY_KeyDown(object sender, KeyEventArgs e)
        {
            if(ExtensionMethods.ValidStringByte(txt_Frame.Text, -127, 127) && e.KeyCode == Keys.Enter)
            {
                UpdateJoystickValues(RelativeToAbsolute(new Point(byte.Parse(txt_joyX.Text),byte.Parse(txt_joyY.Text))), false);
            }
        }

        private void btn_Savem64_MouseClick(object sender, MouseEventArgs e)
        {
            WriteM64();
        }
        void UpdateReadOnly()
        {
            readOnly = chk_readonly.Checked;
            chk_readonly.Text = readOnly ? "Readonly" : "Readwrite";

            // Groupboxes + Child controls
            foreach (Control ctl in gp_User.Controls)
            {
                if(ctl is TextBox){
                TextBox txt = ctl as TextBox;
                txt.ReadOnly = readOnly;
                }
            }
            txt_Rom.ReadOnly = readOnly;
            txt_CTRLS.ReadOnly = readOnly;
            foreach (Control ctl in gp_Plugins.Controls)
            {
                if(ctl is TextBox){
                TextBox txt = ctl as TextBox;
                txt.ReadOnly = readOnly;
                }
            }

            // Joystick buttons + Joystick
            pb_JoystickPic.Enabled = !readOnly;
            txt_joyX.ReadOnly = readOnly;
            txt_joyY.ReadOnly = readOnly;
            foreach (Control ctl in gp_input.Controls)
            {
                if(ctl is CheckBox){
                CheckBox chk = ctl as CheckBox;
                chk.Enabled = !readOnly;
                }
            }
        }
        private void chk_readonly_CheckedChanged(object sender, EventArgs e)
        {
            UpdateReadOnly();
        }

        #endregion


        #region Joystick Drawing, Events, etc...

        Point AbsoluteToRelative(Point abs)
        {
            return new Point(abs.X-82,abs.Y+72);
        }
        Point RelativeToAbsolute(Point rel)
        {
            return new Point(rel.X+82,rel.Y+72);
        }
        void SnapJoystick()
        {
            if (JOY_Rel.X < 5 && JOY_Rel.X > -5)
            {
                JOY_Rel.X = 0;
                JOY_Abs.X = pb_JoystickPic.Width / 2;
            }
            else if (JOY_Rel.Y < 5 && JOY_Rel.Y > -5)
            {
                JOY_Rel.Y = 0;
                JOY_Abs.Y = pb_JoystickPic.Height / 2;
            }
        }

        void UpdateJoystickValues(Point e, bool user)
        {
            JOY_Abs.X = ExtensionMethods.Clamp(e.X, JOY_clampDif/2, pb_JoystickPic.Width - JOY_clampDif);
            JOY_Abs.Y = ExtensionMethods.Clamp(e.Y, JOY_clampDif/2, pb_JoystickPic.Height - JOY_clampDif);
            JOY_Rel.X = ExtensionMethods.Clamp(e.X - JOY_middle.X, -127, 127);
            JOY_Rel.Y = ExtensionMethods.Clamp(e.Y - JOY_middle.Y, -127, 127);


            if(user){
            SnapJoystick();
                if (!readOnly)
                {
                    // Write to array
                    SetInput(frame);
                }
            }
            pb_JoystickPic.Refresh();
        }
        private void pb_JoystickPic_Paint(object sender, PaintEventArgs e) => DrawJoystick(e);

        private void pb_JoystickPic_MouseUp(object sender, MouseEventArgs e)
        {
            JOY_mouseDown = JOY_followMouse;
        }

        private void pb_JoystickPic_MouseDown(object sender, MouseEventArgs e)
        {
            JOY_followMouse = e.Button != MouseButtons.Right || !JOY_followMouse;
            if (e.Button == MouseButtons.Left && JOY_followMouse)
            {
                JOY_followMouse = false;
            }
            JOY_mouseDown = true;
            UpdateJoystickValues(e.Location, true);
        }

        private void DrawJoystick(PaintEventArgs e)
        {
            Pen linepen = new Pen(Color.Blue, 3);
            e.Graphics.DrawLine(linepen, JOY_middle, JOY_Abs); 
            e.Graphics.DrawRectangle(Pens.Black, 0,0,pb_JoystickPic.Width-1,pb_JoystickPic.Height-1);
            e.Graphics.FillEllipse(Brushes.Red, JOY_Abs.X - 4, JOY_Abs.Y - 4, 8, 8);
            e.Graphics.DrawEllipse(Pens.Black, 1,1, pb_JoystickPic.Width-3, pb_JoystickPic.Height-3);
            e.Graphics.DrawLine(Pens.Black, JOY_middle.X, JOY_middle.Y, 0, JOY_middle.Y);
            e.Graphics.DrawLine(Pens.Black, JOY_middle.X, JOY_middle.Y, JOY_middle.X, pb_JoystickPic.Height);
            e.Graphics.DrawLine(Pens.Black, JOY_middle.X, JOY_middle.Y, pb_JoystickPic.Width, JOY_middle.Y);
            e.Graphics.DrawLine(Pens.Black, JOY_middle.X, JOY_middle.Y, JOY_middle.X, 0);
            linepen.Dispose();

        }

        private void pb_JoystickPic_MouseMove(object sender, MouseEventArgs e)
        {
            if (JOY_mouseDown) UpdateJoystickValues(e.Location,true);
        }

        #endregion
    }
}

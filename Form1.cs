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
        bool m64ThreadRunning = false;

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

        // Joystick input
        //int JOY_Relx, JOY_Rely, JOY_Absx, JOY_Absy;
        Point JOY_Rel, JOY_Abs, JOY_middle;
        bool JOY_mouseDown;
        const int JOY_clampDif = 4;

        #endregion

        #region Setup

        public MainForm()
        {
            InitializeComponent();
            InitController();
            InitUI();
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
            this.MaximizeBox = FileLoaded;
            if (!FileLoaded) this.WindowState = FormWindowState.Normal;
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
            this.Invoke((MethodInvoker)(() => this.FormBorderStyle = FileLoaded ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle));
            gp_Path.Invoke((MethodInvoker)(() => gp_Path.Dock = FileLoaded ? DockStyle.Top : DockStyle.Fill));
            st_Status.Invoke((MethodInvoker)(() => gp_Path.Visible = FileLoaded));
            this.Invoke((MethodInvoker)(() => this.MaximizeBox = FileLoaded));
            if (!FileLoaded) this.Invoke((MethodInvoker)(() => this.WindowState = FormWindowState.Normal));
            this.Invoke((MethodInvoker)(() => this.Size = s));

        }

        #endregion

        #region I/O

        void LoadM64()
        {
            m64ThreadRunning = true;
            // Check for suspicious properties
            long len = new FileInfo(Path).Length;
            if (!bypassTypeCheck && (len < 1028 || !System.IO.Path.GetExtension(Path).Equals(".m64", StringComparison.InvariantCultureIgnoreCase)))
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
            Magic = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            Version = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            UID = ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            VIs = br.ReadUInt32();//ByteArrayToString(BitConverter.GetBytes(br.ReadInt32()));
            RRs = br.ReadUInt32().ToString();
            br.ReadByte(); // frames (vertical interrupts) per second ---- SEEK 1 BYTE FORWARD (DUMMY)
            Controllers = br.ReadByte().ToString();
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
            int findx = 0;
            while(findx <= frames)
            {
                if (br.BaseStream.Position + 4 > fs.Length) {
                    findx++;
                    continue; }
#if DEBUG
                Debug.WriteLine("--- Sample " + findx + "/" + frames + " ---");
#endif
                inputList.Add(br.ReadInt32());
                findx++;
            }




            br.Close(); // destroy handle

            /*Set Controls*/
            txt_misc_Magic.Invoke((MethodInvoker)(() => txt_misc_Magic.Text = Magic));
            txt_misc_Version.Invoke((MethodInvoker)(() => txt_misc_Version.Text = Version));
            txt_misc_UID.Invoke((MethodInvoker)(() => txt_misc_UID.Text = UID));

            txt_VIs.Invoke((MethodInvoker)(() => txt_VIs.Text = VIs.ToString()));
            txt_RR.Invoke((MethodInvoker)(() => txt_RR.Text = RRs));
            txt_CTRLS.Invoke((MethodInvoker)(() => txt_CTRLS.Text = Controllers));
            txt_StartType.Invoke((MethodInvoker)(() => txt_StartType.Text = StartType));

            txt_videoplugin.Invoke((MethodInvoker)(() => txt_videoplugin.Text = VideoPlugin));
            txt_inputplugin.Invoke((MethodInvoker)(() => txt_inputplugin.Text = InputPlugin));
            txtbox_Audioplugin.Invoke((MethodInvoker)(() => txtbox_Audioplugin.Text = AudioPlugin));
            txt_Rsp.Invoke((MethodInvoker)(() => txt_Rsp.Text = RSPPlugin));

            txt_Rom.Invoke((MethodInvoker)(() => txt_Rom.Text = RomName));
            txt_Crc.Invoke((MethodInvoker)(() => txt_Crc.Text = Crc32));
            txt_RomCountry.Invoke((MethodInvoker)(() => txt_RomCountry.Text = RomCountry));

            txt_PathName.Invoke((MethodInvoker)(() => txt_PathName.Text = M64Name));
            txt_Author.Invoke((MethodInvoker)(() => txt_Author.Text = Author));
            txt_Desc.Invoke((MethodInvoker)(() => txt_Desc.Text = Description));

            EnableM64View_ThreadSafe(true);

            ShowStatus_ThreadSafe(M64_LOADED_TEXT);

            m64ThreadRunning = false;
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
            UpdateJoystickValues(new Point(RelativeToAbsolute(joystickX), RelativeToAbsolute(joystickY)), false);
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
                Thread m64load = new Thread ( () => LoadM64() );
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
            this.MinimumSize = FileLoaded ? new Size(980, 480) : new Size(0, 0);
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



        #endregion


        #region Joystick Drawing, Events, etc...

        // 82 / -82
        int AbsoluteToRelative(int abs)
        {
            return abs - 82;
        }
        int RelativeToAbsolute(int rel)
        {
           return rel + 82;
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

            if(user)
            SnapJoystick();

            pb_JoystickPic.Refresh();
        }
        private void pb_JoystickPic_Paint(object sender, PaintEventArgs e) => DrawJoystick(e);

        private void DrawJoystick(PaintEventArgs e)
        {
            Pen linepen = new Pen(Color.Blue, 3);
            Pen outlinepen = new Pen(Color.Black, 1);
            e.Graphics.DrawLine(linepen, JOY_middle, JOY_Abs); 
            e.Graphics.FillEllipse(Brushes.Red, JOY_Abs.X - 4, JOY_Abs.Y - 4, 8, 8);
            e.Graphics.DrawEllipse(outlinepen, 0, 0, pb_JoystickPic.Width-outlinepen.Width, pb_JoystickPic.Height-outlinepen.Width);
            e.Graphics.DrawLine(outlinepen, JOY_middle.X, JOY_middle.Y, 0, JOY_middle.Y);
            e.Graphics.DrawLine(outlinepen, JOY_middle.X, JOY_middle.Y, JOY_middle.X, pb_JoystickPic.Height);
            e.Graphics.DrawLine(outlinepen, JOY_middle.X, JOY_middle.Y, pb_JoystickPic.Width, JOY_middle.Y);
            e.Graphics.DrawLine(outlinepen, JOY_middle.X, JOY_middle.Y, JOY_middle.X, 0);
            linepen.Dispose();
            outlinepen.Dispose();

        }

        private void pb_JoystickPic_MouseMove(object sender, MouseEventArgs e)
        {
            if (Control.MouseButtons==MouseButtons.Left) UpdateJoystickValues(e.Location,true);
        }

        #endregion
    }
}

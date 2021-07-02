


// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&*  ,#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#. .*######(*  *&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@. .,,********,,   (@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@(.,,...         ...,..@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@/*//***,,..   ..,,,,**/.#@@@@@@@@@@@@@@@@@@@@@@@@@@@
// @@@@@@@@@@@@%,.#@@@@@@@@@@&*(#(((///*.**,/ ,***///((*(@@@@@@@@@@@(*&@@@@@@@@@@@@
// @@@@@@@@/ ./#####(. /@@@@#*&&%%%##(( /#*,#(.,//((((##(*@@@@#. *(####(, /@@@@@@@@
// @@@@@, .,***********,.   #@@@@&&&%/ (##*,###,.(###%%%&&.   .************, ,@@@@@
// @@@@@.*##(,              ,./@@@@&*,####*,####*.#%%&&#.. ,*,,.        .*(#(*@@@@@
// @@@@@.*######(.     ...,, */,.#&,*(####*,#####(.(%,./*.//***,,,. .(######(*@@@@@
// @@@@@.*########* ..,,****/.,(((*/(#####*.(#####(*/((,,(((///**,.*((######(*@@@@@
// @@@@@.*########((.,*////(((*./(((#(, ,(%%#*..(##(((./%%##(((/*./((#######(*@@@@@
// @@@@@.*#########((,,(((###%%(.*  ,***********/*. . %@&&%%%##*./(((#######(*@@@@@
// @@@@@.*##########((*.#%%%&&%,.////*.        .*////*.#@@&&%%,,((((########(*@@@@@
// @@@@@.*##########(((/.#@@( *///////////, ////////////,.&@%.*((((#########(*@@@@@
// @@@@@.*######(..(#((((. ,((((//////////, ////////////((/../(((((* /######(*@@@@@
// @@@@@.*######(.,./#((((((((((//////////, ////////////((((((((((,../######(*@@@@@
// @@@@@.*%#####(.**./#((((((((((/////////, ///////////((((((((((,,* /######(*@@@@@
// @@@@@.*%%####(.*//./(((((((((/. *//////, ///////../(((((((((( */* /######(*@@@@@
// @@@@@.*%%####(.*///, *(((((*.(#.*//////, ///////.*(.,/((((/..///* /#####%(*@@@@@
// @@@@@./%%%###(.*//////,     /@@,*//////, ///////,&@@*    .//////* /#####%(*@@@@@
// @@@@@./%%%%##(.*//////,(@@@@@@@,*//////, ///////,&@@@@@@@(//////* /####%%(*@@@@@
// @@@@@./%%%%##(.*//////,(@@@@@@@,*(/////, ///////,&@@@@@@@(//////* /###%%%(*@@@@@
// @@@@@/ ,(%%##(.*////*..%@@@@@@@,*(/////, ///////,&@@@@@@@(.*////* /###%#* /@@@@@
// @@@@@@@@@%, ,/.,,.(@@@@@@@@@@@@,*(/////, ///////,&@@@@@@@@@@@%,., /* ,%@@@@@@@@@
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@,*((////, /////(/,&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@,*(((///, /////(/,&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@,*(((///, /////(/,&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@,,/((///, ////((*.%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&/ .*/, //. ,%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&(/&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
/*
 

  __  __                          _    _ _   _ _ _ _   _           
 |  \/  |                        | |  | | | (_) (_) | (_)          
 | \  / |_   _ _ __   ___ _ __   | |  | | |_ _| |_| |_ _  ___  ___ 
 | |\/| | | | | '_ \ / _ \ '_ \  | |  | | __| | | | __| |/ _ \/ __|
 | |  | | |_| | |_) |  __/ | | | | |__| | |_| | | | |_| |  __/\__ \
 |_|  |_|\__,_| .__/ \___|_| |_|  \____/ \__|_|_|_|\__|_|\___||___/
              | |                                                  
              |_|                                                  

 Feature-rich Utility application for Mupen64

 By Aurumaker72

*/


using MupenUtils.Forms;
using MupenUtils.Networking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MupenUtils
{
    public partial class MainForm : Form
    {
        #region Vars

        public const string PROGRAM_VERSION = "1.7";
        public const string PROGRAM_NAME = "Mupen Utilities";

        public const string M64_LOADED_TEXT = "M64 Loaded";
        public const string M64_LOADING_TEXT = "M64 Loading";
        public const string M64_FAILED_TEXT = "Failed to load M64.";
        public const string M64_SELECTED_TEXT = "Type: M64";
        public const string ST_SELECTED_TEXT = "Type: ST";

        public const byte UPDATE_CLIENT_OUTDATED = 0;
        public const byte UPDATE_CLIENT_AHEAD = 1;
        public const byte UPDATE_EQUAL = 2;
        public const byte UPDATE_UNKNOWN = 255;

        public const bool RELATIVE = false;
        public const bool ABSOLUTE = true;

        public static bool standardBitArh;
        // [] means reserved, <^>v is direction
        public static string[] inputStructNames = { "D>", "D<", "Dv", "D^", "Start", "Z", "B", "A", "C>", "C<", "Cv", "C^", "R", "L", "[1]", "[2]", "X", "Y" };

        Thread m64load;
        MoreForm moreForm = new MoreForm();
        AdvancedDebugForm debugForm = new AdvancedDebugForm();
        TASStudioMoreForm tasStudioForm = new TASStudioMoreForm();
        ReplacementForm replacementForm = new ReplacementForm();
        ControllerFlagsForm controllerFlagsForm = new ControllerFlagsForm();
        MupenHookForm mupenHookForm = new MupenHookForm();
        STForm stForm = new STForm();
        static ExceptionForm exceptionForm = new ExceptionForm();
        InputStatsForm inputStatisticsForm = new InputStatsForm();

        List<Color> ctlColor = new List<Color>();

        public static string Path, SavePath;
        public static bool FileLoaded = false;
        bool ExpandedMenu = false;
        bool Sticky = false;
        bool liveTasStudio = true;
        bool loopInputs = true;
        bool forwardsPlayback = true;
        bool readOnly = true;

        /*TAS Studio*/
        public static int markedGoToFrame = 0;
        public static int markedSizeCell = 10;
        public static bool forceGoto = false;
        public static bool forceResizeCell = false;
        public static bool tasStudioBusy = false;
        int cellSize = 10;

        bool simpleMode = false;
        public static bool mupenRunning = false;
        public static bool loadedInvalidFile = false;
        public static bool m64loadBusy = false;

        // M64 Data as Strings
        string Magic;
        Int32 magic_Raw;
        string Version;
        Int32 UID;
        UInt32 VIs; // vis
        byte VI_s; // vi/s
        public static UInt32 frames;
        public static UInt32 RRs;
        byte Controllers;
        public static bool[] ControllersEnabled = { false, false, false, false };
        Int16 StartType;
        string RomName;
        UInt32 Crc32;
        UInt16 RomCountry;
        string VideoPlugin;
        string InputPlugin;
        string AudioPlugin;
        string RSPPlugin;
        UInt32 Samples;
        public static UInt32 ControllerFlags;

        string M64Name; // Name = m64 file name (path)
        string Author;
        string Description;

        public CheckBox[] controllerButtonsChk;

        public static List<int> inputListCtl1 = new List<int>();
        public static List<int> inputListCtl2 = new List<int>();
        public static List<int> inputListCtl3 = new List<int>();
        public static List<int> inputListCtl4 = new List<int>();

        public static List<int>[] inputLists = { inputListCtl1, inputListCtl2, inputListCtl3, inputListCtl4 };

        public static byte selectedController = 0;

        public static List<int> SAVE_inputList = new List<int>();
        
        int lastValue;

        public static int frame;
        System.Windows.Forms.Timer stepFrameTimer = new System.Windows.Forms.Timer();

        // Joystick input
        //int JOY_Relx, JOY_Rely, JOY_Absx, JOY_Absy;
        Point JOY_Rel, JOY_Abs, JOY_middle;
        bool JOY_mouseDown, JOY_followMouse;
        bool lockType;
        UpdateNotifier updateNotifier = new UpdateNotifier();
        SmoothingMode JOY_SmoothingMode = SmoothingMode.HighQuality;

        Point[] originalGroupboxLocation = { new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0) };

        public static bool notifiedReupdateControllerFlags;

        public enum UsageTypes
        {
            Any,
            M64,
            ST,
            Mupen,
            Replacement,
            Autodetect
        };
        public static UsageTypes UsageType = UsageTypes.M64;

        public enum UIThemes
        {
            Default,
            Gray,
            Dark
        };
        public static UIThemes UITheme = UIThemes.Default;

        const int PROCESS_QUERY_INFORMATION = 0x0400;
        const int MEM_COMMIT = 0x00001000;
        const int PAGE_READWRITE = 0x04;
        const int PROCESS_WM_READ = 0x0010;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);
        [DllImport("kernel32.dll", SetLastError=true)]

        static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);
        public struct MEMORY_BASIC_INFORMATION
        {
            public int BaseAddress;
            public int AllocationBase;
            public int AllocationProtect;
            public int RegionSize;
            public int State;
            public int Protect;
            public int lType;
        }
        public struct SYSTEM_INFO
        {
            public ushort processorArchitecture;
            ushort reserved;
            public uint pageSize;
            public IntPtr minimumApplicationAddress;
            public IntPtr maximumApplicationAddress;
            public IntPtr activeProcessorMask;
            public uint numberOfProcessors;
            public uint processorType;
            public uint allocationGranularity;
            public ushort processorLevel;
            public ushort processorRevision;
        }

        #endregion

        #region Setup

        public MainForm()
        {
            // must do this before anything else
#if !DEBUG
            Application.ThreadException += applicationThreadException;
            AppDomain.CurrentDomain.UnhandledException += currentDomainUnhandledException;
#endif
            InitializeComponent();

            InitController();
            InitUI();

            // check for updates
            if (updateNotifier.CheckForInternetConnection())
                updateNotifier.CheckForUpdates(UPDATE_UNKNOWN, true);

            
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
            chk_Cup,     //U_CBUTTON            (CONTROL)

            chk_R,      //R_TRIG               (CONTROL)
            chk_L,       //L_TRIG               (CONTROL)

            chk_RESERVED1,    // RESERVED!!! (CONTROL)
            chk_RESERVED2     // RESERVED!!! (CONTROL)
        };

            stepFrameTimer.Tick += new EventHandler(AdvanceInputAuto);
            stepFrameTimer.Interval = 1000/30; // 30 fps
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
            this.KeyPreview = true;
            ResetTitle();
            this.AllowDrop = true;

            cbox_startType.Items.Add("Snapshot");
            cbox_startType.Items.Add("Power on");
            cbox_startType.Items.Add("EEPROM");
            cbox_startType.Items.Add("Unknown");

            originalGroupboxLocation[0] = gp_User.Location;
            originalGroupboxLocation[1] = gp_M64_misc.Location;
            originalGroupboxLocation[2] = gpRom.Location;
            originalGroupboxLocation[3] = gp_Plugins.Location;

            //tsmi_Themes.Checked = MupenUtilities.Properties.Settings.Default.DarkMode;
            //darkMode = tsmi_Themes.Checked;
            //if(darkMode) SetDarkMode(darkMode);

            UITheme = (UIThemes)MupenUtilities.Properties.Settings.Default.UITheme; // doing this in C would be so painful
            if (UITheme != UIThemes.Default) SetUITheme(UITheme);

            foreach(ToolStripMenuItem _ts in tsmi_Themes.DropDownItems) _ts.Checked = false;
            ToolStripMenuItem ts = tsmi_Themes.DropDownItems[(int)UITheme] as ToolStripMenuItem;
            ts.Checked = true;

//#if DEBUG
            ctx_Input_Debug.Items.Add(new ToolStripSeparator());
            ToolStripMenuItem tsmi_DBG_Crash = new ToolStripMenuItem();
            tsmi_DBG_Crash.MouseDown += (s, e) => throw new Exception("Intentional crash");
            tsmi_DBG_Crash.Text = "Debug - Crash";
            ctx_Input_Debug.Items.Add(tsmi_DBG_Crash);
            
//#endif
            if (!BitConverter.IsLittleEndian)
            {
                // incompatible because this program is somewhat endian dependent
                this.Text += " - Unsupported";
                MessageBox.Show("Your system is big-endian and this program might not work properly!");
            }

            

            
            UpdateReadOnly();

            EnableM64View(false, true);


            UsageType = (UsageTypes)MupenUtilities.Properties.Settings.Default.UsageType;
            Debug.WriteLine("loaded usage type " + MupenUtilities.Properties.Settings.Default.UsageType.ToString());
            UpdateVisualsTop(false);
        }

        #endregion

        #region UI

        void SetUITheme(UIThemes uitheme)
        {
            Color gp_BackColor  = Color.Red;
            Color chk_BackColor = Color.Red;
            Color btn_BackColor = Color.Red;
            Color txt_BackColor = Color.Red;
            Color dgv_BackColor = Color.Red;
            Color dgv_GridColor = Color.Red;
            Color miscColor     = Color.Red;


            if (uitheme == UIThemes.Gray)
            {
                gp_BackColor =  Color.Gray;
                chk_BackColor = Color.Gray;
                btn_BackColor = Color.Gray;
                txt_BackColor = Color.Gray;
                miscColor =     Color.Gray;
                dgv_BackColor = Color.Gray;
                dgv_GridColor = Color.Black;
            }
            else if(uitheme == UIThemes.Default)
            {
                
                gp_BackColor = Color.FromKnownColor(KnownColor.Control);
                chk_BackColor = Color.FromKnownColor(KnownColor.Control);
                btn_BackColor = Color.FromKnownColor(KnownColor.Control);
                txt_BackColor = Color.FromKnownColor(KnownColor.Control);
                miscColor = Color.FromKnownColor(KnownColor.Control);
                dgv_BackColor = Color.FromKnownColor(KnownColor.Control);
                dgv_GridColor = Color.Black;

            } else if(uitheme == UIThemes.Dark)
            {
                gp_BackColor =  Color.FromArgb(255,50,50,50);
                chk_BackColor = Color.FromArgb(255,50,50,50);
                btn_BackColor = Color.FromArgb(255,50,50,50);
                txt_BackColor = Color.FromArgb(255,50,50,50);
                miscColor =     Color.FromArgb(255,50,50,50);
                dgv_BackColor = Color.FromArgb(255,50,50,50);
                dgv_GridColor = Color.Black;
            }

            this.ForAllControls(c =>
                {
                    if (c is GroupBox) c.BackColor = gp_BackColor;
                    if (c is CheckBox) c.Parent.BackColor = chk_BackColor;
                    if (c is Button)
                    {
                        Button b = c as Button;
                        if (uitheme != UIThemes.Default)
                        {
                            b.FlatStyle = FlatStyle.Flat;
                            b.FlatAppearance.BorderSize = 0;
                        }
                        else
                            b.FlatStyle = FlatStyle.Standard;

                        

                        b.BackColor = btn_BackColor;
                        b.UseVisualStyleBackColor = uitheme == UIThemes.Default;
                    }
                    if (c is TextBox) c.BackColor = txt_BackColor;
                });

            tr_MovieScrub.BackColor = miscColor;
            this.BackColor = miscColor;
            dgv_Main.BackgroundColor = dgv_BackColor;
            dgv_Main.GridColor = dgv_GridColor;
            dgv_Main.ForeColor = dgv_GridColor;

            pb_JoystickPic.BackColor = Color.Transparent;

            
        }
        void ResetTitle()
        {
#if DEBUG
            string bitarh;
            bitarh = IntPtr.Size == 4 ? "32 bit" : "64 bit";
            standardBitArh = IntPtr.Size == 4;
            this.Text = PROGRAM_NAME + " " + PROGRAM_VERSION + " " + bitarh;
            this.Text += " DEBUG clr ";
            this.Text += Environment.Version;

#else
            this.Text = PROGRAM_NAME + " " + PROGRAM_VERSION;
#endif
        }

        void ShowTipsForm()
        {
            moreForm.ShowDialog();
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

        void RedControlBack(Control ctrl)
        {
            Color tempcolor = ctrl.BackColor;
            ctrl.BackColor = Color.Red;
            new Thread(() =>
               {
                   Thread.Sleep(1000);
                   ctrl.BackColor = tempcolor;
               }).Start();
        }

        void EnableM64View(bool flag, bool change)
        {
            
            Size s;
            ExpandedMenu = flag;
            if (change) FileLoaded = flag;

            
            s = flag ? new Size(1320, 620) : new Size(100 + btn_Help.Location.X + 20, 150);
            gp_Path.Dock = flag ? DockStyle.Top : DockStyle.Fill;
            if (!flag) this.WindowState = FormWindowState.Normal;
            btn_FrameBack.Enabled = FileLoaded;
            btn_FrameBack2.Enabled = FileLoaded;
            btn_FrameFront.Enabled = FileLoaded;
            btn_FrameFront2.Enabled = FileLoaded;
            btn_PlayDirection.Enabled = FileLoaded;
            btn_PlayPause.Enabled = FileLoaded;
            tr_MovieScrub.Enabled = FileLoaded;
            txt_Frame.ReadOnly = !FileLoaded;

                SuspendLayout();
    base.OnResizeBegin(null);

            this.MinimumSize = flag ? gp_M64.Size : new Size(1, 1);

            this.Size = s;

            this.FormBorderStyle = flag ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle;
            this.MaximizeBox = flag;

                ResumeLayout();
    base.OnResizeEnd(null);

            gp_M64.Visible = flag;
            st_Status.Visible = flag;

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
            s = flag ? new Size(1320, 620) : new Size(100 + btn_Help.Location.X + 20, 150);
            this.Invoke((MethodInvoker)(() => this.FormBorderStyle = flag ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle));
            gp_Path.Invoke((MethodInvoker)(() => gp_Path.Dock = flag ? DockStyle.Top : DockStyle.Fill));
            st_Status.Invoke((MethodInvoker)(() => gp_Path.Visible = flag));
            this.Invoke((MethodInvoker)(() => this.MaximizeBox = flag));
            if (!flag) this.Invoke((MethodInvoker)(() => this.WindowState = FormWindowState.Normal));
            btn_FrameBack.Invoke((MethodInvoker)(() => btn_FrameBack.Enabled = flag));
            btn_FrameBack2.Invoke((MethodInvoker)(() => btn_FrameBack2.Enabled = flag));
            btn_FrameFront.Invoke((MethodInvoker)(() => btn_FrameFront.Enabled = flag));
            btn_FrameFront2.Invoke((MethodInvoker)(() => btn_FrameFront2.Enabled = flag));
            btn_PlayDirection.Invoke((MethodInvoker)(() => btn_PlayDirection.Enabled = flag));
            btn_PlayPause.Invoke((MethodInvoker)(() => btn_PlayPause.Enabled = flag));
            tr_MovieScrub.Invoke((MethodInvoker)(() => tr_MovieScrub.Enabled = flag));
            txt_Frame.Invoke((MethodInvoker)(() => txt_Frame.ReadOnly = flag));
            this.Invoke((MethodInvoker)(() => this.MinimumSize = flag ? gp_M64.Size : new Size(1, 1)));
            this.Invoke((MethodInvoker)(() => this.Size = s));



        }

        void ResetLblColors()
        {

            for (int i = 0; i < gp_User.Controls.Count; i++)
            {
                if (gp_User.Controls[i] is Label)
                {
                    Label lbl = gp_User.Controls[i] as Label;
                    lbl.Invoke((MethodInvoker)(() => lbl.ForeColor = Color.Black));
                }
            }
            for (int i = 0; i < gp_M64.Controls.Count; i++)
            {
                if (gp_User.Controls[i] is Label)
                {
                    Label lbl = gp_User.Controls[i] as Label;
                    lbl.Invoke((MethodInvoker)(() => lbl.ForeColor = Color.Black));
                }
            }
        }

        void UpdateVisualsTop(bool serialize)
        {
            btn_LoadLatest.Enabled = true;
            string txt = "?";

            switch (UsageType)
            {
                case UsageTypes.Any:
                    txt = "Browse Any";
                    btn_LoadLatest.Enabled = false;
                    break;
                case UsageTypes.M64:
                    txt = "Browse M64";
                    rb_M64sel.Checked = true;
                    break;
                case UsageTypes.ST:
                    txt = "Browse ST";
                    rb_STsel.Checked = true;
                    break;
                case UsageTypes.Mupen:
                    txt = "Hook";
                    btn_LoadLatest.Enabled = false;
                    rb_MUPSel.Checked = true;
                    break;
                case UsageTypes.Replacement:
                    txt = "Replacement";
                    btn_LoadLatest.Enabled = false;
                    rb_ReplacementSel.Checked = true;
                    break;
                case UsageTypes.Autodetect:
                    txt = "Autodetect";
                    btn_LoadLatest.Enabled = false;
                    break;
            }

            if (serialize)
            {
                MupenUtilities.Properties.Settings.Default.UsageType = (byte)UsageType;
                MupenUtilities.Properties.Settings.Default.Save();
                Debug.WriteLine("saved usage type " + MupenUtilities.Properties.Settings.Default.UsageType.ToString());
            }

            btn_PathSel.Text = txt;
        }

        #endregion

        #region I/O
        void DumpInputsFile(bool plain)
        {

            FileStream fs;
            BinaryWriter br;
            try
            {
                fs = File.Open("inputs.bin", FileMode.Create);
                br = new BinaryWriter(fs);

            }
            catch { return; }
            if (!plain)
            {
                for (int i = 0; i < inputListCtl1.Count; i++)
                    br.Write(inputListCtl1[i]);

                br.Flush(); br.Close();

                MessageBox.Show(String.Format("Dumped {0} input samples to {1}", inputListCtl1.Count, fs.Name));

                fs.Close();
            }
        }
        public void MupenHook()
        {
        go:
            string procName = "mupen64";

            if (Process.GetProcessesByName("mupen64").Length == 0)
            {
                // normal mupen not found... try to find debug mupen
                procName = "mupen64_debug";
                if (Process.GetProcessesByName("mupen64_debug").Length == 0)
                {
                    MessageBox.Show("Couldn\'t find any instance of mupen64 running.", PROGRAM_NAME + " - Mupen not running", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MupenHookForm.loading = true;
            mupenHookForm.Show();
            

            SYSTEM_INFO sys_info = new SYSTEM_INFO();
            GetSystemInfo(out sys_info);  

            IntPtr proc_min_address = sys_info.minimumApplicationAddress;
            IntPtr proc_max_address = sys_info.maximumApplicationAddress;

            long proc_min_address_l = (long)proc_min_address;
            long proc_max_address_l = (long)proc_max_address;

            Process process = Process.GetProcessesByName(procName)[0];
            IntPtr processHandle = OpenProcess(PROCESS_QUERY_INFORMATION | PROCESS_WM_READ, false, process.Id);
            MEMORY_BASIC_INFORMATION mem_basic_info = new MEMORY_BASIC_INFORMATION();

            int bytesRead = 0;
            //byte[] buffer = new byte[400]; // shouldnt be bigger that 64mb or something
            List<byte> buffer = new List<byte>();

            while (proc_min_address_l < proc_max_address_l)
            {
                VirtualQueryEx(processHandle, proc_min_address, out mem_basic_info, 28);

                // if this memory chunk is accessible
                if (mem_basic_info.Protect == PAGE_READWRITE && mem_basic_info.State == MEM_COMMIT)
                {
                    byte[] tmp = new byte[mem_basic_info.RegionSize];
                    ReadProcessMemory((int)processHandle, mem_basic_info.BaseAddress, tmp, mem_basic_info.RegionSize, ref bytesRead);
                    
                    foreach (Byte b in tmp)
                        buffer.Add(b);
                }

                // move to the next memory chunk
                proc_min_address_l += mem_basic_info.RegionSize;
                proc_min_address = new IntPtr(proc_min_address_l);
            }

            
            const string MUPEN_VERSION = "Mupen 64 1.0.9";
            const string MUPEN_SPLIT = "Mupen 64";
            string finalName = "";
            string str = "";
            str = ExtensionMethods.CharsToString(Encoding.ASCII.GetChars(buffer.ToArray()));
            int baseIndex = str.IndexOf(MUPEN_SPLIT) - str.Length;
            
            if (baseIndex > 0)
            {
                for (int i = 0; i < MUPEN_VERSION.Length; i++)
                {
                    finalName = String.Concat(finalName, (char)buffer[i]);
                }
            }

            

            MupenHookForm.MupenDataStruct mupenData;
            mupenData.CONFIRMED = finalName != "";
            mupenData.MUPEN_NAME = finalName;
            mupenData.PROCESS_NAME = procName;
            MupenHookForm.MupenData = mupenData;

            MupenHookForm.loading = false;
        }

        void ErrorProcessing(string failReason)
        {
            Debug.WriteLine("failed to load m64 " + failReason);

            loadedInvalidFile = true;


            string msg = UsageType.ToString() + " - ";
            MessageBox.Show(msg + " " + failReason, PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);

            txt_Path.Invoke((MethodInvoker)(() => txt_Path.Text = string.Empty));

        }
        void ReadM64()
        {
            m64loadBusy = true;
            // Check for suspicious MupenUtilities.Properties
            Debug.WriteLine("Attempting to load m64...");

            loadedInvalidFile = false;
            if (UsageType != UsageTypes.Any)
            {
                string errReason = "";

                if(!System.IO.Path.GetExtension(Path).Equals(".m64", StringComparison.InvariantCultureIgnoreCase))
                    errReason += "Extension invalid. ";
                if(String.IsNullOrEmpty(Path) || String.IsNullOrWhiteSpace(Path) || !ExtensionMethods.ValidPath(Path))
                    errReason += "Path invalid. ";
                if (!File.Exists(Path))
                    errReason += "File does not exist. ";

                if (errReason != "")
                {
                    ErrorProcessing(errReason);
                    m64loadBusy = false;
                    return;
                }
            }
            long len = new FileInfo(Path).Length;
            if (len < 1027)
            {
                ErrorProcessing("File is too small to be a movie."); 
                m64loadBusy = false;
                return;
            }
            foreach (Process procarr in Process.GetProcesses())
            {
                if (String.Equals(procarr.ProcessName, "mupen64", StringComparison.InvariantCultureIgnoreCase) || procarr.ProcessName.Contains("mupen64"))
                {
                    st_Status.Invoke((MethodInvoker)(() => st_Status.Visible = true));
                    st_Status1.GetCurrentParent().Invoke((MethodInvoker)(() => st_Status1.Visible = true));
                    st_Status1.GetCurrentParent().Invoke((MethodInvoker)(() => st_Status1.ForeColor = Color.Red));
                    st_Status1.GetCurrentParent().Invoke((MethodInvoker)(() => st_Status1.Text = "Mupen64 is running, this might cause file access issues"));
                    mupenRunning = true;
                    break;
                }
            }

            ASCIIEncoding ascii = new ASCIIEncoding();
            UTF8Encoding utf8 = new UTF8Encoding();
            FileStream fs;
            try { fs = File.Open(Path, FileMode.Open); }
            catch
            {
                ErrorProcessing("File inaccessible.");
                m64loadBusy = false;
                return;
            }
            BinaryReader br = new BinaryReader(fs);

            // Reset
            inputListCtl1.Clear();
            inputListCtl2.Clear();
            inputListCtl3.Clear();
            inputListCtl4.Clear();

            frame = 0;
            lbl_FrameSelected.Invoke((MethodInvoker)(() => lbl_FrameSelected.Text = "0"));
            txt_Frame.Invoke((MethodInvoker)(() => txt_Frame.Text = "0"));
            tr_MovieScrub.Invoke((MethodInvoker)(() => tr_MovieScrub.Minimum = 1));
            tr_MovieScrub.Invoke((MethodInvoker)(() => tr_MovieScrub.Value = 1));
            gp_input.Invoke((MethodInvoker)(() => gp_input.Enabled = true));
            Invoke((MethodInvoker)(() => tr_MovieScrub.Enabled = true));
            chk_readonly.Invoke((MethodInvoker)(() => chk_readonly.Enabled = readOnly));
            chk_readonly.Invoke((MethodInvoker)(() => chk_readonly.Text = "Readonly"));
            cbox_Controllers.Invoke((MethodInvoker)(() => cbox_Controllers.Items.Clear()));
            ResetLblColors();

            // Read header
            magic_Raw = br.ReadInt32();
            Magic = ExtensionMethods.ByteArrayToString(BitConverter.GetBytes(magic_Raw));
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
            ControllerFlags = br.ReadUInt32(); // controller flags
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

            for (int i = 0; i < 4; i++)
             ControllersEnabled[i] = ExtensionMethods.GetBit(ControllerFlags, i);
            

            // Load inputs
            // We need a buffer to check if end of file reached

            // tasstudio docs about mupen are fucking retarded and apparently the person who wrote it doesnt know what the difference
            // between a frame and a VI is...
            // to quote: "00C 4-byte little-endian unsigned int: number of frames (vertical interrupts)"
            // WHATTT???? 

            
            Debug.WriteLine("VI/s:" + VIs);
            frames = VIs;
            int findx = 0;
            // position 1024
            while (findx <= frames)
            {
                for (int i = 0; i < Controllers; i++)
                {


                    if (br.BaseStream.Position + 4 > fs.Length)
                    {
                        findx++;
                        continue;
                    }


                    try
                    {
                        if (ControllersEnabled[0])
                            inputListCtl1.Add(br.ReadInt32());
                        if (ControllersEnabled[1])
                            inputListCtl2.Add(br.ReadInt32());
                        if (ControllersEnabled[2])
                            inputListCtl3.Add(br.ReadInt32());
                        if (ControllersEnabled[3])
                            inputListCtl4.Add(br.ReadInt32());
                    }
                    catch {}
                    findx++;
                }
            }
            SAVE_inputList = inputListCtl1; // copy




            br.Close(); // destroy handle

            /*Set Controls*/
            txt_misc_Magic.Invoke((MethodInvoker)(() => txt_misc_Magic.Text = Magic));
            txt_misc_Version.Invoke((MethodInvoker)(() => txt_misc_Version.Text = Version));
            txt_misc_UID.Invoke((MethodInvoker)(() => txt_misc_UID.Text = UID.ToString()));

            txt_VIs.Invoke((MethodInvoker)(() => txt_VIs.Text = VIs.ToString()));
            txt_RR.Invoke((MethodInvoker)(() => txt_RR.Text = RRs.ToString()));
            txt_CTRLS.Invoke((MethodInvoker)(() => txt_CTRLS.Text = Controllers.ToString()));



            cbox_startType.Invoke((MethodInvoker)(() => cbox_startType.SelectedItem = DataHelper.GetMovieStartupType(StartType)));

            txt_videoplugin.Invoke((MethodInvoker)(() => txt_videoplugin.Text = VideoPlugin));
            txt_inputplugin.Invoke((MethodInvoker)(() => txt_inputplugin.Text = InputPlugin));
            txtbox_Audioplugin.Invoke((MethodInvoker)(() => txtbox_Audioplugin.Text = AudioPlugin));
            txt_Rsp.Invoke((MethodInvoker)(() => txt_Rsp.Text = RSPPlugin));

            txt_Rom.Invoke((MethodInvoker)(() => txt_Rom.Text = RomName));
            txt_Crc.Invoke((MethodInvoker)(() => txt_Crc.Text = Crc32.ToString()));

            object[] countryData = DataHelper.GetCountryResource(RomCountry);
            Image countryImage = (Image)countryData[1];

            txt_RomCountry.Invoke((MethodInvoker)(() => txt_RomCountry.Text = (string)countryData[0]));
            pb_RomCountry.Invoke((MethodInvoker)(() => pb_RomCountry.Size = countryImage.Size));
            pb_RomCountry.Invoke((MethodInvoker)(() => pb_RomCountry.BackgroundImage = countryImage));
            

            txt_PathName.Invoke((MethodInvoker)(() => txt_PathName.Text = M64Name));
            txt_Author.Invoke((MethodInvoker)(() => txt_Author.Text = Author));
            txt_Desc.Invoke((MethodInvoker)(() => txt_Desc.Text = Description));

            tr_MovieScrub.Invoke((MethodInvoker)(() => tr_MovieScrub.Minimum = 1));
            tr_MovieScrub.Invoke((MethodInvoker)(() => tr_MovieScrub.Maximum = (int)Samples));

            for (int i = 0; i < Controllers; i++)
                cbox_Controllers.Invoke((MethodInvoker)(() => cbox_Controllers.Items.Add("Controller " + (i + 1))));

            cbox_Controllers.Invoke((MethodInvoker)(() => cbox_Controllers.SelectedIndex = 0));

            EnableM64View_ThreadSafe(true);

            CheckSuspiciousProperties();
            //ShowStatus_ThreadSafe(M64_LOADED_TEXT);

            this.Invoke(new Action(() => PreloadTASStudio()));

            m64loadBusy = false;
        }
        void CheckSuspiciousProperties()
        {
            if (Controllers > 1)
            {
                lbl_Ctrls.ForeColor = Color.Red;
                MessageBox.Show("Your movie has more than one controller plugged in. This might cause bugs and crashes.", PROGRAM_NAME + " - Too many controllers");
            }

            if (txt_RomCountry.Text.Contains("Unknown"))
                lbl_RomCountry.ForeColor = Color.Red;

            if (StartType > 4 || StartType < 1)
                lb_starttype.ForeColor = Color.Red;

            if (magic_Raw != 439629389)
                lbl_misc_Magic.ForeColor = Color.Red;

            if (VIs == 0 || VI_s == 0)
                lb_VIs.ForeColor = Color.Red;

            

           

           lbl_ROMCRC.ForeColor = Color.Red;
           foreach(var crc in DataHelper.validCrcs)
            {
                //Debug.WriteLine("Crc32: " + Crc32.ToString("X2"));
                //Debug.WriteLine("crc check: " + crc.ToString("X2"));
                if(Crc32 == crc || Crc32.ToString("X2") == crc.ToString("X2")) // so much slower but might work 
                {
                    lbl_ROMCRC.ForeColor = Color.Black;
                    break;
                }
                
            }

        }
        void WriteM64()
        {
            Debug.WriteLine(String.Format("Begin Save M64: File loaded: {0}", FileLoaded));

            if (!FileLoaded)
            {
                RedControl(btn_PathSel);
                return;
            }
            if(Controllers != 1 || byte.Parse(txt_CTRLS.Text) != 1)
            {
                RedControl(lbl_Ctrls);
                return;
            }

            string tmpPath = System.IO.Path.GetFileNameWithoutExtension(Path) + "-modified";

            while (File.Exists(tmpPath))
            {

                Debug.WriteLine("File already exists, trying " + tmpPath);
                tmpPath = tmpPath + "-modified";
            }

            tmpPath = tmpPath + ".m64";

            SavePath = tmpPath;

            Debug.WriteLine(tmpPath);

            File.Delete(SavePath);

            FileStream fs = File.Open(SavePath, FileMode.Create);
            BinaryWriter br = new BinaryWriter(fs);
            //ShowStatus("Saving M64...", st_Status1);
            byte[] zeroar1 = new byte[160]; byte[] zeroar2 = new byte[56];
            byte[] magic = new byte[5] { 0x4D, 0x36, 0x34, 0x1A, 0x03};
            //magic[0] = 0x4D;
            //magic[1] = 0x36;
            //magic[2] = 0x34;
            //magic[3] = 0x1A;
            //magic[4] = 0x03;
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

            br.Write(BitConverter.ToInt32(magic,0)); // Int32 - Magic (4D36341A)
            br.Write(0x3); // UInt32 - Version number (3)
            br.Write(UID); // UInt32 - UID
            br.Write((UInt32)VIs); // UInt32 - VIs
            br.Write((UInt32)RRs); // UInt32 - RRs
            br.Write(VI_s); // Byte - VI/s
            br.Write(Controllers); // Byte - Controllers
            br.Write((Int16)0); // 2 Bytes - RESERVED
            br.Write(Samples); // UInt32 - Input Samples

            br.Write((UInt16)DataHelper.GetMovieStartupTypeIndex(cbox_startType.SelectedItem.ToString())); // UInt16 - Movie start type
            br.Write((Int16)0); // 2 bytes - RESERVED
            br.Write(ControllerFlags); // UInt32 - Controller Flags
            br.Write(zeroar1, 0, zeroar1.Length); // 160 bytes - RESERVED
            byte[] romname;
            romname = ASCIIEncoding.ASCII.GetBytes(RomName);
            Array.Resize(ref romname, 32);
            br.Write(romname, 0, 32);
            br.Write(Crc32);
            br.Write(RomCountry);
            br.Write(zeroar2, 0, zeroar2.Length); // 56 bytes - RESERVED


            byte[] gfx = new byte[64];
            byte[] audio = new byte[64];
            byte[] input = new byte[64];
            byte[] rsp = new byte[64];
            byte[] author = new byte[222];
            byte[] desc = new byte[256];

            gfx = Encoding.ASCII.GetBytes(VideoPlugin);
            audio = Encoding.ASCII.GetBytes(AudioPlugin);
            input = Encoding.ASCII.GetBytes(InputPlugin);
            rsp = Encoding.ASCII.GetBytes(RSPPlugin);
            author = Encoding.UTF8.GetBytes(Author);
            desc = Encoding.UTF8.GetBytes(Description);
            
            Array.Resize(ref gfx, 64);
            Array.Resize(ref audio, 64);
            Array.Resize(ref input, 64);
            Array.Resize(ref rsp, 64);
            Array.Resize(ref author, 222);
            Array.Resize(ref desc, 256);

            br.Write(gfx, 0, 64);
            br.Write(audio, 0, 64);
            br.Write(input, 0, 64);
            br.Write(rsp, 0, 64);
            br.Write(author, 0, 222);
            br.Write(desc, 0, 256);
            for (int i = 0; i < inputListCtl1.Count; i++)
            {
                br.Write(inputListCtl1[i]);
            }
            br.Flush();
            br.Close();
            fs.Close();
            //ShowStatus("Finished Saving M64 (" + SavePath + ")", st_Status1);
        }



        void LoadST()
        {
            if (UsageType != UsageTypes.Any)
            {
                Debug.WriteLine(Path);
                Debug.WriteLine(System.IO.Path.GetExtension(Path));
                string errReason = "";

                if (System.IO.Path.GetExtension(Path).Equals(".st", StringComparison.InvariantCultureIgnoreCase) == false && System.IO.Path.GetExtension(Path).Equals(".savestate", StringComparison.InvariantCultureIgnoreCase) == false)
                    errReason += "Extension invalid. ";
                if (String.IsNullOrEmpty(Path) || String.IsNullOrWhiteSpace(Path) || !ExtensionMethods.ValidPath(Path))
                    errReason += "Path invalid. ";
                if (!File.Exists(Path))
                    errReason += "File does not exist. ";

                if (errReason != "")
                {
                    ErrorProcessing(errReason);
                    return;
                }
            }

            FileInfo f = new FileInfo(Path);
            FileStream origFs, defFs;
            GZipStream deStream;
            string newFs;
            origFs = f.OpenRead();


            string curFs = f.FullName;
            newFs = curFs.Remove(curFs.Length - f.Extension.Length) + ".bin";

            defFs = File.Create(newFs);

            deStream = new GZipStream(origFs, CompressionMode.Decompress);
            deStream.CopyTo(defFs);

            BinaryReader br = new BinaryReader(defFs);

            //defFs.Read(STForm.savestateRDRAM, 0, (int)deStream.BaseStream.Length);
            br.BaseStream.Seek(0x1B0, SeekOrigin.Begin); // have fun figuring this out without docs
            STForm.savestateRDRAM = br.ReadBytes(8388608);

            STForm.savestate = ExtensionMethods.ReadAllBytes(br.BaseStream).ToList();

            defFs.Close();
            origFs.Close();
            br.Close();

            string tmpPath = System.IO.Path.GetFileNameWithoutExtension(Path) + "-modified";
            while (File.Exists(tmpPath))
            {
                Debug.WriteLine("File already exists, trying " + tmpPath);
                tmpPath = tmpPath + "-modified";
            }
            tmpPath = tmpPath + ".st";
            STForm.Path = tmpPath;


            stForm.ShowDialog(); // main ui thread here pauses because of modal popup (execution does not continue)
            
            //MessageBox.Show("Savestate has been decompressed to " + newFs, PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        #endregion

        #region Input & Frames

        // TODO: Maybe refactor. This is a mess and order of execution is very hard to trace!

        void PreloadTASStudio()
        {
            // nuke data
            // this crashes for some reason after the 2nd time

            while (tasStudioBusy)
            {
                Debug.WriteLine("tasstudio wait for tasstudio");
                Application.DoEvents();
                Thread.Sleep(100);
            }

            dgv_Main.Rows.Clear();
            dgv_Main.Columns.Clear();
            dgv_Main.ClearSelection();
            dgv_Main.Refresh();


            dgv_Main.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dgv_Main, true, null);
            dgv_Main.ColumnCount = 18; // 16 buttons + joystick X Y
            dgv_Main.ColumnHeadersVisible = true;
            dgv_Main.ReadOnly = true; // lol 


            for (byte i = 0; i < inputStructNames.Length; i++)
            {
                dgv_Main.Columns[i].Name = inputStructNames[i];
                dgv_Main.Columns[i].Width = 50; // bad! why do in loop s mh hshshshsjadhasuo d273781 !!
                dgv_Main.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            gp_TASStudio.Text = "TAS Studio - Loading " + inputLists[selectedController].Count + " samples";
            // populate with input data (this is cringe and painful and slow i dont care)
            new Thread(() =>
           {
               while (dgv_Main.RecreatingHandle) ; // spin until handle is created
               while (tasStudioBusy) ;
               tasStudioBusy = true;
               for (int y = 0; y < inputLists[selectedController].Count; y++)
               {
                   // for each frame
                   dgv_Main.Invoke((MethodInvoker)(() => dgv_Main.Rows.Add()));

                   for (int x = 0; x < inputStructNames.Length; x++)
                   {
                       // for each button


                       // kind of stupid implementation
                       // this is easily done faster but do i care?

                       string cellValue = "";
                       //Debug.WriteLine("X: " + x + " (" + inputStructNames[x] + ")");

                       if (y > inputLists[selectedController].Count) continue; // desync! skip
                       if (inputLists[selectedController].Count == 0) continue; // empty...

                       if (x < 16)
                       {


                           if ((inputLists[selectedController][y] & (int)Math.Pow(2, x)) != 0)
                               cellValue = inputStructNames[x];
                       }
                       else
                       {

                           byte[] data = BitConverter.GetBytes(inputLists[selectedController][y]);

                           if (x == 16)
                               cellValue = ((sbyte)data[2]).ToString();
                           else if (x == 17)
                               cellValue = ((sbyte)data[3]).ToString();
                       }
                       try
                       {
                           dgv_Main.Invoke((MethodInvoker)(() => dgv_Main.Rows[y].Cells[x].Value = cellValue));
                       }
                       catch
                       {
                           // desync...
                           continue;
                       }
                   }
               }
               gp_TASStudio.Invoke((MethodInvoker)(() => gp_TASStudio.Text = "TAS Studio"));
               tasStudioBusy = false;
           }).Start();
        }



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
            //while (tasStudioBusy)
            //{
            //    Debug.WriteLine("main waiting for tasstudio");
            //    Application.DoEvents();
            //    Thread.Sleep(1);
            //}
            if (tasStudioBusy || m64loadBusy)
            {
                Debug.WriteLine("setinput critical thread busy... return");
                return;
            }
            int value = 0XDD;
            try
            {
                value = inputLists[selectedController][frame];
            } // get value at that frame. If this fails then m64 is corrupted 
            catch
            {
                EnableM64View(false, false);
                stepFrameTimer.Enabled = false;
                MessageBox.Show("Failed to find input value at frame " + frame + ". The application might behave unexpectedly until a restart.\nThis can be caused by a corrupted m64 or loading movies in quick succession", PROGRAM_NAME + " - Fatal desync");
                return;
            }

            for (int i = 0; i < controllerButtonsChk.Length; i++)
            {
                //Debug.WriteLine("[INSIDE LOOP] FRAME " + frame + " | VALUE: " + value.ToString("X") + " | BUTTON: " + controllerButtonsChk[i].Text.ToString() + " | Checked: " + controllerButtonsChk[i].Checked.ToString());
                ExtensionMethods.SetBit(ref value, controllerButtonsChk[i].Checked, i);
            }
            byte[] joydata = BitConverter.GetBytes(value);
            joydata[2] = (byte)JOY_Rel.X;
            joydata[3] = (byte)-JOY_Rel.Y;
            

            value = BitConverter.ToInt32(joydata, 0);
            lastValue = value;
            inputLists[selectedController][frame] = value;
            Debug.WriteLine("[METHOD END] FRAME " + frame + " | VALUE: " + value.ToString("X"));

            // update tas studio
                if (liveTasStudio)
                {
                    dgv_Main.ReadOnly = false;
                    // workaround because windows controls are fucked

                    for (int i = 0; i < inputStructNames.Length; i++)
                    {
                        string cellValue = "";

                        if (i < 16)
                        {
                            
                            if ((inputLists[selectedController][frame] & (int)Math.Pow(2, i)) != 0)
                            cellValue = inputStructNames[i];

                        }
                        else
                        {

                            byte[] data = BitConverter.GetBytes(inputLists[selectedController][frame]);

                        if (i == 16)
                            cellValue = ((sbyte)data[2]).ToString();
                        else if (i == 17)
                            //cellValue = ((sbyte)data[3]).ToString();
                            cellValue = txt_joyY.Text;
                        }

                    int index = frame - 1;
                    if (index < 1) index = 1;
                        dgv_Main.Rows[index].Cells[i].Value = cellValue;
                    }
                    dgv_Main.ReadOnly = true;

                }

        }
        void GetInput(int value)
        {
            for (int i = 0; i < controllerButtonsChk.Length; i++)
            {
                controllerButtonsChk[i].Checked = (value & (int)Math.Pow(2, i)) != 0;
            }
            byte[] data = BitConverter.GetBytes(value);
            sbyte joystickX = (sbyte)data[2];
            sbyte joystickY = (sbyte)data[3];

            txt_joyX.Text = joystickX.ToString();
            txt_joyY.Text = (/*-*/joystickY).ToString();// lie to user

            
            SetJoystickValue(new Point(joystickX, joystickY), RELATIVE, false);
            SetInput(frame);
            chk_restart.Checked = chk_RESERVED1.Checked && chk_RESERVED2.Checked;
            chk_restart.ForeColor = chk_restart.Checked ? Color.Orange : Color.Black;
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
        bool checkAllowedStep(int stepAmount)
        {
            if (frame > frames || frame < 0)
            {
                if (!loopInputs)
                {
                    if (frame > frames)
                        frame = (int)frames;
                    else if (frame < 0)
                        frame = 0;
                }
                else
                {
                    if (frame > frames)
                    {
                        frame = 0;
                    }
                    else if (frame < 0)
                    {
                        frame = (int)frames - 1;
                    }
                }
                return false;
            }
            return true;
        }

        void SetFrame(int targetframe)
        {
            frame = targetframe;
            if (!checkAllowedStep(targetframe))
            {
                return;
            }
            if (frame >= inputLists[selectedController].Count)
            {
                frame = inputLists[selectedController].Count;
                stepFrameTimer.Enabled = false;
                return;
            }
            GetInput(inputLists[selectedController][frame]);
            UpdateFrameControlUI();
        }
        #endregion

        #region Event Handlers

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if(UsageType != UsageTypes.M64 && UsageType != UsageTypes.ST)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Move;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string file = files[0];
            if (files.Length > 1)
            {
                MessageBox.Show("You are attempting to load more than one file, picking first one from list...", PROGRAM_NAME + " - Too much data");
            }

            if (!ExtensionMethods.ValidPath(file))
            {
                Debug.WriteLine("invalid path"); return;
            }
            Path = txt_Path.Text = file;
            MupenUtilities.Properties.Settings.Default.LastPath = Path;
            MupenUtilities.Properties.Settings.Default.Save();

            if (UsageType == UsageTypes.M64)
            {
                if (rb_M64sel.Checked)
                {
                    while (m64loadBusy)
                    {
                        Debug.WriteLine("main wait for m64load");
                        Application.DoEvents();
                        Thread.Sleep(1);
                    }
                    m64load = new Thread(() => ReadM64());
                    m64load.Start();
                }
            }
            else if(UsageType == UsageTypes.ST)
            {
                LoadST();
            }
        }

        private void btn_Input_Debug_Click(object sender, EventArgs e)
        {
            ctx_Input_Debug.Show(Cursor.Position);
        }

        private void dgv_Main_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ctx_TasStudio.Show(Cursor.Position);
        }
        private void dgv_Main_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys != Keys.Control) return;


            cellSize += Math.Sign(e.Delta)*5;

            for (int i = 0; i < dgv_Main.Columns.Count; i++)
            {
                DataGridViewColumn c = dgv_Main.Columns[i];
                c.Width = cellSize;
            }
        }
        private void tsmi_Input_Debug_DumpData_Click(object sender, EventArgs e)
        {
            DumpInputsFile(false);
        }

        private void tsmi_Input_Sticky_Click(object sender, EventArgs e)
        {
            Sticky = !Sticky;
            tsmi_Input_Sticky.Checked = Sticky;
        }

        private void tsmi_Input_SetInput_Click(object sender, EventArgs e)
        {
            debugForm.ShowDialog();
        }
        private void dgv_Main_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            

            using (SolidBrush b = new SolidBrush(dgv_Main.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
        private void dgv_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.H && e.Modifiers == Keys.Control)
                tasStudioForm.ShowDialog();

        }

        private void MainForm_Focus(object sender, EventArgs e)
        {
            if (forceGoto)
            {
                dgv_Main.CurrentCell = dgv_Main.Rows[markedGoToFrame].Cells[0];
                dgv_Main.Rows[markedGoToFrame].Selected = true;

                forceGoto = false;
            }
            if (forceResizeCell)
            {
                for (int i = 0; i < dgv_Main.Columns.Count; i++)
                {
                    DataGridViewColumn c = dgv_Main.Columns[i];
                    c.Width = markedSizeCell;
                }
                forceResizeCell = false;
            }
            if (notifiedReupdateControllerFlags)
            {
                Controllers = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (ExtensionMethods.GetBit(ControllerFlags, i))
                        Controllers++;
                }
                txt_CTRLS.Text = Controllers.ToString();

                notifiedReupdateControllerFlags = false;
            }

        }

        private void utilityToolStripMenuItem_Click(object sender, EventArgs e)
        {

            tasStudioForm.ShowDialog();
        }

        private void txt_GenericNumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        
        private void btn_PathSel_MouseClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("browse...");

            if (UsageType == UsageTypes.Mupen)
            {
                MupenHook(); // skip dialog
                return;
            }
            if(UsageType == UsageTypes.Replacement)
            {
                replacementForm.ShowDialog();
                return;
            }

            object[] result = UIHelper.ShowFileDialog(UsageType);
            if ((string)result[0] == "FAIL" && (bool)result[1] == false)
            {
                Debug.WriteLine("failed dialog");
                return;
            }

            txt_Path.Text = (string)result[0];
            Path = (string)result[0];

            
            MupenUtilities.Properties.Settings.Default.LastPath = Path;
            MupenUtilities.Properties.Settings.Default.Save();

            if (UsageType == UsageTypes.M64)
            {
                m64load = new Thread(() => ReadM64());
                m64load.Start();
            }
            else if (UsageType == UsageTypes.ST)
                LoadST();
            else if (UsageType == UsageTypes.Autodetect)
            {
                
                string ext = System.IO.Path.GetExtension(Path);
                if (ext.Equals(".m64", StringComparison.InvariantCultureIgnoreCase))
                {
                    m64load = new Thread(() => ReadM64());
                    m64load.Start();

                } 
                else if (ext.Equals(".st", StringComparison.InvariantCultureIgnoreCase) || ext.Equals(".savestate", StringComparison.InvariantCultureIgnoreCase))
                {
                    LoadST();
                }
                else if (ext.Equals(".exe", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (Path.Contains("mupen"))
                    {
                        Process.Start(Path);
                        MupenHook();
                    }
                    else
                    {
                        ErrorProcessing("Executable not mupen");
                        return;
                    }
                   
                }
                else
                {
                    ErrorProcessing("Unknown type " + ext);
                    return;
                }
            }
        }
        private void btn_Last_MouseClick(object sender, MouseEventArgs e)
        {
            Path = MupenUtilities.Properties.Settings.Default.LastPath;
            if (UsageType == UsageTypes.M64 && ExtensionMethods.ValidPath(Path))
            {
                m64load = new Thread(() => ReadM64());
                m64load.Start();
            }
            else if (UsageType == UsageTypes.ST) LoadST();
            else if (UsageType == UsageTypes.Mupen) MupenHook();
        }
        private void rb_M64sel_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            UsageType = UsageTypes.Autodetect;
            else if(e.Button == MouseButtons.Left)
            UsageType = UsageTypes.M64;
            UpdateVisualsTop(true);
        }
        private void rb_STsel_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            UsageType = UsageTypes.Autodetect;
            else if(e.Button == MouseButtons.Left)
            UsageType = UsageTypes.ST;
            UpdateVisualsTop(true);
        }

        private void rb_MUPsel_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            UsageType = UsageTypes.Autodetect;
            else if(e.Button == MouseButtons.Left)
            UsageType = UsageTypes.Mupen;
            UpdateVisualsTop(true);
        }
        private void rb_Replacementsel_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            UsageType = UsageTypes.Autodetect;
            else if(e.Button == MouseButtons.Left)
            UsageType = UsageTypes.Replacement;
            UpdateVisualsTop(true);
        }

        private void btn_Override_MouseDown(object sender, MouseEventArgs e)
        {
            EnableM64View(!ExpandedMenu, false);
            btn_Override.Text = ExpandedMenu ? "v" : "^";
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
        void StepFrameAuto()
        {
            if (forwardsPlayback)
                StepFrame(1);
            else
                StepFrame(-1);
        }
        void UpdateFrameControlUI()
        {
            lbl_FrameSelected.Text = "Frame " + frame.ToString();
            chk_restart.Checked = chk_RESERVED1.Checked && chk_RESERVED2.Checked;
            chk_restart.ForeColor = chk_restart.Checked ? Color.Orange : Color.Black;

            txt_Frame.Text = frame.ToString();

            int index = frame-1;

            if (frame <= dgv_Main.Rows.Count)
            {
                
                dgv_Main.CurrentCell = dgv_Main.Rows[index].Cells[0];
                dgv_Main.Rows[index].Selected = true;
            }
            if (frame <= tr_MovieScrub.Maximum && frame >= tr_MovieScrub.Minimum)
                tr_MovieScrub.Value = frame;

        }
        void AdvanceInputAuto(object obj, EventArgs e)
        {
            StepFrameAuto();
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Oem5) //  (\ or |)
            {
                stepFrameTimer.Enabled = false;
                btn_PlayPause.Text = "|>";
                StepFrameAuto();
            }
            else if ((e.KeyCode == Keys.Enter && e.Modifiers == Keys.Alt) || e.KeyCode == Keys.F11)
            {
                ExtensionMethods.FullScreen(this);
            }
            if (!readOnly)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                    case Keys.Up:
                        SetJoystickValue(new Point(0, -127), false, false);
                        break;
                    case Keys.A:
                    case Keys.Left:
                        SetJoystickValue(new Point(-128, 0), false, false);
                        break;
                    case Keys.S:
                    case Keys.Down:
                        SetJoystickValue(new Point(0,127/*-127 actually but this is inaccuracy which will be fixed*/), false, false);
                        break;
                    case Keys.D:
                    case Keys.Right:
                        SetJoystickValue(new Point(127, 0), false, false);
                        break;
                }
            }
        }


        private void btn_PlayPause_Click(object sender, EventArgs e)
        {
            // Toggle timer
            stepFrameTimer.Enabled = !stepFrameTimer.Enabled;
            btn_PlayPause.Text = stepFrameTimer.Enabled ? "| |" : forwardsPlayback ? "|>" : "<|";
        }
        private void btn_PlayDirection_Click(object sender, EventArgs e)
        {
            forwardsPlayback = !forwardsPlayback;
            btn_PlayDirection.Text = forwardsPlayback ? ">" : "<";
            btn_PlayPause.Text = stepFrameTimer.Enabled ? "| |" : forwardsPlayback ? "|>" : "<|";
        }
        private void tsmi_TasStudio_Big_Click(object sender, EventArgs e)
        {
            gp_TASStudio.Dock = gp_TASStudio.Dock == DockStyle.Right ? DockStyle.Fill : DockStyle.Right;
            tr_MovieScrub.Visible = gp_TASStudio.Dock == DockStyle.Right;
            tsmi_TasStudio_Big.Checked = gp_TASStudio.Dock == DockStyle.Fill;
            cbox_Controllers.Visible = gp_TASStudio.Dock != DockStyle.Fill;
        }

        private void tsmi_AAJoystick_Click(object sender, EventArgs e)
        {
            JOY_SmoothingMode = JOY_SmoothingMode == SmoothingMode.HighQuality ? SmoothingMode.None : SmoothingMode.HighQuality;
            tsmi_AAJoystick.Checked = JOY_SmoothingMode == SmoothingMode.HighQuality;
            pb_JoystickPic.Invalidate();
        }

        private void tsmi_TasStudioAllow_Click(object sender, EventArgs e)
        {
            gp_TASStudio.Visible = !gp_TASStudio.Visible;
            tsmi_TasStudioAllow.Checked = gp_TASStudio.Visible;
            if (gp_TASStudio.Visible) gp_TASStudio.Refresh();
        }

        private void tsmi_SimpleMode_Click(object sender, EventArgs e)
        {
            simpleMode = !simpleMode;
            tsmi_SimpleMode.Checked = simpleMode;
            txt_joyX.Visible
                = txt_joyY.Visible
                = lbl_X.Visible
                = lbl_Y.Visible
                = txt_Frame.Visible
                = btn_FrameBack2.Visible
                = btn_FrameFront2.Visible
                = gp_TASStudio.Visible
                = chk_restart.Visible
                = chk_RESERVED1.Visible
                = chk_RESERVED2.Visible
                = gp_M64_misc.Visible
                = gpRom.Visible
                = !simpleMode;

            tsmi_TasStudioAllow.Visible =
            tsmi_Input_Debug_DumpData.Visible =
            tsmi_Input_SetInput.Visible =
            tsmi_Input_Sticky.Visible =
            tsmi_TasStudioAllow.Checked = !simpleMode;


            if (simpleMode) gp_Plugins.Location = gp_M64_misc.Location;
            else
            {
                //gp_User.Location;
                //gp_M64_misc.Location;
                //gpRom.Location;
                //gp_Plugins.Location;

                gp_Plugins.Location = originalGroupboxLocation[3];
                gp_M64_misc.Location = originalGroupboxLocation[1];
            }
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
            if (m64load != null && m64load.IsAlive)
            {
                bool exit;
                exit = MessageBox.Show("The m64 loading thread is still running. Are you sure you want to close the program and attempt to kill the thread? (might cause issues)",
                "Thread running",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes;
                if (exit)
                    m64load.Abort();
                e.Cancel = !exit;


                return;
            }
        }

        private void txt_Frame_KeyDown(object sender, KeyEventArgs e)
        {
            if (ExtensionMethods.ValidStringInt(txt_Frame.Text, 0, (int)frames) && e.KeyCode == Keys.Enter)
            {
                SetFrame(Int32.Parse(txt_Frame.Text));
            }
        }
        void ParseXYTextbox()
        {
            if (ExtensionMethods.ValidStringSByte(txt_joyX.Text) && ExtensionMethods.ValidStringSByte(txt_joyY.Text))
                SetJoystickValue(new Point(sbyte.Parse(txt_joyX.Text), sbyte.Parse(txt_joyY.Text)), RELATIVE, false);
        }
        private void txt_joyX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ParseXYTextbox();
            if (e.KeyCode == Keys.Escape) this.ActiveControl = null;
        }

        private void txt_joyY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ParseXYTextbox();
            if (e.KeyCode == Keys.Escape) this.ActiveControl = null;
        }

        private void btn_Savem64_MouseClick(object sender, MouseEventArgs e) => WriteM64();
        private void btn_Tips_Click(object sender, EventArgs e) => ShowTipsForm();

        void UpdateReadOnly()
        {
            readOnly = chk_readonly.Checked;
            chk_readonly.Text = readOnly ? "Read-only" : "Read-write";
            //if(!readOnly) ShowStatus("Read-Write mode: All changes will be flushed to a new file upon pressing \'Save File\'", st_Status1);
            //else ShowStatus("Read-only mode: You can only view M64 data", st_Status1);
            // Groupboxes + Child controls
            foreach (Control ctl in gp_User.Controls)
            {
                if (ctl is TextBox)
                {
                    TextBox txt = ctl as TextBox;
                    txt.ReadOnly = readOnly;
                }
            }
            txt_Rom.ReadOnly = readOnly;
            txt_CTRLS.ReadOnly = readOnly;
            cbox_startType.Enabled = !readOnly;
            foreach (Control ctl in gp_Plugins.Controls)
            {
                if (ctl is TextBox)
                {
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
                if (ctl is CheckBox)
                {
                    CheckBox chk = ctl as CheckBox;
                    chk.Enabled = !readOnly;
                }
            }
        }

        private void tr_MovieScrub_Scroll(object sender, EventArgs e)
        {
            SetFrame(tr_MovieScrub.Value);
        }

        private void chk_readonly_CheckedChanged(object sender, EventArgs e)
        {
            UpdateReadOnly();
        }

        private void generic_ClickDisallowedProperty(object sender, MouseEventArgs e)
        {
            RedControlBack(sender as TextBox);
        }

        private void tsmi_Agressive_Click(object sender, EventArgs e)
        {
            tsmi_Agressive.Checked ^= true;
        }

        private void cbox_Controllers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox_Controllers.SelectedIndex + 1 > Controllers)
            {
                selectedController = 0;
                goto update;
            }
            selectedController = Convert.ToByte(cbox_Controllers.SelectedIndex);

        update:
            GetInput(frame);
            cbox_Controllers.SelectedIndex = selectedController;
        }

        private void btn_CtlFlags_Click(object sender, EventArgs e)
        {
            controllerFlagsForm.ShowDialog();
        }
        private void tsmi_GetInput_Click(object sender, EventArgs e)
        {
            if (FileLoaded)
            { 
                string s = "";
                s += String.Format("Input data at frame {0}: {1}", frame, ExtensionMethods.ByteArrayToString(BitConverter.GetBytes(inputLists[selectedController][frame])) + "\n");
                s += "View:\n";
                s += DataHelper.GetFriendlyValue(inputLists[selectedController][frame]);
                s += "\nGuide: Bit 0-15 are dedicated to Buttons and Bytes 2,3 (Bits 16-24 and Bits 24-36) are Joystick X and Y respectively.";


                MessageBox.Show(s, PROGRAM_NAME + " - Advanced Get Input");

            }
        }
        private void tsmi_LiveTasStudio_Click_1(object sender, EventArgs e)
        {
            liveTasStudio ^= true;
            tsmi_LiveTasStudio.Checked = liveTasStudio;
        }
        

        private void themeSelectedClick(object sender, MouseEventArgs e)
        {
            ToolStripMenuItem btn = sender as ToolStripMenuItem;

            foreach(ToolStripMenuItem ts in tsmi_Themes.DropDownItems) ts.Checked = false;

            for (int i = 0; i < tsmi_Themes.DropDownItems.Count; i++)
            {
                if (tsmi_Themes.DropDownItems[i] == btn)
                {
                    UITheme = (UIThemes)i;
                    SetUITheme(UITheme);
                    ToolStripMenuItem ts = tsmi_Themes.DropDownItems[i] as ToolStripMenuItem;
                    ts.Checked = true;
                    break;
                }
                    
            }
        }
        private void inputStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputStatsForm.inputCtl1 = inputListCtl1;
            InputStatsForm.inputCtl2 = inputListCtl2;
            InputStatsForm.inputCtl3 = inputListCtl3;
            InputStatsForm.inputCtl4 = inputListCtl4;

            inputStatisticsForm.ShowDialog();
        }

        private void dgv_Main_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            SetFrame(e.RowIndex+1);
        }
        private void tsmi_CRCPopulate_Click(object sender, EventArgs e)
        {
            int len = DataHelper.validCrcs.Count;
            DataHelper.PopulateCRCsFromFile();
            
            MessageBox.Show("Added " + (DataHelper.validCrcs.Count - len) + " new CRCs");
        }
        #endregion

        #region Joystick Behaviour

        private void InputChk_Changed(object sender, MouseEventArgs e)
        {
            // This fires when any input checkbox has been changed
            if (readOnly || !FileLoaded)
                return;

            UpdateFrameControlUI();
            SetInput(frame);
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

        Point RelativeToAbsolute(Point pt)
        {
            int X = pb_JoystickPic.ClientRectangle.Left + (pt.X + 128) * (pb_JoystickPic.ClientRectangle.Right - pb_JoystickPic.ClientRectangle.Left) / 256;
            int Y = pb_JoystickPic.ClientRectangle.Top + (pt.Y + 128) * (pb_JoystickPic.ClientRectangle.Bottom - pb_JoystickPic.ClientRectangle.Top) / 256;
            return new Point(X, Y);
        }
        Point AbsoluteToRelative(Point pt)
        {
            int x = (pt.X * 256 / pb_JoystickPic.Width - 128 + 1);
            int y = (pt.Y * 256 / pb_JoystickPic.Height - 128 + 1);
            x = ExtensionMethods.Clamp(x, -128, 127);
            y = ExtensionMethods.Clamp(y, -127, 128);
            return new Point(x, y);

        }
        void SetJoystickValue(Point pos, bool abs, bool user)
        {
            lockType = abs == ABSOLUTE;

            if (abs == ABSOLUTE)
            {
                // Point pos is absolute control location
                JOY_Abs = pos;
                JOY_Rel = AbsoluteToRelative(pos);
            }
            else
            {
                // Point pos is relative joystick location
                JOY_Rel = pos;
                JOY_Abs = RelativeToAbsolute(pos);
            }

            //if (user && !readOnly)  (frame);



            txt_joyX.Text = JOY_Rel.X.ToString();
            txt_joyY.Text = JOY_Rel.Y.ToString();

            pb_JoystickPic.Refresh();



        }

        private void pb_JoystickPic_Paint(object sender, PaintEventArgs e) => DrawJoystick(e);
        private void pb_JoystickPic_MouseUp(object sender, MouseEventArgs e) => JOY_mouseDown = JOY_followMouse;
        private void pb_JoystickPic_MouseMove(object sender, MouseEventArgs e)
        {
            if (JOY_mouseDown) SetJoystickValue(e.Location, ABSOLUTE, true);
        }

        private void pb_JoystickPic_MouseDown(object sender, MouseEventArgs e)
        {
            JOY_followMouse = e.Button != MouseButtons.Right || !JOY_followMouse;
            JOY_followMouse = !(e.Button == MouseButtons.Left && JOY_followMouse);
            JOY_mouseDown = true;
            SetJoystickValue(e.Location, ABSOLUTE, true);
        }

        

        private void DrawJoystick(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = JOY_SmoothingMode;

            Pen linepen = Pens.Red;

            if (readOnly) linepen = new Pen(Color.Gray, 3);

            if(UITheme == UIThemes.Default)      linepen = new Pen(Color.Blue, 3);
            else if(UITheme == UIThemes.Gray)    linepen = new Pen(Color.Black, 3);
            else if(UITheme == UIThemes.Dark)    linepen = new Pen(Color.Gray, 3);

            if(UITheme == UIThemes.Default)   e.Graphics.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), pb_JoystickPic.ClientRectangle);
            else if(UITheme == UIThemes.Gray) e.Graphics.FillRectangle(Brushes.Gray, pb_JoystickPic.ClientRectangle);
            else if(UITheme == UIThemes.Dark) e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255,50,50,50)), pb_JoystickPic.ClientRectangle);

            //Console.WriteLine("Repaint! " + JOY_Abs.X + "/" + JOY_Abs.Y);
            if (lockType)
            {
                SnapJoystick(); // warning: is this desync proof and accurate?
            }

            Point xy;
            if (lockType)
                xy = JOY_Abs;
            else
            {
                xy = RelativeToAbsolute(JOY_Rel);
            }


            // TODO: somehow optimize this because branching in wm_paint is not good
            // but this isnt too bad because gdi+ isn't hardware accelerated, so no hardware waiting for eachother
            if (!readOnly)
            {
                if (UITheme == UIThemes.Default)
                {
                     e.Graphics.DrawEllipse(Pens.Black, 1, 1, pb_JoystickPic.Width - 2, pb_JoystickPic.Height - 2);
                    e.Graphics.DrawLine(Pens.Black, 0, JOY_middle.Y, pb_JoystickPic.Width, JOY_middle.Y);
                    e.Graphics.DrawLine(Pens.Black, JOY_middle.X, pb_JoystickPic.Height, JOY_middle.X, -pb_JoystickPic.Height);
                    e.Graphics.DrawLine(linepen, JOY_middle, xy);
                    e.Graphics.FillEllipse(Brushes.Red, xy.X - 4, xy.Y - 4, 8, 8);
                }
                else if(UITheme == UIThemes.Gray)
                {
                    e.Graphics.DrawEllipse(Pens.Black, 1, 1, pb_JoystickPic.Width - 2, pb_JoystickPic.Height - 2);
                    e.Graphics.DrawLine(Pens.Black, 0, JOY_middle.Y, pb_JoystickPic.Width, JOY_middle.Y);
                    e.Graphics.DrawLine(Pens.Black, JOY_middle.X, pb_JoystickPic.Height, JOY_middle.X, -pb_JoystickPic.Height);
                    e.Graphics.DrawLine(linepen, JOY_middle, xy);
                    e.Graphics.FillEllipse(Brushes.Black, xy.X - 4, xy.Y - 4, 8, 8);
                   
                }
                else if(UITheme == UIThemes.Dark)
                {
                    e.Graphics.DrawEllipse(linepen, 1, 1, pb_JoystickPic.Width - 2, pb_JoystickPic.Height - 2);
                    e.Graphics.DrawLine(linepen, 0, JOY_middle.Y, pb_JoystickPic.Width, JOY_middle.Y);
                    e.Graphics.DrawLine(linepen, JOY_middle.X, pb_JoystickPic.Height, JOY_middle.X, -pb_JoystickPic.Height);
                    e.Graphics.DrawLine(linepen, JOY_middle, xy);
                    e.Graphics.FillEllipse(linepen.Brush, xy.X - 4, xy.Y - 4, 8, 8);
                }
            }
            else
            {
                if (UITheme == UIThemes.Default)
                {
                    e.Graphics.DrawEllipse(Pens.DarkGray, 1, 1, pb_JoystickPic.Width - 2, pb_JoystickPic.Height - 2);
                    e.Graphics.DrawLine(Pens.DarkGray, 0, JOY_middle.Y, pb_JoystickPic.Width, JOY_middle.Y);
                    e.Graphics.DrawLine(Pens.DarkGray, JOY_middle.X, pb_JoystickPic.Height, JOY_middle.X, -pb_JoystickPic.Height);
                    e.Graphics.DrawLine(linepen, JOY_middle, xy);
                    e.Graphics.FillEllipse(Brushes.DarkGray, xy.X - 4, xy.Y - 4, 8, 8);
                }
                else if (UITheme == UIThemes.Gray)
                {
                    e.Graphics.DrawEllipse(Pens.DarkGray, 1, 1, pb_JoystickPic.Width - 2, pb_JoystickPic.Height - 2);
                    e.Graphics.DrawLine(Pens.DarkGray, 0, JOY_middle.Y, pb_JoystickPic.Width, JOY_middle.Y);
                    e.Graphics.DrawLine(Pens.DarkGray, JOY_middle.X, pb_JoystickPic.Height, JOY_middle.X, -pb_JoystickPic.Height);
                    e.Graphics.DrawLine(linepen, JOY_middle, xy);
                    e.Graphics.FillEllipse(Brushes.DarkGray, xy.X - 4, xy.Y - 4, 8, 8);
                }
                else if (UITheme == UIThemes.Dark)
                {
                    e.Graphics.DrawEllipse(linepen, 1, 1, pb_JoystickPic.Width - 2, pb_JoystickPic.Height - 2);
                    e.Graphics.DrawLine(linepen, 0, JOY_middle.Y, pb_JoystickPic.Width, JOY_middle.Y);
                    e.Graphics.DrawLine(linepen, JOY_middle.X, pb_JoystickPic.Height, JOY_middle.X, -pb_JoystickPic.Height);
                    e.Graphics.DrawLine(linepen, JOY_middle, xy);
                    e.Graphics.FillEllipse(linepen.Brush, xy.X - 4, xy.Y - 4, 8, 8);
                }
            }
            linepen.Dispose();

            if (tsmi_Agressive.Checked)
                SetInput(frame);
        }


        #endregion

        #region Special

        private static void currentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ExceptionForm.mException = e.ExceptionObject as Exception;
            exceptionForm.ShowDialog();
            //MExcept(e.ExceptionObject as Exception, true);
        }
        private static void applicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ExceptionForm.mException = e.Exception;
            exceptionForm.ShowDialog();
            //MExcept(e.Exception, true);
        }

        public static string MExcept(Exception ex, bool mbox)
        {
            if(mbox)
            if (MessageBox.Show("Exception occured and the program will attempt to continue. Do you want to dump relevant data to a crash log?", PROGRAM_NAME + " - Exception", MessageBoxButtons.YesNo, MessageBoxIcon.Error) != DialogResult.Yes) return string.Empty;

            string exStr = "";
            exStr += "message: " + ex.Message + "\n";
            exStr += "stack trace: " + ex.StackTrace + "\n";
            exStr += "file loaded: " + FileLoaded.ToString() + "\n";
            exStr += "mupen running: " + mupenRunning.ToString() + "\n";
            exStr += "loaded invalid file: " + loadedInvalidFile.ToString() + "\n";
            exStr += "usage type: " + UsageType.ToString() + "\n";
            exStr += "file path: " + Path + "\n";
            exStr += "theme: " + UITheme.ToString() + "\n";

            File.WriteAllText(@"exception.log", exStr);

            return @"exception.log";
        }

        #endregion
    }
}

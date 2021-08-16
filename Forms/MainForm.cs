


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


using MupenUtilities.Forms;
using MupenUtilities.Helpers;
using MupenUtils.Forms;
using MupenUtils.Networking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace MupenUtils
{
    public partial class MainForm : Form
    {
        #region Vars

        public const string PROGRAM_VERSION = "1.9";
        public const string PROGRAM_NAME = "Mupen Utilities";

        public const byte UPDATE_CLIENT_OUTDATED = 0;
        public const byte UPDATE_CLIENT_AHEAD = 1;
        public const byte UPDATE_EQUAL = 2;
        public const byte UPDATE_UNKNOWN = 255;

        public const bool RELATIVE = false;
        public const bool ABSOLUTE = true;

        public const int MINIMUM_FRAME = 0;

        public const string MUPEN_VERSION = "Mupen 64 1.0.0";
        public const string MUPEN_SPLIT = "Mupen 64";

        public const uint MAXIMUM_SUGGESTED_FRAMES = uint.MaxValue / 2;

        public Size BIG_SIZE = new Size(1438, 620);
        public static bool standardBitArh;
        // [] means reserved, <^>v is direction
        public static string[] inputStructNames = { "D>", "D<", "Dv", "D^", "S", "Z", "B", "A", "C>", "C<", "Cv", "C^", "R", "L", "1", "2", "X", "Y" };

        public static Thread m64load;
        MoreForm moreForm;//= new MoreForm();
        AdvancedDebugForm debugForm;//= new AdvancedDebugForm();
        TASStudioMoreForm tasStudioForm;//= new TASStudioMoreForm();
        ReplacementForm replacementForm;//= new ReplacementForm();
        MovieTrimmerForm trimmerForm;
        ControllerFlagsForm controllerFlagsForm;//= new ControllerFlagsForm();
        MupenHookForm mupenHookForm;//= new MupenHookForm();
        STForm stForm;//= new STForm();
        static ExceptionForm exceptionForm;//= new ExceptionForm();
        InputStatsForm inputStatisticsForm; //= new InputStatsForm();
        MovieDiagnosticForm movieDiagForm;
        TASStudioFillForm tasStudioFillForm;
        List<Color> ctlColor = new List<Color>();

        public static string Path, SavePath;
        public static bool FileLoaded = false;
        bool ExpandedMenu = false;
        bool Sticky = false;
        bool liveTasStudio = true;
        bool forwardsPlayback = true;
        public static bool readOnly = true;
        public static bool rehookMupen = false;
        public static bool encodeMode = false;

        /*TAS Studio*/
        public static int markedGoToFrame = 0;
        public static int markedSizeCell = 10;
        public static bool forceGoto = false;
        public static bool forceResizeCell = false;
        public static bool forceFill = false;
        public static bool tasStudioAutoScroll = true;
        public static bool reloadTASStudioOnControllerChange = true;
        public static int fillbIndex = 0;
        int[] copied;
        int cellSize = 10;

        bool simpleMode = false;
        public static bool mupenRunning = false;
        public static bool loadedInvalidFile = false;
        public static bool m64loadBusy = false;
        public static bool ignoreIllegalDesync = false;

        // M64 Data 
        public static M64.MovieStruct MovieHeader;
        public static bool[] ControllersEnabled = new bool[4];
        ulong frames = 0; // special
        public CheckBox[] controllerButtonsChk;
        public static List<int> inputListCtl1 = new List<int>();
        public static List<int> inputListCtl2 = new List<int>();
        public static List<int> inputListCtl3 = new List<int>();
        public static List<int> inputListCtl4 = new List<int>();
        public static List<int>[] inputLists = { inputListCtl1, inputListCtl2, inputListCtl3, inputListCtl4 };

        public static List<List<int>> cmbInput = new List<List<int>>();
        public static List<int> cmbLens = new List<int>();
        public static List<string> cmbNames = new List<string>();
        public static int combos = 0;

        public static byte selectedController = 0;

        int lastValue;

        int beginRegion = -1, endRegion = -1;
        bool regionExist;

        public static int frame;
        System.Windows.Forms.Timer stepFrameTimer = new System.Windows.Forms.Timer();


        // Joystick input
        Point JOY_Rel, JOY_Abs, JOY_middle;
        double JOY_Theta;
        bool JOY_mouseDown, JOY_followMouse, JOY_Keyboard;
        bool lockType;
        UpdateNotifier updateNotifier = new UpdateNotifier();
        SmoothingMode JOY_SmoothingMode = SmoothingMode.AntiAlias;

        Point[] originalGroupboxLocation = { new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0,0) };

        public static bool notifiedReupdateControllerFlags;

        public enum UsageTypes
        {
            Any,
            M64,
            ST,
            Mupen,
            Replacement,
            Combo,
            Autodetect,
            Trimmer,
        };
        public static UsageTypes UsageType = UsageTypes.M64;

        public enum UIThemes
        {
            Default,
            Gray,
            Dark,
            Transparent
        };
        public static UIThemes UITheme = UIThemes.Default;


        /* Save Options */
        public static bool saveCompressed = false;
        public static bool saveSamplesOnly = false;

        #region WINAPI extern
        const int PROCESS_QUERY_INFORMATION = 0x0400;
        const int MEM_COMMIT = 0x00001000;
        const int PAGE_READWRITE = 0x04;
        const int PROCESS_WM_READ = 0x0010;
        const int UDS_HORZ = 0x0040;

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);
        [DllImport("kernel32.dll", SetLastError = true)]



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
            stepFrameTimer.Interval = 1000 / 30; // 30 fps
            stepFrameTimer.Stop();

            JOY_middle.X = pb_JoystickPic.Width / 2;
            JOY_middle.Y = pb_JoystickPic.Height / 2;
        }

        void InitUI()
        {
            this.ForAllControls(c =>
            {
                c.TabIndex = 0; c.TabStop = false;
            });
            
            rb_M64sel.Checked = true;
            rb_M64sel.TabStop = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
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
            originalGroupboxLocation[4] = new Point(gp_TASStudio.Size); // cursed

            //tsmi_Themes.Checked = MupenUtilities.Properties.Settings.Default.DarkMode;
            //darkMode = tsmi_Themes.Checked;
            //if(darkMode) SetDarkMode(darkMode);

            UITheme = (UIThemes)MupenUtilities.Properties.Settings.Default.UITheme; // doing this in C would be so painful
            if (UITheme != UIThemes.Default) SetUITheme(UITheme);

            foreach (ToolStripMenuItem _ts in tsmi_Themes.DropDownItems) _ts.Checked = false;
            ToolStripMenuItem ts = tsmi_Themes.DropDownItems[(int)UITheme] as ToolStripMenuItem;
            ts.Checked = true;

            //#if DEBUG
            tsmi_DBG_Crash.MouseDown += (s, e) => throw new Exception("Intentional crash");
            tsmi_DBG_Crash.Text = "Debug - Crash";
            ctx_Input_Debug.Items.Add(tsmi_DBG_Crash);

            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                Type dgvType = dgv_Main.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dgv_Main, true, null);
            }

            //#endif
            if (!BitConverter.IsLittleEndian)
            {
                // incompatible because this program is somewhat endian dependent
                this.Text += " - Unsupported";
                MessageBox.Show("Your system is big-endian and this program might not work properly!");
            }


            cmb_Country.Items.Add("Demo");
            cmb_Country.Items.Add("Beta");
            cmb_Country.Items.Add("USA/Japan");
            cmb_Country.Items.Add("German");
            cmb_Country.Items.Add("USA");
            cmb_Country.Items.Add("France");
            cmb_Country.Items.Add("Italy");
            cmb_Country.Items.Add("Japan");
            cmb_Country.Items.Add("Spain");
            cmb_Country.Items.Add("Australia");
            cmb_Country.Items.Add("Europe");
            cmb_Country.Items.Add("Unknown");

            UpdateReadOnly();

            EnableM64View(false, true, false);


            UsageType = (UsageTypes)MupenUtilities.Properties.Settings.Default.UsageType;
            Debug.WriteLine("loaded usage type " + MupenUtilities.Properties.Settings.Default.UsageType.ToString());
            UpdateVisualsTop(false);

            JOY_Keyboard = MupenUtilities.Properties.Settings.Default.JoystickKeyboard;
            tsmi_JoyKeyboard.Checked = JOY_Keyboard;
                
            reloadTASStudioOnControllerChange = MupenUtilities.Properties.Settings.Default.ReloadTASStudioOnControllerChange;
            tsmi_ReloadTASStudioOnCtlChange.Checked = reloadTASStudioOnControllerChange;

            nud_X.Minimum = -128;
            nud_X.Maximum = 127;

            nud_Y.Minimum = -127;
            nud_Y.Maximum = 128;

            nud_Angle.Maximum = decimal.MaxValue;
            nud_Angle.Minimum = decimal.MinValue;
            nud_Angle.Increment = 1;

            UpdateTASStudioRegionUI();
            //SetWindowLong(nud_X.Handle, -20, UDS_HORZ);

            exceptionForm = new ExceptionForm();


        }

        #endregion

        #region UI
        void MovieDiag()
        {
            if (ignoreIllegalDesync) return;

            if (movieDiagForm == null)
                movieDiagForm = new MovieDiagnosticForm();

            movieDiagForm.ShowDialog();
        }
        void SetTASStudioBig()
        {
            gp_TASStudio.Dock = gp_TASStudio.Dock == DockStyle.Right ? DockStyle.Fill : DockStyle.Right;
            tsmi_TasStudio_Big.Checked = gp_TASStudio.Dock == DockStyle.Fill;
            panel_Input.Visible = gp_TASStudio.Dock != DockStyle.Fill;
        }
        void SetInputsGroupboxBig()
        {
            gp_input.Dock = (gp_input.Dock == DockStyle.Right) ? DockStyle.Fill : DockStyle.Right;
            gp_header.Visible = gp_input.Dock != DockStyle.Fill;
            tsmi_MaximizeInputGp.Checked = gp_input.Dock == DockStyle.Fill;
            gp_TASStudio.Size = gp_input.Dock == DockStyle.Fill ? new Size((int)(originalGroupboxLocation[4].X * 1.5), originalGroupboxLocation[4].Y) : new Size(originalGroupboxLocation[4]);
            tsmi_TasStudio_Big.Enabled = gp_input.Dock != DockStyle.Fill;
        }

        void SetUITheme(UIThemes uitheme)
        {
            Color gp_BackColor =  Color.FromKnownColor(KnownColor.Control);
            Color chk_BackColor = Color.FromKnownColor(KnownColor.Control);
            Color btn_BackColor = Color.FromKnownColor(KnownColor.Control);
            Color txt_BackColor = Color.FromKnownColor(KnownColor.Control);
            Color dgv_BackColor = Color.FromKnownColor(KnownColor.Control);
            Color dgv_GridColor = Color.FromKnownColor(KnownColor.Black);
            Color miscColor = Color.FromKnownColor(KnownColor.Control);
            double alpha = 1;

            if (uitheme == UIThemes.Gray)
            {
                gp_BackColor = Color.Gray;
                chk_BackColor = Color.Gray;
                btn_BackColor = Color.Gray;
                txt_BackColor = Color.Gray;
                miscColor = Color.Gray;
                dgv_BackColor = Color.Gray;
                dgv_GridColor = Color.Black;
            }
            else if (uitheme == UIThemes.Default)
            {

                gp_BackColor =  Color.FromKnownColor(KnownColor.Control);
                chk_BackColor = Color.FromKnownColor(KnownColor.Control);
                btn_BackColor = Color.FromKnownColor(KnownColor.Control);
                txt_BackColor = Color.FromKnownColor(KnownColor.Control);
                miscColor =     Color.FromKnownColor(KnownColor.Control);
                dgv_BackColor = Color.FromKnownColor(KnownColor.Control);
                dgv_GridColor = Color.Black;

            }
            else if (uitheme == UIThemes.Dark)
            {
                gp_BackColor = Color.FromArgb(255, 50, 50, 50);
                chk_BackColor = Color.FromArgb(255, 50, 50, 50);
                btn_BackColor = Color.FromArgb(255, 50, 50, 50);
                txt_BackColor = Color.FromArgb(255, 50, 50, 50);
                miscColor = Color.FromArgb(255, 50, 50, 50);
                dgv_BackColor = Color.FromArgb(255, 50, 50, 50);
                dgv_GridColor = Color.Black;
            }else if(uitheme == UIThemes.Transparent)
            {
                alpha = .8;
            }
            this.Opacity = alpha;
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

            if(uitheme != UIThemes.Transparent)
            pb_JoystickPic.BackColor = Color.Transparent;
            else
                pb_JoystickPic.BackColor = Color.FromKnownColor(KnownColor.Control);

        }
        void ResetTitle()
        {
#if DEBUG
            string bitarh;
            bitarh = IntPtr.Size == 4 ? "32 bit" : "64 bit";
            standardBitArh = IntPtr.Size == 4;
            this.Text = PROGRAM_NAME + " " + PROGRAM_VERSION + " " + bitarh;
            this.Text += " DEBUG ";
#else
            this.Text = PROGRAM_NAME + " " + PROGRAM_VERSION;
#endif
        }

        void ShowTipsForm()
        {
            if (moreForm == null)
                moreForm = new MoreForm();

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
        void ControlText(Control ctrl, string text)
        {
            string temptxt = ctrl.Text;
            ctrl.Text = text;
            new Thread(() =>
            {
                Thread.Sleep(1000);
                ctrl.Text = temptxt;
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


        void EnableM64View(bool flag, bool change, bool force)
        {

            if (m64loadBusy) return;
            if (!force && UsageType != UsageTypes.M64 && UsageType != UsageTypes.Combo && UsageType != UsageTypes.Any) return;


            Size s; 
            ExpandedMenu = flag;
            if (change) FileLoaded = flag;

            
            s = flag ? BIG_SIZE : new Size(100 + btn_Override.Location.X + 20, 150);
            if (!flag) this.WindowState = FormWindowState.Normal;
            btn_FrameBack.Enabled = FileLoaded;
            btn_FrameBack2.Enabled = FileLoaded;
            btn_FrameFront.Enabled = FileLoaded;
            btn_FrameFront2.Enabled = FileLoaded;
            btn_PlayDirection.Enabled = FileLoaded;
            btn_PlayPause.Enabled = FileLoaded;
            tr_MovieScrub.Enabled = FileLoaded;
            txt_Frame.Enabled = FileLoaded;
            this.FormBorderStyle = flag ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle;
            this.MaximizeBox = flag;
            gp_M64.Visible = flag;
            gp_Path.Dock = flag ? DockStyle.Top : DockStyle.Fill;

            SuspendLayout();
            this.Size = s;
            ResumeLayout(true);



        }


        private void EnableM64View_ThreadSafe(bool flag)
        {
            Size s;
            FileLoaded = flag;
            gp_M64.Invoke((MethodInvoker)(() => gp_M64.Visible = flag));
            s = flag ? BIG_SIZE : new Size(100 + btn_Override.Location.X + 20, 150);
            this.Invoke((MethodInvoker)(() => this.FormBorderStyle = flag ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle));
            gp_Path.Invoke((MethodInvoker)(() => gp_Path.Dock = flag ? DockStyle.Top : DockStyle.Fill));
            this.Invoke((MethodInvoker)(() => this.MaximizeBox = flag));
            if (!flag) this.Invoke((MethodInvoker)(() => this.WindowState = FormWindowState.Normal));
            btn_FrameBack.Invoke((MethodInvoker)(() => btn_FrameBack.Enabled = flag));
            btn_FrameBack2.Invoke((MethodInvoker)(() => btn_FrameBack2.Enabled = flag));
            btn_FrameFront.Invoke((MethodInvoker)(() => btn_FrameFront.Enabled = flag));
            btn_FrameFront2.Invoke((MethodInvoker)(() => btn_FrameFront2.Enabled = flag));
            btn_PlayDirection.Invoke((MethodInvoker)(() => btn_PlayDirection.Enabled = flag));
            btn_PlayPause.Invoke((MethodInvoker)(() => btn_PlayPause.Enabled = flag));
            tr_MovieScrub.Invoke((MethodInvoker)(() => tr_MovieScrub.Enabled = flag));
            txt_Frame.Invoke((MethodInvoker)(() => txt_Frame.Enabled = flag));

            this.Invoke((MethodInvoker)(() => this.MinimumSize = flag ? new Size(200, 200) : new Size(1, 1)));
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
            for (int i = 0; i < gp_M64_misc.Controls.Count; i++)
            {
                if (gp_M64_misc.Controls[i] is Label)
                {
                    Label lbl = gp_M64_misc.Controls[i] as Label;
                    lbl.Invoke((MethodInvoker)(() => lbl.ForeColor = Color.Black));
                }
            }
            for (int i = 0; i < gpRom.Controls.Count; i++)
            {
                if (gpRom.Controls[i] is Label)
                {
                    Label lbl = gpRom.Controls[i] as Label;
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
            btn_Override.Enabled = UsageType == UsageTypes.M64 || UsageType == UsageTypes.Combo || UsageType == UsageTypes.Autodetect;
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
                    gp_header.Visible = true;
                    gp_M64.Text = "M64";
                    gp_input.Dock = DockStyle.Right;
                    gp_CMB.Visible = false;
                    frames = 1;
                    SetFrame(0);
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
                case UsageTypes.Trimmer:
                    txt = "Trimmer";
                    btn_LoadLatest.Enabled = false;
                    rb_Trimmer.Checked = true;
                    break;
                case UsageTypes.Combo:
                    txt = "Browse CMB";
                    rb_CMBSel.Checked = true;
                    gp_header.Visible = false;
                    gp_M64.Text = "Combo";
                    gp_CMB.Visible = true;
                    frames = 1;
                    SetFrame(0);
                    break;
                case UsageTypes.Autodetect:
                    txt = "Autodetect";
                    btn_LoadLatest.Enabled = false;
                    // special care
                    rb_M64sel.Checked = rb_MUPSel.Checked = rb_ReplacementSel.Checked = rb_STsel.Checked = false;
                    break;
            }

            if (serialize)
            {
                MupenUtilities.Properties.Settings.Default.UsageType = (byte)UsageType;
                MupenUtilities.Properties.Settings.Default.Save();
                Debug.WriteLine("saved usage type " + MupenUtilities.Properties.Settings.Default.UsageType.ToString());
            }
            if (UsageType != UsageTypes.M64 && UsageType != UsageTypes.Combo && UsageType != UsageTypes.Any && UsageType != UsageTypes.Autodetect)
            {
                EnableM64View(false, false, true);
            }
            btn_PathSel.Text = txt;
        }
        void UpdateTASStudioRegionUI()
        {
            regionExist = (beginRegion >= MINIMUM_FRAME) && (endRegion >= MINIMUM_FRAME) && (endRegion > beginRegion);

            tsmi_RegionReplacement.Enabled = regionExist;
            tsmi_RegToBase64.Enabled = regionExist;
            tsmi_Regfill.Enabled = regionExist;

            dgv_Main.Refresh();
        }
        void TASStudioEndRegion()
        {
            if (tasStudioAutoScroll)
                endRegion = dgv_Main.SelectedRows[0].Index;
            else
                endRegion = dgv_Main.SelectedCells[0].RowIndex;

            UpdateTASStudioRegionUI();
        }
        void TASStudioBeginRegion()
        {
            if (tasStudioAutoScroll)
                beginRegion = dgv_Main.SelectedRows[0].Index;
            else
                beginRegion = dgv_Main.SelectedCells[0].RowIndex;
            UpdateTASStudioRegionUI();
        }

        void UpdateSaveButtonsVisuals()
        {
            
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
                for (int i = 0; i < inputLists[selectedController].Count; i++)
                    br.Write(inputLists[selectedController][i]);

                br.Flush(); br.Close();

                MessageBox.Show(String.Format("Succesfully dumped inputs.\nPath: {1}\nCount: {0}\nController: {2}", inputLists[selectedController].Count, fs.Name, selectedController+1), PROGRAM_NAME);

                fs.Close();
            }
        }
        public void MupenHook()
        {
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



            SYSTEM_INFO sys_info = new SYSTEM_INFO();
            GetSystemInfo(out sys_info);

            IntPtr proc_min_address = sys_info.minimumApplicationAddress;
            IntPtr proc_max_address = sys_info.maximumApplicationAddress;

            long proc_min_address_l = (long)proc_min_address;
            long proc_max_address_l = (long)proc_max_address;

            Process process = Process.GetProcessesByName(procName)[0];

            IntPtr processHandle =
            OpenProcess(PROCESS_QUERY_INFORMATION | PROCESS_WM_READ, false, process.Id);

            MEMORY_BASIC_INFORMATION mem_basic_info = new MEMORY_BASIC_INFORMATION();

            int bytesRead = 0;
            List<byte> procMem = new List<byte>();

            while (proc_min_address_l < proc_max_address_l)
            {
                // 28 = sizeof(MEMORY_BASIC_INFORMATION)
                VirtualQueryEx(processHandle, proc_min_address, out mem_basic_info, 28);

                // if this memory chunk is accessible
                if (mem_basic_info.Protect ==
                PAGE_READWRITE && mem_basic_info.State == MEM_COMMIT)
                {
                    byte[] buffer = new byte[mem_basic_info.RegionSize];

                    // read everything in the buffer above
                    ReadProcessMemory((int)processHandle,
                    mem_basic_info.BaseAddress, buffer, mem_basic_info.RegionSize, ref bytesRead);

                    foreach (byte b in buffer)
                        procMem.Add(b);

                }

                // move to the next memory chunk
                proc_min_address_l += mem_basic_info.RegionSize;
                proc_min_address = new IntPtr(proc_min_address_l);
            }




            string str = ExtensionMethods.CharsToString(Encoding.ASCII.GetChars(procMem.ToArray()));
            string search = MUPEN_SPLIT;
            int searched = 0;

        goSearch:
            if (searched > 4 && searched < 7) // already tried to find new mupen type name... try old one
                search = "Mupen 64 rr";
            if (searched > 8) // overwrite again
                search = "Mupen 64 rr Lua";

            int[] indexes = ExtensionMethods.AllIndexesOf(str, search);
            string finalName = "";

            for (int i1 = 0; i1 < indexes.Length; i1++)
            {
                string a = "";
                for (int i = 0; i < MUPEN_VERSION.Length; i++)
                    a += str[indexes[i1] + i];
                finalName = a;
            }

            if (finalName == "" && searched < 50)
            {
                searched++;
                goto goSearch;
            }

            if (mupenHookForm == null)
                mupenHookForm = new MupenHookForm();

            MupenHookForm.MupenDataStruct mupenData;
            mupenData.CONFIRMED = finalName != "";
            mupenData.MUPEN_NAME = finalName;
            mupenData.PROCESS_NAME = procName;
            MupenHookForm.MupenData = mupenData;
            MupenHookForm.searched = searched;
            mupenHookForm.ShowDialog();
        }

        void ErrorProcessing(string failReason)
        {
            Debug.WriteLine("failed to load m64 " + failReason);

            loadedInvalidFile = true;


            string msg = UsageType.ToString() + " - ";
            MessageBox.Show(msg + " " + failReason, PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);

            txt_Path.Invoke((MethodInvoker)(() => txt_Path.Text = string.Empty));

        }
        void LoadCombo()
        {
            string errReason = "";
            if (!System.IO.Path.GetExtension(Path).Equals(".cmb", StringComparison.InvariantCultureIgnoreCase)) errReason += "Extension invalid. ";
            if (String.IsNullOrEmpty(Path) || String.IsNullOrWhiteSpace(Path) || !ExtensionMethods.ValidPath(Path)) errReason += "Path invalid. ";
            if (!File.Exists(Path)) errReason += "File does not exist. ";
            if (errReason != "")
            {
                ErrorProcessing(errReason);
                return;
            }

            FileStream fs;
            try
            {
                fs = File.Open(Path, FileMode.Open);
            }
            catch
            {
                ErrorProcessing("File already in use");
                return;
            }

            // destroy everything
            inputListCtl1.Clear();
            inputListCtl2.Clear();
            inputListCtl3.Clear();
            inputListCtl4.Clear();
            cbox_Controllers.Items.Clear();
            SetJoystickValue(new Point(0, 0),RELATIVE,false);
            foreach (var l in cmbInput) l.Clear();
            cmbInput.Clear();
            cmbLens.Clear();
            cmbNames.Clear();

            BinaryReader br = new BinaryReader(fs);

            int iter = 0;
            

            while (br.PeekChar() != -1)
            {
                StringBuilder sbCmbName = new StringBuilder();
                cmbInput.Add(new List<int>());

                char buffer = 'd'; // ame tu cosita 
                while (buffer != '\0')
                {
                    if(br.PeekChar() == -1)
                    {
                        // ran through entire file but no NUL terminator...
                        ErrorProcessing("Malformed combo file: No NUL Terminator.");
                        br.Close();
                        fs.Close();
                        return;
                    }
                    buffer = (char)br.ReadByte();
                    sbCmbName.Append(buffer);
                }


                cmbNames.Add(sbCmbName.ToString());

                int cmbLen = br.ReadInt32();

                cmbLens.Add(cmbLen);
                if (cmbLen > br.BaseStream.Length)
                {
                    ErrorProcessing("Malformed combo file: Combo length is longer than file.");
                    br.Close();
                    fs.Close();
                    return;
                }
                for (int i = 0; i < cmbLen; i++)
                    cmbInput[iter].Add(br.ReadInt32());


                // finished loading one combo off to next one
                iter++;
            }
            br.Close();
            fs.Close();

            combos = cmbNames.Count;

            

            tr_MovieScrub.Maximum = cmbLens[selectedController];
            frames = (ulong)cmbLens[selectedController];
            FileLoaded = true;

            txt_CMBSamples.Text = cmbLens[selectedController].ToString();
            txt_ComboName.Text = cmbNames[selectedController].ToString();

            if(cmbInput.Count > 4)
            {
                ErrorProcessing("This combo collection has more than 4 combos inside. Only the first 4 will be considered.");
                cmbInput.Resize(4);
            }

            for (int i = 0; i < cmbInput.Count; i++)
            cbox_Controllers.Items.Add("Combo " + (i + 1));

            for (int i = 0; i < cmbInput.Count; i++)
            {
                inputLists[i] = cmbInput[i];
            }

            PreloadTASStudio();

            EnableM64View_ThreadSafe(true);

            cbox_Controllers.SelectedIndex = 0;
        }

        void WriteCombo(bool saveAs)
        {
            if (!FileLoaded)
            {
                RedControl(btn_PathSel);
                return;
            }

            string tmpPath;
            if (saveAs)
            {
                object[] res = UIHelper.SaveFileDialog("Save As", "Combo Files (*.cmb)|*.cmb|All files (*.*)|*.*");
                if ((bool)res[1])
                    tmpPath = (string)res[0];
                else
                {
                    return;
                }
            }
            else
            {
                tmpPath = System.IO.Path.GetFileNameWithoutExtension(Path) + "-modified";

                while (File.Exists(tmpPath))
                {

                    Debug.WriteLine("File already exists, trying " + tmpPath);
                    tmpPath = tmpPath + "-modified";
                }

                tmpPath = tmpPath + ".cmb";

            }

            SavePath = tmpPath;


            FileStream fs = new FileStream(SavePath, FileMode.Create);
            BinaryWriter br = new BinaryWriter(fs);
            if (saveSamplesOnly)
            {
                for (int i = 0; i < cmbInput.Count; i++)
                {
                    for (int j = 0; j < cmbInput[i].Count; j++)
                    {
                        br.Write(cmbInput[i][j]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < cmbInput.Count; i++)
                {
                    br.Write(cmbNames[i]);
                    br.Write(cmbLens[i]);
                    for (int j = 0; j < cmbInput[i].Count; j++)
                    {
                        br.Write(cmbInput[i][j]);
                    }
                }
            }
            br.Flush();
            br.Close();
            fs.Close();

            if (!saveAs)
                MessageBox.Show("Finished saving combo at " + SavePath + "\n(Relative path from this exe's location)", PROGRAM_NAME);
            else
                MessageBox.Show("Finished saving combo at " + SavePath, PROGRAM_NAME);

        }

        void ReadM64()
        {
            if (m64loadBusy)
            {
                // spawn on main thread to block ui
                this.Invoke((MethodInvoker)(() => MessageBox.Show("A movie is already loading.", PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning)));
                m64loadBusy = false;
                return;
            }
            m64loadBusy = true;
            Debug.WriteLine("Attempting to load m64...");

            loadedInvalidFile = false;
            if (UsageType != UsageTypes.Any)
            {
                string errReason = "";

                if (!System.IO.Path.GetExtension(Path).Equals(".m64", StringComparison.InvariantCultureIgnoreCase))
                    errReason += "Extension invalid. ";
                if (String.IsNullOrEmpty(Path) || String.IsNullOrWhiteSpace(Path) || !ExtensionMethods.ValidPath(Path))
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

            //foreach (Process procarr in Process.GetProcesses())
            //{
            //    if (String.Equals(procarr.ProcessName, "mupen64", StringComparison.InvariantCultureIgnoreCase) || procarr.ProcessName.Contains("mupen64"))
            //    {
            //        mupenRunning = true;
            //        break;
            //    }
            //}

            // Reset
            inputListCtl1.Clear();
            inputListCtl2.Clear();
            inputListCtl3.Clear();
            inputListCtl4.Clear();

            frame = 1;
            lbl_FrameSelected.Invoke((MethodInvoker)(() => lbl_FrameSelected.Text = "Frame " + frame.ToString()));
            txt_Frame.Invoke((MethodInvoker)(() => txt_Frame.Text = frame.ToString()));
            tr_MovieScrub.Invoke((MethodInvoker)(() => tr_MovieScrub.Minimum = MINIMUM_FRAME));
            tr_MovieScrub.Invoke((MethodInvoker)(() => tr_MovieScrub.Value = MINIMUM_FRAME));
            gp_input.Invoke((MethodInvoker)(() => gp_input.Enabled = true));
            Invoke((MethodInvoker)(() => tr_MovieScrub.Enabled = true));
            chk_readonly.Invoke((MethodInvoker)(() => chk_readonly.Checked = readOnly));
            chk_readonly.Invoke((MethodInvoker)(() => chk_readonly.Text = "Read-only"));
            cbox_Controllers.Invoke((MethodInvoker)(() => cbox_Controllers.Items.Clear()));
            ResetLblColors();

            // Read header
            MovieHeader = M64.ParseMovie(Path);
            FileStream fs;
            try { fs = File.Open(Path, FileMode.Open); }
            catch
            {
                ErrorProcessing("File inaccessible.");
                m64loadBusy = false;
                return;
            }
            
            BinaryReader br = new BinaryReader(fs);

            for (int i = 0; i < 4; i++)
                ControllersEnabled[i] = ExtensionMethods.GetBit(MovieHeader.controllerFlags, i);


            // Load inputs
            // We need a buffer to check if end of file reached

            frames = MovieHeader.length_samples;
            uint findx = 0, lenfs = (uint)fs.Length;
            
            // position 1024
            if(MovieHeader.version == 3)
            br.BaseStream.Seek(1024, SeekOrigin.Begin);
            else
            br.BaseStream.Seek(0x200, SeekOrigin.Begin);

            bool loadinputs = true;
            if(frames > MAXIMUM_SUGGESTED_FRAMES)
            {
                loadinputs = MessageBox.Show("Your movie has A LOT of VIs. If this movie was hexed (intended to have this many VIs), press Yes. Otherwise press no to cancel loading inputs.", PROGRAM_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
            }
            if(frames == 0)
            {
                // ???
                loadinputs = false;
            }

            if (loadinputs)
                while (findx <= frames)
                {
                    




                        // this is really gross but its necessary to avoid evil m64s

                        if (ControllersEnabled[0])
                        {
                            if (br.BaseStream.Position + 4 > lenfs)
                                break;
                            inputListCtl1.Add(br.ReadInt32());
                        }
                        if (ControllersEnabled[1])
                        {
                            if (br.BaseStream.Position + 4 > lenfs)
                                break;
                            inputListCtl2.Add(br.ReadInt32());
                        }
                        if (ControllersEnabled[2])
                        {
                            if (br.BaseStream.Position + 4 > lenfs)
                                break;
                            inputListCtl3.Add(br.ReadInt32());
                        }
                        if (ControllersEnabled[3])
                        {
                            if (br.BaseStream.Position + 4 > lenfs)
                                break;
                            inputListCtl4.Add(br.ReadInt32());
                        }
                        findx++;
                    
                }



            fs.Close();
            br.Close(); // destroy handle

            /*Set Controls*/
            SuspendLayout();

            txt_misc_Magic.Invoke((MethodInvoker)(() => txt_misc_Magic.Text = ExtensionMethods.ByteArrayToString(MovieHeader.magic)));
            txt_misc_Version.Invoke((MethodInvoker)(() => txt_misc_Version.Text = MovieHeader.version.ToString()));
            txt_misc_UID.Invoke((MethodInvoker)(() => txt_misc_UID.Text = ExtensionMethods.ByteArrayToString(MovieHeader.uid)));

            txt_VIs.Invoke((MethodInvoker)(() => txt_VIs.Text = MovieHeader.length_vis.ToString()));
            txt_VI_s.Invoke((MethodInvoker)(() => txt_VI_s.Text = MovieHeader.vis_per_second.ToString()));
            txt_RR.Invoke((MethodInvoker)(() => txt_RR.Text = MovieHeader.rerecord_count.ToString()));
            txt_CTRLS.Invoke((MethodInvoker)(() => txt_CTRLS.Text = MovieHeader.num_controllers.ToString()));



            cbox_startType.Invoke((MethodInvoker)(() => cbox_startType.SelectedItem = DataHelper.GetMovieStartupType(MovieHeader.startFlags)));

            txt_videoplugin.Invoke((MethodInvoker)(() => txt_videoplugin.Text = MovieHeader.videoPluginName));
            txt_inputplugin.Invoke((MethodInvoker)(() => txt_inputplugin.Text = MovieHeader.inputPluginName));
            txtbox_Audioplugin.Invoke((MethodInvoker)(() => txtbox_Audioplugin.Text = MovieHeader.soundPluginName));
            txt_Rsp.Invoke((MethodInvoker)(() => txt_Rsp.Text = MovieHeader.rspPluginName));

            txt_Rom.Invoke((MethodInvoker)(() => txt_Rom.Text = MovieHeader.romNom));
            txt_Crc.Invoke((MethodInvoker)(() => txt_Crc.Text = MovieHeader.romCRC.ToString()));

            object[] countryData = DataHelper.GetCountryResource(MovieHeader.romCountry);
            Image countryImage = (Image)countryData[1];

            cmb_Country.Invoke((MethodInvoker)(() => cmb_Country.SelectedIndex = (int)countryData[2]));
            pb_RomCountry.Invoke((MethodInvoker)(() => pb_RomCountry.Size = countryImage.Size));
            pb_RomCountry.Invoke((MethodInvoker)(() => pb_RomCountry.BackgroundImage = countryImage));


            txt_PathName.Invoke((MethodInvoker)(() => txt_PathName.Text = System.IO.Path.GetFileNameWithoutExtension(Path)));
            txt_Author.Invoke((MethodInvoker)(() => txt_Author.Text = MovieHeader.authorInfos));
            txt_Desc.Invoke((MethodInvoker)(() => txt_Desc.Text = MovieHeader.description));

            tr_MovieScrub.Invoke((MethodInvoker)(() => tr_MovieScrub.Minimum = MINIMUM_FRAME));
            tr_MovieScrub.Invoke((MethodInvoker)(() => tr_MovieScrub.Maximum = (int)frames));


            for (int i = 0; i < MovieHeader.num_controllers; i++)
                cbox_Controllers.Invoke((MethodInvoker)(() => cbox_Controllers.Items.Add("Controller " + (i + 1))));

            cbox_Controllers.Invoke((MethodInvoker)(() => cbox_Controllers.SelectedIndex = 0));

            //cbox_Controllers.Invoke((MethodInvoker)(() => cbox_Controllers.SelectedIndex = 0));

            ResumeLayout(true);

            PreloadTASStudio();

            CheckSuspiciousProperties();

            EnableM64View_ThreadSafe(true);


            //ShowStatus_ThreadSafe(M64_LOADED_TEXT);

            m64loadBusy = false;
        }
        void CheckSuspiciousProperties()
        {
            bool triggerDiag = false;

            cmb_Country.Invoke((MethodInvoker)delegate {
                if (cmb_Country.SelectedIndex == 11)
                lbl_RomCountry.Invoke((MethodInvoker)(() => lbl_RomCountry.ForeColor = Color.Red));
                
            });

            if (MovieHeader.startFlags > 4 || MovieHeader.startFlags < 1)
            lb_starttype.Invoke((MethodInvoker)(() => lb_starttype.ForeColor = Color.Red));

            if (MovieHeader.magic != 439629389)
            {
                lbl_misc_Magic.Invoke((MethodInvoker)(() => lbl_misc_Magic.ForeColor = Color.Red));
                triggerDiag = true;
            }
            if (MovieHeader.length_vis == 0 || MovieHeader.vis_per_second == 0)
            {
                lb_VIs.Invoke((MethodInvoker)(() => lb_VIs.ForeColor = Color.Red));
                triggerDiag = true;
            }
            if(MovieHeader.version != 3)
            {
                lbl_misc_version.Invoke((MethodInvoker)(() => lbl_misc_version.ForeColor = Color.Red));
                triggerDiag = true;
            }


            if (triggerDiag)
            {
                MovieDiagnosticForm.warnText = "An automatic movie diagnostic was performed\r\nbecause suspicious properties were detected";
                MovieDiag();
            }



            lbl_ROMCRC.ForeColor = Color.Red;
            foreach (var crc in DataHelper.validCrcs)
            {
                //Debug.WriteLine("Crc32: " + Crc32.ToString("X2"));
                //Debug.WriteLine("crc check: " + crc.ToString("X2"));
                if (MovieHeader.romCRC == crc || MovieHeader.romCRC.ToString("X2") == MovieHeader.romCRC.ToString("X2")) // so much slower but might work 
                {
                    lbl_ROMCRC.ForeColor = Color.Black;
                    break;
                }

            }

        }
        void WriteM64(bool saveAs)
        {
            Debug.WriteLine(String.Format("Begin Save M64: File loaded: {0}", FileLoaded));

            if (!FileLoaded)
            {
                RedControl(btn_PathSel);
                return;
            }
            //if (MovieHeader.num_controllers != 1)
            //{
            //    MessageBox.Show("fuck off", PROGRAM_NAME);
            //    return;
            //}

            string tmpPath;
            if (saveAs)
            {
                object[] res = UIHelper.SaveFileDialog("Save As", "M64 Files (*.m64)|*.m64|All files (*.*)|*.*");
                if ((bool)res[1])
                    tmpPath = (string)res[0];
                else
                {
                    return;
                }
            }
            else
            {
                tmpPath = System.IO.Path.GetFileNameWithoutExtension(Path) + "-modified";

                while (File.Exists(tmpPath))
                {

                    Debug.WriteLine("File already exists, trying " + tmpPath);
                    tmpPath = tmpPath + "-modified";
                }

                tmpPath = tmpPath + ".m64";

            }

            SavePath = tmpPath;
            Debug.WriteLine(tmpPath);

            File.Delete(SavePath);

            FileStream fs = File.Open(SavePath, FileMode.Create);
            BinaryWriter br = new BinaryWriter(fs);
            if (saveSamplesOnly)
            {
                for (int i = 0; i < inputListCtl1.Count/*All should have same amount of inputs... right*/; i++)
                {

                    if (ExtensionMethods.GetBit(MovieHeader.controllerFlags, 0))
                        br.Write(inputListCtl1[i]);
                    if (ExtensionMethods.GetBit(MovieHeader.controllerFlags, 1) && i < inputListCtl2.Count)
                        br.Write(inputListCtl2[i]);
                    if (ExtensionMethods.GetBit(MovieHeader.controllerFlags, 2) && i < inputListCtl3.Count)
                        br.Write(inputListCtl3[i]);
                    if (ExtensionMethods.GetBit(MovieHeader.controllerFlags, 3) && i < inputListCtl4.Count)
                        br.Write(inputListCtl4[i]);
                    
                }
            }
            else
            {
                byte[] zeroar1 = new byte[160]; byte[] zeroar2 = new byte[56];
                byte[] magic = new byte[4] { 0x4D, 0x36, 0x34, 0x1A };
                Array.Clear(zeroar1, 0, zeroar1.Length);
                Array.Clear(zeroar2, 0, zeroar2.Length);

                try
                {
                    byte[] uid = new byte[4];
                    uid = BitConverter.GetBytes(Convert.ToUInt32(txt_misc_UID.Text, 16));
                    Array.Reverse(uid);

                    MovieHeader.uid = BitConverter.ToUInt32(uid,0);
                    MovieHeader.length_vis = UInt32.Parse(txt_VIs.Text);
                    MovieHeader.rerecord_count = UInt32.Parse(txt_RR.Text);
                    MovieHeader.num_controllers = byte.Parse(txt_CTRLS.Text);
                    MovieHeader.romNom = txt_Rom.Text;
                    MovieHeader.videoPluginName = txt_videoplugin.Text;
                    MovieHeader.soundPluginName = txtbox_Audioplugin.Text;
                    MovieHeader.inputPluginName = txt_inputplugin.Text;
                    MovieHeader.rspPluginName = txt_Rsp.Text;
                    MovieHeader.authorInfos = txt_Author.Text;
                    MovieHeader.description = txt_Desc.Text;
                    MovieHeader.vis_per_second = byte.Parse(txt_VI_s.Text);
                    MovieHeader.romCRC = uint.Parse(txt_Crc.Text);
                }catch(FormatException e)
                {
                    // aaahh idiot user you dumbass
                    MessageBox.Show("Error parsing a textbox\'s text. Please double check that you wrote valid text in each modified property. The saving process will attempt to continue", PROGRAM_NAME);
                }

                // lol cringe
                br.Write(magic); // Int32 - Magic (4D36341A)
                br.Write(0x3); // UInt32 - Version number (3)
                br.Write(MovieHeader.uid); // UInt32 - UID
                br.Write((UInt32)MovieHeader.length_vis); // UInt32 - VIs
                br.Write((UInt32)MovieHeader.rerecord_count); // UInt32 - RRs
                br.Write(MovieHeader.vis_per_second); // Byte - VI/s
                br.Write(MovieHeader.num_controllers); // Byte - Controllers
                br.Write((Int16)0); // 2 Bytes - RESERVED
                br.Write(MovieHeader.length_samples); // UInt32 - Input Samples

                br.Write((UInt16)DataHelper.GetMovieStartupTypeIndex(cbox_startType.SelectedItem.ToString())); // UInt16 - Movie start type
                br.Write((Int16)0); // 2 bytes - RESERVED
                br.Write(MovieHeader.controllerFlags); // UInt32 - Controller Flags
                br.Write(zeroar1, 0, zeroar1.Length); // 160 bytes - RESERVED
                byte[] romname;
                romname = ASCIIEncoding.ASCII.GetBytes(MovieHeader.romNom);
                Array.Resize(ref romname, 32);
                br.Write(romname, 0, 32);
                br.Write(MovieHeader.romCRC);
                br.Write(MovieHeader.romCountry);
                br.Write(zeroar2, 0, zeroar2.Length); // 56 bytes - RESERVED


                byte[] gfx = new byte[64];
                byte[] audio = new byte[64];
                byte[] input = new byte[64];
                byte[] rsp = new byte[64];
                byte[] author = new byte[222];
                byte[] desc = new byte[256];

                gfx = Encoding.ASCII.GetBytes(MovieHeader.videoPluginName);
                audio = Encoding.ASCII.GetBytes(MovieHeader.soundPluginName);
                input = Encoding.ASCII.GetBytes(MovieHeader.inputPluginName);
                rsp = Encoding.ASCII.GetBytes(MovieHeader.rspPluginName);
                author = Encoding.UTF8.GetBytes(MovieHeader.authorInfos);
                desc = Encoding.UTF8.GetBytes(MovieHeader.description);

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
                    if (ExtensionMethods.GetBit(MovieHeader.controllerFlags, 0))
                        br.Write(inputListCtl1[i]);
                    if (ExtensionMethods.GetBit(MovieHeader.controllerFlags, 1) && i < inputListCtl2.Count)
                        br.Write(inputListCtl2[i]);
                    if (ExtensionMethods.GetBit(MovieHeader.controllerFlags, 2) && i < inputListCtl3.Count)
                        br.Write(inputListCtl3[i]);
                    if (ExtensionMethods.GetBit(MovieHeader.controllerFlags, 3) && i < inputListCtl4.Count)
                        br.Write(inputListCtl4[i]);
                }
            }

            br.Flush();
            br.Close();
            fs.Close();
            
            if(!saveAs)
            MessageBox.Show("Finished saving M64 at " + SavePath + "\n(Relative path from this exe's location)", PROGRAM_NAME );
            else
                MessageBox.Show("Finished saving M64 at " + SavePath, PROGRAM_NAME);

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

            byte[] decompressed;

            decompressed = ExtensionMethods.Decompress(File.ReadAllBytes(Path));

            if (decompressed.Length < 10485760)
            {
                ErrorProcessing("Too small.");
                return;
            }


            BinaryReader br = new BinaryReader(new MemoryStream(decompressed));

            //defFs.Read(STForm.savestateRDRAM, 0, (int)deStream.BaseStream.Length);
            br.BaseStream.Seek(0x1B0, SeekOrigin.Begin); // have fun figuring this out without docs
            STForm.savestateRDRAM = br.ReadBytes(8388608);

            br.BaseStream.Seek(0, SeekOrigin.Begin);
            STForm.savestate = decompressed;

            br.Close();

            string tmpPath = System.IO.Path.GetFileNameWithoutExtension(Path) + "-modified";
            while (File.Exists(tmpPath))
            {
                Debug.WriteLine("File already exists, trying " + tmpPath);
                tmpPath = tmpPath + "-modified";
            }
            tmpPath = tmpPath + ".st";
            STForm.Path = tmpPath;

            if (stForm == null) stForm = new STForm();

            stForm.ShowDialog(); // main ui thread here pauses because of modal popup (execution does not continue)

            //MessageBox.Show("Savestate has been decompressed to " + newFs, PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        #endregion

        #region Input & Frames

        void PreloadTASStudio()
        {
            /*
             * TAS Studio
             * ----------
             * This is the heaviest method in the entire program and gets called after m64 load.
             * It loads input data into the datagridview
             * 
             */

            // nuke all old data
            dgv_Main.Invoke((MethodInvoker)(() => dgv_Main.Rows.Clear()));
            dgv_Main.Invoke((MethodInvoker)(() => dgv_Main.Columns.Clear()));
            dgv_Main.Invoke((MethodInvoker)(() => dgv_Main.ClearSelection()));
            dgv_Main.Invoke((MethodInvoker)(() => dgv_Main.ColumnCount = 18));
            dgv_Main.Invoke((MethodInvoker)(() => dgv_Main.ColumnHeadersVisible = true));
            dgv_Main.Invoke((MethodInvoker)(() => dgv_Main.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing));
            dgv_Main.Invoke((MethodInvoker)(() => dgv_Main.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None));
            dgv_Main.Invoke((MethodInvoker)(() => dgv_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None));
            dgv_Main.Invoke((MethodInvoker)(() => dgv_Main.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing));
            dgv_Main.Invoke((MethodInvoker)(() => dgv_Main.Refresh()));

            // resize header sizes back to original
            for (byte i = 0; i < inputStructNames.Length; i++)
            {
                dgv_Main.Invoke((MethodInvoker)(() => dgv_Main.Columns[i].Name = inputStructNames[i]));
                dgv_Main.Invoke((MethodInvoker)(() => dgv_Main.Columns[i].Width = 40));
                dgv_Main.Invoke((MethodInvoker)(() => dgv_Main.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable));
                dgv_Main.Invoke((MethodInvoker)(() => dgv_Main.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None));
            }
            gp_TASStudio.Invoke((MethodInvoker)(() => gp_TASStudio.Text = "TAS Studio - Loading " + inputLists[selectedController].Count + " samples"));
            txt_Path.Invoke((MethodInvoker)(() => txt_Path.Text = "Loading... Please wait"));

            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            string[] buffer = new string[inputStructNames.Length];

            ((ISupportInitialize)dgv_Main).BeginInit();


            for (int y = 0; y < inputLists[selectedController].Count - 1/*???*/; y++)
            {
                // for each frame
                rows.Add(new DataGridViewRow());

                // this can be done in a nested loop, but somehow this is faster
                // todo: replace this to only one condition to minimize branching (here we are doing if else for each button, meaning 30 branches)
                // e.g:
                // if(bit(inputlist[y])
                // buffer[0] = names[0];
                buffer[0] = (inputLists[selectedController][y] & (int)Math.Pow(2, 0)) != 0 ? inputStructNames[0] : "";
                buffer[1] = (inputLists[selectedController][y] & (int)Math.Pow(2, 1)) != 0 ? inputStructNames[1] : "";
                buffer[2] = (inputLists[selectedController][y] & (int)Math.Pow(2, 2)) != 0 ? inputStructNames[2] : "";
                buffer[3] = (inputLists[selectedController][y] & (int)Math.Pow(2, 3)) != 0 ? inputStructNames[3] : "";
                buffer[4] = (inputLists[selectedController][y] & (int)Math.Pow(2, 4)) != 0 ? inputStructNames[4] : "";
                buffer[5] = (inputLists[selectedController][y] & (int)Math.Pow(2, 5)) != 0 ? inputStructNames[5] : "";
                buffer[6] = (inputLists[selectedController][y] & (int)Math.Pow(2, 6)) != 0 ? inputStructNames[6] : "";
                buffer[7] = (inputLists[selectedController][y] & (int)Math.Pow(2, 7)) != 0 ? inputStructNames[7] : "";
                buffer[8] = (inputLists[selectedController][y] & (int)Math.Pow(2, 8)) != 0 ? inputStructNames[8] : "";
                buffer[9] = (inputLists[selectedController][y] & (int)Math.Pow(2, 9)) != 0 ? inputStructNames[9] : "";
                buffer[10] = (inputLists[selectedController][y] & (int)Math.Pow(2, 10)) != 0 ? inputStructNames[10] : "";
                buffer[11] = (inputLists[selectedController][y] & (int)Math.Pow(2, 11)) != 0 ? inputStructNames[11] : "";
                buffer[12] = (inputLists[selectedController][y] & (int)Math.Pow(2, 12)) != 0 ? inputStructNames[12] : "";
                buffer[13] = (inputLists[selectedController][y] & (int)Math.Pow(2, 13)) != 0 ? inputStructNames[13] : "";
                buffer[14] = (inputLists[selectedController][y] & (int)Math.Pow(2, 14)) != 0 ? inputStructNames[14] : "";
                buffer[15] = (inputLists[selectedController][y] & (int)Math.Pow(2, 15)) != 0 ? inputStructNames[15] : "";

                buffer[16] = ExtensionMethods.GetSByte(inputLists[selectedController][y], 2).ToString();
                buffer[17] = ExtensionMethods.GetSByte(inputLists[selectedController][y], 3).ToString();

                rows[rows.Count - 1].CreateCells(dgv_Main, buffer);

            }

            dgv_Main.Invoke((MethodInvoker)(() => dgv_Main.Rows.AddRange(rows.ToArray())));
            txt_Path.Invoke((MethodInvoker)(() => txt_Path.Text = Path));
            ((ISupportInitialize)dgv_Main).EndInit();
            gp_TASStudio.Invoke((MethodInvoker)(() => gp_TASStudio.Text = "TAS Studio"));
        }
        void SetInputPure(int frameTarget, int value)
        {
            if (!FileLoaded) return;
            if (m64loadBusy) return;

            inputLists[selectedController][frameTarget] /*|*/= value;


            GetInput(inputLists[selectedController][frameTarget], false, frameTarget);


            UpdateTASStudio(frameTarget);

        }
        unsafe void SetInput(int frame)
        {
            if (!FileLoaded) return;
            if (m64loadBusy) return;

            int value;
            try
            {
                int pos = frame;

                // normalize
                if (pos > inputLists[selectedController].Count) pos = inputLists[selectedController].Count - 1;
                if (pos < 0) pos = 0;

                value = inputLists[selectedController][pos];



            } // get value at that frame. If this fails then m64 is corrupted 
            catch
            {
                if (UsageType != UsageTypes.M64 || ignoreIllegalDesync) return;

                EnableM64View(false, false, false);
                stepFrameTimer.Enabled = false;
                //MessageBox.Show("Failed to find input value at frame " + frame + ". The application might behave unexpectedly until a restart.\nThis can be caused by a corrupted m64 or loading movies in quick succession", PROGRAM_NAME + " - Fatal desync");
                MovieDiagnosticForm.warnText = "An automatic movie diagnostic was performed\r\nbecause of a desync";
                MovieDiag();
                return;

            }

            for (int i = 0; i < controllerButtonsChk.Length; i++)
            {
                ExtensionMethods.SetBit(ref value, controllerButtonsChk[i].Checked, i);
            }
            ExtensionMethods.SetByte(&value, (byte)JOY_Rel.X, 2);
            ExtensionMethods.SetByte(&value, (byte)-JOY_Rel.Y, 3);
            lastValue = value;
            inputLists[selectedController][frame] = value;

            // update tas studio
            UpdateTASStudio(frame);

        }
        void UpdateTASStudio(int frameTarget)
        {

            //if (UsageType == UsageTypes.Combo) return;
            if (liveTasStudio)
            {
                for (int i = 0; i < inputStructNames.Length; i++)
                {
                    string cellValue = "";

                    if (i < 16)
                    {
                        if (ExtensionMethods.GetBit(inputLists[selectedController][frameTarget], i))
                            cellValue = inputStructNames[i];
                    }
                    else
                    {

                        byte[] data = BitConverter.GetBytes(inputLists[selectedController][frameTarget]);

                        if (i == 16)
                            cellValue = ((sbyte)data[2]).ToString();
                        else if (i == 17)
                            cellValue = nud_Y.Value.ToString();
                    }

                    dgv_Main.Rows[frameTarget].Cells[i].Value = cellValue;
                }
            }
        }
        void GetInput(int value, bool setinput, int targetFrame)
        {
            for (int i = 0; i < controllerButtonsChk.Length; i++)
            {
                controllerButtonsChk[i].Checked = (value & (int)Math.Pow(2, i)) != 0;
            }
            byte[] data = BitConverter.GetBytes(value);
            sbyte joystickX = (sbyte)data[2];
            sbyte joystickY = (sbyte)-data[3]; // flip

            nud_X.Value = ExtensionMethods.Clamp(joystickX, -128, 127);
            nud_Y.Value = ExtensionMethods.Clamp(joystickY, -127, 128);

            SetJoystickValue(new Point(joystickX, joystickY), RELATIVE, false);

            if (setinput)
                SetInput(targetFrame);

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
            if (frame > (int)frames || frame < MINIMUM_FRAME)
            {
                {
                    if (frame > (int)frames)
                        frame = (int)frames;
                    else if (frame < MINIMUM_FRAME)
                        frame = MINIMUM_FRAME;
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
            GetInput(inputLists[selectedController][(int)frame], true, frame);
            UpdateFrameControlUI();
        }
        #endregion

        #region Event Handlers

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (UsageType != UsageTypes.M64 && UsageType != UsageTypes.ST && UsageType != UsageTypes.Combo)
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
                MessageBox.Show("You are attempting to load more than one file, picking first one from list...", PROGRAM_NAME);
            }

            if (!ExtensionMethods.ValidPath(file))
            {
                Debug.WriteLine("invalid path"); return;
            }
            Path = txt_Path.Text = file;
            MupenUtilities.Properties.Settings.Default.LastPath = Path;
            MupenUtilities.Properties.Settings.Default.Save();

            if (UsageType == UsageTypes.M64 || UsageType == UsageTypes.Any)
            {
                m64load = new Thread(() => ReadM64());
                m64load.Start();
            }
            else if (UsageType == UsageTypes.ST)
            {
                LoadST();
            }
            else if (UsageType == UsageTypes.Combo)
            {
                LoadCombo();
            }
        }

        private void btn_Input_Debug_Click(object sender, EventArgs e)
        {
            ctx_Input_Debug.Show(MousePosition);
        }

        private void dgv_Main_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ctx_TasStudio.Show(MousePosition);
        }
        private void dgv_Main_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys != Keys.Control) return;

            cellSize += Math.Sign(e.Delta) * 5;

            for (int i = 0; i < dgv_Main.Columns.Count; i++)
                dgv_Main.Columns[i].Width = cellSize;

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
            if (debugForm == null)
                debugForm = new AdvancedDebugForm();
            debugForm.ShowDialog();
        }
        private void dgv_Main_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgv_Main.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }

            if(beginRegion != -1 && e.RowIndex == beginRegion)
                using (SolidBrush b = new SolidBrush(Color.FromArgb(128, Color.Blue)))
                    e.Graphics.FillRectangle(b, new Rectangle(e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 6, 10, 10));
            
            if (endRegion != -1 && e.RowIndex == endRegion)
                using (SolidBrush b = new SolidBrush(Color.FromArgb(128, Color.Red)))
                    e.Graphics.FillRectangle(b, new Rectangle(e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 6, 10, 10));
        }
        private void dgv_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.H && e.Modifiers == Keys.Control)
            {

                if (tasStudioForm == null)
                    tasStudioForm = new TASStudioMoreForm();
                tasStudioForm.ShowDialog();
            }
            if(e.KeyCode == Keys.F5)
            {
                TASStudioBeginRegion();
            }
            if(e.KeyCode == Keys.F6)
            {
                TASStudioEndRegion();
            }
            
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                if (tasStudioAutoScroll)
                {
                    MessageBox.Show("Please disable Move Mode for copy/paste functionality.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ctrl + c
                // copy selection into buffer

                int selectedRows = 0;

                for (int i = 1; i < dgv_Main.SelectedCells.Count; i++)
                    if (dgv_Main.SelectedCells[i].RowIndex != dgv_Main.SelectedCells[i - 1].RowIndex) selectedRows++;

                copied = new int[selectedRows];
                for (int i = 0; i < selectedRows; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)dgv_Main.Rows[dgv_Main.SelectedCells[i].RowIndex];
                    copied[i] = inputLists[selectedController][row.Index];
                }


            }
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                if (tasStudioAutoScroll)
                {
                    MessageBox.Show("Please disable Move Mode for copy/paste functionality.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Debug.WriteLine("paste tasstudio {0}", copied.Length);

                for (int i = dgv_Main.SelectedCells[0].RowIndex; i < copied.Length; i++)
                {
                    inputLists[selectedController][i] = copied[i];
                    for (int j = 0; j < inputStructNames.Length - 2; j++)
                    {
                        dgv_Main.Rows[i].Cells[j].Value = ExtensionMethods.GetBit(copied[i], j) ? inputStructNames[j].ToString() : "";
                    }
                    //UpdateTASStudio(dgv_Main.SelectedCells[i].RowIndex);
                    Debug.WriteLine("pasting value {0} at {1}", copied[i], i);
                }
                

                

                //ControlText(dgv_Main, String.Format("{0} - In-place paste {1} frames", "TAS Studio", copied.Length));
            }
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
                MovieHeader.num_controllers = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (ExtensionMethods.GetBit(MovieHeader.controllerFlags, i))
                        MovieHeader.num_controllers++;
                }
                txt_CTRLS.Text = MovieHeader.num_controllers.ToString();

                notifiedReupdateControllerFlags = false;
            }
            if (forceFill)
            {
                if (!regionExist) return;
                for (int i = beginRegion; i < endRegion; i++)
                {
                    int tmp = inputLists[selectedController][i];
                    ExtensionMethods.SetBit(ref tmp, true, fillbIndex);
                    inputLists[selectedController][i] = tmp;
                    UpdateTASStudio(i);
                }
                forceFill = false;
            }
        }

        private void utilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tasStudioForm == null)
                tasStudioForm = new TASStudioMoreForm();
            tasStudioForm.ShowDialog();
        }

        private void txt_GenericNumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        void AutodetectLoad()
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
            else if (ext.Equals(".cmb", StringComparison.InvariantCultureIgnoreCase))
            {
                LoadCombo();
            }
            else if (ext.Equals(".exe", StringComparison.InvariantCultureIgnoreCase))
            {
                if (System.IO.Path.GetFileNameWithoutExtension(Path).Contains("mupen"))
                {
                    var proc = Process.Start(Path);
                    while (string.IsNullOrEmpty(proc.MainWindowTitle))
                    {
                        System.Threading.Thread.Sleep(100);
                        proc.Refresh();
                    }

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
                ErrorProcessing("Type " + ext + " could not be resolved to any usage type");
                return;
            }
        }
        private void btn_PathSel_MouseClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("browse...");

            // for these:
            // special care - skip continuing to openfiledialog
            if (UsageType == UsageTypes.Mupen)
            {
                MupenHook();
                return;
            }
            else if (UsageType == UsageTypes.Replacement)
            {
                if (replacementForm == null)
                    replacementForm = new ReplacementForm();

                ReplacementForm.useExternalData = false;

                replacementForm.ShowDialog();
                return;
            }
            else if (UsageType == UsageTypes.Trimmer)
            {
                if (trimmerForm == null)
                    trimmerForm = new MovieTrimmerForm();

                trimmerForm.ShowDialog();
                return;
            }

            object[] result = UIHelper.ShowFileDialog(UsageType);
            if ((string)result[0] == "FAIL" || (bool)result[1] == false)
            {
                Debug.WriteLine("failed dialog");
                return;
            }

            txt_Path.Text = (string)result[0];
            Path = (string)result[0];


            MupenUtilities.Properties.Settings.Default.LastPath = Path;
            MupenUtilities.Properties.Settings.Default.Save();

            if (UsageType == UsageTypes.M64 || UsageType == UsageTypes.Any)
            {
                m64load = new Thread(() => ReadM64());
                m64load.Start();
            }
            else if (UsageType == UsageTypes.ST)
                LoadST();
            else if (UsageType == UsageTypes.Combo)
                LoadCombo();
            else if (UsageType == UsageTypes.Autodetect)
            {
                AutodetectLoad();
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
            else if (UsageType == UsageTypes.Combo) LoadCombo();
        }
        private void rb_M64sel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                UsageType = UsageTypes.Autodetect;
            else if (e.Button == MouseButtons.Left)
                UsageType = UsageTypes.M64;
            UpdateVisualsTop(true);
        }
        private void rb_STsel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                UsageType = UsageTypes.Autodetect;
            else if (e.Button == MouseButtons.Left)
                UsageType = UsageTypes.ST;
            UpdateVisualsTop(true);
        }

        private void rb_MUPsel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                UsageType = UsageTypes.Autodetect;
            else if (e.Button == MouseButtons.Left)
                UsageType = UsageTypes.Mupen;
            UpdateVisualsTop(true);
        }
        private void rb_ReplacementSel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                UsageType = UsageTypes.Autodetect;
            else if (e.Button == MouseButtons.Left)
                UsageType = UsageTypes.Replacement;
            UpdateVisualsTop(true);
        }

        private void rb_CMBSel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) UsageType = UsageTypes.Autodetect;
            else if (e.Button == MouseButtons.Left)
                UsageType = UsageTypes.Combo;

            UpdateVisualsTop(true);
        }

        private void rb_Trimmer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) UsageType = UsageTypes.Autodetect;
            else if (e.Button == MouseButtons.Left)
                UsageType = UsageTypes.Trimmer;

            UpdateVisualsTop(true);
        }
        private void btn_Override_MouseDown(object sender, MouseEventArgs e)
        {
            EnableM64View(!ExpandedMenu, false, false);
            btn_Override.Text = ExpandedMenu ? "Collapse" : "Expand";
        }
        private void cmb_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            ushort ccode = DataHelper.GetCountryCodeFromComboIndex(cmb_Country.SelectedIndex);
            object[] data = DataHelper.GetCountryResource(ccode);
            pb_RomCountry.BackgroundImage = (Image)data[1];
            cmb_Country.SelectedIndex = (int)data[2];
            MovieHeader.romCountry = ccode;
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

            int index = frame;
            if (index < dgv_Main.Rows.Count)
            {
                dgv_Main.CurrentCell = dgv_Main.Rows[index].Cells[0];
                dgv_Main.Rows[index].Selected = true;
            }

            if(index <= tr_MovieScrub.Maximum && index >= tr_MovieScrub.Minimum) tr_MovieScrub.Value = frame;
            
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
            if (this.ActiveControl == pb_JoystickPic && FileLoaded && e.KeyCode == Keys.Space)
            {
                TogglePlay();
                //this.ActiveControl = null;
            }
            if (!readOnly && JOY_Keyboard)
            {
                if (this.ActiveControl == pb_JoystickPic) return;
                Debug.Write("key\n");
                Point target = new Point(0, 0);

                //cringe 
                if (Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.Up))
                {
                    target = new Point(0, -127);

                }
                if (Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left))
                {
                    target = new Point(-128, 0);
                }
                if (Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.Down))
                {
                    target = new Point(0, 127);
                }
                if (Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right))
                {
                    target = new Point(127, 0);
                }


                SetJoystickValue(target, false, false);


            }
            if (e.KeyCode == Keys.F1)
            {
                //MessageBox.Show("Encoding mode is now " + (encodeMode ? "enabled" : "disabled") + "\nPress again to toggle");
                
                // encoding mode
                encodeMode ^= true;
                btn_Input_Debug.Visible =
                    btn_PlayDirection.Visible =
                    btn_PlayPause.Visible =
                    btn_FrameBack.Visible =
                    btn_FrameBack2.Visible =
                    btn_FrameFront.Visible =
                    btn_FrameFront2.Visible =
                    tr_MovieScrub.Visible =
                    cbox_Controllers.Visible =
                    txt_Frame.Visible = !encodeMode;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (!readOnly && JOY_Keyboard)
            {
                if (Keyboard.IsKeyUp(Key.D)
                    || Keyboard.IsKeyUp(Key.Right)
                    || Keyboard.IsKeyUp(Key.S)
                    || Keyboard.IsKeyUp(Key.Down)
                    || Keyboard.IsKeyUp(Key.A)
                    || Keyboard.IsKeyUp(Key.Left)
                    || Keyboard.IsKeyUp(Key.W)
                    || Keyboard.IsKeyUp(Key.Up))
                    SetJoystickValue(new Point(0, 0), false, false);
            }
        }

        private void tsmi_JoyKeyboard_Click(object sender, EventArgs e)
        {
            JOY_Keyboard ^= true;
            tsmi_JoyKeyboard.Checked = JOY_Keyboard;
            MupenUtilities.Properties.Settings.Default.JoystickKeyboard = JOY_Keyboard;
            MupenUtilities.Properties.Settings.Default.Save();
        }

        void TogglePlay()
        {
            stepFrameTimer.Enabled = !stepFrameTimer.Enabled;
            btn_PlayPause.Text = stepFrameTimer.Enabled ? "| |" : forwardsPlayback ? "|>" : "<|";
        }
        private void btn_PlayPause_Click(object sender, EventArgs e)
        {
            // Toggle timer
            TogglePlay();
        }
        private void btn_PlayDirection_Click(object sender, EventArgs e)
        {
            forwardsPlayback = !forwardsPlayback;
            btn_PlayDirection.Text = forwardsPlayback ? ">" : "<";
            btn_PlayPause.Text = stepFrameTimer.Enabled ? "| |" : forwardsPlayback ? "|>" : "<|";
        }
        private void tsmi_TasStudio_Big_Click(object sender, EventArgs e)
        {
            SetTASStudioBig();
        }

        private void tsmi_AAJoystick_Click(object sender, EventArgs e)
        {
            JOY_SmoothingMode = JOY_SmoothingMode == SmoothingMode.AntiAlias ? SmoothingMode.None : SmoothingMode.AntiAlias;
            tsmi_AAJoystick.Checked = JOY_SmoothingMode == SmoothingMode.AntiAlias;
            pb_JoystickPic.Invalidate();
        }


        private void tsmi_SimpleMode_Click(object sender, EventArgs e)
        {
            simpleMode = !simpleMode;
            tsmi_SimpleMode.Checked = simpleMode;
            nud_X.Visible
                = nud_Y.Visible
                = nud_Angle.Visible 
                = lbl_Deg.Visible
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

            tsmi_Input_Debug_DumpData.Visible =
            tsmi_Input_SetInput.Visible =
            tsmi_Input_Sticky.Visible = !simpleMode;


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
        void JoystickFromNudControl()
        {
            //if (ExtensionMethods.ValidStringSByte(txt_joyX.Text) && ExtensionMethods.ValidStringSByte(txt_joyY.Text))
            
            SetJoystickValue(new Point((int)nud_X.Value, (int)nud_Y.Value), RELATIVE, false);

        }

        private void nud_X_KeyDown(object sender, KeyEventArgs e)
        {
            JoystickFromNudControl();
            if (e.KeyCode == Keys.Escape) this.ActiveControl = null;
        }
        private void nud_X_ValueChanged(object sender, EventArgs e)
        {
            //Debug.WriteLine("ok");
            //JoystickFromNudControl();

            // this event is dogshit
        }
        private void nud_X_MouseUp(object sender, MouseEventArgs e)
        {
            JoystickFromNudControl();
        }
        private void btn_Savem64_MouseClick(object sender, MouseEventArgs e)
        {
            if (UsageType == UsageTypes.M64)
                WriteM64(false);
            else if (UsageType == UsageTypes.Combo)
                WriteCombo(false);
        }
        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
            if (UsageType == UsageTypes.M64)
                WriteM64(true);
            else if (UsageType == UsageTypes.Combo)
                WriteCombo(true);
        }
        private void btn_Reload_Click(object sender, EventArgs e)
        {
            if (!FileLoaded) return;
            AutodetectLoad();
        }
        private void btn_Tips_Click(object sender, EventArgs e) => ShowTipsForm();

        void UpdateReadOnly()
        {
            readOnly = chk_readonly.Checked;
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
            txt_Crc.ReadOnly = readOnly;
            cbox_startType.Enabled = !readOnly;
            foreach (Control ctl in gp_Plugins.Controls)
            {
                if (ctl is TextBox)
                {
                    TextBox txt = ctl as TextBox;
                    txt.ReadOnly = readOnly;
                }
            }
            foreach (Control ctl in gp_CMB.Controls)
            {
                if (ctl is TextBox)
                {
                    TextBox txt = ctl as TextBox;
                    txt.ReadOnly = readOnly;
                }
            }

            // Joystick buttons + Joystick
            pb_JoystickPic.Enabled = !readOnly;
            nud_X.Enabled = !readOnly;
            nud_Y.Enabled = !readOnly;
            nud_Angle.Enabled = !readOnly;
            foreach (Control ctl in panel_Input.Controls)
            {
                if (ctl is CheckBox)
                {
                    CheckBox chk = ctl as CheckBox;
                    chk.Enabled = !readOnly;
                }
            }
            cmb_Country.Enabled = !readOnly;
            dgv_Main.ReadOnly = true;

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

        }

        private void tsmi_Agressive_Click(object sender, EventArgs e)
        {
            tsmi_Agressive.Checked ^= true;
        }
        
        private void tsmi_MovieDiagnostic_Click(object sender, EventArgs e)
        {
            MovieDiagnosticForm.warnText = "A manual movie diagnostic has been requested";
            MovieDiag();
        }
        private void cbox_Controllers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            SetFrame(MINIMUM_FRAME);
            UpdateFrameControlUI();
            if (UsageType == UsageTypes.M64)
            {
                if (cbox_Controllers.SelectedIndex + 1 > MovieHeader.num_controllers)
                {
                    selectedController = 0;
                    goto update;
                }
            }
            selectedController = Convert.ToByte(cbox_Controllers.SelectedIndex);

            update:
            if (reloadTASStudioOnControllerChange)
                PreloadTASStudio();
            GetInput(inputLists[selectedController][frame], true, frame);
            cbox_Controllers.SelectedIndex = selectedController; // wtf how does this work
            if(UsageType == UsageTypes.Combo)
            {
                txt_CMBSamples.Text = cmbLens[selectedController].ToString();
                txt_ComboName.Text = cmbNames[selectedController].ToString();
            }
            
        }

        private void btn_CtlFlags_Click(object sender, EventArgs e)
        {
            if (controllerFlagsForm == null)
                controllerFlagsForm = new ControllerFlagsForm();
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
        private void btn_VIMAX_Click(object sender, EventArgs e)
        {
            MovieHeader.length_vis = UInt32.MaxValue;
            txt_VIs.Text = MovieHeader.length_vis.ToString();
        }

        private void pb_RomCountry_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The movie\'s country is " + (string)DataHelper.GetCountryResource(MovieHeader.romCountry)[0] + ", with the country code of " + MovieHeader.romCountry + " (Hex: " + ExtensionMethods.ByteArrayToString(BitConverter.GetBytes(MovieHeader.romCountry)) + ")", this.Text);
        }

        private void themeSelectedClick(object sender, MouseEventArgs e)
        {
            ToolStripMenuItem btn = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem ts in tsmi_Themes.DropDownItems) ts.Checked = false;

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

            if (inputStatisticsForm == null)
                inputStatisticsForm = new InputStatsForm();
            inputStatisticsForm.ShowDialog();
        }

        private void dgv_Main_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (!tasStudioAutoScroll) return;
            //
            //if (e.RowIndex >= MINIMUM_FRAME && e.RowIndex < inputLists[selectedController].Count)
            //SetFrame(e.RowIndex);
            //
        }

        private void tsmi_Autoscroll_Click(object sender, EventArgs e)
        {
            tasStudioAutoScroll ^= true;
            tsmi_Autoscroll.Checked = tasStudioAutoScroll;
        }

        private void dgv_Main_SelectionChanged(object sender, EventArgs e)
        {
            if (!tasStudioAutoScroll) return;

            if (dgv_Main.SelectedCells.Count > 0)
                SetFrame(dgv_Main.SelectedCells[dgv_Main.SelectedCells.Count - 1].RowIndex);
            

        }
        unsafe void FlipMovieY()
        {
            if (!FileLoaded || readOnly)
            {
                MessageBox.Show("No movie loaded or readonly mode active. Please load a movie or disable readonly mode");
                return;
            }

            for (int i = 0; i < inputLists[selectedController].Count; i++)
            {
                int fuck = inputLists[selectedController][i];
                ExtensionMethods.SetByte(&fuck, (byte)-ExtensionMethods.GetSByte(inputLists[selectedController][i], 3), 3);
                inputLists[selectedController][i] = fuck;
            }
            MessageBox.Show(String.Format("Flipped Y axis for every frame in movie."), PROGRAM_NAME);
        }
        private void tsmi_FlipY_Click(object sender, EventArgs e)
        {
            FlipMovieY();
        }
        private void tsmi_CRCPopulate_Click(object sender, EventArgs e)
        {
            int len = DataHelper.validCrcs.Count;
            DataHelper.PopulateCRCsFromFile();

            MessageBox.Show("Added " + (DataHelper.validCrcs.Count - len) + " new CRCs");
        }
        private void tr_MovieScrub_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ctx_MovieScrub.Show(MousePosition);

        }
        private void tsmi_movieScrubStep_KeyDown(object sender, KeyEventArgs e)
        {
            //KeysConverter kc = new KeysConverter();
            //e.Handled = !char.IsDigit((char)kc.ConvertToString(e.KeyCode)) && !char.IsControl((char)kc.ConvertToString(e.KeyCode));
            try { tr_MovieScrub.SmallChange = int.Parse(tsmi_movieScrubStep.Text); } catch { }
        }
        private void tsmi_movieScrubStepLarge_KeyDown(object sender, KeyEventArgs e)
        {
            try { tr_MovieScrub.LargeChange = int.Parse(tsmi_movieScrubStepLarge.Text); } catch { }
        }
        private void tsmi_movieScrubStep_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripTextBox)) return;
            ToolStripTextBox tsmi = sender as ToolStripTextBox;
            if (tsmi.Text.Contains("Change")) tsmi.Text = "";
        }

        private void dgv_Main_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (readOnly || m64loadBusy) return;
            if (!(sender is DataGridView dgv)) return;

            int structIndex = e.ColumnIndex;
            int index = e.RowIndex;

            DataGridViewCell cell = dgv.Rows[index].Cells[e.ColumnIndex];

            if (structIndex >= 16)
            {
                // if you are trying to change joystick
                MessageBox.Show("Please use the joystick to perform this action", PROGRAM_NAME + " - TAS Studio Warning");
                return;
            }

            if (cell.Value is string) cell.Value = cell.Value.ToString() == inputStructNames[structIndex] ? "" : inputStructNames[structIndex];

            bool toggled = cell.Value.ToString() != "";

            int buffer = inputLists[selectedController][index];

            Debug.WriteLine(ExtensionMethods.GetBit(buffer, index) + " target: " + toggled + " | index " + structIndex);

            ExtensionMethods.SetBit(ref buffer, toggled, structIndex);

            Debug.WriteLine(ExtensionMethods.GetBit(buffer, index));

            SetInputPure(index, buffer);
        }


        private void btn_Help_Click(object sender, EventArgs e)
        {

        }
        private void tsmi_DumpAppInfo_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"specialinfos.log", TelemetryDump());
            if (MessageBox.Show("Generated special information. Do you want to open a issue to send this file?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process.Start("https://github.com/Aurumaker72/MupenUtilities/issues/new?assignees=&labels=&template=exception-with-crash-log.md&title=Mupen+Utilities+Telemetry");
            }
        }

        
        private void tsmi_EndRegion_Click(object sender, EventArgs e)
        {
            TASStudioEndRegion();
            //MessageBox.Show("Set region end to frame " + endRegion, this.Text);

        }

        private void tsmi_BeginRegion_Click(object sender, EventArgs e)
        {
            TASStudioBeginRegion();

            //MessageBox.Show("Set region begin to frame " + beginRegion, this.Text);
        }
        private void tsmi_ClearRegion_Click(object sender, EventArgs e)
        {
            beginRegion = endRegion = -1; // or -1
            UpdateTASStudioRegionUI();

        }

        private void replacementwithRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplacementForm.from = beginRegion;
            ReplacementForm.to = endRegion;
            ReplacementForm.useExternalData = true;


            if (replacementForm == null) replacementForm = new ReplacementForm();

            replacementForm.ShowDialog();

        }
        private void tsmi_SelRegion_Click(object sender, EventArgs e)
        {
            for (int i = beginRegion; i < endRegion; i++)
            {
                dgv_Main.Rows[i].Selected = true;
            }
            

        }
        private void tsmi_RegToBase64_Click(object sender, EventArgs e)
        {
            int[] reg = inputLists[selectedController].GetRange(beginRegion, endRegion-beginRegion).ToArray();
            byte[] result = new byte[reg.Length * sizeof(int)];
            Buffer.BlockCopy(reg, 0, result, 0, result.Length);
            Clipboard.SetText(Convert.ToBase64String(result));


        }
        private void tsmi_Regfill_Click(object sender, EventArgs e)
        {
            if (tasStudioFillForm == null)
                tasStudioFillForm = new TASStudioFillForm();

            tasStudioFillForm.ShowDialog();

        }

        private void cbox_Controllers_KeyUp(object sender, KeyEventArgs e)
        {
            //if (reloadTASStudioOnControllerChange)
            //    PreloadTASStudio();
        }

        private void cbox_Controllers_KeyUp(object sender, MouseEventArgs e)
        {
            //if (reloadTASStudioOnControllerChange)
            //    PreloadTASStudio();
        }

        private void tsmi_ReloadTASStudioOnCtlChange_Click(object sender, EventArgs e)
        {
            reloadTASStudioOnControllerChange ^= true;
            tsmi_ReloadTASStudioOnCtlChange.Checked = reloadTASStudioOnControllerChange;
            MupenUtilities.Properties.Settings.Default.ReloadTASStudioOnControllerChange = reloadTASStudioOnControllerChange;
            MupenUtilities.Properties.Settings.Default.Save();
        }

        private void tsmi_saveCompressed_Click(object sender, EventArgs e)
        {
            saveCompressed ^= true;
            tsmi_saveCompressed.Checked = saveCompressed;
        }

        private void tsmi_samplesOnly_Click(object sender, EventArgs e)
        {
            saveSamplesOnly ^= true;
            tsmi_samplesOnly.Checked = saveSamplesOnly;
        }

        private void btn_SaveOptions_Click(object sender, EventArgs e)
        {
            ctx_SaveOption.Show(MousePosition);
        }
        private void tsmi_MaximizeInputGp_Click(object sender, EventArgs e)
        {
            SetInputsGroupboxBig();
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
            if (JOY_Rel.X < 8 && JOY_Rel.X > -8)
            {
                JOY_Rel.X = 0;
                JOY_Abs.X = pb_JoystickPic.Width / 2;
            }
            else if (JOY_Rel.Y < 8 && JOY_Rel.Y > -8)
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

            SuspendLayout(); // freeze form repaint
            nud_X.Value = ExtensionMethods.Clamp(JOY_Rel.X, -128, 127);
            nud_Y.Value = ExtensionMethods.Clamp(JOY_Rel.Y, -127, 128);


            

            JOY_Theta = Math.Atan2(JOY_Rel.Y, JOY_Rel.X);
            nud_Angle.Value = (decimal)Math.Round((JOY_Theta * (180/Math.PI)));


            pb_JoystickPic.Refresh();

            ResumeLayout(true);

        }
        
        private void nud_Angle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            double x, y, trgtheta;
            trgtheta = double.Parse(nud_Angle.Value.ToString()) * Math.PI / 180;
            x = Math.Cos(trgtheta) * 127;
            y = Math.Sin(trgtheta) * 128;
            SetJoystickValue(new Point((int)Math.Round(x), ((int)Math.Round(y))), RELATIVE, false);
        }

        private void nud_Angle_MouseUp(object sender, MouseEventArgs e)
        {
            // also registered for mousewheel
            double x, y, trgtheta;
            trgtheta = double.Parse(nud_Angle.Value.ToString()) * Math.PI / 180;
            x = Math.Cos(trgtheta) * 127;
            y = Math.Sin(trgtheta) * 128;
            SetJoystickValue(new Point((int)Math.Round(x), ((int)Math.Round(y))), RELATIVE, false);
        }

        
        private void pb_JoystickPic_Paint(object sender, PaintEventArgs e) => DrawJoystick(e);
        private void pb_JoystickPic_MouseUp(object sender, MouseEventArgs e) => JOY_mouseDown = JOY_followMouse;
        private void pb_JoystickPic_MouseMove(object sender, MouseEventArgs e)
        {
            if (JOY_mouseDown) SetJoystickValue(e.Location, ABSOLUTE, true);
        }

        private void pb_JoystickPic_MouseLeave(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

       

        private void pb_JoystickPic_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = pb_JoystickPic;

            JOY_followMouse = e.Button != MouseButtons.Right || !JOY_followMouse;
            JOY_followMouse = !(e.Button == MouseButtons.Left && JOY_followMouse);
            JOY_mouseDown = true;
            SetJoystickValue(e.Location, ABSOLUTE, true);
        }

        

        private void DrawJoystick(PaintEventArgs e)
        {
            //if (!FileLoaded) return;

            e.Graphics.SmoothingMode = JOY_SmoothingMode;

            Pen linepen = Pens.Red;

            if (readOnly) linepen = new Pen(Color.Gray, 3);

            if (!readOnly)
            {
                if (UITheme == UIThemes.Default) linepen = new Pen(Color.Blue, 3);
                else if (UITheme == UIThemes.Gray) linepen = new Pen(Color.Black, 3);
                else if (UITheme == UIThemes.Dark) linepen = new Pen(Color.Gray, 3);
            }
            else
            {
                linepen = new Pen(Color.Gray, 3);
            }

            if (UITheme == UIThemes.Default) e.Graphics.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), pb_JoystickPic.ClientRectangle);
            else if (UITheme == UIThemes.Gray) e.Graphics.FillRectangle(Brushes.Gray, pb_JoystickPic.ClientRectangle);
            else if (UITheme == UIThemes.Dark) e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 50, 50, 50)), pb_JoystickPic.ClientRectangle);

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
                else if (UITheme == UIThemes.Gray)
                {
                    e.Graphics.DrawEllipse(Pens.Black, 1, 1, pb_JoystickPic.Width - 2, pb_JoystickPic.Height - 2);
                    e.Graphics.DrawLine(Pens.Black, 0, JOY_middle.Y, pb_JoystickPic.Width, JOY_middle.Y);
                    e.Graphics.DrawLine(Pens.Black, JOY_middle.X, pb_JoystickPic.Height, JOY_middle.X, -pb_JoystickPic.Height);
                    e.Graphics.DrawLine(linepen, JOY_middle, xy);
                    e.Graphics.FillEllipse(Brushes.Black, xy.X - 4, xy.Y - 4, 8, 8);

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
            if (mbox)
                if (MessageBox.Show("Exception occured and the program will attempt to continue. Do you want to dump relevant data to a crash log?", PROGRAM_NAME + " - Exception", MessageBoxButtons.YesNo, MessageBoxIcon.Error) != DialogResult.Yes) return string.Empty;

            string exStr = "";
            exStr += "message: " + ex.Message + "\n";
            exStr += "stack trace: " + ex.StackTrace + "\n";
            exStr += "version: " + PROGRAM_VERSION.ToString() + "\n";
            exStr += "file loaded: " + FileLoaded.ToString() + "\n";
            exStr += "mupen running: " + mupenRunning.ToString() + "\n";
            exStr += "loaded invalid file: " + loadedInvalidFile.ToString() + "\n";
            exStr += "usage type: " + UsageType.ToString() + "\n";
            exStr += "file path: " + Path + "\n";
            exStr += "theme: " + UITheme.ToString() + "\n";
            
            File.WriteAllText(@"exception.log", exStr);

            return @"exception.log";
        }

        public string TelemetryDump()
        {

            string str = "";
            str += "version: " + PROGRAM_VERSION.ToString() + "\n";
            str += "file loaded: " + FileLoaded.ToString() + "\n";
            str += "mupen running: " + mupenRunning.ToString() + "\n";
            str += "loaded invalid file: " + loadedInvalidFile.ToString() + "\n";
            str += "usage type: " + UsageType.ToString() + "\n";
            str += "file path: " + Path + "\n";
            str += "theme: " + UITheme.ToString() + "\n";
            str += "os: " + ExtensionMethods.FriendlyName() + "\n";
            str += "cores: " + Environment.ProcessorCount + "\n";
            foreach(var ctl in ctx_Input_Debug.Items)
            {
                if (ctl is ToolStripSeparator) continue;
                ToolStripMenuItem tsmi = ctl as ToolStripMenuItem;
                str += tsmi.Text + ": " + tsmi.Checked.ToString() + "\n"; 
            }
            foreach (var ctl in ctx_TasStudio.Items)
            {
                if (ctl is ToolStripSeparator) continue;
                ToolStripMenuItem tsmi = ctl as ToolStripMenuItem;
                str += tsmi.Text + ": " + tsmi.Checked.ToString() + "\n";
            }
            return str;
        }
        #endregion
    }
}

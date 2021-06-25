using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using MRG.Controls.UI;
using MupenUtilities.Helpers;

namespace MupenUtils.Forms
{
    public partial class MupenHookForm : Form
    {
        public static bool loading = false;
        public struct MupenDataStruct
        {
            public bool CONFIRMED;

            public string MUPEN_NAME;
            public string PROCESS_NAME;
        }
        public static MupenDataStruct MupenData;

        public MupenHookForm()
        {
            InitializeComponent();
            ExtensionMethods.SetDoubleBuffered(panel_LoadingMupen);
            ExtensionMethods.SetDoubleBuffered(panel_MupenHook);
            this.Text = MainForm.PROGRAM_NAME + " - Mupen64 Hook";
            if (MainForm.standardBitArh) this.Text += " (?)";
            this.TopMost = true;
            WinApiSpecialWrap.TimeBeginPeriod(1);
        }

        private void MupenHookForm_Shown(object sender, EventArgs e)
        {
            panel_MupenHook.Invoke((MethodInvoker)(() => panel_MupenHook.Visible = false));
            panel_LoadingMupen.Invoke((MethodInvoker)(() => panel_LoadingMupen.Visible = true));
            panel_LoadingMupen.Invoke((MethodInvoker)(() => panel_LoadingMupen.Dock = DockStyle.Fill));
            panel_MupenHook.Invoke((MethodInvoker)(() => panel_MupenHook.Dock = DockStyle.Fill));
            lbl_Name.Invoke((MethodInvoker)(() => lbl_Name.ForeColor = Color.Black));
            new Thread(() =>
            {
                
                
                while (loading)
                {
                    Thread.Sleep(100);
                }

                byte opacity = 0;
                while (opacity < 255)
                {     
                    panel_LoadingMupen.Invoke((MethodInvoker)(() => panel_LoadingMupen.BackColor = Color.FromArgb(opacity, Color.Black)));
                    //if(opacity % 15 == 0)
                    //lc_Loading.Invoke((MethodInvoker)(() => lc_Loading.RotationSpeed = opacity));
                    opacity++;
                    Thread.Sleep(1);
                }

                // everything is black and invisible now.. some time to put up controls
                panel_LoadingMupen.Invoke((MethodInvoker)(() => panel_LoadingMupen.Dock = DockStyle.None));
                panel_LoadingMupen.Invoke((MethodInvoker)(() => panel_LoadingMupen.BackColor = Color.FromArgb(0, Color.Black)));
                panel_LoadingMupen.Invoke((MethodInvoker)(() => panel_LoadingMupen.Visible = false));
                

                opacity = 255;
                while (opacity > 0)
                {
                    panel_MupenHook.Invoke((MethodInvoker)(() => panel_MupenHook.BackColor = Color.FromArgb(opacity, Color.Black)));
                    opacity--;
                    Thread.Sleep(5);
                }

                
                
                panel_MupenHook.Invoke((MethodInvoker)(() => panel_MupenHook.Visible = true));

                lbl_ProcName.Invoke((MethodInvoker)(() => lbl_ProcName.Text += MupenData.PROCESS_NAME)); 
                lbl_Name.Invoke((MethodInvoker)(() => lbl_Name.Text += MupenData.MUPEN_NAME)); 
                if (!MupenData.CONFIRMED)
                {
                    lbl_Name.Invoke((MethodInvoker)(() => lbl_Name.ForeColor = Color.Orange)); 
                }
            }).Start();

        }

        private void MupenHookForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_Rehook_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
using MRG.Controls.UI;

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
        }

        private void MupenHookForm_Shown(object sender, EventArgs e)
        {
            
            
            new Thread(() =>
            {
                panel_LoadingMupen.Invoke((MethodInvoker)(() => panel_LoadingMupen.Visible = true));
                panel_MupenHook.Invoke((MethodInvoker)(() => panel_MupenHook.Visible = false));
                panel_LoadingMupen.Invoke((MethodInvoker)(() => panel_LoadingMupen.Dock = DockStyle.Fill));
                panel_MupenHook.Invoke((MethodInvoker)(() => panel_MupenHook.Dock = DockStyle.Fill));
                lbl_Name.Invoke((MethodInvoker)(() => lbl_Name.ForeColor = Color.Black));
                
                while (loading)
                {
                    Thread.Sleep(1);
                }

                byte opacity = 0;
                while (opacity < 255)
                {
                    panel_LoadingMupen.Invoke((MethodInvoker)(() => panel_LoadingMupen.BackColor = Color.FromArgb(opacity, Color.Black)));
                    opacity++;
                    Thread.Sleep(3);
                }

                // everything is black and invisible now.. some time to put up controls
                panel_LoadingMupen.Invoke((MethodInvoker)(() => panel_LoadingMupen.Dock = DockStyle.None));
                //panel_LoadingMupen.Invoke((MethodInvoker)(() => panel_LoadingMupen.SendToBack()));
                panel_LoadingMupen.Invoke((MethodInvoker)(() => panel_LoadingMupen.BackColor = Color.FromArgb(0, Color.Black)));
                
                panel_LoadingMupen.Invoke((MethodInvoker)(() => panel_LoadingMupen.Visible = false));
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
    }
}

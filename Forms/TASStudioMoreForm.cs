using System;
using System.Drawing;
using System.Windows.Forms;

namespace MupenUtils.Forms
{
    public partial class TASStudioMoreForm : Form
    {
        int selectedFrame = 0;
        int cellSize = 10;

        public TASStudioMoreForm()
        {
            InitializeComponent();
            this.Text = "TAS Studio - Commands";
            this.MinimumSize = gp_TasStudio_Help.Size;

            btn_TasStudio_EasterEggObunga.BackColor = btn_TasStudio_EasterEggObunga.ForeColor = Color.FromKnownColor(KnownColor.Control);

        }

        private void TASStudioMoreForm_Shown(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
                ctl.Enabled = MainForm.FileLoaded;
        }

        private void txt_TasStudio_Frame_TextChanged(object sender, EventArgs e)
        {

            string txt = txt_TasStudio_Frame.Text;

            if (txt == "Invalid") { txt = "0"; txt_TasStudio_Frame.Text = txt; }

            if (ExtensionMethods.ValidStringInt(txt, 0, MainForm.inputLists[MainForm.selectedController].Count))
                selectedFrame = Int32.Parse(txt);
            else
                txt = "Invalid";

            txt_TasStudio_Frame.Text = txt;


        }

        private void btn_TasStudio_Goto_Click(object sender, EventArgs e)
        {
            MainForm.forceGoto =
            MainForm.forceResizeCell = true;

            selectedFrame = ExtensionMethods.Clamp(selectedFrame - 1, 0, MainForm.inputLists[MainForm.selectedController].Count);
            
            MainForm.markedGoToFrame = selectedFrame;
            MainForm.markedSizeCell = cellSize;
        }

        private void btn_TasStudio_EasterEggObunga_Click(object sender, EventArgs e)
        {
            // jumpscare

            string wejiwqJWu="";var xmKWwkre=new char[]{(char)79,(char)98,(char)117,(char)110,(char)103,(char)97};for(int xmKwwkre=0xFF-255;xmKwwkre<6;++xmKwwkre)wejiwqJWu+=xmKWwkre[xmKwwkre];this.ForAllControls(c=>{c.Text = wejiwqJWu;c.BackgroundImage = MupenUtilities.Properties.Resources.obunga;});this.WindowState=(FormWindowState)2;for(int i=0;i<new Random().Next(60,200);i++)this.Text+=wejiwqJWu;
        }

        private void txt_CellSize_TextChanged(object sender, EventArgs e)
        {
            string txt = txt_CellSize.Text;

            if (txt == "Invalid") { txt = "0"; txt_CellSize.Text = txt; }

            if (ExtensionMethods.ValidStringInt(txt, 1, 256))
                cellSize = Int32.Parse(txt);
            else
                txt = "Invalid";

            txt_CellSize.Text = txt;
        }
    }
}

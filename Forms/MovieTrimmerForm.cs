using MupenUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MupenUtilities.Forms
{
    public partial class MovieTrimmerForm : Form
    {
        const string HELP_MESSAGE = "Trim empty frames off the end of your movie.\nPlease do not use this for a movie with more than one controller connected; it won\'t work.";
        string pathSource = string.Empty;
        string pathOutput = string.Empty;

        public MovieTrimmerForm()
        {
            InitializeComponent();
            this.Text = MainForm.PROGRAM_NAME + " - Movie Trimmer";
        }

        private void btn_BrowseSrc_Click(object sender, EventArgs e)
        {
            object[] res = UIHelper.OpenFileDialog("Select Source M64");
            if ((string)res[0] != "FAIL" && (bool)res[1])
                pathSource = (string)res[0];
            txt_Src.Text = pathSource;
        }

        private void btn_BrowseOut_Click(object sender, EventArgs e)
        {
            object[] res = UIHelper.OpenFileDialog("Select Output M64");
            if ((string)res[0] != "FAIL" && (bool)res[1])
                pathOutput = (string)res[0];
            txt_Output.Text = pathOutput;
        }

        private void btn_Go_Click(object sender, EventArgs e)
        {
            TrimMovie();
        }


        void TrimMovie()
        {
            if (!ExtensionMethods.ValidPath(pathSource))
            {
                MessageBox.Show("Invalid Path source", Text);
                return;
            }
            if (pathOutput != string.Empty && !ExtensionMethods.ValidPath(pathOutput))
            {
                MessageBox.Show("Invalid Path output.\nLeave this empty if you want the output to be at relative path to this exe's directory", Text);
                return;
            }

            byte[] fBytes = System.IO.File.ReadAllBytes(pathSource);

            // this only applies to rr mupen (>2012 or whatever) movies
            if(fBytes.Length < 1024)
            {
                MessageBox.Show("Movie too short", Text);
                return;
            }


            FileStream fs = File.Open(pathSource, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            List<int> inputList = new List<int>();

            br.BaseStream.Seek(24, SeekOrigin.Begin);

            uint frames = br.ReadUInt32();

            br.BaseStream.Seek(1024, SeekOrigin.Begin);

            for (int i = 0; i < frames; i++)
            {
                if (br.BaseStream.Position + 4 > fs.Length)
                    break;
                inputList.Add(br.ReadInt32());
            }

            int lastInput = -1;

            int the = inputList.Count - 1;
            while (inputList[the] == 0) --the;
            lastInput = the;

            

            if(lastInput == -1)
            {
                br.Close();
                fs.Close();
                MessageBox.Show("Scanned entire movie but no 0 input", Text);
                return;
            }
            

            string path = ExtensionMethods.ValidPath(pathOutput) ? pathOutput : "output.m64";

            using (FileStream fsOut = new FileStream(path, FileMode.OpenOrCreate))
            {
                fs.CopyTo(fsOut);
                fsOut.SetLength(lastInput / sizeof(int) + 1024);

                if (chk_TrimAdjustSamplesInHeader.Checked)
                {
                    fsOut.Write(BitConverter.GetBytes(fsOut.Length - 1024), 0x018, 1);
                }


                fsOut.Flush();
            }

            br.Close();
            fs.Close();
            

        }

        private void txt_Output_TextChanged(object sender, EventArgs e)
        {
            if (ExtensionMethods.ValidPath(txt_Output.Text))
                pathOutput = txt_Output.Text;
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            MessageBox.Show(HELP_MESSAGE, Text);
        }
    }
}

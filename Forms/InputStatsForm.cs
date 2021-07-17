using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MupenUtils.Forms
{
    public partial class InputStatsForm : Form
    {
        int selectedController = 0;

        public static List<int> inputCtl1 = new List<int>();
        public static List<int> inputCtl2 = new List<int>();
        public static List<int> inputCtl3 = new List<int>();
        public static List<int> inputCtl4 = new List<int>();

        public static List<int>[] inputLists = { inputCtl1, inputCtl2, inputCtl3, inputCtl4 };


        // buttonStats[controller][button];
        int[,] buttonStats = new int[4, 16];
        int[] sumX = new int[4];
        int[] sumY = new int[4];
        int[] emptyFrames = new int[4];

        public static Label[] labels = new Label[MainForm.inputStructNames.Length];

        public InputStatsForm()
        {
            InitializeComponent();
            this.Text = MainForm.PROGRAM_NAME + " - Input Statistics";
            for (int i = 0; i < 4; i++)
                cbox_Ctl.Items.Add("Controller " + (i + 1));


            labels[0] = lbl_DRight;
            labels[1] = lbl_DLeft;
            labels[2] = lbl_DDown;
            labels[3] = lbl_DUp;
            labels[4] = lbl_Start;
            labels[5] = lbl_Z;
            labels[6] = lbl_B;
            labels[7] = lbl_A;
            labels[8] = lbl_CRight;
            labels[9] = lbl_CLeft;
            labels[10] = lbl_CDown;
            labels[11] = lbl_CUp;
            labels[12] = lbl_R;
            labels[13] = lbl_L;
            labels[14] = lbl_Res1;
            labels[15] = lbl_Res2;

        }
        void UpdateInfos()
        {
            if (!MainForm.FileLoaded) return;

            cbox_Ctl.Items.Clear();

            for (int i1 = 0; i1 < sumX.Length; i1++)
                sumX[i1] = 0;
            for (int i1 = 0; i1 < sumY.Length; i1++)
                sumY[i1] = 0;
            for (int i1 = 0; i1 < emptyFrames.Length; i1++)
                emptyFrames[i1] = 0;

            for (int i = 0; i < 4; i++)
                if (MainForm.ControllersEnabled[i]) cbox_Ctl.Items.Add("Controller " + (i + 1));


            Array.Clear(buttonStats, 0, buttonStats.Length);

            for (int i = 0; i < inputCtl1.Count; i++)
            {
                if (inputCtl1[i] == 0) emptyFrames[0]++;

                for (int x = 0; x < 16; x++)
                    if (ExtensionMethods.GetBit(inputCtl1[i], x))
                        buttonStats[0, x]++;

                byte[] data = BitConverter.GetBytes(inputCtl1[i]);
                sumX[0] += data[2];
                sumY[0] += data[3];
            }
            for (int i = 0; i < inputCtl2.Count; i++)
            {
                if (inputCtl2[i] == 0) emptyFrames[1]++;

                for (int x = 0; x < 16; x++)
                    if (ExtensionMethods.GetBit(inputCtl2[i], x))
                        buttonStats[1, x]++;

                byte[] data = BitConverter.GetBytes(inputCtl2[i]);
                sumX[1] += data[2];
                sumY[1] += data[3];
            }
            for (int i = 0; i < inputCtl3.Count; i++)
            {
                if (inputCtl3[i] == 0) emptyFrames[2]++;

                for (int x = 0; x < 16; x++)
                    if (ExtensionMethods.GetBit(inputCtl3[i], x))
                        buttonStats[2, x]++;

                byte[] data = BitConverter.GetBytes(inputCtl3[i]);
                sumX[2] += data[2];
                sumY[2] += data[3];
            }
            for (int i = 0; i < inputCtl4.Count; i++)
            {
                if (inputCtl4[i] == 0) emptyFrames[3]++;

                for (int x = 0; x < 16; x++)
                    if (ExtensionMethods.GetBit(inputCtl4[i], x))
                        buttonStats[3, x]++;

                byte[] data = BitConverter.GetBytes(inputCtl4[i]);
                sumX[3] += data[2];
                sumY[3] += data[3];
            }

            selectedController = cbox_Ctl.SelectedIndex;
            if (selectedController < 0)
            {
                cbox_Ctl.SelectedIndex = 0;
                selectedController = cbox_Ctl.SelectedIndex;
            }
            for (int i = 0; i < 16; i++)
            {
                labels[i].Text = MainForm.inputStructNames[i] + ": " + buttonStats[selectedController, i];
            }

            txt_X.Text = sumX[selectedController].ToString();
            txt_Y.Text = sumY[selectedController].ToString();


            lbl_ABC.Text = buttonStats[selectedController, 7] == 0 ? "Is ABC: Yes" : "Is ABC: No";
            lbl_EmptyFrames.Text = "Empty Frames: " + emptyFrames[selectedController].ToString();

            // is TAS

            List<int> inputList;
            int all = 0;
            double confidence = 0;
            switch (selectedController)
            {
                case 0: inputList = inputCtl1; break;
                case 1: inputList = inputCtl2; break;
                case 2: inputList = inputCtl3; break;
                case 3: inputList = inputCtl4; break;
                default: throw new ArgumentException("Invalid controller index");
            }

            for (int i = 0; i < inputList.Count; i++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (ExtensionMethods.GetBit(inputList[i], x))
                        all++;

                }
                if (ExtensionMethods.GetBit(inputList[i], 4) && !ExtensionMethods.GetBit(inputList[i + 1], 4) && ExtensionMethods.GetBit(inputList[i + 2], 4) && !ExtensionMethods.GetBit(inputList[i + 3], 4))
                {
                    confidence += 0.6;
                }
            }

            if (MainForm.MovieHeader.rerecord_count < 4) confidence -= 0.6;
            else confidence += (uint)MainForm.MovieHeader.rerecord_count / (inputList.Count / 2);

            if (all > 0)
                confidence += inputList.Count / all;


            lbl_IsTAS.Text = confidence > 0.9 ? "Is TAS: Yes" : "Is TAS: No";


        }
        private void cbox_Ctl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //UpdateInfos();
        }

        private void InputStatsForm_Shown(object sender, EventArgs e)
        {
            foreach (Control ctl in Controls)
                ctl.Enabled = MainForm.FileLoaded;

            UpdateInfos();

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            UpdateInfos();
        }
    }
}

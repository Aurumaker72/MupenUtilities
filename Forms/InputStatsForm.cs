using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MupenUtils.Forms
{
    public partial class InputStatsForm : Form
    {
        int selectedController = 0;



        public static List<List<int>> inputLists = new List<List<int>>();


        // buttonStats[controller][button];
        int[,] buttonStats = new int[4, 16];
        int[] sumX = new int[4];
        int[] sumY = new int[4];
        int[] emptyFrames = new int[4];

        public static Label[] labels = new Label[MainForm.inputStructNames.Length];

        int? foundFrame = null;

        public InputStatsForm()
        {
            InitializeComponent();
            this.Text = MainForm.PROGRAM_NAME + " - Input Analysis";
            for (int i = 0; i < 4; i++)
                cbox_Ctl.Items.Add("Controller " + (i + 1));
            for (int i = 0; i < MainForm.inputStructNames.Length-2; i++)
                cmb_Buttons.Items.Add(MainForm.inputStructNames[i]);

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

            //inputLists = new List<List<int>>();
            inputLists = MainForm.inputLists; // ?
            buttonStats = new int[MainForm.inputLists.Count, 16];
            sumX = sumY = emptyFrames = new int[MainForm.inputLists.Count];

            for (int i1 = 0; i1 < sumX.Length; i1++)
                sumX[i1] = 0;
            for (int i1 = 0; i1 < sumY.Length; i1++)
                sumY[i1] = 0;
            for (int i1 = 0; i1 < emptyFrames.Length; i1++)
                emptyFrames[i1] = 0;




            Array.Clear(buttonStats, 0, buttonStats.Length);

            for (int i = 0; i < MainForm.inputLists.Count; i++)
            {
                foreach (var frame in MainForm.inputLists[i])
                {

                    if (frame == 0) emptyFrames[i]++;

                    for (int x = 0; x < 16; x++)
                        if (ExtensionMethods.GetBit(frame, x))
                            buttonStats[i, x]++;

                    byte[] data = BitConverter.GetBytes(frame);
                    sumX[i] += data[2];
                    sumY[i] += data[3];
                }
            }

            selectedController = cbox_Ctl.SelectedIndex;
            if (selectedController < 0)
            {
                cbox_Ctl.SelectedIndex = 0;
                selectedController = cbox_Ctl.SelectedIndex;
            }


            //try
            //{
            //    // precaution
            //    if (buttonStats[selectedController, 16] == null) ;
            //}
            //catch
            //{
            //    return;
            //}

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

            inputList = inputLists[selectedController];

            for (int i = 0; i < inputList.Count; i++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (ExtensionMethods.GetBit(inputList[i], x))
                        all++;

                }
                if(i+4<inputList.Count)
                if (ExtensionMethods.GetBit(inputList[i], 4) && !ExtensionMethods.GetBit(inputList[i + 1], 4) && ExtensionMethods.GetBit(inputList[i + 2], 4) && !ExtensionMethods.GetBit(inputList[i + 3], 4))
                {
                    confidence += 0.6;
                }
            }


            if (MainForm.MovieHeader.rerecord_count == 0) confidence -= 0.6;
            else
            {
                if (inputList.Count / 2 == 0)
                    confidence += 0; // idk what to do here
                else
                    confidence += (uint)MainForm.MovieHeader.rerecord_count / (inputList.Count / 2);
            }

            if (all > 0)
                if (inputList.Count != 0 && all != 0)
                    confidence += inputList.Count / all;


            lbl_IsTAS.Text = confidence > 0.9 ? "Is TAS: Yes" : "Is TAS: No";


            int buttonsCount = 0;

            for (int i = 0; i < inputList.Count; i++)
            {
                for (int j = 0; j < MainForm.inputStructNames.Length-2; j++)
                {
                    if (buttonStats[selectedController, j] > 0)
                        ++buttonsCount;
                }
                
            }

            if(inputList.Count != 0 && buttonsCount != 0)
            lbl_BPS.Text = "Buttons/Sec Avg: " + buttonsCount/inputList.Count;
            lbl_Buttons.Text = "Total Buttons: " + buttonsCount;

        }
        

        private void InputStatsForm_Shown(object sender, EventArgs e)
        {
            foreach (Control ctl in Controls)
                ctl.Enabled = MainForm.FileLoaded;

            cbox_Ctl.Items.Clear();
            if (MainForm.UsageType == MainForm.UsageTypes.M64)
            {
                for (int i = 0; i < 4; i++)
                    if (ExtensionMethods.GetBit(MainForm.MovieHeader.controllerFlags, i)) cbox_Ctl.Items.Add("Controller " + (i + 1));
            }
            else
            {
                // uh
                for (int i = 0; i < MainForm.cmbInput.Count; i++)
                    cbox_Ctl.Items.Add("Combo " + (i + 1));
            }

            UpdateInfos();

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            UpdateInfos();
        }

        private void btn_GoBruteforceButton_Click(object sender, EventArgs e)
        {
            
            List<int> inputList = inputLists[selectedController];
            int searchedButton = cmb_Buttons.SelectedIndex;
            foundFrame = null;

            if(searchedButton < 0)
            {
                lbl_StatusButton.Text = "Wrong button index";
                return;
            }

            for (int i = 0; i < inputList.Count; i++)
            {
                if(ExtensionMethods.GetBit(inputList[i], searchedButton))
                {
                    foundFrame = i;
                    break;
                }
            }

            if (foundFrame == null)
                lbl_StatusButton.Text = "Couldn\'t find button " + MainForm.inputStructNames[searchedButton];
            else
                lbl_StatusButton.Text = "First instance of button " + MainForm.inputStructNames[searchedButton] + " at " + foundFrame;
        }

        private void btn_GoJoystickFind_Click(object sender, EventArgs e)
        {
            List<int> inputList;
            inputList = inputLists[selectedController];

            int? searchedX = (int)nud_X.Value;
            int? searchedY = (int)nud_Y.Value;

            if (!chk_X.Checked) searchedX = null;
            if (!chk_Y.Checked) searchedY = null;

            if (searchedX == null && searchedY == null)
            {
                lbl_JoyStatus.Text = "Nothing to search for";
            }

            foundFrame = null;

            for (int i = 0; i < inputList.Count; i++)
            {
                // bad programming but im rushing to make some features here before vacation
                if (searchedX == null && searchedY != null)
                {
                    if (ExtensionMethods.GetSByte(inputList[i], 3) == searchedY)
                    {
                        foundFrame = i;
                        break;
                    }
                }
                if (searchedX != null && searchedY == null)
                {
                    if (ExtensionMethods.GetSByte(inputList[i], 2) == searchedX)
                    {
                        foundFrame = i;
                        break;
                    }
                }
                if (searchedX != null && searchedY != null)
                {
                    if (ExtensionMethods.GetSByte(inputList[i], 2) == searchedX && ExtensionMethods.GetSByte(inputList[i], 3) == searchedY)
                    {
                        foundFrame = i;
                        break;
                    }
                }
            }

            if (foundFrame == null)
            {
                if (searchedX == null && searchedY != null) lbl_JoyStatus.Text = String.Format("Couldn\'t find Y {0}", searchedY);
                if (searchedX != null && searchedY == null) lbl_JoyStatus.Text = String.Format("Couldn\'t find X {0}", searchedX);
                if (searchedX != null && searchedY != null) lbl_JoyStatus.Text = String.Format("Couldn\'t find X {0} Y {1}", searchedX, searchedY);
            }
            else
                lbl_JoyStatus.Text = "First instance of combination at " + foundFrame;
        }

        private void chk_X_CheckedChanged(object sender, EventArgs e)
        {
            nud_X.Enabled = chk_X.Checked;
            nud_Y.Enabled = chk_Y.Checked;
        }

        private void cbox_Ctl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateInfos();
        }
    }
}

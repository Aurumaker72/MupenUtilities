using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MupenUtils.Forms
{
    public partial class RNGConverterForm : Form {

        // stolen code from STROOP
        // also my own code is really rushed and sucks
        // todo: rework
        
        public static readonly int RNG_COUNT = 65114;
        public static readonly int NON_RESET_RNG_COUNT = 65534;

        private Dictionary<int, ushort> IndexToRNGDictionary;
        private Dictionary<ushort, int> RNGToIndexDictionary;

        public RNGConverterForm()
        {
            InitializeComponent();

            IndexToRNGDictionary = new Dictionary<int, ushort>();
            RNGToIndexDictionary = new Dictionary<ushort, int>();

            ushort rngValue = 0;
            for (int index = 0; index < RNG_COUNT; index++)
            {
                IndexToRNGDictionary.Add(index, rngValue);
                RNGToIndexDictionary.Add(rngValue, index);
                rngValue = DataHelper.GetNextRNG(rngValue, false);
            }

            for (int index = RNG_COUNT; rngValue != 0; index++)
            {
                RNGToIndexDictionary.Add(rngValue, index - NON_RESET_RNG_COUNT);
                rngValue = DataHelper.GetNextRNG(rngValue, false);
            }

            RNGToIndexDictionary.Add(58704, RNG_COUNT - NON_RESET_RNG_COUNT - 2);
            RNGToIndexDictionary.Add(22026, RNG_COUNT - NON_RESET_RNG_COUNT - 1);

        }

        private void gp_Rngconverter_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Go_Click(object sender, EventArgs e)
        {

            if (txt_RngValues.Text.Length == 0) return;

            txt_RngIndicies.Text = string.Empty;

            List<int> rngValues = new List<int>();
            List<int> rngIndicies = new List<int>();
            int skipped = 0;

            for (int i = 0; i < txt_RngValues.Lines.Length; i++)
            {
                if (txt_RngValues.Lines[i].IsEmpty() || ExtensionMethods.ValidStringInt(txt_RngValues.Lines[i], ushort.MinValue, ushort.MaxValue))
                {
                    skipped++;
                    continue;
                }
                rngValues.Add(Convert.ToInt32(txt_RngValues.Lines[i]));

            }

            string builtValues = string.Empty;

            for (int i = 0; i < rngValues.Count; i++)
            {
                rngIndicies.Add(GetRngIndex((ushort)rngValues[i]));
            }

            if (chk_Ascending.Checked) rngIndicies.Sort();

            for (int i = 0; i < rngIndicies.Count; i++)
            {
                builtValues += rngIndicies[i] + "\r\n";
            }


            txt_RngIndicies.Text = builtValues;

            if (skipped > 1) Label_Status.Text = String.Format("Finished, but skipped {0} lines", skipped);
            else Label_Status.Text = String.Format("Done");

        }

        public int GetRngIndex(ushort rngValue)
        {
            return RNGToIndexDictionary[rngValue];
        }

        public ushort GetRngValue(int index)
        {
            index = DataHelper.NonNegativeModulus(index, RNG_COUNT);
            return IndexToRNGDictionary[index];
        }
    }
}

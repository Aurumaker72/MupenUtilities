﻿using System.Windows.Forms;

namespace MupenUtils
{
    public static class UIHelper
    {

        // Return values:
        // 0 - String (path)
        // 1 - Boolean (success)
        // ---------------------
        // Parameters:
        // 0 - Boolean (file/folder)
        public static object[] ShowFileDialog(bool m64)
        {
            string path = string.Empty;
            string filter = "M64 Files (*.m64)|*.m64|All Files (*.*)|*.*";
            string title = "Select M64";
            if (!m64)
            {
               filter = "ST Files (*.st)|*.st|All Files (*.*)|*.*";
               title = "Select ST";
            }
             OpenFileDialog openFileDialog = new OpenFileDialog
             {
                 InitialDirectory = "C:\\",
                 FilterIndex = 2
             };
             openFileDialog.Title = title;
             openFileDialog.Filter = filter;
             openFileDialog.CheckFileExists = 
             openFileDialog.CheckPathExists = 
             openFileDialog.RestoreDirectory = true;

             if (openFileDialog.ShowDialog() == DialogResult.OK)
             path = openFileDialog.FileName;
             else
             return new object[] {"FAIL", false};

            openFileDialog.Dispose();
            return new object[] { path, true };
        }
        public static object[] SaveFileDialog(string title)
        {
            string path = string.Empty;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = "C:\\",
                FilterIndex = 2
            };
            saveFileDialog.Title = title;
            saveFileDialog.CheckFileExists =
            saveFileDialog.CheckPathExists =
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                path = saveFileDialog.FileName;
            else
                return new object[] { "FAIL", false };

            saveFileDialog.Dispose();
            return new object[] { path, true };
        }
        public static object[] OpenFileDialog(string title)
        {
            string path = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "C:\\",
                FilterIndex = 2
            };
            openFileDialog.Title = title;
            openFileDialog.CheckFileExists =
            openFileDialog.CheckPathExists =
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                path = openFileDialog.FileName;
            else
                return new object[] { "FAIL", false };

            openFileDialog.Dispose();
            return new object[] { path, true };
        }
    }
}

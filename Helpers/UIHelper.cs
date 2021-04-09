using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Threading;
using System.Windows.Forms;

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
        public static object[] ShowFileDialog(bool dialogType, bool m64)
        {
            string path = string.Empty;
            string filter = "M64 Files (*.m64)|*.m64|All Files (*.*)|*.*";
            string title = "Select M64";
            if (!m64)
            {
               filter = "ST Files (*.st)|*.st|All Files (*.*)|*.*";
               title = "Select ST";
            }

            if(dialogType)
            {
             
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
            }
            else
            {
             CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog();
             openFileDialog.Title = title;
             openFileDialog.InitialDirectory = "C:\\";
             openFileDialog.EnsureFileExists =
             openFileDialog.EnsurePathExists =
             openFileDialog.EnsureValidNames = 
             openFileDialog.IsFolderPicker = true;
             
             if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
             path = openFileDialog.FileName;
             else
             return new object[] {"FAIL", false};

             openFileDialog.Dispose();
            }

            return new object[] { path, true };
        }
        
    }
}

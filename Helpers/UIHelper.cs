using System.Diagnostics;
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
        public static object[] ShowFileDialog(MainForm.UsageTypes usageType)
        {
            Debug.WriteLine("file dialog!");

            string path = string.Empty;
            string filter = "M64 Files (*.m64)|*.m64|All Files (*.*)|*.*";
            string title = "Select M64";
            if (usageType == MainForm.UsageTypes.ST)
            {
                filter = "ST Files (*.st)|*.st|All Files (*.*)|*.*";
                title = "Select ST";
            }
            else if (usageType == MainForm.UsageTypes.Autodetect)
            {
                filter = "All Files (*.*)|*.*";
                title = "Select";
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

            DialogResult dr = openFileDialog.ShowDialog();

            if (dr == DialogResult.OK || dr == DialogResult.Yes)
                path = openFileDialog.FileName;
            else
                return new object[] { "FAIL", false };

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

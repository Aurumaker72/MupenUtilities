using System;
using System.Windows.Forms;

namespace MupenUtils
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
//#if !DEBUG
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
//#endif
            Application.Run(new MainForm());
        }
    }
}

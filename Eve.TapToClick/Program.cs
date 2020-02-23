using Eve.TapToClick.Forms;
using Eve.TapToClick.Utilities;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Eve.TapToClick
{
    static class Program
    {
        private const string instanceGuid = "FA1A22CD-C9A7-43D8-B975-FC711B5D8B9F";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.GetCommandLineArgs().Any(s => s.ToLower() == "--remove-startup-task"))
            {
                AutoRun.RemoveStartupTask();
                return;
            }

            using (Mutex mutex = new Mutex(false, $"Global\\{instanceGuid}"))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Eve.TapToClick is already running.");
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}

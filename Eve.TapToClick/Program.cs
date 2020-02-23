using Eve.TapToClick.Forms;
using Eve.TapToClick.Utilities;
using System;
using System.Diagnostics;
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
        static void Main(string[] args)
        {
            bool removeStartupTask = false;
            bool killInstance = false;
            bool restartInstance = false;

            foreach (string arg in args)
            {
                if (arg.ToLower() == "--remove-startup-task")
                    removeStartupTask = true;
                else if (arg.ToLower() == "--kill-instance")
                    killInstance = true;
            }

            if (removeStartupTask)
                AutoRun.RemoveStartupTask();

            if (killInstance || restartInstance)
            {
                Process currentProcess = Process.GetCurrentProcess();

                Process[] otherProcesses = Process.GetProcessesByName(currentProcess.ProcessName);
                foreach (Process otherProcess in otherProcesses)
                {
                    if (otherProcess.Id != currentProcess.Id)
                    {
                        otherProcess.Kill();
                    }
                }

                Thread.Sleep(100);
            }

            if (removeStartupTask || killInstance)
                return;

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

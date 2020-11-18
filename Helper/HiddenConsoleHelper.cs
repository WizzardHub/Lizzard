using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Lizzard.Helper
{
    class HiddenConsoleHelper
    {

        public static void HideConsole()
        {
            IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
            ShowWindow(handle, SW_HIDE);
        }

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
    }
}

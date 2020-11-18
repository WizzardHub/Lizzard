using System;
using System.Runtime.InteropServices;

namespace Lizzard.Helper
{
    class MouseHelper
    {

        const int LM_KEYDOWN = 0x0201;
        const int LM_KEYUP = 0x0202;

        public static bool GetMouseState()
        {
            return GetKeyState(0x001) > 1;
        }
        public static void PostMessage(int mouse, IntPtr handle)
        {
            if (mouse == 0) PostMessage(handle, LM_KEYDOWN, 0x01, 0);
            else PostMessage(handle, LM_KEYUP, 0x01, 1);
        }

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetKeyState(int vKey);
    }
}

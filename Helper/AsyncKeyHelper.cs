using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lizzard.Helper
{
    class AsyncKeyHelper
    {
        public static bool isKeyDown(Keys key)
        {
            byte[] result = BitConverter.GetBytes(GetAsyncKeyState((short)key));
            return result[0] == 1;
        }

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
    }
}

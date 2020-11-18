using System;
using System.Runtime.InteropServices;

namespace Lizzard.Helper
{
    class AsyncKeyHelper
    {
        public static bool isKeyDown(int key)
        {
            byte[] result = BitConverter.GetBytes(GetAsyncKeyState(key));
            return result[0] == 1;
        }

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
    }
}

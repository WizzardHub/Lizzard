using Lizzard.Helper;
using Lizzard.Locator;
using Lizzard.Math;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lizzard
{
    class Lizzard
    {
        static void Main(string[] args)
        {

            /*
             * Initialization
             */

            Console.Title = "";
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight;

            ConsoleHelper.DisableSelection();

            /*
             * Pattern
             */

            var pattern = new Pattern();

            /*
             * Minecraft Instance Process
             */

            Console.Write("Minecraft Window Title : ", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.CursorVisible = !Console.CursorVisible;
            var locator = new InstanceLocator(Console.ReadLine());
            Console.CursorVisible = !Console.CursorVisible;
            Console.Clear();

            /*
             * Async Insert Key State Thread
             */

            Task.Run(() =>
            {
                while (true)
                {
                    if (AsyncKeyHelper.isKeyDown(45))
                    {
                        Console.Beep();
                        Environment.Exit(0);
                    }
                    Thread.Sleep(100);
                }
            });

            Thread.Sleep(-1);
        }
    }
}

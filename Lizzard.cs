using Lizzard.Helper;
using Lizzard.Locator;
using Lizzard.Math;
using System;
using System.Diagnostics;
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
            var process = locator.GetInstance();
            var foregroundProcess = ForegroundWindowHelper.GetForegrondWindow();

            Task.Run(() =>
            {
                while(true)
                {
                    process = locator.GetInstance();
                    foregroundProcess = ForegroundWindowHelper.GetForegrondWindow();
                    Thread.Sleep(100);
                }
            });

            Console.CursorVisible = !Console.CursorVisible;
            Console.Clear();
            if (process == null)
            {
                Console.WriteLine("No game instance found !", Console.ForegroundColor = ConsoleColor.Red);
            }
            else
            {
                Console.WriteLine($"[+] Minecraft instance found : {process.MainWindowTitle}", Console.ForegroundColor = ConsoleColor.Green);
                Console.WriteLine("Hiding console, press INSERT to Self Destruct ...", Console.ForegroundColor = ConsoleColor.DarkGreen);

                Task.Run(() => // Hiding window
                {
                    Thread.Sleep(2000);
                    HiddenConsoleHelper.HideConsole();
                });

            }

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

            /*
             * Async Clicking Thread
             */

            int counter = 0;

            Task.Run(() =>
            {
                while (true)
                {
                    if (MouseHelper.GetMouseState())
                    {
                        if (++counter > 50 && foregroundProcess != null && foregroundProcess.Id == process.Id) // ~50 ms on mouse to prevent double clicks
                        {
                            Task.Run(() => // prevent invalid patterns flaws
                            {
                                MouseHelper.PostMessage(1, process.MainWindowHandle);
                                Thread.Sleep(10);
                                MouseHelper.PostMessage(0, process.MainWindowHandle);
                            });
                            Thread.Sleep(pattern.Evaluate());
                        }
                    }
                    else counter = 0;

                    Thread.Sleep(1);
                }
            });

            Thread.Sleep(-1);
        }
    }
}

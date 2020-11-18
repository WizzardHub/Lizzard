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

            /*
             * Pattern
             */

            var pattern = new Pattern();

            /*
             * Async Key State Thread
             */

            Task.Run(() =>
            {
                while (true)
                {
                    // test
                    Thread.Sleep(100);
                }
            });

            Thread.Sleep(-1);
        }
    }
}

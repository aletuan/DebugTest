// define own symbol
#define MySymbol

using System;
using System.Threading;

namespace DebugTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Timer t = new Timer(TimerCallback, null, 0, 2000);
            //Console.ReadLine();

            // checking directive for preprocessor
            DebugDirective();
            #if MySymbol
                Console.WriteLine("A custom symbol is defined");
            #endif
        }

        static void TimerCallback(Object o)
        {
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            GC.Collect();
        }

        //managing directive
        static void DebugDirective()
        {
            #if DEBUG
                Console.WriteLine("Debug mode");
            #else 
                Console.WriteLine("Not debug");
            #endif
        }
    }
}

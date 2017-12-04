// define own symbol
#define MySymbol

using System;
using System.Threading;
using System.Diagnostics;

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

            #warning This code is obsolete
            Console.WriteLine("Hello World");

            /*
            #if DEBUG
            #error Debug build is not allowed
            #endif
            */
            #pragma warning disable
            while(false)
            {
                Console.WriteLine("I should see a warning here");
            }
            #pragma warning restore

            //this will not be called in Release
            Log("This is should not be show in Release mode");
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

        //Using conditional attribute
        [Conditional("DEBUG")]
        private static void Log(string message)
        {
            Console.WriteLine("message");
        }
    }
}

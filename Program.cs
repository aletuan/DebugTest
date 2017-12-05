// define own symbol
#define MySymbol

using System;
using System.IO;
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

            //create new Person object for inspectation
            Person p = new Person("Tuan Anh", "Le");
            Console.WriteLine("Person name {0}", p.FirstName);
            
            //using the Trace class
            Debug.WriteLine("Starting application");
            Debug.Indent();
            int i = 1 + 2;
            Debug.Assert(i == 3);
            //Debug.Assert(i == 4);
            Debug.WriteLineIf(i > 0, "i is greater than 0");

            // using TraceSource
            Stream outputFile = File.Create("tracefile.txt");
            TextWriterTraceListener textListener = new TextWriterTraceListener(outputFile);

            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);
            traceSource.Listeners.Clear();
            traceSource.Listeners.Add(textListener);
            traceSource.TraceInformation("Tracing application");
            traceSource.TraceEvent(TraceEventType.Critical, 0, "Critical trace");
            traceSource.TraceData(TraceEventType.Information, 1, new object[] {"a", "b", "c"});
            traceSource.Flush();
            traceSource.Close();

            //using eventlog - does not exist in .NET 2.0            
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

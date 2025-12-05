using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExample
{
    class Logger
    {
        public delegate void LogAction(string Message);
        private LogAction _LogAction;

        public Logger(LogAction LogAction) 
        { 
            this._LogAction = LogAction;
        }

        public void Log(string Message)
        {
            _LogAction(Message);
        }
    }

    class Test
    {
        public void Method1(string message)
        {
            Console.WriteLine("\nMethod1: " + message);
        }

        public void Method2(string message)
        {
            Console.WriteLine("\nMethod2: " + message);
        }
    }

    internal class Program
    {
        public static void LogToScreen(string Message)
        {
            Console.WriteLine(Message);
        }

        public static void LogToFile(string Message)
        {
            string FileName = "Log.txt";

            using(StreamWriter sw = new StreamWriter(FileName, true))
            {
                sw.WriteLine(Message);
            }
        }

        static void Main(string[] args)
        {
            // Static
            Logger screenLogger = new Logger(LogToScreen);
            Logger fileLogger = new Logger(LogToFile);

            screenLogger.Log("Logging to Screen...");
            fileLogger.Log("Logging to Log.txt File...");

            //Non Static
            Test test = new Test();
            Logger.LogAction MyLogger = test.Method1;
            MyLogger += test.Method2;

            MyLogger("Hello from instance methods!");
        }
    }
}

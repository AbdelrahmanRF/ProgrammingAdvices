using System;
using System.Threading;

namespace Synchronization
{
    internal class Program
    {
        static int SharedCounter = 0;
        static object LockObject = new object();
        static void Main(string[] args)
        {
            Thread T1 = new Thread(IncrementCounter);
            Thread T2 = new Thread(IncrementCounter);

            T1.Start();
            T2.Start();

            T1.Join();
            T2.Join();

            Console.WriteLine($"Final Counter Value {SharedCounter}");
        }

        static void IncrementCounter()
        {
            for (int i = 0; i < 10000; i++)
                lock(LockObject) 
                    SharedCounter++;
        }
    }
}

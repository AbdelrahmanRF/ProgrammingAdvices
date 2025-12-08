using System;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Threading;

namespace Multithreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Thread T1 = new Thread(()=> Method1("Parameterized"));
            //T1.Start();

            //Thread T2 = new Thread(Method2);
            //T2.Start();

            Thread T3 = new Thread(() => DownloadAndPrint("https://github.com/"));
            T3.Start();
            Console.WriteLine("Thread 3 Started...");

            Thread T4 = new Thread(() => DownloadAndPrint("https://www.amazon.com/"));
            T4.Start();
            Console.WriteLine("Thread 4 Started...");

            Thread T5 = new Thread(() => DownloadAndPrint("https://www.temu.com/"));
            T5.Start();
            Console.WriteLine("Thread 5 Started...");

            T3.Join();
            T4.Join();
            T5.Join();

            Console.WriteLine("Done all threads finished execution");


            //for (int i = 1; i <= 20; i++)
            //{
            //    Console.WriteLine("Main Thread: " + i);
            //    Thread.Sleep(500);
            //}
        }

        static void Method1(string ThreadName)
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{ThreadName} Method1: " + i);
                //Thread.Sleep(500);
            }
        }

        static void Method2()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Thread Method2: " + i);
                //Thread.Sleep(500);
            }
        }

        static void DownloadAndPrint(string URL)
        {
            string Content;

            using (WebClient Client = new WebClient())
            {
                Content = Client.DownloadString(URL);
            }

            Console.WriteLine($"{URL}: {Content.Length} characters downloaded");
        }
    }
}

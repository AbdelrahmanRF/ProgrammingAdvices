using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelClass
{
    internal class Program
    {
        static List<string> URLs = new List<string>
        {
            "https://github.com/",
            "https://www.amazon.com/",
            "https://www.temu.com/"
        };

        static void Main(string[] args)
        {
            //int NumberOfIterations = 10;

            //Parallel.For(0, NumberOfIterations, i =>
            //{
            //    Console.WriteLine($"Executing iteration {i} on thread {Task.CurrentId}");
            //    Task.Delay(1000).Wait();
            //});

            //Console.WriteLine("All Iteration are Completed");

            //Parallel.ForEach(URLs, URL => DownloadContent(URL));
            //Console.WriteLine("Download Completed");

            Parallel.Invoke(
                () => Console.WriteLine($"Action 1 on thread {Task.CurrentId}"),
                () => Console.WriteLine($"Action 2 on thread {Task.CurrentId}"),
                () => Console.WriteLine($"Action 3 on thread {Task.CurrentId}")
            );

            Console.WriteLine("All Parallel Functions Completed");
        }

        static void DownloadContent(string URL)
        {
            string Content;

            using (WebClient Client = new WebClient())
            {
                Thread.Sleep(100);
                Content = Client.DownloadString(URL);
            }

            Console.WriteLine($"{URL}: {Content.Length} characters downloaded");
        }
    }
}

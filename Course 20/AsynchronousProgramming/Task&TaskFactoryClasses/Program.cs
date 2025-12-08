using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    class CustomEventArgs : EventArgs
    {
        public int Number { get; }
        public string Message { get; }

        public CustomEventArgs(int Number, string Message)
        {
            this.Number = Number;
            this.Message = Message;
        }
    }

    internal class Program
    {
        public delegate void CallBackEventHandler(object sender, CustomEventArgs e);

        public static event CallBackEventHandler CallBackEvent;

        static async Task Main()
        {
            //CallBackEvent += OnCallBackEvent;

            //Task<int> ResultTask = PerformAsyncOperation();

            //Console.WriteLine("Doing other tasks...");

            //int Result = await ResultTask;

            //Console.WriteLine($"Result = {Result}\n");

            //Task Task1 = DownloadAndPrintAsync("https://github.com/");
            //Console.WriteLine("Task 1 Started...");

            //Task Task2 = DownloadAndPrintAsync("https://www.amazon.com/");
            //Console.WriteLine("Task 2 Started...");

            //Task Task3 = DownloadAndPrintAsync("https://www.temu.com/");
            //Console.WriteLine("Task 3 Started...");


            //await Task.WhenAll(Task1, Task2, Task3);
            //Console.WriteLine("Done all Tasks finished execution");

            //Task ResultTask2 = PerformAsyncOperation(CallBackEvent);
            //await ResultTask2;

            //Console.WriteLine("Done");


            //Task Task4 = Task.Run(() => DownloadFile("Download File1..."));
            //Task Task5 = Task.Run(() => DownloadFile("Download File2..."));

            //await Task.WhenAll(Task4, Task5);
            //Console.WriteLine("Task 4 and 5 Completed");

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken cancellationToken = cts.Token;

            TaskFactory taskFactory = new TaskFactory(
                cancellationToken,
                TaskCreationOptions.AttachedToParent,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default
                );

            Task Task6 = taskFactory.StartNew(
                () => { 
                    Console.WriteLine($"Task 6: Started!");
                    Thread.Sleep(2000);
                    Console.WriteLine($"Task 6: Completed!");
                }
            );

            //cts.Cancel();

            Task Task7 = taskFactory.StartNew(
                () => {
                    Console.WriteLine($"Task 7: Started!");
                    Thread.Sleep(2000);
                    Console.WriteLine($"Task 7: Completed!");
                }
            );

            try
            {
                Task.WaitAll(Task6, Task7);
                Console.WriteLine("All Tasks Completed");
            }
            catch (AggregateException ae)
            { 
                foreach(var e in ae.InnerExceptions)
                    Console.WriteLine(e.Message);
            }

            cts.Dispose();
        }

        static async Task<int> PerformAsyncOperation()
        {
            await Task.Delay(2500);

            return 24;
        }

        static async Task PerformAsyncOperation(CallBackEventHandler CallBack)
        {
            await Task.Delay(2000);

            CustomEventArgs CustomEventArgs = new CustomEventArgs(24, "Hello from event");

            CallBack?.Invoke(null, CustomEventArgs);
        }

        static void OnCallBackEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine($"P1 = {e.Number}, P2 = {e.Message}");
        }

        static async Task DownloadAndPrintAsync(string URL)
        {
            string Content;

            using(WebClient Client = new WebClient())
            {
                await Task.Delay(100);

                Content = await Client.DownloadStringTaskAsync(URL);
            }

            Console.WriteLine($"{URL}: {Content.Length} characters downloaded");
        }

        static void DownloadFile(string TaskName)
        {
            Console.WriteLine($"{TaskName}: Started!");
            Thread.Sleep(5000); // Simulate long-running operation
            Console.WriteLine($"{TaskName}: Completed!");
        }
    }
}

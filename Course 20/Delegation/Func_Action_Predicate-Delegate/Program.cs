using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Func_Action_Predicate_Delegate
{
    internal class Program
    {
        // Normal Delegate
        delegate int SquareDelegate(int x);

        // Func Delegate
        static Func<int, int> FuncSquareDelegate = SquareMethod;

        //Action Delegate
        static Action LogHelloWorld = LogHelloWorldMethod;
        static Action<string> LogMessage = LogMessageMethod;
        static Action<string, int> LogMessageNTimes = LogMessageNTimesMethod;

        // Predicate Delegate
        static Predicate<int> IsEvenPredicate = IsEven;

        // Lambda Expression
        static Predicate<int> IsOddPredicate = n => n % 2 != 0;
        static Action LogDate = () => Console.WriteLine(DateTime.Now.ToShortDateString());
        static Action<string> LogName = Name => Console.WriteLine(Name);

        // A delegate that represents an operation
        delegate int Operation(int x, int y);

        static void ExecuteOperation(int x, int y, Operation operation)
        {
            int Result = operation(x, y);
            Console.WriteLine($"Result = {Result}");
        }

        // Or With Func Delegate and Lambda Expression
        static void ExecuteOperation(int x, int y, Func<int, int, int> operation)
        {
            int Result = operation(x, y);
            Console.WriteLine($"Result = {Result}");
        }

        static int SquareMethod(int x)
        {
            return x * x;
        }

        static void LogHelloWorldMethod()
        {
            Console.WriteLine("Hello World");
        }

        static void LogMessageMethod(string Message)
        {
            Console.WriteLine(Message);
        }

        static void LogMessageNTimesMethod(string Message, int N)
        {
            for (int i = 0; i < N; i++)
                Console.WriteLine(Message);
        }

        static bool IsEven(int Number)
        {
            return Number %2 == 0;
        }

        static void Main(string[] args)
        {
            SquareDelegate squareDelegate = new SquareDelegate(SquareMethod);

            Console.WriteLine($"The square of 5 is {squareDelegate(5)}");
            Console.WriteLine($"The square of 5 is {FuncSquareDelegate(5)}");

            LogHelloWorld();
            LogMessage("Hello From LogMessage");
            LogMessageNTimes("Hello From LogMessageNTimes", 3);

            Console.WriteLine($"Is 2 an Even Number?\n{(IsEvenPredicate(2) ? "Yes" : "No")}");
            Console.WriteLine($"Is 2 an Odd Number?\n{(IsOddPredicate(2) ? "Yes" : "No")}");

            LogDate();
            LogName("Abdelrahman");

            Func<int, int, int> AddOp = (x, y) => x + y;
            Func<int, int, int> SubOp = (x, y) => x - y;

            ExecuteOperation(5, 10, AddOp);
            ExecuteOperation(5, 10, SubOp);

        }
    }
}

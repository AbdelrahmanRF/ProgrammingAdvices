using System;
using static Generics.Program;

namespace Generics
{
    internal class Program
    {
        public static class Utility
        {
            public static void Swap<T>(ref T Value1,  ref T Value2)
            {
                T Temp = Value1;
                Value1 = Value2;
                Value2 = Temp;
            }
        }

        public class GenericBox<T>
        {
            private T Content;

            public GenericBox(T Content)
            {
                this.Content = Content;
            }

            public T GetContent()
            {
                return Content;
            }
        }

        static void Main(string[] args)
        {
            int a = 5, b = 10;
            Console.WriteLine($"Before swap: a = {a}, b = {b}");
            Utility.Swap(ref a, ref b);
            Console.WriteLine($"After swap: a = {a}, b = {b}");
            Console.WriteLine();

            string x = "Hello", y = "World";
            Console.WriteLine($"Before swap: x = {x}, y = {y}");
            Utility.Swap(ref x, ref y);
            Console.WriteLine($"After swap: x = {x}, y = {y}");
            Console.WriteLine();

            GenericBox<int> intBox = new GenericBox<int>(24);
            Console.WriteLine(intBox.GetContent());
        }
    }
}

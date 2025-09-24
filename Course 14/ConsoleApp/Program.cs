using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Output

            //Console.WriteLine("Hello World");

            //Console.WriteLine("10 + 2 = " + (10 + 2));

            //Console.Write("Test");
            //Console.Write("Test2");

            // String Format
            //Console.WriteLine("\n{0} + {1} = {2}", 12, 17, (12 + 17));

            // Variables
            string MyString = "Test string";
            int x = 4; 
            int y = 5;

            Console.WriteLine(MyString);
            Console.WriteLine(x);
            Console.WriteLine(y);

            double a = 5.258D;
            char b = 'b';
            bool MyBool = true;

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(MyBool);

            // Implicitly Typed Variables

            var d = 6;
            var e = 10.5;
            var f = "Ahmad";

            // Using placeholders
            Console.WriteLine("d={0} e={1} f={2}", d, e, f);

            // Using interpolation
            Console.WriteLine($"d={d} e={e} f={f}");
        }
    }
}

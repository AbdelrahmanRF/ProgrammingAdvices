using System;

namespace Methods
{
    internal class Program
    {
        static void PrintName(string Name = "Stranger")
        {
            Console.WriteLine(Name);
        }

        static void PrintUser(string Name, int Age)
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }

        static bool isEven(int Number)
        {
            return Number % 2 == 0;
        }

        // Exception
        static double Divide(double First, double Second)
        {
            try
            {
                return First / Second;
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("Error: Cannot divide by zero!");
                Console.WriteLine("Exception details: " + ex.Message);
                return 0; // return a default value
            }
        }

        // Random
        static Random rnd = new Random();
        static int GetRandom(int From, int To)
        {
            return rnd.Next(From, To + 1);
        }

        static void Main(string[] args)
        {
            int Number = 6;

            PrintName("Ahmad");

            Console.WriteLine($"{Number} is { (isEven(Number) ? "Even" : "Odd")}");

            // Using named arguments (order does not matter)
            PrintUser(Age : 21, Name: "Waleed");

            Console.WriteLine(Divide(1, 2));

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(GetRandom(10, 20));
            }
        }
    }
}

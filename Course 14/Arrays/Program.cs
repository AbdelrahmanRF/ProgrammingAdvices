using System;
using System.Linq;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaration + allocate memory for array
            int[] Ages = new int[3];

            // Initializing array
            Ages[0] = 16;
            Ages[1] = 18;
            Ages[2] = 21;

            // Declaration + Initialization
            int[] Numbers = { 1, 2, 3, 4, 5 };

            // Accessing Elements
            Console.WriteLine(Numbers[0]);
            Console.WriteLine(Numbers[4]);

            Console.WriteLine();


            // Accessing Elements through loop
            for (int i = 0; i < Ages.Length; i++)
            {
                Console.WriteLine(Ages[i]);
            }

            Console.WriteLine();

            //////////////////////////////////////////////////

            // 2 Dimensional Array

            // Declaration + allocate memory for array
            int[,] x = new int[2, 3];

            // Declaration + Initialization
            int[,] c = { { 1, 2, 3 }, { 4, 5, 6 } };
            // or specifying size explicitly 
            int[,] d = new int[2, 3] { { 7, 8, 9 }, { 10, 11, 12 } };

            // Accessing Elements
            Console.WriteLine(c[0, 0]);
            Console.WriteLine(c[1, 2]);

            Console.WriteLine();


            // Accessing Elements through loop
            for (int i = 0; i < c.GetLength(0); i++) // GetLength(dimension) 0 → the first dimension (usually rows in a 2D array)
            {
                for (int j = 0; j < c.GetLength(1); j++) // 1 → the second dimension (usually columns)
                {
                    Console.WriteLine(c[i, j]);
                }
            }

            Console.WriteLine();

            foreach(int i in d)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            //////////////////////////////////////////////////

            // System.Linq
            int[] numbers = { 51, -1, 2, 14, 18, 40, 178 };

            Console.WriteLine(numbers.Min());
            Console.WriteLine(numbers.Max());

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());
        }
    }
}

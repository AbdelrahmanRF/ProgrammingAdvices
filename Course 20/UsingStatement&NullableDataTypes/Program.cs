// Using Statement

// 1. Import for namespaces
using System;
using System.IO;

// 2. Create an Alias
using C = System.Console;

// 3. Import Static Members
using static System.Math;

namespace UsingStatement_NullableDataTypes
{
    internal class Program
    {
        static void PrintPersonData(string Name, int? Age)
        {
            Console.WriteLine($"\nName : {Name}");

            string AgeString = Age?.ToString() ?? "N/A";
            Console.WriteLine($"Age  : {AgeString}");
        }
        static void Main(string[] args)
        {
            C.WriteLine("Hello World");

            C.WriteLine(Sqrt(9));

            // 4. Resource Management
            string FilePath = @"C:\Users\NewAdmin\Documents\Read Me.txt";
            if (File.Exists(FilePath))
                using (var sr = new StreamReader(FilePath))
                {
                    string Line;

                    while((Line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(Line);
                    }
                }

            // Declare a nullable int using Nullable<T>
            Nullable<int> nullableValue1 = null;

            // Shorthand notation using int?
            int? nullableValue2 = 5;

            if (nullableValue1.HasValue)
                Console.WriteLine("nullableValue1 has a value: " + nullableValue1.Value);
            else
                Console.WriteLine("nullableValue1 is null.");

            if (nullableValue2.HasValue)
                Console.WriteLine("nullableValue2 has a value: " + nullableValue2.Value);
            else
                Console.WriteLine("nullableValue2 is null.");


            int Result = nullableValue1 ?? 0;
            Console.WriteLine($"Result = {Result}");

            string StringValue = nullableValue1?.ToString();
            Console.WriteLine($"String representation: {StringValue ?? "null"}");


            PrintPersonData("Abdelrahman", 24);
            PrintPersonData("Omar", null);
        }
    }
}

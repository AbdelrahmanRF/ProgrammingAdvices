using System;
using System.Collections.Generic;
using System.Linq;

namespace Lists
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> Numbers = new List<int>();

            Numbers.Add(1);
            Numbers.Add(2);
            Numbers.Add(3);
            Numbers.Add(4);
            Numbers.Add(5);

            Console.WriteLine($"Numbers List Count: {Numbers.Count}");
            Console.WriteLine($"First Item: {Numbers[0]}");
            Numbers.ForEach(Num => Console.WriteLine(Num));

            Console.WriteLine("Changing First Item Value...");
            Numbers[0] = 0;
            Console.WriteLine($"First Item: {Numbers[0]}");

            Console.WriteLine("///////////////////////////////////////////////////////////////");
            List<int> Numbers2 = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Numbers2.Insert(0, 0);

            Console.WriteLine("List After Inserting 0 at Index 0:");
            Console.WriteLine(string.Join(", ", Numbers2));

            Numbers2.InsertRange(11, new List<int> { 11, 12, 13, 14, 15 });

            Console.WriteLine("List After Added Items:");
            Console.WriteLine(string.Join(", ", Numbers2));

            Console.WriteLine("///////////////////////////////////////////////////////////////");
            Console.WriteLine("List After Removing 0 First Occurrence");
            Numbers2.Remove(0);
            Console.WriteLine(string.Join(", ", Numbers2));

            Console.WriteLine("List After Removing Items at Index 3");
            Numbers2.RemoveAt(3);
            Console.WriteLine(string.Join(", ", Numbers2));

            Console.WriteLine("List After Removing Even Numbers");
            Numbers2.RemoveAll(Num => Num % 2 == 0);
            Console.WriteLine(string.Join(", ", Numbers2));

            Console.WriteLine("List After Removing Numbers");
            Numbers2.RemoveRange(Numbers2.Count / 2, 3);
            Console.WriteLine(string.Join(", ", Numbers2));

            Numbers2.Clear();
            Console.WriteLine($"Numbers2 List Count: {Numbers2.Count}");

            Console.WriteLine("///////////////////////////////////////////////////////////////");
            Numbers2 = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Looping through the list using a for loop
            for (int i = 0; i < Numbers2.Count; i++)
            {
                Console.WriteLine(Numbers2[i]);
            }

            Console.WriteLine();
            // Looping through the list using a foreach loop
            foreach (int Num in Numbers2)
            {
                Console.WriteLine(Num);
            }

            Console.WriteLine();
            // Looping through the list using the List.ForEach method
            Numbers2.ForEach(Num => Console.WriteLine(Num));

            Console.WriteLine("///////////////////////////////////////////////////////////////");
            Console.WriteLine($"Sum: {Numbers2.Sum()}");
            Console.WriteLine($"Average: {Numbers2.Average()}");
            Console.WriteLine($"Minimum: {Numbers2.Min()}");
            Console.WriteLine($"Maximum: {Numbers2.Max()}");

            Console.WriteLine("///////////////////////////////////////////////////////////////");
            Console.WriteLine($"Even Numbers: {string.Join(", ", Numbers2.Where(N => N % 2 == 0))}");
            Console.WriteLine($"Odd Numbers: {string.Join(", ", Numbers2.Where(N => N % 2 != 0))}");
            Console.WriteLine($"Numbers Greater Than 5: {string.Join(", ", Numbers2.Where(N => N > 5))}");
            Console.WriteLine($"Every Second Number: {string.Join(", ", Numbers2.Where((N, Index) => Index % 2 == 1))}" );
            Console.WriteLine($"Numbers Between 3 and 8: {string.Join(", ", Numbers2.Where(N => N > 3 && N < 8))}");

            Console.WriteLine("///////////////////////////////////////////////////////////////");
            List<int> Numbers3 = new List<int> { 44, 22, 55, 666, 9, -6, 345, 11, 3, -3 };

            Numbers3.Sort();
            Console.WriteLine($"Sorted in Ascending Order: { string.Join(", ", Numbers3)}");

            Numbers3.Sort();
            Numbers3.Reverse();
            Console.WriteLine($"Sorted in Descending Order: {string.Join(", ", Numbers3)}");

            // Using LINQ
            Console.WriteLine($"Sorted in Ascending Order: {string.Join(", ", Numbers3.OrderBy(N => N))}");

            Console.WriteLine($"Sorted in Descending Order: {string.Join(", ", Numbers3.OrderByDescending(N => N))}");

            // Custom Sorting Logic
            Numbers3.Sort((A, B) => Math.Abs(A).CompareTo(Math.Abs(B)));
            Console.WriteLine($"Sorted by Absolute Values: {string.Join(", ", Numbers3)}");

            Console.WriteLine("///////////////////////////////////////////////////////////////");
            Console.WriteLine($"Is List Contains 9? {Numbers3.Contains(9)}");
            Console.WriteLine($"List Contains Negative Number? {Numbers3.Exists(N => N < 0)}");
            Console.WriteLine($"First Negative Number: {Numbers3.Find(N => N < 0)}");
            Console.WriteLine($"All Negative Numbers: {string.Join(", ", Numbers3.FindAll(N => N < 0))}");
            Console.WriteLine($"Any numbers greater than 100? {Numbers3.Any(N => N > 100)}");

            Console.WriteLine("///////////////////////////////////////////////////////////////");
            // Fixing the initialization of the Persons list
            List<Person> People = new List<Person>
            {
                new Person("Rami", 22),
                new Person("Waleed", 30),
                new Person("Raed", 24),
                new Person("Qasem", 19),
            };

            Person FoundPerson = People.Find(P => P.Name == "Waleed");

            if (FoundPerson != null)
                Console.WriteLine($"Found Person Name: {FoundPerson.Name}\nFound Person Age: {FoundPerson.Age}");
            else
                Console.WriteLine("Person not Found");

            Console.WriteLine();
            List<Person> PeopleOver20 = People.FindAll(P => P.Age > 20);
            PeopleOver20.ForEach(P => Console.WriteLine($"Name: {P.Name}, Age: {P.Age}"));

            Console.WriteLine("///////////////////////////////////////////////////////////////");
            int[] Numbers3Array = Numbers3.ToArray();
            Console.WriteLine($"Array elements: {string.Join(", ", Numbers3Array)}");

            List<int> ArrayToList = new List<int>(Numbers3Array);
            Console.WriteLine($"List elements: {string.Join(", ", ArrayToList)}");
        }
    }
}

using System;

namespace TypeCasting
{
    internal class Program
    {
        enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat }
        static void Main(string[] args)
        {
            // Implicit Casting 
            int MyInt = 5;
            double MyDouble = MyInt;  // Automatic casting: int to double
            Console.WriteLine(MyDouble);
            // Explicit Casting
            double F = 10.5;
            int T = (int)F;

            Console.WriteLine(F);
            Console.WriteLine(T);

            // Type Conversion Methods
            bool MyBool = true;
            Console.WriteLine(Convert.ToInt32(MyBool));

            // Enums Conversion
            Console.WriteLine(Days.Sun);
            Console.WriteLine((int)Days.Sun);
            Console.WriteLine((Days)MyInt);

            // User Input
            Console.WriteLine("Enter Day Number (1-7):");
            int DayNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Day is: {(Days)DayNumber - 1}");

        }
    }
}

using System;

namespace DataTypes
{
    internal class Program
    {
        enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat }
        enum Status : byte { Active = 1, Inactive = 0 }

        struct Name
        {
            public string FirstName;
            public string LastName;
        }

        static void Main(string[] args)
        {
            byte b1 = 100;
            sbyte b2 = -100;

            Console.WriteLine($"b1: {b1} b2: {b2}");

            Console.WriteLine("Byte:");
            Console.WriteLine($"Min={Byte.MinValue} Max={Byte.MaxValue}");

            Console.WriteLine("SByte:");
            Console.WriteLine($"Min={SByte.MinValue} Max={SByte.MaxValue}");


            // hex and binary
            int hex = 0x2F;
            int binary = 0b_0100_0000;

            Console.WriteLine($"hex={hex} binary={binary}");


            // Default Values
            int i = default;
            char j = default;
            bool k = default;
            double l = default;

            Console.WriteLine($"i={i} j={j} k={k} l={l}");

            // Enums
            Days WeekDay = Days.Sun;

            //Nullable Types
            int? x = null;

            if (x.HasValue)
                Console.WriteLine(x);
            else
                Console.WriteLine("x has no value");


            // Anonymous Type
            var Student = new
            {
                Id = 0197878,
                FirstName = "Ali",
                LastName = "Al-Omari",

                Address = new { Id = 1, City = "Amman", Country = "Jordan" },
            };

            //Error anonymous type is readonly
            //you cannot change the values of properties as they are read-only.
            //Student.Id = 5;

            Console.WriteLine(Student.Address.Country);

            // Struct 
            Name r; // or Name r = new Name();

            r.FirstName = "Rami";
            r.LastName = "Qasem";

            Console.WriteLine($"{r.FirstName} {r.LastName}");

            // Dynamic Types
            dynamic MyDynamicVar = 100;
            Console.WriteLine(MyDynamicVar.GetType());

            MyDynamicVar = "string";
            Console.WriteLine(MyDynamicVar.GetType());

            var a = 10;     // int
            // a = "hi";   // compile error

        }
    }
}


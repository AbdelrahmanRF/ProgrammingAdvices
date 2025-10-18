using System;

namespace Constructor_and_Destructor
{
    class clsPerson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // Private constructor to prevent creating object from this class
        //clsPerson()
        //{

        //}

        //public clsPerson()
        //{
        //    ID = -1;
        //    Name = "Empty";
        //    Age = 0;
        //}

        public clsPerson(int ID, string Name, int Age)
        {
            this.ID = ID;
            this.Name = Name;
            this.Age = Age;
        }

        public static clsPerson Find(int id)
        {
            // Only for simulation
            if (id == 1)
                return new clsPerson(1, "Ahmad Ali", 25);

            return null;
        }

        public static clsPerson Find(string username, string password)
        {
            // Only for simulation

            if (username == "user3" && password == "Aaa12345")
                return new clsPerson(3, "Yazeed Ali", 30);

            return null;
        }

        // Destructor
        ~clsPerson()
        {
            Console.WriteLine("Destructor Called");
        }
    }

    static class Settings
    {
        public static int DayNumber
        {
            get
            {
                return DateTime.Today.Day;
            }
        }

        public static string DayName
        {
            get
            {
                return DateTime.Today.DayOfWeek.ToString();
            }
        }

        public static string ProjectPath { get; set; }

        // Static constructor will be called once during the program
        // Static constructor is parameter-less only
        static Settings()
        {
            ProjectPath = @"C:\Projects\";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //clsPerson Person1 = new clsPerson();
            //Console.WriteLine($"ID : {Person1.ID}");
            //Console.WriteLine($"Name : {Person1.Name}");
            //Console.WriteLine($"Age : {Person1.Age}");

            //Console.WriteLine("\n-----------------------------------\n");

            //clsPerson Person2 = new clsPerson(1, "Ahmad Ali", 25);

            clsPerson Person2 = clsPerson.Find(11);

            if (Person2 != null)
            {
                Console.WriteLine($"ID : {Person2.ID}");
                Console.WriteLine($"Name : {Person2.Name}");
                Console.WriteLine($"Age : {Person2.Age}");
            }
            else
            {
                Console.WriteLine("Could not find person by the given ID");
            }

            Console.WriteLine("\n-----------------------------------\n");

            clsPerson Person3 = clsPerson.Find("user3", "Aaa12345");

            if (Person3 != null)
            {
                Console.WriteLine($"ID : {Person3.ID}");
                Console.WriteLine($"Name : {Person3.Name}");
                Console.WriteLine($"Age : {Person3.Age}");
            }
            else
            {
                Console.WriteLine("Could not find person by the given username and password");
            }

            Console.WriteLine("\n-----------------------------------\n");
        }
    }
}

using System;

namespace Class___Object
{
    class clsPerson
    {
        public string FirstName;
        public string LastName;

        public string FullName()
        {
            return FirstName + ' ' + LastName;
        }
    }

    class clsA
    {
        public int x = 10;
        private int y = 20;
        protected int z = 30;

        public static int st = 40;
        public int FuncA()
        {
            return 100 + st;
        }

        private int FuncB()
        {
            return 200;
        }

        protected int FuncC()
        {
            return 300;
        }

        public static int FuncSt()
        {
            return st;
        }

    }

    class clsB : clsA
    {
        public int FuncD()
        {
            return x + z;
        }
    }

    class clsEmployee
    {
        private int _ID;
        private string _Name = string.Empty;

        // Read Only
        public int ID
        {
            get
            {
                return _ID;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }
    }

    class clsEmployeeAuto
    {
        public int ID
        {
            get;
        }

        public string Name
        {
            get;
            set;
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

        public static string ProjectPath
        {
            get;
            set;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n////////////////////////////////////////////////\n");

            clsPerson Person1 = new clsPerson();

            Person1.FirstName = "Ali";
            Person1.LastName = "Salman";

            Console.WriteLine(Person1.FullName());

            Console.WriteLine("\n////////////////////////////////////////////////\n");

            clsA A = new clsA();
            clsB B = new clsB();

            Console.WriteLine("Class A:");
            Console.WriteLine(A.x);
            Console.WriteLine(A.FuncA());
            Console.WriteLine(clsA.FuncSt());
            Console.WriteLine(clsA.st);

            clsA.st = 400;
            Console.WriteLine(clsA.st);

            Console.WriteLine("\nClass B:");
            Console.WriteLine(B.x);
            Console.WriteLine(B.FuncA());
            Console.WriteLine(B.FuncD());

            Console.WriteLine("\n////////////////////////////////////////////////\n");

            clsEmployee Emp1 = new clsEmployee();

            Emp1.Name = "Test";

            Console.WriteLine($"Emp1 ID: {Emp1.ID}, Emp1 Name: {Emp1.Name}");

            clsEmployeeAuto Emp2 = new clsEmployeeAuto();
            Emp2.Name = "Test2";

            Console.WriteLine($"Emp2 ID: {Emp2.ID}, Emp2 Name: {Emp2.Name}");

            Console.WriteLine("\n////////////////////////////////////////////////\n");

            Console.WriteLine(Settings.DayNumber);
            Console.WriteLine(Settings.DayName);

            Settings.ProjectPath = @"C:\Projects\";
            Console.WriteLine(Settings.ProjectPath);
        }
    }
}

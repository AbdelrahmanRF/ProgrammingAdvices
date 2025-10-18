using System;

namespace Inheritance
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public Person(int ID, string FirstName, string LastName, string Title)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Title = Title;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"ID          : {ID}");
            Console.WriteLine($"FullName    : {FullName}");
            Console.WriteLine($"Title       : {Title}");
        }

        public virtual void Greet()
        {
            Console.WriteLine("**********************************************************");
            Console.WriteLine($"Hello I am {FullName}, My title {Title}");
            Console.WriteLine("**********************************************************");
        }
    }

    // Single Inheritance
    public class Employee : Person
    {
        public float Salary { get; set; }
        public string Department { get; set; }

        public Employee(int ID, string FirstName, string LastName, string Title, float Salary, string Department) 
            : base(ID, FirstName, LastName, Title)
        {
            this.Salary = Salary;
            this.Department = Department;
        }

        public float IncreaseSalaryByAmount(float Amount)
        {
            return Salary + Amount;
        }

        // Overriding 
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Salary      : {Salary}");
            Console.WriteLine($"Department  : {Department}");
        }

        // Method Hiding/Shadowing
        public new void Greet()
        {
            Console.WriteLine("**********************************************************");
            Console.WriteLine($"Hello I am {FullName}, I Work at {Department} Department");
            Console.WriteLine("**********************************************************");

        }
    }

    // Multi Level Inheritance
    public class Manager : Employee
    {
        public int TeamSize { get; set; }
        public string OfficeNumber { get; set; }

        public Manager(int ID, string FirstName, string LastName, string Title, float Salary, string Department, int TeamSize, string OfficeNumber) : 
            base(ID, FirstName, LastName, Title, Salary, Department)
        {
            this.TeamSize = TeamSize;
            this.OfficeNumber = OfficeNumber;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Team Size   : {TeamSize}");
            Console.WriteLine($"Office Num  : {OfficeNumber}");
            Console.WriteLine("---------------------------------------------");
        }
    }

    // Hierarchal Inheritance
    public class Student : Person
    {
        public string University { get; set; }
        public string Major { get; set; }
        public float GPA { get; set; }
        public int Year { get; set; }

        public Student(int ID, string FirstName, string LastName, string Title,
               string University, string Major, float GPA, int Year)
        : base(ID, FirstName, LastName, Title)
        {
            this.University = University;
            this.Major = Major;
            this.GPA = GPA;
            this.Year = Year;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"University  : {University}");
            Console.WriteLine($"Major       : {Major}");
            Console.WriteLine($"GPA         : {GPA}");
            Console.WriteLine($"Year        : {Year}");
            Console.WriteLine("---------------------------------------------");
        }
    }

        internal class Program
    {
        static void Main(string[] args)
        {
            Employee Emp1 = new Employee(1, "Ahmad", "Ali", "Software Engineer |", 800, "Back-End");

            Emp1.PrintInfo();
            Emp1.Greet();

            // Upcasting 
            Person P = Emp1;
            //Console.WriteLine(P.Salary); // Compile error — P is a Person
            P.PrintInfo(); // Calls Employee.PrintInfo(), because object is Employee

            // Calls Person.Greet() 
            // because compiler looks only at the reference type (Person) when the method is hidden (not overridden)
            P.Greet();

            // Downcasting
            Person P2 = new Employee(2, "Zaid", "Mohammed", "Software Engineer ||", 800, "Back-End");
            Employee Emp2 = (Employee)P2;
            Emp2.PrintInfo();


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Manager M1 = new Manager(1, "Qasem", "Nemer", "Software Engineer Manager", 5000, "Back-End", 8, "A2-1");
            M1.PrintInfo();

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Student S1 = new Student(3, "Omar", "Khaled", "Student", "University of Jordan", "Computer Science", 3.8f, 3);
            S1.PrintInfo();
        }
    }
}

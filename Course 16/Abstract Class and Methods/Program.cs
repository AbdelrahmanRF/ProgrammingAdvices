using System;

namespace Abstract_Class_and_Methods
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public abstract void Introduce();

        public void SayGoodbye()
        {
            Console.WriteLine("Goodbye");
        }
    }

    public class Employee : Person
    {
        public int EmpID { get; set; }
        public override void Introduce()
        {
            Console.WriteLine($"Hi, my name is: {FirstName} {LastName} and my Employee ID : {EmpID}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee Emp1 = new Employee();

            Emp1.EmpID = 123;
            Emp1.FirstName = "Ahmad";
            Emp1.LastName = "Ali";

            Emp1.Introduce();
            Emp1.SayGoodbye();
        }
    }
}

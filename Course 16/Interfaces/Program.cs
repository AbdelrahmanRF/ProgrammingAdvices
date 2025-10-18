using System;

namespace Interfaces
{
    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        void Introduce();

        void SayGoodbye();
    }

    public interface ICommunicate
    {
        void CallPhone();

        void SendEmail(string Title, string Body);

        void SendSMS(string Title, string Body);
    }

    public abstract class Person : IPerson, ICommunicate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public void Introduce() 
        {
            Console.WriteLine($"Hi, my name is: {FirstName} {LastName}");
        }

        public void SayGoodbye()
        {
            Console.WriteLine("Goodbye");
        }

        public void CallPhone()
        {
            Console.WriteLine("Phone Called");
        }

        public void SendEmail(string Title, string Body)
        {
            Console.WriteLine("Email Sent");
        }

        public void SendSMS(string Title, string Body)
        {
            Console.WriteLine("SMS Sent");
        }
    }

    public class Employee : Person
    {

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee Emp = new Employee();

            Emp.SendEmail("Hello", "Body");
        }
    }
}

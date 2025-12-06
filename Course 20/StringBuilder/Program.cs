using System;
using System.Text;

namespace StringBuilderExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "Hello";
            s += " World";   // Creates a NEW object

            StringBuilder sb = new StringBuilder("Hello");
            sb.Append(" World"); // Modifies SAME object

            sb.Insert(5, " C#");
            sb.Replace("World", "Developer");
            sb.Remove(5, 3);

            Console.WriteLine(sb.ToString());

        }
    }
}

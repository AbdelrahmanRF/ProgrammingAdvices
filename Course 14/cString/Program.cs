using System;

namespace cString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string S1 = "Focusing on the Present";

            Console.WriteLine(S1.Length);

            Console.WriteLine(S1.Substring(0, 8));
            Console.WriteLine(S1.ToLower());
            Console.WriteLine(S1.ToUpper());
            Console.WriteLine(S1[0]);
            Console.WriteLine(S1.Insert(23, " :-)"));
            Console.WriteLine(S1.Replace("F", "f"));
            Console.WriteLine(S1.IndexOf("t"));
            Console.WriteLine(S1.Contains("t"));
            Console.WriteLine(S1.Contains("x"));
            Console.WriteLine(S1.LastIndexOf("e"));


            string S2 = "Ali,Ahmed,Khalid";

            string[] FullName = S2.Split(',');

            Console.WriteLine($"{FullName[0]} {FullName[1]} {FullName[2]}");

            string S3 = "  Present  ";
            Console.WriteLine(S3.Trim());
            Console.WriteLine(S3.TrimStart());
            Console.WriteLine(S3.TrimEnd());
        }
    }
}

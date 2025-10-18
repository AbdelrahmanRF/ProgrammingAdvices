using System;
using Class_Library;

namespace dot_NET_Class_Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyMath myMath = new MyMath();

            Console.WriteLine(myMath.Sum(6,6));
            Console.WriteLine(myMath.Sum(6,6, 10));
        }
    }
}

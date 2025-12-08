using System;
using System.Reflection;

namespace OperatorOverloading
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int X, int Y) 
        { 
            this.X = X; 
            this.Y = Y; 
        }

        public static Point operator+ (Point P1, Point P2)
        {
            return new Point(P1.X + P2.X, P1.Y + P2.Y);
        }

        public static Point operator -(Point P1, Point P2)
        {
            return new Point(P1.X - P2.X, P1.Y - P2.Y);
        }

        public static bool operator ==(Point P1, Point P2)
        {
            return P1.X == P2.X && P1.Y == P2.Y;
        }

        public static bool operator !=(Point P1, Point P2)
        {
            return P1.X != P2.X || P1.Y == P2.Y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Point P1 = new Point(1, 2);
            Point P2 = new Point(3, 4);

            Point P3 = P1 + P2;
            Point P4 = P3 - P1;

            Console.WriteLine($"Point1 : {P1.ToString()}");
            Console.WriteLine($"Point2 : {P2.ToString()}");
            Console.WriteLine($"Point3 is the result of P1 + P2: {P3.ToString()}");
            Console.WriteLine($"Point4 is the result of P3 - P1: {P4.ToString()}");

            if (P1 == P2)
                Console.WriteLine("Using == : Yes, P1 = P2");
            else
                Console.WriteLine("Using == : No, P1 does not equal P2");

            // Using the overloaded != operator for point inequality
            if (P1 != P2)
                Console.WriteLine("Using != : Yes, P1 does not equal P2");
            else
                Console.WriteLine("Using != : No, P1 = P2");
        }
    }
}

using System;

namespace Operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 10;

            // Arithmetic Operators
            x += 5;  // x = x + 5  → 15
            x -= 3;  // x = x - 3  → 12
            x *= 2;  // x = x * 2  → 24
            x /= 4;  // x = x / 4  → 6
            x %= 5;  // x = x % 5  → 1  (remainder)

            x = 6;   // binary: 110
            int y = 3;   // binary: 011

            // Bitwise and Bit Shift Operators
            x &= y;  // Bitwise AND Assignment  x = x & y   → 2  (binary 010)
            x |= y;  // Bitwise OR Assignment   x = x | y   → 3  (binary 011)
            x ^= y;  // Bitwise XOR Assignment  x = x ^ y   → 1  (binary 001)

            x = 6;
            x <<= 2; 
            // x = x << 2  → shifts left by 2 bits
            // 6 << 2 → 24 (binary 110 → 0001 1000)

            x >>= 1;
            // x = x >> 1  → shifts right by 1 bit
            // 24 >> 1 → 12 (binary 0001 1000 → 0000 1100)

            // Relational Operators
            Console.WriteLine(x == y);  // false
            Console.WriteLine(x != y);  // true
            Console.WriteLine(x > y);   // true
            Console.WriteLine(x < y);   // false
            Console.WriteLine(x >= 5);  // true
            Console.WriteLine(y <= 10); // true

            // Logical Operators
            int Age = 20;
            bool HasID = true;
            bool WithParent = true;
            bool IsRaining = false;

            // && (Logical AND)
            if (Age >= 18 && HasID) 
                Console.WriteLine("You are allowed to access");

            // || (Logical OR)
            if (Age >= 18 || WithParent)
                Console.WriteLine("You are allowed to enter");

            // ! (Logical NOT)
            if (!IsRaining)
                Console.WriteLine("Let\'s go outside");

            // Unary Operators
            int Number = 10;
            Console.WriteLine(++Number);
            Console.WriteLine(--Number);

            string Status = Age >= 18 ? "Adult" : "Minor";
            Console.WriteLine(Status);

        }
    }
}

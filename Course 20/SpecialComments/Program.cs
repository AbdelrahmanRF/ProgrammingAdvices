using System;

namespace SpecialComments
{
    internal class Program
    {
        /// <summary>
        /// This class represents simple calculator
        /// </summary>
        public class Calculator
        {
            /// <summary>
            /// Adds two numbers and returns the result
            /// </summary>
            /// <param name="x">The first number to be added</param>
            /// <param name="y">The second number to be added</param>
            /// <returns>The sum of two numbers</returns>
            public int Add(int x, int y)
            {
                return x + y;
            }

            /// <summary>
            /// Subtracts the second number from the first and returns the result
            /// </summary>
            /// <param name="x">The number to be subtracted from</param>
            /// <param name="y">The number to subtract</param>
            /// <returns>The difference of the two numbers</returns>
            public int Subtract(int x, int y)
            {
                return x - y;
            }

            /// <summary>
            /// Multiplies two numbers and returns the result
            /// </summary>
            /// <param name="x">The first number to multiply</param>
            /// <param name="y">The second number to multiply</param>
            /// <returns>The product of the two numbers</returns>
            public int Multiply(int x, int y)
            {
                return x * y;
            }

            /// <summary>
            /// Divides the first number by the second and returns the result
            /// </summary>
            /// <param name="x">The dividend (the number to be divided)</param>
            /// <param name="y">The divisor (the number to divide by)</param>
            /// <returns>The quotient as a double precision number</returns>
            /// <exception cref="DivideByZeroException">Thrown when y is zero</exception>
            public double Divide(int x, int y)
            {
                if (y == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero.");
                }

                return (double)x / y;
            }
        }

        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            Console.WriteLine(calculator.Add(5, 10));
        }
    }
}

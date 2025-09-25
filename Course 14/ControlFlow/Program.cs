using System;

namespace ControlFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /////////////////////////////////////////////////////
            
            int Mark = 75;

            if (Mark >= 90)
                Console.WriteLine("Grade: A");
            else if (Mark >= 80)
                Console.WriteLine("Grade: B");
            else if (Mark >= 70)
                Console.WriteLine("Grade: C");
            else if (Mark >= 60)
                Console.WriteLine("Grade: D");
            else
                Console.WriteLine("Grade: F");

            /////////////////////////////////////////////////////
            
            int Age = 25;
            bool HasID = true;

            if (Age >= 18)
            {
                if (HasID)
                    Console.WriteLine("You are allowed to enter.");
                else
                    Console.WriteLine("You need an ID.");
            }
            else
                Console.WriteLine("You are under 18.");

            /////////////////////////////////////////////////////

            /* char ch;
            Console.WriteLine("Enter a letter?");

            ch = Convert.ToChar(Console.ReadLine());

            switch(Char.ToLower(ch))
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    Console.WriteLine($"{ch} is Vowel");
                    break;
                default:
                    Console.WriteLine($"{ch} not a Vowel");
                    break;
            }*/

/*            char Op;
            double First, Second, Result;

            Console.Write("Enter first number: ");
            First = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second number: ");
            Second = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter operator (+, -, *, /): ");
            Op = (char)Console.Read();

            switch(Op)
            {
                case '+':
                    Result = First + Second;
                    Console.WriteLine($"{First} + {Second} = {Result}");
                    break;

                case '-':
                    Result = First - Second;
                    Console.WriteLine($"{First} - {Second} = {Result}");
                    break;

                case '*':
                    Result = First * Second;
                    Console.WriteLine($"{First} * {Second} = {Result}");
                    break;

                case '/':
                    Result = First / Second;
                    Console.WriteLine($"{First} / {Second} = {Result}");
                    break;

                default:
                Console.WriteLine("Invalid Operator");
                break;
            }*/

            /////////////////////////////////////////////////////

            string Eligibility = (Age >= 18) ? "Adult" : "Minor";
            Console.WriteLine($"Age {Age} is considered: {Eligibility}");

            /////////////////////////////////////////////////////

            for (int j = 1; j <= 5; j++)
            {
                if (j == 3) continue;
                Console.WriteLine("Iteration: " + j);
            }
            Console.WriteLine();

            int i = 1;
            while (i <= 5)
            {
                if (i == 3) break;

                Console.WriteLine("Iteration: " + i);
                i++;
            }
            Console.WriteLine();

            i = 1;
            do
            {
                Console.WriteLine("Iteration: " + i);
                i++;

            } while (i <= 5);
        }
    }
}

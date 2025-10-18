using System;

namespace Misc1
{
    // Partial Class
    public partial class MyClass
    {
        public int Age { get; set; }

        // Partial Method
        partial void PrintAge();
        public void Method1()
        {
            Console.WriteLine("Method 1 called");
        }

        public void Birthday()
        {
            Age++;
            PrintAge();
        }
    }
}

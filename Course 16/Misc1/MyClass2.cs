using System;

namespace Misc1
{
    // Partial Class
    public partial class MyClass
    {
        public void Method2()
        {
            Console.WriteLine("Method 2 called");
        }

        // Partial Method
        partial void PrintAge()
        {
            Console.WriteLine($"Current Age : {Age}");
        }
    }
}

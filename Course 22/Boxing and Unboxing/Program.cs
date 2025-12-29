using System;

namespace Boxing_and_Unboxing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int valueType = 4;
            object objType = valueType; // Boxing 

            Console.WriteLine($"Value Type    : {valueType}"); // From Stack
            Console.WriteLine($"Object Type   : {objType}"); // From Heap
            
            int unboxedValType = (int)objType; // Unboxing 
            Console.WriteLine($"Unboxed Value : {unboxedValType}");
        }
    }
}

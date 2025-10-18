using System;
using Class_Library;
// Nested Class
public class OuterClass
{
    private int OuterVariable;

    public OuterClass(int OuterVariable)
    {
        this.OuterVariable = OuterVariable;
    }

    public void OuterMethod()
    {
        Console.WriteLine("OuterMethod Called");
    }

    public class InnerClass
    {
        private int InnerVariable;

        public InnerClass(int InnerVariable)
        {
            this.InnerVariable = InnerVariable;
        }

        public void InnerMethod()
        {
            Console.WriteLine($"InnerMethod Called with InnerVariable = {InnerVariable}");
        }

        public void AccessOuterVariable(OuterClass Outer)
        {
            Console.WriteLine($"Accessing Outer Variable From Inner Class = {Outer.OuterVariable}");
        }
    }
}

// Composition
public class clsA
{
    public void Method1()
    {
        // Defining an object of another class inside this class is called Composition
        OuterClass Outer = new OuterClass(100);
        Outer.OuterMethod();
    }
}

// Sealed Classes
sealed class clsB
{

}
// Error
//public class clsC : clsB
//{
//
//}

// Sealed Methods
public class Person
{
    public virtual void Greet()
    {
        Console.WriteLine("The person says hello.");
    }
}

public class Employee : Person
{
    public sealed override void Greet()
    {
        Console.WriteLine("The employee says hello.");
    }
}

public class Manger : Employee
{
    // Error cannot be overridden 
    //public override void Greet()
    //{
    //    Console.WriteLine("The Manger says hello.");
    //}
}


namespace Misc1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OuterClass Outer1 = new OuterClass(100);

            OuterClass.InnerClass Inner1 = new OuterClass.InnerClass(200);

            Outer1.OuterMethod();
            Inner1.InnerMethod();
            Inner1.AccessOuterVariable(Outer1);

            ////////////////////////////////////////////////////////////////////

            MyClass myClass = new MyClass();
            myClass.Method1();
            myClass.Method2();

            myClass.Age = 25;
            myClass.Birthday();

            ////////////////////////////////////////////////////////////////////

            // Class Library
            MyMath myMath = new MyMath();
            Console.WriteLine(myMath.Sum(5,6,7));
        }
    }
}

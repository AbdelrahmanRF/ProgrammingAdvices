//#define DEBUG
#define TRACE_ENABLED
//#define TRACE_ENABLED2
using System.Diagnostics;
using System;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    class HintAttribute : Attribute
    {
        public string Description { get; }

        public HintAttribute(string Description)
        {
            this.Description = Description;
        }
    }

    internal class Program
    {
        [Serializable]
        class MyClass
        {
            public int SerializedField;

            [NonSerialized]
            public int NonSerializedField;
        }

        class MyClass2
        {
            [Conditional("DEBUG")]
            public void DebugMethod()
            {
                Console.WriteLine("Debug Method Executed");
            }

            [Conditional("TRACE_ENABLED")]
            public void TraceMessage(string Message)
            {
                Console.WriteLine($"[Trace] {Message}");
            }

            [Conditional("TRACE_ENABLED2")]
            public void TraceMessage2(string Message)
            {
                Console.WriteLine($"[Trace 2] {Message}");
            }

            //Note:
            //The[Conditional] attribute can only be applied to methods that return void.
            //It cannot be used with methods that return a value.
            //[Conditional("TRACE_ENABLED2")]
            //public int DebugMethod3()
            //{
            //    return 0;
            //}

            [Obsolete("This method is deprecated, Use NewMethod instead")]
            public void OldMethod()
            {
                Console.WriteLine("Warning but still compiles");
            }

            [Obsolete("This method is removed", true)]
            public void OldMethod2()
            {
                Console.WriteLine("compile-time ERROR");
            }

            [Hint("Recommended Method instead of OldMethod")]
            public void NewMethod()
            {
                Console.WriteLine("New Method Executed");
            }

            public void NormalMethod()
            {
                Console.WriteLine("Normal Method Executed");
            }
        }


        static void Main(string[] args)
        {
            MyClass2 myClass2 = new MyClass2();

            myClass2.DebugMethod();
            myClass2.TraceMessage("Trace Message");
            myClass2.TraceMessage2("Trace 2 Message");
            myClass2.NormalMethod();
            myClass2.OldMethod(); // Generates Compiler Warning
            //myClass2.OldMethod2(); // Error
        }
    }
}

using System;
using System.Reflection;
using System.Linq;

namespace Reflection
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class MyCustomAttribute : Attribute
    {
        public string Description { get; }
        public MyCustomAttribute(string Description) 
        { 
            this.Description = Description;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RangeAttribute : Attribute
    {
        public int Min { get; }
        public int Max { get; }

        public string ErrorMessage { get; set; }

        public RangeAttribute(int Min, int Max)
        {
            this.Min = Min;
            this.Max = Max;
        }
    }

    [MyCustom("This is Class Attribute")]
    public class MyClass
    {
        public int Property1 { get; set; }

        [MyCustom("This is Method Attribute")]
        public void Method1()
        {
            Console.WriteLine("\tMethod 1 is Executed");
        }

        public void Method2(string Value1, int Value2)
        {
            Console.WriteLine($"\tMethod 2 is Executed with parameters: {Value1}, {Value2}");
        }
    }

    public class Person
    {
        public string Name { get; set; }

        [Range(18, 99, ErrorMessage = "Age Must be between 18 and 99")]
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Type myType = typeof(string);

            Console.WriteLine("Type Information:");
            Console.WriteLine($"Name: {myType.Name}");
            Console.WriteLine($"Full Name: {myType.FullName}");
            Console.WriteLine($"Is Class: {myType.IsClass}");

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Assembly mscrolib = typeof(string).Assembly;

            Type stringType = mscrolib.GetType("System.String");

            if (stringType != null)
            {
                Console.WriteLine("Methods of System.String class:\n");

                var stringMethods = stringType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .OrderBy(m => m.Name);

                foreach (var Method in stringMethods)
                {
                    Console.WriteLine($"\t{Method.ReturnType} {Method.Name}({GetParameterList(Method.GetParameters())})");
                }

            }

            string GetParameterList(ParameterInfo[] parameters)
            {
                return string.Join(", ", parameters.Select(p => $"{p.ParameterType} {p.Name}"));
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            Type myClassType = typeof(MyClass);

            if (myClassType != null)
            {
                Console.WriteLine($"Type Name: {myClassType.Name}");
                Console.WriteLine($"Full Name: {myClassType.FullName}");
                Console.WriteLine();

                Console.WriteLine("Properties");
                var MyClassProperties = myClassType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .OrderBy(prop => prop.Name);

                foreach (PropertyInfo prop in MyClassProperties)
                {
                    Console.WriteLine($"Property Name: {prop.Name}, Type: {prop.PropertyType}");
                }
                Console.WriteLine();

                Console.WriteLine("Methods\n");
                var MyClassMethods = myClassType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .OrderBy(Method => Method.Name);

                foreach (var Method in MyClassMethods)
                {
                    Console.WriteLine($"\t{Method.ReturnType} {Method.Name}({GetParameterList(Method.GetParameters())})");
                }
                Console.WriteLine();

                Console.WriteLine("Class Attributes");
                object[] Attributes = myClassType.GetCustomAttributes(typeof(MyCustomAttribute), false);
                foreach (MyCustomAttribute Attribute in Attributes)
                {
                    Console.WriteLine($"Class Attribute: {Attribute.Description}");
                }
                Console.WriteLine();

                Console.WriteLine("Method1 Attributes");
                MemberInfo method1Info = myClassType.GetMethod("Method1");
                object[] method1Attributes = method1Info.GetCustomAttributes(typeof(MyCustomAttribute), false);
                foreach (MyCustomAttribute Attribute in method1Attributes)
                {
                    Console.WriteLine($"Class Attribute: {Attribute.Description}");
                }
                Console.WriteLine();


                Console.WriteLine("Set Property1 to 42 using Reflection\n");
                object obj = Activator.CreateInstance(myClassType);
                PropertyInfo Prop = myClassType.GetProperty("Property1");
                Prop.SetValue(obj, 42);

                Console.WriteLine("Getting Property1 value using Reflection");
                Console.WriteLine($"\tProperty1 Value: {Prop.GetValue(obj)}");

                Console.WriteLine("Executing Methods using Reflection\n");
                myClassType.GetMethod("Method1").Invoke(obj, null);

                object[] Parameters = { "Omar", 24 };
                myClassType.GetMethod("Method2").Invoke(obj, Parameters);

            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            Person person1 = new Person { Name = "Omar Salameh", Age = 24 };

            if (ValidatePerson(person1))
                Console.WriteLine("Person is Valid");
            else
                Console.WriteLine("Person is not Valid");

            bool ValidatePerson(Person person)
            {
                Type PersonType = typeof(Person);

                foreach(var Property in PersonType.GetProperties())
                {
                    if (Attribute.IsDefined(Property, typeof(RangeAttribute)))
                    {
                        var RangeAttribute = (RangeAttribute)Attribute.GetCustomAttribute(Property, typeof(RangeAttribute));
                        int Value = (int)Property.GetValue(person);

                        if (Value < RangeAttribute.Min || Value > RangeAttribute.Max)
                        {
                            Console.WriteLine($"Validation failed for Property '{Property.Name}' : {RangeAttribute.ErrorMessage}");
                            return false;
                        }
                    }
                }

                return true;
            }
        }
    }
}

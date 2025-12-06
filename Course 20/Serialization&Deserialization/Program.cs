using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace Serialization_Deserialization
{
    //[Serializable]
    //public class Person
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //}

    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Person Person1 = new Person{ Name = "Rami", Age = 28 };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

            using(TextWriter tw = new StreamWriter("person.xml"))
            {
                xmlSerializer.Serialize(tw, Person1);
            }

            using(TextReader tr = new StreamReader("person.xml"))
            {
                Person DeserializedPerson = (Person)xmlSerializer.Deserialize(tr);
                Console.WriteLine($"Name = {DeserializedPerson.Name}, Age = {DeserializedPerson.Age}");
            }

            Person Person2 = new Person { Name = "Omar", Age = 25 };

            DataContractJsonSerializer DCJSONSerializer = new DataContractJsonSerializer(typeof(Person));

            using(MemoryStream ms = new MemoryStream())
            {
                DCJSONSerializer.WriteObject(ms, Person2);

                string JSONString = System.Text.Encoding.UTF8.GetString(ms.ToArray());

                File.WriteAllText("person.json", JSONString);
            }

            using (FileStream fs = new FileStream("person.json", FileMode.Open))
            {
                Person DeserializedPerson = (Person)DCJSONSerializer.ReadObject(fs);
                Console.WriteLine($"Name = {DeserializedPerson.Name}, Age = {DeserializedPerson.Age}");
            }
        }
    }
}

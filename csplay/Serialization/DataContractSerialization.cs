using System;
using System.Runtime.Serialization;
using System.IO;

using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace csplay
{
    public class DataContractSerialization
    {
        [DataContract]
        public class Person
        {
            [DataMember] public string Name;
            [DataMember] public int Age;
        }

        public static void Start(string[] args)
        {
            Person p = new Person { Name = "Stacey", Age = 30 };
            var ds = new DataContractSerializer(typeof(Person));
            using (Stream s = File.Create("person.xml"))
            {
                ds.WriteObject(s, p); // Serialize
            }

            Person p2;

            using (Stream s = File.OpenRead("person.xml"))
            {
                p2 = (Person)ds.ReadObject(s); // Deserialize
            }

            Console.WriteLine(p2.Name + " " + p2.Age); // Stacey 30
        }
    }
}
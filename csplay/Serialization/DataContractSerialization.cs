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
        private const string fileName = "person.xml";

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

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter w = XmlWriter.Create(fileName, settings))
            {
                ds.WriteObject(w, p);
            }

            Person p2;

            using (Stream s = File.OpenRead(fileName))
            {
                p2 = (Person)ds.ReadObject(s); // Deserialize
            }

            Console.WriteLine(p2.Name + " " + p2.Age); // Stacey 30
            File.Delete(fileName);
        }
    }
}
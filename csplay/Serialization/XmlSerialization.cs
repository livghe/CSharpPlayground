using System;
using System.IO;
using System.Xml.Serialization;

public class XmlSerialization
{
    [XmlInclude(typeof(Student))]
    [XmlInclude(typeof(Teacher))]
    public class Person
    {
        [XmlElement("FirstName")]
        public string Name; // this will be saved with the XML elemenet "FirstName", not "Name".

        public int Age;

        [XmlAttribute]
        public string Address; // this will not be serialized to an XML name, but rathar an attribute.

        [XmlIgnore]
        public DateTime DateOfBirth; // will not be Xml-ser/des.
    }

    public class Student : Person { }
    public class Teacher : Person { }

    public void SerializePerson(Person p, string path)
    {
        // if p is a Student or a Teacher, the XmlSerializer will not know how to serialize it, unless instructed with [XmlInclude(typeof(Student))] & [XmlInclude(typeof(Teacher))]
        XmlSerializer xs = new XmlSerializer(typeof(Person));
        using (Stream s = File.Create(path))
        {
            xs.Serialize(s, p);
        }

        // 2nd option is to specify it in the XmlSerializer, like this:
        XmlSerializer xs2 = new XmlSerializer(typeof(Person), new Type[] { typeof(Student), typeof(Teacher) });

    }

    public static void Start(string[] args)
    {
        Person p = new Person() { Name = "Stacey", Age = 30, Address = "Splaiul Independentei 500", DateOfBirth = DateTime.Now };

        XmlSerializer xs = new XmlSerializer(typeof(Person));

        using (Stream s = File.Create("person.xml"))
        {
            xs.Serialize(s, p);
        }

        Person p2;
        using (Stream s = File.OpenRead("person.xml"))
        {
            p2 = (Person)xs.Deserialize(s);
        }

        Console.WriteLine(p2.Name + " " + p2.Age); // Stacey 30
    }
}
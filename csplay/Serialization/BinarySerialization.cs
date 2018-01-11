using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections.Generic;

public class BinarySerialization
{
    // 1st variant: using the Serializable attribute
    [Serializable]
    class Person
    {
        public string Name;
        public int Age;

        [NonSerialized]
        public string Address; // this field will not be ser/des

        public bool Valid;

        [OptionalField(VersionAdded = 2)] public DateTime DateOfBirth; // if added later, we can still ser/des this class even if versions mismatch.

        [OnDeserializing]
        void OnDeserializing(StreamingContext context)
        {
            Valid = true;
        }

        [OnDeserialized]
        void OnDeserialized(StreamingContext context)
        {
            TimeSpan ts = DateTime.Now - DateOfBirth;
            Age = ts.Days / 365; // Rough age in years
        }


        // ISerializable offers full control of what fields get ser/des
        [Serializable]
        public class Team : ISerializable
        {
            public string Name;
            public List<Person> Players;
            public virtual void GetObjectData(SerializationInfo si, StreamingContext sc)
            {
                si.AddValue("Name", Name);
                si.AddValue("PlayerData", Players.ToArray());
            }

            public Team() { }

            // any class implementing ISerializable, must have a ctor with the same parameters as GetObjectData().
            protected Team(SerializationInfo si, StreamingContext sc)
            {
                Name = si.GetString("Name");
                // Deserialize Players to an array to match our serialization:
                Person[] a = (Person[])si.GetValue("PlayerData", typeof(Person[]));
                // Construct a new List using this array:
                Players = new List<Person>(a);
            }
        }
    }

    public static void Start(string[] args)
    {
        Person p = new Person() { Name = "George", Age = 25 };
        IFormatter formatter = new BinaryFormatter();
        using (FileStream s = File.Create("serialized.bin"))
        {
            formatter.Serialize(s, p);
        }

        using (FileStream s = File.OpenRead("serialized.bin"))
        {
            Person p2 = (Person)formatter.Deserialize(s);
            Console.WriteLine(p2.Name + " " + p.Age); // George 25
        }
    }
}
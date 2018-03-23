using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace csplay
{
    class Reflect
    {
        public static void Start(string[] args)
        {
            Console.WriteLine("\nReflection:");
            Type t1 = DateTime.Now.GetType(); // Type obtained at runtime
            Type t2 = typeof(DateTime); // Type obtained at compile time

            Type t3 = typeof(DateTime[]); // 1-d Array type
            Type t4 = typeof(DateTime[,]); // 2-d Array type
            Type t5 = typeof(Dictionary<int, int>); // Closed generic type
            Type t6 = typeof(Dictionary<,>); // Unbound generic type

            Type t = Assembly.GetExecutingAssembly().GetType("XmlSerialization");

            Type stringType = typeof(string);
            string name = stringType.Name; // String
            Type baseType = stringType.BaseType; // typeof(Object)
            Assembly assem = stringType.Assembly; // mscorlib.dll
            bool isPublic = stringType.IsPublic; // true

            foreach (Type x in typeof(System.Environment).GetNestedTypes())
            {
                Console.WriteLine(x.FullName);
            }

            // gettng base types:
            Type base1 = typeof(System.String).BaseType;
            Type base2 = typeof(System.IO.FileStream).BaseType;
            Console.WriteLine(base1.Name); // Object
            Console.WriteLine(base2.Name); // Stream

            // get interfaces that a type implements
            foreach (Type iType in typeof(Guid).GetInterfaces())
            {
                Console.WriteLine(iType.Name);
            }

            // instantiating types at runtime through Reflection
            DateTime dt = (DateTime)Activator.CreateInstance(typeof(DateTime), 2000, 1, 1);
        }
    }
}

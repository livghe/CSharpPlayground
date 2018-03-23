using System;
using System.Reflection;

namespace csplay
{
    class Assemblies
    {
        public static void Start(string[] args)
        {
            Console.WriteLine("Executing Assembly: " + Assembly.GetExecutingAssembly().FullName);
            Console.WriteLine("Calling Assembly: " + Assembly.GetCallingAssembly().FullName);

            Console.WriteLine("Entry Point: " + Assembly.GetCallingAssembly().EntryPoint.Name);
        }
    }
}

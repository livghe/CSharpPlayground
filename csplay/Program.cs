using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization;

namespace csplay
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContractSerialization.Start(null);
            BinarySerialization.Start(null);
            XmlSerialization.Start(null);

            Assemblies.Start(null);
            Reflect.Start(null);

            TLS.Start(null);
        }
    }
}

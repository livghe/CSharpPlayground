using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csplay
{
    class ParallelInvoke
    {
        public static void Start(string[] args)
        {
            // Invokes multiple System.Action<>'s inparallel
            Parallel.Invoke(
                () => { Console.WriteLine("1"); },
                () => { Console.WriteLine("3"); },
                () => { Console.WriteLine("4"); },
                () => { Console.WriteLine("2"); }
            );
        }
    }
}

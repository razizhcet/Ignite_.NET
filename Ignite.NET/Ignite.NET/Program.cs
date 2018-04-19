using Apache.Ignite.Core;
using Apache.Ignite.Core.Compute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.NET
{
   
    class Program
    {
        static void Main(string[] args)
        {
            //IIgnite ignite =  Ignition.Start();
            Ignition.Start();
            Console.ReadKey(); // keep the node running
        }
    }
}

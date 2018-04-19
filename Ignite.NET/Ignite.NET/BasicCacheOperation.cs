using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.NET
{
    class BasicCacheOperation
    {
        static void Main(string[] args)
        {
            //start Ignite
            IIgnite ignite = Ignition.Start();

            //create cache
            ICache<int, string> cache = ignite.GetOrCreateCache<int, string>("test");

            //put value in cache
            cache.Put(1, "Hello, World!");

            //get value from cache
            Console.WriteLine(cache.Get(1));
            Console.ReadKey();
        }
    }
}

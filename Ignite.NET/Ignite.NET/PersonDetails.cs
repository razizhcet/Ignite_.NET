using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.NET
{
    class Person
    {
        public string name { get; set; }
        public int age { get; set; }

        public override string ToString()
        {
            return $"Person [Name = {name}, Age = {age}]";
        }
    }

    class PersonDetails
    {
        static void Main(string[] args)
        {
            var cfg = new IgniteConfiguration
            {
                // Register custom class for ignite serialization
                BinaryConfiguration = new BinaryConfiguration(typeof(Person))
            };

            IIgnite ignite = Ignition.Start(cfg);

            ICache<int, Person> cache = ignite.GetOrCreateCache<int, Person>("person");
            cache[1] = new Person { name = "Razi Ahmad", age = 27 };
            cache[2] = new Person { name = "Harsh Babu", age = 22 };
            cache[3] = new Person { name = "Razi Ahmad", age = 27 };
            cache[2] = new Person { name = "Harsh Babu", age = 22 };
            foreach (ICacheEntry<int, Person> cacheEntry in cache)
                Console.WriteLine(cacheEntry);

            var binCache = cache.WithKeepBinary<int, IBinaryObject>();
            IBinaryObject binPerson1 = binCache[1];
            Console.WriteLine(binPerson1.GetField<string>("name") + " : " + binPerson1.GetField<int>("age"));

            IBinaryObject binPerson2 = binCache[2];
            Console.WriteLine(binPerson2.GetField<string>("name") + " : " + binPerson2.GetField<int>("age"));

            IBinaryObject binPerson3 = binCache[3];
            Console.WriteLine(binPerson3.GetField<string>("name") + " : " + binPerson3.GetField<int>("age"));


            Console.ReadKey();
        }
    }
}

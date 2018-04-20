using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.NET1
{
    class Person
    {
        public string name { get; set; }
        //public int age { get; set; }
    }
    class PersonCache
    {
        static void Main(string[] args)
        {
            IIgnite ignite = Ignition.Start();

            ICache<int, Person> cache = ignite.GetOrCreateCache<int, Person>("persons");
            cache[1] = new Person { name = "Razi" };

            ICache<int, IBinaryObject> binaryCache = cache.WithKeepBinary<int, IBinaryObject>();
            IBinaryObject binaryPerson = binaryCache[1];

            string name = binaryPerson.GetField<string>("name");

            Console.WriteLine(name);
            Console.ReadKey();
        }
    }
}

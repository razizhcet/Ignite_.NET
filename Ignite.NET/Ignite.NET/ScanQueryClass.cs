using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.NET
{
    class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Employee [Name={Name}, Age={Age}]";
        }
    }

    class ScanQueryClass
    {
        static void Main(string[] args)
        {
            var cfg = new IgniteConfiguration
            {
                BinaryConfiguration = new BinaryConfiguration(typeof(Employee),
            typeof(EmployeeFilter))
            };
            IIgnite ignite = Ignition.Start(cfg);

            ICache<int, Employee> cache = ignite.GetOrCreateCache<int, Employee>("employees");
            cache[1] = new Employee { Name = "John Doe", Age = 27 };
            cache[2] = new Employee { Name = "Jane Moe", Age = 43 };
            cache[3] = new Employee { Name = "Sofia Romi", Age = 29 };
            cache[4] = new Employee { Name = "Abdul Kalam", Age = 33 };

            var scanQuery = new ScanQuery<int, Employee>(new EmployeeFilter());
            IQueryCursor<ICacheEntry<int, Employee>> queryCursor = cache.Query(scanQuery);

            foreach (ICacheEntry<int, Employee> cacheEntry in queryCursor)
                Console.WriteLine(cacheEntry);

            Console.ReadKey();
        }
    }

    class EmployeeFilter : ICacheEntryFilter<int, Employee>
    {
        public bool Invoke(ICacheEntry<int, Employee> entry)
        {
            return entry.Value.Age > 30;
        }
    }
}

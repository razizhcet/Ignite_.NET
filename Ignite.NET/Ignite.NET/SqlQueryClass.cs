using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Cache.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.NET
{
    class Person1
    {
        [QuerySqlField]
        public string Name { get; set; }

        [QuerySqlField]
        public int Age { get; set; }
    }

    class SqlQueryClass
    {
        static void Main(string[] args)
        {

            IIgnite ignite = Ignition.Start();
            ICache<int, Person1> cache = ignite.GetOrCreateCache<int, Person1>(
                           new CacheConfiguration("persons", typeof(Person1)));

            //ICache<int, Person1> cache = ignite.GetOrCreateCache<int, Person1>("persons");
            cache[1] = new Person1 { Name = "John Doe", Age = 27 };
            cache[2] = new Person1 { Name = "Jane Moe", Age = 43 };
            cache[3] = new Person1 { Name = "Sofia Romi", Age = 29 };
            cache[4] = new Person1 { Name = "Abdul Kalam", Age = 33 };

            var sqlQuery = new SqlQuery(typeof(Person1), "where age > ?", 30);
            IQueryCursor<ICacheEntry<int, Person1>> queryCursor = cache.Query(sqlQuery);

            foreach (ICacheEntry<int, Person1> cacheEntry in queryCursor)
                Console.WriteLine(cacheEntry);

            Console.ReadKey();
        }
    }
}

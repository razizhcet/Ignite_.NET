using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Cache.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.NET
{
    class Person2
    {
        [QuerySqlField]
        public string Name { get; set; }

        [QuerySqlField]
        public int Age { get; set; }
    }

    class SqlFieldsQueryClass
    {
        static void Main(string[] args)
        {
            var cfg = new IgniteConfiguration
            {
                BinaryConfiguration = new BinaryConfiguration(typeof(Person2))
            };

            IIgnite ignite = Ignition.Start(cfg);
            ICache<int, Person2> cache = ignite.GetOrCreateCache<int, Person2>(
                           new CacheConfiguration("persons", typeof(Person2)));

            //ICache<int, Person1> cache = ignite.GetOrCreateCache<int, Person1>("persons");
            cache[1] = new Person2 { Name = "John Doe", Age = 27 };
            cache[2] = new Person2 { Name = "Jane Moe", Age = 43 };
            cache[3] = new Person2 { Name = "Sofia Romi", Age = 29 };
            cache[4] = new Person2 { Name = "Abdul Kalam", Age = 33 };

            var fieldsQuery = new SqlFieldsQuery(
            "select name from Person2 where age > ?", 30);
            IQueryCursor<IList> queryCursor = cache.QueryFields(fieldsQuery);

            foreach (IList fieldList in queryCursor)
                Console.WriteLine(fieldList[0]);

            //var fieldsQuery = new SqlFieldsQuery("select sum(age) from Person2");
            //IQueryCursor<IList> queryCursor = cache.QueryFields(fieldsQuery);
            //Console.WriteLine(queryCursor.GetAll()[0]);

            Console.ReadKey();
        }
    }
}

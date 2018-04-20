﻿using Apache.Ignite.Core.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.NET1
{
    public class Address : IBinarizable
    {
        public string Street { get; set; }

        public int Zip { get; set; }

        public void WriteBinary(IBinaryWriter writer)
        {
            // Alphabetic field order is required for SQL DML to work.
            // Even if DML is not used, alphabetic order is recommended.
            writer.WriteString("street", Street);
            writer.WriteInt("zip", Zip);
        }

        public void ReadBinary(IBinaryReader reader)
        {
            // Read order does not matter, however, reading in the same order 
            // as writing improves performance.
            Street = reader.ReadString("street");
            Zip = reader.ReadInt("zip");
            Console.WriteLine(Street);
            Console.WriteLine(Zip);
        }
    }
}
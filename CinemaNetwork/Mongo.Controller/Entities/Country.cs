using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoToSql
{
    public class Country
    {
        public Country(int id, string name)
        {
            this.CountryId = id;
            this.Name = name;
        }

        [BsonRepresentation(BsonType.Int32)]
        public int CountryId { get; set; }

        public string Name { get; set; }
    }
}

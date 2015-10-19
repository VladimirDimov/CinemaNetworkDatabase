using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MongoToSql.Entities
{
    public class GenderMongo
    {
        public GenderMongo(int id, string type)
        {
            this.GenderId = id;
            this.Type = type;
        }

        [BsonRepresentation(BsonType.Int32)]
        public int GenderId { get; set; }

        public string Type { get; set; }

        public virtual ICollection<PersonMongo> People { get; set; }
    }
}

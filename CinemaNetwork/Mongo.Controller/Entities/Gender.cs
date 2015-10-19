using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MongoToSql.Entities
{
    public class Gender
    {
        public Gender(int id, int type)
        {
            this.GenderId = id;
            this.Type = type;
        }

        [BsonRepresentation(BsonType.Int32)]
        public int GenderId { get; set; }

        public int Type { get; set; }

        public virtual ICollection<PersonMongo> People { get; set; }
    }
}

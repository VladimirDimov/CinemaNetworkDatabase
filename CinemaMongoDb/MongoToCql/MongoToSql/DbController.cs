namespace MongoToSql
{
    using MongoDB.Driver;
    using MongoToSql.Entities;
    using System.Collections.Generic;

    public class DbController
    {
        // Returns collection of <Person> from mongodb
        public List<PersonMongo> GetPersonDataCollection(string dbName, string host)
        {
            IMongoDatabase db = GetDatabase(dbName, host);
            var collection = db.GetCollection<PersonMongo>("Person");
            var personCollection = collection.Find(x => true).ToListAsync<PersonMongo>().Result;
            return personCollection;
        }

        public IMongoDatabase GetDatabase(string name, string fromHost)
        {
            var mongoCllient = new MongoClient(fromHost);
            return mongoCllient.GetDatabase(name);
        }
    }
}

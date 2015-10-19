namespace MongoToSql
{
    using MongoDB.Driver;
    using MongoToSql.Entities;
    using System.Collections.Generic;

    public class DbController
    {
        private string dbName;
        private string host;        

        public DbController(string dbName, string host)
        {
            this.dbName = dbName;
            this.host = host;
        }

        public List<PersonMongo> GetPersonDataCollection()
        {
            IMongoDatabase db = GetDatabase();
            var collection = db.GetCollection<PersonMongo>("Person");
            var personCollection = collection.Find(x => true).ToListAsync<PersonMongo>().Result;
            return personCollection;
        }

        public IMongoDatabase GetDatabase()
        {
            var mongoCllient = new MongoClient(host);
            return mongoCllient.GetDatabase(dbName);
        }
    }
}

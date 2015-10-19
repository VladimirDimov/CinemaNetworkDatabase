namespace Mongo.Controller
{
    using MongoDB.Driver;
    using MongoToSql.Entities;
    using System.Collections.Generic;

    public class MongoDbController
    {
        private string dbName;
        private string host;        

        public MongoDbController(string dbName, string host)
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

        public void GenerateRandomData(int numberOfEntities)
        {
            var randomGenerator = new MongoDataGenerator();
            randomGenerator.GenerateRandomPeopleData(this.dbName, this.host, numberOfEntities);
        }

        public IMongoDatabase GetDatabase()
        {
            var mongoCllient = new MongoClient(host);
            return mongoCllient.GetDatabase(dbName);
        }

        public void UploadDataToSql()
        {
            var personEntitiesController = new PersonEntitiesController();
            personEntitiesController.UploadMongToSql(this.dbName, this.host);
        }
    }
}

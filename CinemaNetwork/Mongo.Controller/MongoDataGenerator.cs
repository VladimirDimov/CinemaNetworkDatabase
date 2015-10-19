namespace Mongo.Controller
{
    using MongoToSql.Entities;
    using RandomGenerators;
    using System;
    using System.Collections.Generic;

    public class MongoDataGenerator
    {
        private static Random randomGenerator = new Random();

        internal void GenerateRandomPeopleData(string dbName, string host, int numberOfEntities)
        {
            var dbController = new MongoDbController(dbName, host);
            var db = dbController.GetDatabase();
            var collection = db.GetCollection<PersonMongo>("Person");
            var personCollection = new List<PersonMongo>();
            var countryGenerator = new CountriesCollection();
            var randomGenerator = new RandomGenerator();

            for (int i = 1; i <= numberOfEntities; i++)
            {
                personCollection.Add(new PersonMongo(
                    i,
                    randomGenerator.GetRandomString(3, 5, true),
                    randomGenerator.GetRandomString(4, 7, true),
                    GetGender(i),
                    randomGenerator.GetRandomInt(1920,2015),
                    countryGenerator.GetRandomCountry()));
            }

            collection.InsertManyAsync(personCollection);
            Console.Write("Press key");
            Console.ReadKey();

            Console.WriteLine("Person data created");
        }

        private GenderMongo GetGender(int i)
        {
            if (i % 2 == 0)
            {
                return new GenderMongo(1, "male");
            }

            return new GenderMongo(2, "female");
        }
    }
}

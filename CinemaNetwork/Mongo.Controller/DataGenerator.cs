namespace MongoToSql
{
    using MongoToSql.Entities;
    using RandomGenerators;
    using System;
    using System.Collections.Generic;

    public class DataGenerator
    {
        private static Random randomGenerator = new Random();

        public void GenerateData(string dbName, string host, int numberOfEntities)
        {
            var dbController = new DbController(dbName, host);
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

        private Gender GetGender(int i)
        {
            if (i % 2 == 0)
            {
                return new Gender(1, 1);
            }

            return new Gender(2, 2);
        }
    }
}

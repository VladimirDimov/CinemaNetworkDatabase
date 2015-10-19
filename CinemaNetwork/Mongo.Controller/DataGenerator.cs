namespace MongoToSql
{
    using MongoToSql.Entities;
    using System;
    using System.Collections.Generic;

    public class DataGenerator
    {
        private static Random randomGenerator = new Random();

        public void GenerateData(string dbName, string host, int numberOfEntities)
        {
            var dbController = new DbController(dbName, host);
            var db = dbController.GetDatabase(dbName, host);
            var collection = db.GetCollection<PersonMongo>("Person");
            var personCollection = new List<PersonMongo>();
            var countryGenerator = new CountriesCollection();

            for (int i = 1; i <= numberOfEntities; i++)
            {
                personCollection.Add(new PersonMongo(i, "FName" + i, "LastName" + i, GetGender(i), GetRandomYear(), countryGenerator.GetRandomCountry()));
            }

            collection.InsertManyAsync(personCollection);
            Console.Write("Press key");
            Console.ReadLine();

            Console.WriteLine("Person data created");
        }

        private Genders GetGender(int i)
        {
            if (i % 2 == 0)
            {
                return new Genders(1, "Male");
            }

            return new Genders(2, "Female");
        }

        private int GetRandomYear()
        {
            return randomGenerator.Next(1930, 2000);
        }
    }
}

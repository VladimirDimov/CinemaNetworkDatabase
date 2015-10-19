namespace Mongo.Controller
{
    using System.Collections;
    using MongoToSql;
    using MongoToSql.Entities;
    using System;
    using System.Collections.Generic;
    using CinemaNetwork.Models;
    using System.Data.Entity;

    public class PersonEntitiesController
    {
        private const string DbName = "People";
        private const string Host = "mongodb://127.0.0.1";

        private MongoDbController dbController = new MongoDbController(DbName, Host);
        private Dictionary<int, Country> uniqueCountries = new Dictionary<int, Country>();
        private Dictionary<int, Gender> uniqueGenders = new Dictionary<int, Gender>();

        public void UploadMongToSql(string dbName, string host)
        {
            List<PersonMongo> peopleCollection = dbController.GetPersonDataCollection();

            using (var db = new CinameNetworkEntities())
            {
                foreach (var person in peopleCollection)
                {
                    db.People.Add(GetPersonFromPersonMongo(person));
                }

                db.SaveChanges();
                Console.WriteLine("Success!");
            }
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }

        private Person GetPersonFromPersonMongo(PersonMongo personMongo)
        {
            var person = new Person();
            person.PersonId = personMongo.PersonMongoId;
            person.FirstName = personMongo.FirstName;
            person.LastName = personMongo.LastName;

            var countryId = personMongo.Country.CountryId;
            if (uniqueCountries.ContainsKey(countryId))
            {
                person.Country = uniqueCountries[countryId];
            }
            else
            {
                person.Country = new Country();
                person.Country.Name = personMongo.Country.Name;
                person.Country.CountryId = personMongo.Country.CountryId;
                uniqueCountries.Add(countryId, person.Country);
            }

            var genderId = personMongo.Genders.GenderId;
            if (uniqueGenders.ContainsKey(genderId))
            {
                person.Gender = uniqueGenders[genderId];
            }
            else
            {
                person.Gender = new Gender();
                person.Gender.GenderId = personMongo.Genders.GenderId;
                person.Gender.Type = personMongo.Genders.Type;
                uniqueGenders.Add(genderId, person.Gender);
            }

            person.BirthYear = personMongo.BirthYear;

            return person;
        }
    }
}
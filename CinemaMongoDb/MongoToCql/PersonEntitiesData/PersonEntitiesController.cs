namespace PersonEntitiesData
{
    using MongoToSql;
    using MongoToSql.Entities;
    using System;
    using System.Collections.Generic;

    public class PersonEntitiesController
    {
        private const string DbName = "PeopleDb";
        private const string Host = "mongodb://127.0.0.1";

        private DbController dbController = new DbController();
        private Dictionary<int, Country> uniqueCountries = new Dictionary<int, Country>();
        private Dictionary<int, Genders> uniqueGenders = new Dictionary<int, Genders>();

        public void ExecuteCommand(string command)
        {
            if (command == "generate")
            {
                GeneratePersonData(DbName, Host, 200);
            }
            else if (command == "upload")
            {
                UploadMongToSql(DbName, Host);
            }
        }

        public void GeneratePersonData(string dbName, string host, int numberOfEntities)
        {
            var dataGenerator = new DataGenerator();
            dataGenerator.GenerateData(dbName, host, 200);

        }

        public void UploadMongToSql(string dbName, string host)
        {
            List<PersonMongo> peopleCollection = dbController.GetPersonDataCollection(dbName, host);

            using (var db = new CinameNetworkEntities())
            {
                var personCollection = new List<Person>();
                foreach (var person in peopleCollection)
                {
                    personCollection.Add(GetPersonFromPersonMongo(person));
                }

                db.Person.AddRange(personCollection);
                db.SaveChanges();
                Console.WriteLine("Success!");
            }

            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }

        private Person GetPersonFromPersonMongo(PersonMongo personMongo)
        {
            var person = new Person();
            person.PersonId = personMongo.PersonId;
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
            person.Country.Person.Add(person);

            var genderId = personMongo.Genders.GenderId;
            if (uniqueGenders.ContainsKey(genderId))
            {
                person.Genders = uniqueGenders[genderId];
            }
            else
            {
                person.Genders = new Genders();
                person.Genders.GenderId = personMongo.Genders.GenderId;
                person.Genders.Type = personMongo.Genders.Type;
                uniqueGenders.Add(genderId, person.Genders);
            }
            person.Genders.Person.Add(person);

            person.BirthYear = personMongo.BirthYear;

            return person;
        }
    }
}
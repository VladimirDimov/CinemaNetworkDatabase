namespace MongoToSql.Entities
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class PersonMongo
    {
        public PersonMongo(int id, string firstName, string lastName, GenderMongo gender, int birthYear, CountryMongo country)
        {
            this.PersonMongoId = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Genders = gender;
            this.BirthYear = birthYear;
            this.Country = country;
        }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.Int32)]
        public int PersonMongoId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int BirthYear { get; set; }

        public virtual CountryMongo Country { get; set; }

        public virtual GenderMongo Genders { get; set; }
    }
}

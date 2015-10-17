namespace MongoToSql.Entities
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class PersonMongo
    {
        public PersonMongo(int id, string firstName, string lastName, Genders gender, int birthYear, Country country)
        {
            this.PersonId = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Genders = gender;
            this.BirthYear = birthYear;
            this.Country = country;
        }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.Int32)]
        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int BirthYear { get; set; }

        public virtual Country Country { get; set; }

        public virtual Genders Genders { get; set; }
    }
}

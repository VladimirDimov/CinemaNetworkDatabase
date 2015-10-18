namespace CinemaSystem.Importer
{
    using System;
    using System.IO;
    using CinemaSystem.Data;

    public class CountryImporter : IImporter
    {
        private const int numberOfCountries = 100;

        public string Message
        {
            get { return "Importing Countries"; }
        }

        public int Order
        {
            get { return 1; }
        }

        public Action<CinameEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    for (int i = 0; i < numberOfCountries; i++)
                    {
                        db.Country.Add(new Country()
                        {
                            // to do
                        });
                    }
                };
            }
        }
    }
}

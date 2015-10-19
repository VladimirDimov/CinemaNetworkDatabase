using System.Collections.Generic;
using System.Linq;

namespace SqlToXmlExporter
{
    using System;
    using CinemaNetwork.Models;
    using RandomGenerators;
    using SqlToExcelExporter;

    public class Startup
    {
        private static CinameNetworkEntities db;

        public static void Main(string[] args)
        {
            //int newId = InserNewMovie();
            //Console.WriteLine("Row affected - new movie with movieId {0} created", newId);

            // InsertNewCountries(5);

            var countries = new List<string>();
            var numberOfMoives = new List<int>();

            var db = new CinameNetworkEntities();
            using (db)
            {
                countries = db.Countries
                            .Select(x => x.Name)
                            .ToList();

                numberOfMoives = db.Countries
                        .Select(y => y.Movies.Count)
                        .ToList();
            }


            SqlToExcel.WriteDataToExcelFile(countries, numberOfMoives);
        }

        public static int InserNewMovie()
        {
            var rand = new RandomGenerator();

            CinameNetworkEntities northwindEntities = new CinameNetworkEntities();

            Movy newProduct = new Movy
            {
                Title = rand.GetRandomString(5, 15),
                GenreId = rand.GetRandomInt(1, 1000),
                ReleaseDate = rand.GetRandomDateTime(),
                Director = rand.GetRandomInt(1, 1000),
                Actors = rand.GetRandomInt(1, 100),
                Description = rand.GetRandomString(20, 60),
                CoverLink = rand.GetRandomString(5, 25),
                Subtitles = false,
                DurationMinutes = rand.GetRandomInt(40, 150)
            };

            northwindEntities.Movies.Add(newProduct);
            northwindEntities.SaveChanges();

            return newProduct.MovieId;
        }

        public static void InsertNewCountries(int count)
        {
            while (count > 0)
            {
                var rand = new RandomGenerator();

                CinameNetworkEntities northwindEntities = new CinameNetworkEntities();

                Country newEntry = new Country
                {
                    Name = rand.GetRandomString(5, 20)
                };

                northwindEntities.Countries.Add(newEntry);
                northwindEntities.SaveChanges();

                Console.WriteLine("Row affected - new country with movieId {0} created", newEntry.CountryId);
                count--;
            }
        }
    }
}

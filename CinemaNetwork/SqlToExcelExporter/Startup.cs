using SqlToExcelExporter;

namespace SqlToXmlExporter
{
    using System;
    using CinemaNetwork.Models;
    using RandomGenerators;

    public class Startup
    {
        private static CinameNetworkEntities db;

        public static void Main(string[] args)
        {
            //int newId = InserNewMovie();
            //Console.WriteLine("Row affected - new movie with movieId {0} created", newId);

            // InsertNewCountries(5);
            SqlToExcel.WriteDataToExcelFile();
        }

        public static int InserNewMovie()
        {
            var rand = new RandomGeneratorController();

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
                var rand = new RandomGeneratorController();

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

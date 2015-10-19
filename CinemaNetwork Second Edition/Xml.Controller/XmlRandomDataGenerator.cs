namespace Xml.Controller
{
    using CinemaNetwork.Models;
    using RandomGenerators;
    using System.Linq;
    using System.Xml.Linq;

    public class XmlRandomDataGenerator
    {
        private RandomGenerator randomGenerator;
        private int numberOfGenres;
        private int numberOfMovies;

        public XmlRandomDataGenerator(RandomGenerator randomGenerator, int numberOfGenres, int numberOfMovies)
        {
            this.randomGenerator = randomGenerator;
            this.numberOfGenres = numberOfGenres;
            this.numberOfMovies = numberOfMovies;
        }

        public void ReadXmlFromFile(string path)
        {
            var xElement = XElement.Parse(path);
        }

        public void GenerateRandomData(string savePath)
        {
            AddRandomGenresToDatabase();

            using (var db = new CinameNetworkEntities())
            {
                var xElement = new XElement("Movies");
                for (int i = 0; i < this.numberOfMovies; i++)
                {
                    Movy movie = GetRandomMovie();

                    // Adding movie to database
                    db.Movies.Add(movie);
                    db.SaveChanges();

                    var xMovie = new XElement(
                        "movie",
                        new XElement("Title", movie.Title),
                        new XElement("GenreId", movie.GenreId),
                        new XElement("ReleaseDate", movie.ReleaseDate),
                        new XElement("Director", movie.Director),
                        new XElement("CountryId", movie.CountryId),
                        new XElement("Description", movie.Description),
                        new XElement("Description", movie.Description),
                        new XElement("Subtitles", "yes"),
                        new XElement("Duration", movie.DurationMinutes));

                    var xActors = new XElement("Actors");
                    foreach (var actor in movie.People)
                    {
                        xActors.Add(new XElement("Actor", actor.PersonId));
                    }

                    xMovie.Add(new XElement("Actors", xActors));

                    xElement.Add(xMovie);
                }
                
                xElement.Save(savePath);
            }

            System.Console.WriteLine("Random movies added.");
        }

        private Movy GetRandomMovie()
        {
            using (var db = new CinameNetworkEntities())
            {
                var genreIds = db.Genres.Select(g => g.GenreId).ToList();
                var countriesIds = db.Countries.Select(c => c.CountryId).ToList();
                var peopleIds = db.People.Select(p => p.PersonId).ToList();
                var people = db.People.ToList();

                var movie = new Movy();
                movie.Title = randomGenerator.GetRandomString(5, 20);
                movie.GenreId = genreIds[randomGenerator.GetRandomInt(0, genreIds.Count - 1)];
                movie.ReleaseDate = randomGenerator.GetRandomDateTime();
                movie.Director = peopleIds[randomGenerator.GetRandomInt(0, peopleIds.Count - 1)];

                var numberOfActors = randomGenerator.GetRandomInt(3, 10);
                for (int i = 0; i < numberOfActors; i++)
                {
                    movie.People.Add(people[randomGenerator.GetRandomInt(0, people.Count - 1)]);
                }

                movie.CountryId = countriesIds[randomGenerator.GetRandomInt(0, countriesIds.Count - 1)];
                movie.Description = randomGenerator.GetRandomString(10, 20);
                movie.Subtitles = false;
                movie.DurationMinutes = randomGenerator.GetRandomInt(5, 200);

                return movie;
            }
        }

        private void AddRandomGenresToDatabase()
        {
            using (var db = new CinameNetworkEntities())
            {
                for (int i = 0; i < numberOfGenres; i++)
                {
                    var genre = GetRandomGenre();
                    db.Genres.Add(genre);
                }

                db.SaveChanges();
            }
        }

        private Genre GetRandomGenre()
        {
            var genre = new Genre();
            genre.Name = randomGenerator.GetRandomString(5, 10);
            return genre;
        }
    }
}

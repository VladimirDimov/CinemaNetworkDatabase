namespace XmlReporter.Generators
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Xml;

    using CinemaNetwork.Models;

    public class XmlReportGenerator
    {
        private CinameNetworkEntities dbContext;


        public XmlReportGenerator(CinameNetworkEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public XmlReportGenerator()
            : this(new CinameNetworkEntities())
        {
        }

        public void Generate(string fileName)
        {
            var genres = this.GetData(this.dbContext);

            using (XmlWriter writer = XmlWriter.Create(fileName, new XmlWriterSettings() { Indent = true}))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Genres");

                foreach (GenreModel genre in genres)
                {
                    writer.WriteStartElement("Genre", genre.Name);

                    foreach (MovieModel movie in genre.Movies)
                    {
                        writer.WriteStartElement("Movie");

                        writer.WriteElementString("Title", movie.Title);
                        writer.WriteElementString("ReleaseDate", movie.ReleaseDate.ToString());

                        writer.WriteStartElement("Director");
                        writer.WriteElementString("FirstName", movie.Director.FirstName);
                        writer.WriteElementString("LastName", movie.Director.LastName);
                        writer.WriteElementString("Gender", movie.Director.Gender);
                        writer.WriteElementString("BirthYear", movie.Director.BirthYear.ToString());
                        writer.WriteElementString("Origin", movie.Director.Origin);
                        writer.WriteEndElement();

                        writer.WriteStartElement("Actors");

                        foreach (PersonModel actor in movie.Actors)
                        {
                            writer.WriteStartElement("Actor");

                            writer.WriteElementString("FirstName", actor.FirstName);
                            writer.WriteElementString("LastName", actor.LastName);
                            writer.WriteElementString("Gender", actor.Gender);
                            writer.WriteElementString("BirthYear", actor.BirthYear.ToString());
                            writer.WriteElementString("Origin", actor.Origin);

                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();

                        writer.WriteElementString("Country", movie.Country);
                        writer.WriteElementString("Description", movie.Description);
                        writer.WriteElementString("CoverLink", movie.CoverLink);
                        writer.WriteElementString("Subtitles", movie.HasSubtitles.ToString());
                        writer.WriteElementString("DurationInMinutes", movie.Duration.ToString());

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();

                System.Console.WriteLine("Xml report generated!");
            }
        }

        private IEnumerable<GenreModel> GetData(CinameNetworkEntities dbContext)
        {
            var genres = dbContext
                .Genres
                .Select(x => new GenreModel()
                {
                    Name = x.Name,
                    Movies = x.Movies
                    .Select(m => new MovieModel()
                    {
                        Title = m.Title,
                        ReleaseDate = m.ReleaseDate,
                        Director = new PersonModel()
                        {
                            FirstName = m.Person.FirstName,
                            LastName = m.Person.LastName,
                            Gender = m.Person.Gender.Type,
                            BirthYear = m.Person.BirthYear,
                            Origin = m.Person.Country.Name
                        },
                        Actors = m.People
                            .Select(a => new PersonModel()
                            {                            
                                FirstName = a.FirstName,
                                LastName = a.LastName,
                                Gender = a.Gender.Type,
                                BirthYear = a.BirthYear,
                                Origin = a.Country.Name
                            })
                            .ToList(),
                        Country = m.Country.Name,
                        Description = m.Description,
                        CoverLink = m.CoverLink,
                        HasSubtitles = m.Subtitles,
                        Duration = m.DurationMinutes
                    })
                    .ToList()
                })
                .ToList();

            return genres;
        }
    }
}

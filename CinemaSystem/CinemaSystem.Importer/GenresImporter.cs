namespace CinemaSystem.Importer
{
    using System;
    using System.IO;
    using CinemaSystem.Data;

    public class GenresImporter : IImporter
    {
        public string Message
        {
            get { return "Importing movie Genres"; }
        }

        public int Order
        {
            get { return 2; }
        }

        public Action<CinameEntities, TextWriter> Get { get; set; }
    }
}

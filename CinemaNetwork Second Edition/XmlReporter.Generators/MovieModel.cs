namespace XmlReporter.Generators
{
    using System;
    using System.Collections.Generic;

    using CinemaNetwork.Models;

    public class MovieModel
    {
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public PersonModel Director { get; set; }

        public IEnumerable<PersonModel> Actors { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }

        public string CoverLink { get; set; }

        public bool HasSubtitles { get; set; }

        /// <summary>
        /// Duration in Minutes.
        /// </summary>
        public int Duration { get; set; }
    }
}

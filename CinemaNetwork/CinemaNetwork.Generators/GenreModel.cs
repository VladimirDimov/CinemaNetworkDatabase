namespace CinemaNetwork.Generators
{
    using System.Collections.Generic;

    using CinemaNetwork.Models;

    public class GenreModel
    {
        public string Name { get; set; }

        public IEnumerable<MovieModel> Movies { get; set; }
    }
}

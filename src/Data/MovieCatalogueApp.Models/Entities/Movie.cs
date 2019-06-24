using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogueApp.Models.Entities
{
    public class Movie
    {
        public Movie()
        {
            this.Actors = new HashSet<Actor>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public double Rating { get; set; }
        public string Summary { get; set; }
        public string Poster { get; set; }

        public ICollection<Actor> Actors { get; set; }

        //public int GenreId { get; set; }
        public Genre Genre { get; set; }

    }
}

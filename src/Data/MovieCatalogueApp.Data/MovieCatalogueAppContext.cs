using System;
using Microsoft.EntityFrameworkCore;
using MovieCatalogueApp.Models.Entities;

namespace MovieCatalogueApp.Data
{
    public class MovieCatalogueAppContext: DbContext
    {

        public MovieCatalogueAppContext(DbContextOptions<MovieCatalogueAppContext> options)
            : base(options)
        {
        }

        public DbSet<Actor> Actors{ get; set; }
        public DbSet<Genre> Genres{ get; set; }
        public DbSet<Movie> Movies{ get; set; }

    }
}

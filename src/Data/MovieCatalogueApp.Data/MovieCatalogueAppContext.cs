using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCatalogueApp.Models.Entities;

namespace MovieCatalogueApp.Data
{
    public class MovieCatalogueAppContext :   DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasOptional(m => m.Movie)
                .WithOptionalPrincipal(g => g.Genre)
                .Map(a => a.MapKey("GenreId"));
        }
    }
}

using MovieCatalogueApp.Data;
using MovieCatalogueApp.Models.Entities;
using MovieCataloogueApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCataloogueApp.Services
{
    public class MovieService : IMovieService
    {

        private readonly IRepository<Movie> movieRepository;

        public MovieService(IRepository<Movie> _movieRepository)
        {
            this.movieRepository = _movieRepository;
        }

        public IEnumerable<Movie> allMovieOrderByReleaseDate()
        {
            var result = this.movieRepository.All().OrderByDescending(
                m => m.ReleaseDate).AsEnumerable();

            return result;
        }

    }
}

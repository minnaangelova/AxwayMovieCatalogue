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

        public IEnumerable<Movie> allMovieOrderBy(string orderBy)
        {
            var result = this.movieRepository.All();

            if(orderBy=="Title")
            {
                result.OrderBy(m => m.Title);

            }
            else if(orderBy=="Rating")
            {
                result.OrderByDescending(m => m.Rating);
            }
            return result.AsEnumerable();

        }

        public IEnumerable<Movie> addMovie(Movie movie)
        {
            var doesExist = movieRepository.All().Any(m => m.Title == movie.Title);

            if(!doesExist)
            {
                movieRepository.Add(movie);
                movieRepository.SaveChangesAsync();

                return movieRepository.All();
            }
            else
            {
                throw new InvalidOperationException("Movie already exists.");
            }

            
        }

        public IEnumerable<Movie> deleteMovie(int movieId)
        {
            var deleteMovie = this.movieRepository.All().FirstOrDefault(m => m.Id == movieId);

            if (deleteMovie == null)
            {
                throw new InvalidOperationException("Movie doesn't exists.");
            }
            else
            {
                movieRepository.Delete(deleteMovie);
                movieRepository.SaveChangesAsync();

                return movieRepository.All();
            }
        }

    }
}

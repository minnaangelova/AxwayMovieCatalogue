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
        private const int TOP_RATED_MOVIES_HOME_VIEW = 3;
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
            var result = this.movieRepository.All().ToList();
           


            if(orderBy=="Title")
            {
                var orderByTitle = result.OrderBy(m => m.Title).ToList();
                result=orderByTitle;

            }
            else if(orderBy=="Rating")
            {
                var orderByRating = result.OrderByDescending(m => m.Rating).ToList();
                result = orderByRating;
            }
            return result.AsEnumerable();

        }

        public IEnumerable<Movie> addMovie(Movie movie)
        {
            var doesExist = movieRepository.All().Any(m => m.Title == movie.Title);

            if(!doesExist)
            {
                movieRepository.Add(movie);
                movieRepository.SaveChanges();

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
                movieRepository.SaveChanges();

                return movieRepository.All();
            }
        }

        public Movie searchMovie(string title)
        {
            var searchMovie = this.movieRepository.All().FirstOrDefault(m => m.Title.Contains(title));

            if(searchMovie==null)
            {
                throw new InvalidOperationException("Movie doesn't exists.");
            }
            else
            {
                return searchMovie;
            }

        }

        public IEnumerable<Movie> GetHomeTopRatedMovies()
        {
            var topRatedMovies = this.movieRepository.All().OrderByDescending(m => m.Rating).Take(TOP_RATED_MOVIES_HOME_VIEW);
            return topRatedMovies;
        }

        public IEnumerable<Movie> EditMovie(int id, Movie movie)
        {
            var getMovie = this.movieRepository.All().FirstOrDefault(m => m.Id == id);

            if(getMovie == null)
            {
                throw new InvalidOperationException("Movie doesn't exists.");
            }
            else
            {
                getMovie.Title = movie.Title;
                movieRepository.SaveChanges();
                return movieRepository.All();
            }
        }
    }

     
}

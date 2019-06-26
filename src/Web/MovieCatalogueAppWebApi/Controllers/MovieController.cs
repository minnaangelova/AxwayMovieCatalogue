using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieCatalogueApp.Data;
using MovieCatalogueApp.Models.Entities;
using MovieCataloogueApp.Services.Interfaces;

namespace MovieCatalogueAppWebApi.Controllers
{
    [RoutePrefix("movies")]
    public class MovieController : ApiController
    {

        private readonly IMovieService movieService;
        public MovieController(IMovieService _movieService)
        {
            this.movieService = _movieService;
        }

        [HttpGet, Route("all")]
        public IHttpActionResult GetAlMoviesByReleaseDate()
        {
            var result = this.movieService.allMovieOrderByReleaseDate();
            return Ok(result);
        }

        [HttpGet, Route("orderBy/{orderBy}")]
        public IHttpActionResult GetAllMoviesBy(string orderBy)
        {
            var result = this.movieService.allMovieOrderBy(orderBy);
            return Ok(result);
        }

        [AcceptVerbs("DELETE", "GET")]
        [HttpDelete, Route("deleteMovie/{id}")]
        public IHttpActionResult DeleteMovie(int id)
        {
            var result = this.movieService.deleteMovie(id);
            return Ok(result);
        }

        [HttpGet, Route("search/{title}")]
        public IHttpActionResult SearchMovie(string title)
        {
            var result = this.movieService.searchMovie(title);
            return Ok(result);
        }

        [HttpGet, Route("topMovies")]
        public IHttpActionResult HomeTopMovies()
        {
            var result = this.movieService.GetHomeTopRatedMovies();
            return Ok(result);
        }
    }
}

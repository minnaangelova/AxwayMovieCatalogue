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
        private readonly IRepository<Movie> _movieRepository;

        private readonly IMovieService movieService;
        public MovieController(IRepository<Movie> _movieRepository,IMovieService _movieService)
        {
            this._movieRepository = _movieRepository;
            this.movieService = _movieService;
        }



        [HttpGet, Route("all")]
        public IHttpActionResult GetAlMoviesByReleaseDate()
        {
            var result = this.movieService.allMovieOrderByReleaseDate();
            return Ok(result);
        }

      
    }
}

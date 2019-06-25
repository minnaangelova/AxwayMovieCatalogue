﻿using System;
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

        [HttpGet,Route("{orderBy}")]
        public IHttpActionResult GetAllMoviesBy(string orderBy)
        {
            var result = this.movieService.allMovieOrderBy(orderBy);
            return Ok(result);
        }

     [HttpPost, Route("add")]
     public IHttpActionResult AddMovie(Movie movie)
        {
            var result = this.movieService.addMovie(movie);
            return Ok(result);
        }
        
        [HttpDelete, Route("delete/{id}")]
        public IHttpActionResult DeleteMovie([FromUri]int movieId)
        {
            var result = this.movieService.deleteMovie(movieId);
            return Ok(result);
        }

    }
}

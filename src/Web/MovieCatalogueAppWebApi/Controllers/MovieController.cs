using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieCatalogueApp.AbstractionLayer;
using MovieCatalogueApp.Models.Entities;

namespace MovieCatalogueAppWebApi.Controllers
{
    [RoutePrefix("movies")]
    public class MovieController : ApiController
    {
        private readonly IRepository<Movie> _movieRepository;

        public MovieController(IRepository<Movie> _movieRepository)
        {
            this._movieRepository = _movieRepository;
        }



        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            var movie = this._movieRepository.All();
            return Json(movie);
        }

        //[HttpGet, Route("")]
        //public IEnumerable<Movie> Get()
        //{
        //    return this._movieRepository.All().ToList();
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MovieCataloogueApp.Services.Interfaces;

namespace MovieCatalogueAppWebApi.Controllers
{
    [RoutePrefix("actors")]
    public class ActorController : ApiController
    {

        private readonly IActorService actorService;
        public ActorController(IActorService _actorService)
        {
            this.actorService = _actorService;
        }

        [HttpGet, Route("all")]
        public IHttpActionResult GetAlMoviesByReleaseDate()
        {
            var result = this.actorService.allActor();
            return Ok(result);
        }

    }
}
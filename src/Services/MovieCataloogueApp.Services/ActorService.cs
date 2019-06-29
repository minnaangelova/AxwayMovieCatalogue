using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCatalogueApp.Data;
using MovieCatalogueApp.Models.Entities;
using MovieCataloogueApp.Services.Interfaces;

namespace MovieCataloogueApp.Services
{
    public class ActorService : IActorService
    {
        private readonly IRepository<Actor> actorRepository;

        public ActorService(IRepository<Actor> _actorRepository)
        {
            this.actorRepository = _actorRepository;
        }

        public IEnumerable<Actor> allActor()
        {
            var result = this.actorRepository.All()
                .OrderBy(m => m.FirstName).AsEnumerable();

            return result;
        }
    }
}

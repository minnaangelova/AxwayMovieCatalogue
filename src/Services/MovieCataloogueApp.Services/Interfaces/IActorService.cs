using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCatalogueApp.Models.Entities;

namespace MovieCataloogueApp.Services.Interfaces
{
    public interface IActorService
    {
        IEnumerable<Actor> allActor();
    }
}

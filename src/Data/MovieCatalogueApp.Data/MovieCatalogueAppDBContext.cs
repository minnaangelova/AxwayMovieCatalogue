using System;
using System.Data.Entity;

namespace MovieCatalogueApp.Data
{
    public class Context: DbContext
    {
        public Context() : base("name = MovieCatalogueDBConnectionString")
        {

        }
    }
}

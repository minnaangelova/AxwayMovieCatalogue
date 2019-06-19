using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalogueApp.Data.Entities
{
    public class Actor
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Born { get; set; }
        public DateTime? Died { get; set; }
        public string Biography { get; set; }
        public string Picture { get; set; }

        public int MovieId { get; set; }
        public Movie Movie {get;set;}
    }
}

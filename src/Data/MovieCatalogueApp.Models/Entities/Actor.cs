using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogueApp.Models.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Born { get; set; }
        public DateTime? Died { get; set; }
        public string Biography { get; set; }
        public string Picture { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}

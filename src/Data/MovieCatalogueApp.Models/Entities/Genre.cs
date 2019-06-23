using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogueApp.Models.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[ForeignKey("Movie")]
        //public int MovieId { get; set; }
        public Movie Movie { get; set; }

    }
}

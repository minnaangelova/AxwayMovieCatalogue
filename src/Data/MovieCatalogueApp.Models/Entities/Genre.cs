﻿using System;
using System.Collections.Generic;
using System.Text;
using MovieCatalogueApp.Models.Entities;

namespace MovieCatalogueApp.Data.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}

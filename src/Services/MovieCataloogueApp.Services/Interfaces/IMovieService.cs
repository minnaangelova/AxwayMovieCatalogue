﻿using MovieCatalogueApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCataloogueApp.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> allMovieOrderByReleaseDate();
    }
}

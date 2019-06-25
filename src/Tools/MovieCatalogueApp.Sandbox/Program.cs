using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using MovieCatalogueApp.Data;
using MovieCatalogueApp.Models.Entities;
using Newtonsoft.Json.Linq;

namespace MovieCatalogueApp.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {    // Seed Database via web api . Using Newtonsoft.json for parsing Json
            #region SeedDatabase

            var context = new MovieCatalogueAppContext();
            WebClient webClient = new WebClient();
            //for (int i = 6; i <= 11; i++)
            //{
            /*string webApiUrl = "http://www.omdbapi.com/?apikey=72d47109&i=tt866391" + i;*/ // apikey should be changed for new user usage
            string webApiUrl = "http://www.omdbapi.com/?apikey=72d47109&i=tt3741700";
                var webApiJsonDownload = webClient.DownloadString(webApiUrl); // Download json data from webApiUrl
                var parsedJson = JObject.Parse(webApiJsonDownload);
                var movieTitle = parsedJson["Title"].ToString();
                var movieRating = Convert.ToDouble(parsedJson["imdbRating"]);
                var movieReleaseDate = Convert.ToDateTime(parsedJson["Released"]);
                var movieSummary = parsedJson["Plot"].ToString();
                var moviePosterUrl = parsedJson["Poster"].ToString();
                var movieGenre = parsedJson["Genre"].ToString().Split(',')[0];


                var movieActors = parsedJson["Actors"].ToString()
                    .Split(new char[]
                        {
                            ','
                        },
                        StringSplitOptions.RemoveEmptyEntries)
                    .ToList();


                var actors = new List<Actor>();

                var movie = new Movie
                {
                    Title = movieTitle,
                    Rating = movieRating,
                    Poster = moviePosterUrl,
                    ReleaseDate = movieReleaseDate,
                    Summary = movieSummary
                };

                foreach (var movieActor in movieActors)
                {
                    var movieActorTokens = movieActor.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var movieActorFirstName = movieActorTokens[0];
                    var movieActorLastName = movieActorTokens[1];

                    var actor = new Actor
                    {
                        FirstName = movieActorFirstName,
                        LastName = movieActorLastName,
                        Movie = movie,




                    };
                    actors.Add(actor);
                }
                 var genre = new Genre
                {
                    Movie = movie,
                    Name = movieGenre,
                   

                };
                try
                {
                    context.Actors.AddRange(actors);
                    context.Genres.Add(genre);
                    context.Movies.Add(movie);
                    context.SaveChanges();
                    VisualizedSeededData(movieTitle,movieRating, movieReleaseDate, movieSummary, moviePosterUrl, movieGenre, movieActors);
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }


            //}

        }

        private static void VisualizedSeededData(string movieTitle, double movieRating, DateTime movieReleaseDate,
            string movieSummary, string moviePosterUrl, string movieGenre, List<string> movieActors)
        {
            Console.WriteLine(
                $"Added Movie -\nMovie Title: {movieTitle}\nMovie Rating: {movieRating}\nMovie Release Date: {movieReleaseDate}\nMovie Summary: {movieSummary}\nMovie Poster Url: {moviePosterUrl}\nMovie Genre: {movieGenre}\n Movie Actors: {string.Join(" ",movieActors)}");
            Console.WriteLine(new string('-', 50));
        }

        #endregion

    }
}


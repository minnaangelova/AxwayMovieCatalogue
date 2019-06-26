using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MovieCatalogueApp.Models.Entities;

namespace MovieCatalogueAppWPF.ViewModels
{
    public class StartupViewModel: ViewModel
    {
        public ICommand SearchMovieCommand { get; set; }

        public StartupViewModel()
        {
            SearchMovieCommand = new LambdaCommand(() =>
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:12789/")
                };

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var url = "api/movie";  //+ id;

                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var movie = response.Content.ReadAsAsync<Movie>().Result;
                    MessageBox.Show(
                        $"Movie Found {movie.Title} \n {movie.Genre} \n {movie.Rating} \n {movie.ReleaseDate} \n {movie.Summary} \n {movie.Poster}");
                }
                else
                {
                    MessageBox.Show($"Error code {response.StatusCode}");
                }

            });
        }
    }
}

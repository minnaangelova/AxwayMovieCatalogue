using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private string _textBoxValue;
        private double _rating;

        public ObservableCollection<Movie> Movies { get; set; }

        public double Rating
        {
            get => _rating;
            set
            {
                if (Rating != value)
                {
                    _rating = value;
                    OnPropertyChanged(nameof(Rating));
                }
            }
        }

        public string TextBoxValue
        {
            get => _textBoxValue;
            set
            {
                if (this._textBoxValue != value)
                {
                    _textBoxValue = value;
                    OnPropertyChanged(nameof(TextBoxValue));
                }
            }
        }

        public ICommand SearchMovieCommand { get; set; }

        public StartupViewModel()
        {
            

            SearchMovieCommand = new LambdaCommand(() =>
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:62560/")
                };

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var url = "movies/search/" + this.TextBoxValue; //+ id;

                HttpResponseMessage response = client.GetAsync(url).Result;


                var movies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;

                Movies = new ObservableCollection<Movie>(movies);

                var topRatedMovie = Movies.OrderByDescending(m => m.Rating).Take(1);

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

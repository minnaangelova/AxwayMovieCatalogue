using MovieCatalogueAppWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MovieCatalogueApp.Models.Entities;
using System.Net.Http.Headers;
using System.Collections.ObjectModel;

namespace MovieCatalogueAppWPF.ViewModels
{
    public class DeleteMovieViewModel:ViewModel
    {


        private Movie _currentMovie;

        public Movie CurrentMovie
        {
            get => _currentMovie;
            set
            {
                if (CurrentMovie != value)
                {
                    _currentMovie = value;
                    OnPropertyChanged(nameof(CurrentMovie));
                }
            }
        }

        private ObservableCollection<Movie> _collectionOfMovies;

        public ObservableCollection<Movie> CollectionOfMovies
        {
            get => _collectionOfMovies;
            set
            {
                if (this._collectionOfMovies != value)
                {
                    _collectionOfMovies = value;
                    OnPropertyChanged(nameof(CollectionOfMovies));
                }
            }
        }

        public ICommand DeleteMovieCommand { get; set; }
        public ICommand ListAll { get; set; }

        public DeleteMovieViewModel()
        {
            ListAll = new LambdaCommand(() =>
            {

                {
                    HttpClient client = new HttpClient
                    {
                        BaseAddress = new Uri("http://localhost:62560/")
                    };

                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));


                    var response = client.GetAsync("movies/all").Result;

                    var movies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;

                    CollectionOfMovies = new ObservableCollection<Movie>(movies);

                    MessageBox.Show(response.IsSuccessStatusCode
                        ? "Success!"
                        : $"Error code: {response.StatusCode} \n Message: {response.ReasonPhrase}");
                }
            });



            DeleteMovieCommand = new LambdaCommand(() =>
            {
                if (CurrentMovie == null)
                {

                }
                else
                {
                    HttpClient client = new HttpClient
                    {
                        BaseAddress = new Uri("http://localhost:62560/movies/")

                    };

                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var url = "deleteMovie/" + this.CurrentMovie.Id;
                    HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();
                    
                    MessageBox.Show(response.IsSuccessStatusCode
                        ? "Movie Deleted"
                        : $"Error code {response.StatusCode}");
                }
            });
        }
    }
}

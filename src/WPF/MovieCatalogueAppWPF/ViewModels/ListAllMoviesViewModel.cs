using MovieCatalogueAppWPF.Views;
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
using MovieCatalogueAppWPF.Validations;
using System.Collections.ObjectModel;

namespace MovieCatalogueAppWPF.ViewModels
{
    public class ListAllMoviesViewModel : ViewModel
    {
        private string _title;
        private DateTime _releasedDate;
        private string _summary;
        private double _rating;
        private Genre _genre;
        private Actor _actor;

        public ObservableCollection<Movie> collectionOfMovies
        {
            get;
            set;
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public DateTime ReleaseDate
        {
            get
            {
                return _releasedDate;
            }
            set
            {
                _releasedDate = value;
                OnPropertyChanged(nameof(ReleaseDate));
            }
        }

        public string Summary
        {
            get
            {
                return _summary;
            }
            set
            {
                _summary = value;
                OnPropertyChanged(nameof(Summary));
            }
        }

        public double Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                _rating = value;
                OnPropertyChanged(nameof(Rating));
            }
        }

        public Genre Genre
        {
            get
            {
                return _genre;
            }
            set
            {
                _genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }

        public Actor Actor
        {
            get
            {
                return _actor;
            }
            set
            {
                _actor = value;
                OnPropertyChanged(nameof(Actor));
            }
        }


        public ICommand ListAllMovies { get; set; }

        public ListAllMoviesViewModel()
        {
            ListAllMovies = new LambdaCommand(() =>
            {

                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:62560/")
                };

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));


                var response = client.GetAsync("movies/all").Result;

                var movies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;


                collectionOfMovies = movies as ObservableCollection<Movie>;

                MessageBox.Show(response.IsSuccessStatusCode
                    ? "Success!"
                    : $"Error code: {response.StatusCode} \n Message: {response.ReasonPhrase}");

            });
        }

    }


}


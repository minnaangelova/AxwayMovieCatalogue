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
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using MovieCatalogueAppWPF.Helpers;

namespace MovieCatalogueAppWPF.ViewModels
{
    public class ListAllMoviesViewModel : ViewModel
    {
        private string _title;
        private DateTime _releasedDate;
        private string _summary;
        private double _rating;
        private Genre _genre;
        private Option _selectedOption = new Option();

        private ObservableCollection<Option> _collectionOfOptions = new ObservableCollection<Option>();
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

        public Option SelectedOption
        {
            get => _selectedOption;
            set
            {
                if (_selectedOption != value)
                {
                    _selectedOption = value;
                    OnPropertyChanged(nameof(SelectedOption));
                }
            }
        }

        public ObservableCollection<Option> CollectionOfOptions
        {
            get => _collectionOfOptions;
            set
            {
                if (_collectionOfOptions != value)
                {
                    _collectionOfOptions = value;
                    OnPropertyChanged(nameof(CollectionOfOptions));
                }
            }
        }



        public ICommand ListAllMovies { get; set; }

        public ICommand ByRating { get; set; }

        public ICommand ByTitle { get; set; }


        public ListAllMoviesViewModel()
        {
            CollectionOfOptions.Add(new Option() { OptionName = "Descending" });
            CollectionOfOptions.Add(new Option() { OptionName = "Title" });
            CollectionOfOptions.Add(new Option() { OptionName = "Rating" });

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:62560/")
            };

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            ListAllMovies = new LambdaCommand(() =>
              {
                  if (SelectedOption.OptionName == "Title")
                  {
                      var response = client.GetAsync("movies/orderBy/Title").Result;

                      var movies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;

                      CollectionOfMovies = new ObservableCollection<Movie>(movies);
                  }

                  else if (SelectedOption.OptionName == "Rating")
                  {
                      var response = client.GetAsync("movies/orderBy/Rating").Result;

                      var movies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;

                      CollectionOfMovies = new ObservableCollection<Movie>(movies);
                  }

                  else
                  {
                      var response = client.GetAsync("movies/all").Result;

                      var movies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;

                      CollectionOfMovies = new ObservableCollection<Movie>(movies);
                  }

              });


            //    ByTitle = new LambdaCommand(() =>
            //      {
            //          HttpClient client = new HttpClient
            //          {
            //              BaseAddress = new Uri("http://localhost:62560/")
            //          };

            //          client.DefaultRequestHeaders.Accept.Add(
            //              new MediaTypeWithQualityHeaderValue("application/json"));


            //          var response = client.GetAsync("movies/orderBy/Title").Result;

            //          var movies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;

            //          CollectionOfMovies = new ObservableCollection<Movie>(movies);
            //      });


            //    ListAllMovies = new LambdaCommand(() =>
            //    {


            //        HttpClient client = new HttpClient
            //        {
            //            BaseAddress = new Uri("http://localhost:62560/")
            //        };

            //        client.DefaultRequestHeaders.Accept.Add(
            //            new MediaTypeWithQualityHeaderValue("application/json"));


            //        var response = client.GetAsync("movies/all").Result;

            //        var movies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;


            //        CollectionOfMovies = new ObservableCollection<Movie>(movies);                



            //        MessageBox.Show(response.IsSuccessStatusCode
            //            ? "Success!"
            //            : $"Error code: {response.StatusCode} \n Message: {response.ReasonPhrase}");

            //    });
            //}

        }
    }

}


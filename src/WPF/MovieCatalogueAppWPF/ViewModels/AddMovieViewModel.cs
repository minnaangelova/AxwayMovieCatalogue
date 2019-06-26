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

namespace MovieCatalogueAppWPF.ViewModels
{
    public class AddMovieViewModel: ViewModel
    {
        private string _title;
        private DateTime _releasedDate;
        private string _summary;
        private double _rating;
        private Genre _genre;

        public string Title
        {
            get => _title;
            set
            {
                if (Title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public DateTime ReleaseDate   
        {
            get => _releasedDate;
            set
            {
                if (ReleaseDate != value)
                {
                    _releasedDate = value;
                    OnPropertyChanged(nameof(ReleaseDate));
                }
            }
        }

        public string Summary
        {
            get => _summary;
            set
            {
                if (Summary != value)
                {
                    (_summary) = value;
                    OnPropertyChanged(nameof(Summary));
                }
            }
        }

        public double Rating
        {
            get => _rating;
            set
            {
                if (Math.Abs(Rating - value) > 0.01)
                {
                    _rating = value;
                    OnPropertyChanged(nameof(Rating));
                }
            }
        }

        public Genre Genre
        {
            get => _genre;
            set
            {
                if (Genre != value)
                {
                    _genre = value;
                    OnPropertyChanged(nameof(Genre));
                }
            }
        }

        public ICommand AddNewMovie { get; set; }

        public AddMovieViewModel()
        {
            AddNewMovie = new LambdaCommand(() =>
            {
                var validation = new Validations.AreFieldsEmpty();
                //if (!validation.AreFieldsValid(this.Title, this.ReleaseDate, this.Summary, this.Rating, this.Genre.ToString()))
                {
                    HttpClient client = new HttpClient
                    {
                        BaseAddress = new Uri("http://localhost:12789/")
                    };

                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var movieToAdd = new Movie
                    {
                        Title = this.Title,
                        ReleaseDate = this.ReleaseDate,
                        Summary = this.Summary,
                        Rating = this.Rating,
                        Genre = this.Genre
                    };


                    var response = client.PostAsJsonAsync("api/movies", movieToAdd).Result;

                    MessageBox.Show(response.IsSuccessStatusCode
                        ? "Success!"
                        : $"Error code: {response.StatusCode} \n Message: {response.ReasonPhrase}");
                }
            });
        }
    }
}

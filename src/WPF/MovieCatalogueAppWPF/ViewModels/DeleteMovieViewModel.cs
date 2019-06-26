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

        public ICommand DeleteMovieCommand { get; set; }

        public DeleteMovieViewModel()
        {
            this.DeleteMovieCommand = new LambdaCommand(() =>
            {
                if (CurrentMovie == null)
                {
                }

                else
                {
                    HttpClient client = new HttpClient {BaseAddress = new Uri("http://localhost:12789/")};

                    var url = "api/movie";  //+ id;
                    HttpResponseMessage response = client.DeleteAsync(url).Result;

                    MessageBox.Show(response.IsSuccessStatusCode
                        ? "User Deleted"
                        : $"Error code {response.StatusCode}");
                }
            });
        }
    }
}

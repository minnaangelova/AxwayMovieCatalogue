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
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace MovieCatalogueAppWPF.ViewModels
{
    public class AddMovieViewModel: ViewModel
    {
        private string _title;
        private DateTime _releasedDate;
        private string _summary;
        private double _rating;
        private Genre _genre;
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

        public ICommand ListAll { get; set; }
        public ICommand AddNewMovie { get; set; }

        public AddMovieViewModel()
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



            AddNewMovie = new LambdaCommand(() =>
              {

                  //HttpClient client = new HttpClient
                  //{
                  //    BaseAddress = new Uri("http://localhost:62560/")
                  //};




                  string ResponseString = "";
                  HttpWebResponse response = null;
                  using (var httpClient = new HttpClient())
                  {
                      httpClient.DefaultRequestHeaders.Accept.Add(
                          new MediaTypeWithQualityHeaderValue("application/json"));

                      var movieToAdd = new Movie
                      {
                          Title = this.Title,
                          ReleaseDate = this.ReleaseDate,
                          Summary = this.Summary,
                          Rating = this.Rating,
                          Genre = this.Genre


                      };
                      JavaScriptSerializer jss = new JavaScriptSerializer();
                      // serialize into json string
                      var myContent = jss.Serialize(movieToAdd);
                      var httpContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                      HttpResponseMessage responseMessage = httpClient.PostAsync("http://localhost:62560/movies/add", httpContent).GetAwaiter().GetResult();


                      
                  }


                  //application/xml
                  //     var request = (HttpWebRequest)WebRequest.Create("http://localhost:62560/movies/add");
                  //     request.Accept = "application/json"; //"application/xml";
                  //     request.Method = "POST";
                  // var movieToAdd = new Movie
                  // {
                  //     Title = this.Title,
                  //     ReleaseDate = this.ReleaseDate,
                  //     Summary = this.Summary,
                  //     Rating = this.Rating,
                  //     Genre = this.Genre
                  // };
                  //     JavaScriptSerializer jss = new JavaScriptSerializer();
                  //   var myContent = jss.Serialize(movieToAdd);
                  //   var data = Encoding.ASCII.GetBytes(myContent);

                  //     request.ContentType = "application/json";
                  //     request.ContentLength = data.Length;
                  //     using (var stream = request.GetRequestStream())
                  //     {
                  //         stream.Write(data, 0, data.Length);
                  //     }
                  //     response = (HttpWebResponse)request.GetResponse();

                  //     ResponseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


                  //var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();

                  //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                  //{
                  //    var result = streamReader.ReadToEnd();
                  //}
                  //client.DefaultRequestHeaders.Accept.Add(
                  //        new MediaTypeWithQualityHeaderValue("application/json"));


                  //var movieToAdd = new Movie
                  //{
                  //    Title = this.Title,
                  //    ReleaseDate = this.ReleaseDate,
                  //    Summary = this.Summary,
                  //    Rating = this.Rating,
                  //    Genre = this.Genre
                  //};
                  //var movie = JsonConvert.SerializeObject(movieToAdd);
                  //;
                  //var stringContent = new StringContent(Js.SerializeObject(movieToAdd));
                  //var response = client.PostAsync("movies/add", stringContent).Result;



                  //MessageBox.Show(response.IsSuccessStatusCode
                  //     ? "Success!"
                  //     : $"Error code: {response.StatusCode} \n Message: {response.ReasonPhrase}");



              });


        }
    }
}

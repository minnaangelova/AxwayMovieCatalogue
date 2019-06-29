using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MovieCatalogueApp.Models.Entities;

namespace MovieCatalogueAppWPF.ViewModels
{
    public class ListActorsViewModel : ViewModel
    {
            private string _firstName;
            private string _lastName;

            private ObservableCollection<Actor> _collectionOfActors;


            public ObservableCollection<Actor> CollectionOfActors
            {
                get => _collectionOfActors;
                set
                {
                    if (this._collectionOfActors != value)
                    {
                        _collectionOfActors = value;
                        OnPropertyChanged(nameof(CollectionOfActors));
                    }
                }
            }

            public string FirstName
            {
                get
                {
                    return _firstName;
                }
                set
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }

            public string LastName
            {
                get
                {
                    return _lastName;
                }
                set
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }



            public ICommand ListActorsCommand { get; set; }

            public ListActorsViewModel()
            {

                ListActorsCommand = new LambdaCommand(() =>
                {
                    HttpClient client = new HttpClient
                    {
                        BaseAddress = new Uri("http://localhost:62560/")
                    };

                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));


                    var response = client.GetAsync("actors/all").Result;

                    var actors = response.Content.ReadAsAsync<IEnumerable<Actor>>().Result;

                    CollectionOfActors = new ObservableCollection<Actor>(actors);
                });

            }

        }
    }


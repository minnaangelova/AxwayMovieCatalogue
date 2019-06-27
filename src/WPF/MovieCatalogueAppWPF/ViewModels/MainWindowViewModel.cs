using MovieCatalogueAppWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieCatalogueAppWPF.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                if (CurrentView != value)
                {
                    _currentView = value;
                    OnPropertyChanged(nameof(CurrentView));
                }
            }
        }

        
        public ICommand StartupViewCommand { get; set; }
        public ICommand AddMovieViewCommand { get; set; }
        public ICommand DeleteMovieViewCommand { get; set; }
        public ICommand ListAllMoviesViewCommand { get; set; }
        public ICommand EditMovieViewCommand { get; set; }

        public MainWindowViewModel()
        {
            CurrentView = new StartupView();

            StartupViewCommand = new LambdaCommand(() =>
            {
                CurrentView = new StartupView();
            });

            AddMovieViewCommand = new LambdaCommand(() =>
            {
                CurrentView = new AddMovieView();

            });

            DeleteMovieViewCommand = new LambdaCommand(() =>
            {
                CurrentView = new DeleteMovieView();
            });

            EditMovieViewCommand = new LambdaCommand(() =>
            {
                CurrentView = new EditMovieView();

            });

            ListAllMoviesViewCommand = new LambdaCommand(() =>
            {
                CurrentView = new ListAllMoviesView();

            });

        }


    }

}


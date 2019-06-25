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
        private ICommand _AddCommand;

        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new RelayCommand(AddExecute, CanAddExecute, false);
                }
                return _AddCommand;
            }
            set
            {

            }
        }

        private void AddExecute(object parameter)
        {
            new AddMovieView();
        }

        private bool CanAddExecute(object parameter)
        {
            return true;
        }

        private ICommand _DeleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new RelayCommand(DeleteExecute, CanDeleteExecute, false);
                }
                return _DeleteCommand;
            }
            set
            {

            }
        }

        private void DeleteExecute(object parameter)
        {
            new DeleteMovieView();
        }

        private bool CanDeleteExecute(object parameter)
        {
            return true;
        }

        private ICommand _EditCommand;

        public ICommand EditCommand
        {
            get
            {
                if (_EditCommand == null)
                {
                    _EditCommand = new RelayCommand(EditExecute, CanEditExecute, false);
                }
                return _EditCommand;
            }
            set
            {

            }
        }

        private void EditExecute(object parameter)
        {
            new EditMovieView();
        }

        private bool CanEditExecute(object parameter)
        {
            return true;
        }

        private ICommand _ListAllommand;

        public ICommand ListAllCommand
        {
            get
            {
                if (_ListAllommand == null)
                {
                    _ListAllommand = new RelayCommand(ListAllExecute, CanListAllExecute, false);
                }
                return _ListAllommand;
            }
            set
            {

            }
        }

        private void ListAllExecute(object parameter)
        {
            new ListAllMoviesView();
        }

        private bool CanListAllExecute(object parameter)
        {
            return true;
        }

        private ICommand _StartupCommand;

        public ICommand StartupCommand
        {
            get
            {
                if (_StartupCommand == null)
                {
                    _StartupCommand = new RelayCommand(StartupExecute, CanStartupExecute, false);
                }
                return _StartupCommand;
            }
            set
            {

            }
        }

        private void StartupExecute(object parameter)
        {
            new StartupView();
        }

        private bool CanStartupExecute(object parameter)
        {
            return true;
        }


    }

}


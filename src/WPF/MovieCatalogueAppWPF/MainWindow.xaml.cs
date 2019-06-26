using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MovieCatalogueAppWPF.ViewModels;
using MovieCatalogueAppWPF.Views;

namespace MovieCatalogueAppWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel();
            this.DataContext = new StartupView();
        }

        private void ButtonStartup(object sender, RoutedEventArgs e)
        {
            this.DataContext = new StartupView();
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            this.DataContext = new AddMovieView();
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            this.DataContext = new DeleteMovieView();
        }

        private void ButtonEdit(object sender, RoutedEventArgs e)
        {
            this.DataContext = new EditMovieView();
        }

        private void ButtonList(object sender, RoutedEventArgs e)
        {
            this.DataContext = new ListAllMoviesView();
        }
    }
}

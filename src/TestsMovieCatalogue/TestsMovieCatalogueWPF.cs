using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieCatalogueAppWPF.ViewModels;

namespace TestsMovieCatalogue
{
    [TestClass]
    public class TestsMovieCatalogueWPF
    {
        [TestMethod]
        public void TestSideMenuButtons()
        {
            MainWindowViewModel target = new MainWindowViewModel();

            var addMovieCommandButton = target.AddMovieViewCommand;
            var listMovieCommandButton = target.ListAllMoviesViewCommand;

            Assert.AreEqual(true, addMovieCommandButton.CanExecute(null));

            Assert.AreEqual(true, listMovieCommandButton.CanExecute(null));
        }
    }



    [TestClass]
    public class WPF_View_Tests
    {
        [TestMethod]
        public void AddMovieView_FieldsAreEmpty_Check()
        {
            AddMovieViewModel amw = new AddMovieViewModel();

            Assert.AreEqual(null, amw.Title);
            Assert.AreEqual(null, amw.ReleaseDate);
            Assert.AreEqual(0, amw.Rating);
            Assert.AreEqual(null, amw.Summary);
        }



        [TestMethod]
        public void IsTheSearchFieldEmpty()
        {
            StartupViewModel startUp = new StartupViewModel();

            Assert.AreEqual(null, startUp.TextBoxValue);
        }

    }
}


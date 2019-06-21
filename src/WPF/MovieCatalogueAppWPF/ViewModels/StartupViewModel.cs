using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieCatalogueAppWPF.ViewModels
{
    public class StartupViewModel: ViewModel
    {
        public ICommand StartUpCommand { get; set; }

        //public StartupViewModel()
        //{
        //    this.StartUpCommand = new LambdaCommand((() =>
        //    {
        //        var startUpWindow = new StartupView();
        //        startUpWindow.
        //    }));
        //}
    }
}

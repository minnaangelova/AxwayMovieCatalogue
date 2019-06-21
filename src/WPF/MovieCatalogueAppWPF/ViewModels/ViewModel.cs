using System.ComponentModel;
using MovieCatalogueAppWPF.Annotations;

namespace MovieCatalogueAppWPF.ViewModels
{
    public class ViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged( string propertyName)
        {
            PropertyChanged?.Invoke
                (this, 
                new PropertyChangedEventArgs(propertyName));
        }
    }
}

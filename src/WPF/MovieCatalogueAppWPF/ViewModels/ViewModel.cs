using System.ComponentModel;
using MovieCatalogueAppWPF.Annotations;

namespace MovieCatalogueAppWPF
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke
                (this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}

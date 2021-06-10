using System.Collections.ObjectModel;
using System.ComponentModel;
using TesteRegina.Model;

namespace TesteRegina.ViewModel
{
    public class HistoricoViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<HistoricoModel> _ListaOrdens;

        public ObservableCollection<HistoricoModel> ListaOrdens
        {
            get
            {
                return _ListaOrdens;
            }
            set
            {
                _ListaOrdens = value;
                OnPropertyChanged("ListaOrdens");
            }
        }

        public HistoricoViewModel()
        {
            ListaOrdens = new ObservableCollection<HistoricoModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
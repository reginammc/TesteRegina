using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Timers;
using TesteRegina.Model;
using TesteRegina.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteRegina.View
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoricoView : ContentPage, INotifyPropertyChanged
    {
        public HistoricoViewModel viewModelHistoricos;

        private Timer aTimer, aTimer2, aTimer3;

        private int limiteMaximo = 0;
        //usado para parar os timers quando atingir determinado limite. 
        //Para rodar indefinidamente, limitemaximo = 0 

        private long _Qtde, _QtdeDisponivel;
        public long Qtde
        {
            get { return _Qtde; }
            set
            {
                _Qtde = value;
                OnPropertyChanged();
            }
        }
        public long QtdeDisponivel
        {
            get { return _QtdeDisponivel; }
            set
            {
                _QtdeDisponivel = value;
                OnPropertyChanged();
            }
        }

        public HistoricoView()
        {
            InitializeComponent();

            viewModelHistoricos = new HistoricoViewModel();
            this.BindingContext = viewModelHistoricos;

            aTimer = new System.Timers.Timer();
            aTimer.Interval = 50;
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventAdd); ;
            aTimer.Enabled = true;

            aTimer2 = new System.Timers.Timer();
            aTimer2.Interval = 500;
            aTimer2.Elapsed += new ElapsedEventHandler(OnTimedEventEdit); ;
            aTimer2.Enabled = true;

            aTimer3 = new System.Timers.Timer();
            aTimer3.Interval = 10000;
            aTimer3.Elapsed += new ElapsedEventHandler(OnTimedEventAsync); ;
            aTimer3.Enabled = true;
            
            lbQtde.SetBinding(Label.TextProperty, new Binding("Qtde", BindingMode.Default));
            lbQtde.BindingContext = this;
            lbQtdeDisponivel.SetBinding(Label.TextProperty, new Binding("QtdeDisponivel", BindingMode.Default));
            lbQtdeDisponivel.BindingContext = this;
        }

        private void OnTimedEventAdd(Object source, System.Timers.ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => { AdicionaItemAsync(); });
        }
        private void OnTimedEventEdit(Object source, System.Timers.ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                for (long i = 0; i < 100; i++)
                {
                    EditaItemAsync();
                }
            });
        }

        private async void OnTimedEventAsync(Object source, System.Timers.ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                for (long i = 0; i < 1000; i++)
                {
                    AdicionaItemAsync();
                }
            });
        }

        private async Task AdicionaItemAsync()
        {
            Random randNum = new Random();
            var registro = new HistoricoModel();
            registro.Data = DateTime.Now;
            registro.Assessor = "-";
            registro.Conta = randNum.Next(1000000, 9999999);
            registro.Ativo = "ABCDE";
            registro.Tipo = "C";
            registro.Quantidade = 1;
            registro.QtdDisp = randNum.Next(10);
            registro.ObjDisp = "-";
            registro.Objetivo = "-";
            registro.QtdAparente = 1;
            registro.QtdCanc = 0;
            registro.QtdExec = 0;
            registro.Reducao = "-";

            AddItem(registro);
            Qtde = viewModelHistoricos.ListaOrdens.Count;
            QtdeDisponivel += registro.QtdDisp;
        }

        private async Task EditaItemAsync()
        {
            Random randNum = new Random();
            int ind = randNum.Next(viewModelHistoricos.ListaOrdens.Count);
            viewModelHistoricos.ListaOrdens[ind].Objetivo = "ALTERADO";
            viewModelHistoricos.ListaOrdens[ind].Tipo = "D";
            viewModelHistoricos.ListaOrdens[ind].Valor += 10;
        }

        private void AddItem(HistoricoModel registro)
        {
            viewModelHistoricos.ListaOrdens.Add(registro);
            Qtde = viewModelHistoricos.ListaOrdens.Count;

            if (limiteMaximo > 0 && Qtde == limiteMaximo)
            {
                aTimer.Stop();
                aTimer2.Stop();
                aTimer3.Stop();

                aTimer.Dispose();
                aTimer2.Dispose();
                aTimer3.Dispose();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
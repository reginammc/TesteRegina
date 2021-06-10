using TesteRegina.View;
using Xamarin.Forms;

namespace TesteRegina
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            //MainPage = new CustomNavigationPage(new HistoricoView());
            MainPage = new HistoricoView();
        }
    }
}

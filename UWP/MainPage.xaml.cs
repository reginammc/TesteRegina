using Xamarin.Forms.Platform.UWP;

namespace UWP
{
    public partial class MainPage : WindowsPage
    {
        public MainPage()
        {
            //InitializeComponent();
            LoadApplication(new TesteRegina.App());
        }
    }
}
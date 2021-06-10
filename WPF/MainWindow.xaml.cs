using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace WPF
{
    /// <summary>
    /// Lógica interna para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();
            Forms.Init();
            LoadApplication(new TesteRegina.App());
        }
    }
}

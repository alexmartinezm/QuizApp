using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace QuizHelp.Views
{
    public partial class HomePage
    {
        public HomePage()
        {
            InitializeComponent();

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }
    }
}

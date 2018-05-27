using Xamarin.Forms.Xaml;

namespace QuizHelp.Views
{
    public partial class HomePage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        void Handle_PositionSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {
            if (e.NewValue == 0)
            {

            }
        }
    }
}

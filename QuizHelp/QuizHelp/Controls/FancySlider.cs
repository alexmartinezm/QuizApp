using Xamarin.Forms;

namespace QuizHelp.Controls
{
    public class FancySlider : Slider
    {
        public static readonly BindableProperty BarHeightProperty = BindableProperty.Create(nameof(BarHeight), typeof(double), typeof(FancySlider), 4.0);

        public double BarHeight
        {
            get => (double)GetValue(BarHeightProperty);
            set => SetValue(BarHeightProperty, value);
        }
    }
}

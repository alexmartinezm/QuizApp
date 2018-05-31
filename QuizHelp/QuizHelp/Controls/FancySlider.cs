using Xamarin.Forms;

namespace QuizHelp.Controls
{
    public class FancySlider : Slider
    {
        public static readonly BindableProperty BarHeightProperty = BindableProperty.Create(nameof(BarHeight), typeof(double), typeof(FancySlider), 4.0);

        public static readonly BindableProperty SelectedValueProperty = BindableProperty.Create(nameof(SelectedValue), typeof(int), typeof(FancySlider), 0, BindingMode.TwoWay);

        public double BarHeight
        {
            get => (double)GetValue(BarHeightProperty);
            set => SetValue(BarHeightProperty, value);
        }

        public int SelectedValue
        {
            get => (int)GetValue(SelectedValueProperty);
            set => SetValue(SelectedValueProperty, value);
        }
    }
}

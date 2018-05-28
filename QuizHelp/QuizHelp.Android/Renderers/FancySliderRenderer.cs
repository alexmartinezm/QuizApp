using Android.Content;
using QuizHelp.Controls;
using QuizHelp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FancySlider), typeof(FancySliderRenderer))]
namespace QuizHelp.Droid.Renderers
{
    public class FancySliderRenderer : SliderRenderer
    {
        private int _barHeight;

        public FancySliderRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || e.NewElement == null)
                return;
            var slider = (FancySlider)Element;
            _barHeight = (int)slider.BarHeight;
        }
    }
}

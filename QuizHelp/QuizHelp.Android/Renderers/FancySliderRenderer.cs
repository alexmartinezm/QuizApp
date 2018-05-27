using Android.Content;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.OS;
using Android.Widget;
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

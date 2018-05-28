using QuizHelp.Controls;
using QuizHelp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FancySlider), typeof(FancySliderRenderer))]
namespace QuizHelp.iOS.Renderers
{
    public class FancySliderRenderer : SliderRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            if (e.NewElement != null && e.NewElement is FancySlider slider)
            {
                SetNativeControl(new Controls.FancySlideriOS(slider.BarHeight));
                base.OnElementChanged(e);
            }
        }
    }
}

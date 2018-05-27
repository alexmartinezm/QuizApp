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
            SetNativeControl(new Controls.FancySlideriOS(((FancySlider)e.NewElement).BarHeight));
            base.OnElementChanged(e);
        }
    }
}

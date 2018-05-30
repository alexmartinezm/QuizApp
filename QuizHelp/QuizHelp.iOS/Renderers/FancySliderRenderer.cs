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
                var customSlider = new Controls.FancySlideriOS(slider.BarHeight);
                customSlider.ValueChanged += OnControlValueChanged;

                SetNativeControl(customSlider);

                base.OnElementChanged(e);
            }
        }

        void OnControlValueChanged(object sender, System.EventArgs e)
        {
            ((IElementController)Element).SetValueFromRenderer(Slider.ValueProperty, Control.Value);
        }

        protected override void Dispose(bool disposing)
        {
            if (Control != null)
                Control.ValueChanged -= OnControlValueChanged;

            base.Dispose(disposing);
        }
    }
}
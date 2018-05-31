using System;
using System.ComponentModel;
using QuizHelp.Controls;
using QuizHelp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using QuizHelp.iOS.Controls;

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

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (!(sender is FancySlider slider))
                return;

            if (e.PropertyName == nameof(FancySlider.SelectedValue))
            {
                var args = new EventArgs();
                if (slider.SelectedValue == 0 && Math.Abs(slider.Value) > Double.Epsilon)
                {
                    Control.Value = 0;
                    OnControlValueChanged(Control, null);
                }
            }
        }

        void OnControlValueChanged(object sender, EventArgs e)
        {
            var newValue = Math.Round(((FancySlideriOS)sender).Value / 1);

            Control.Value = (float)(newValue * 1);
            ((IElementController)Element).SetValueFromRenderer(Slider.ValueProperty, Control.Value);
            ((FancySlider)Element).SelectedValue = (int)Control.Value;
        }

        protected override void Dispose(bool disposing)
        {
            if (Control != null)
                Control.ValueChanged -= OnControlValueChanged;

            base.Dispose(disposing);
        }
    }
}
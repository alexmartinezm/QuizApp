using System;
using System.ComponentModel;
using Android.Content;
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
        private readonly Context _context;

        public FancySliderRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || e.NewElement == null)
                return;

            var progressDrawable = _context.GetDrawable(Resource.Drawable.seekbar_custom);
            Control.ProgressDrawable = progressDrawable;

            var thumbDrawable = _context.GetDrawable(Resource.Drawable.seekbar_thumb_custom);
            Control.SetThumb(thumbDrawable);

            Control.Max = (int)e.NewElement.Maximum;
            e.NewElement.ValueChanged += NewElement_ValueChanged;
            //Control.ProgressChanged += Control_ProgressChanged;
            Control.SplitTrack = false;
        }

        void Control_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            Control.SetValue(Slider.ValueProperty, e.Progress);
        }

        void NewElement_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            //((IElementController)Element).SetValueFromRenderer(Slider.ValueProperty, Control.Progress);
            //Control.SetValue(Slider.ValueProperty, Control.Progress);
        }

    }
}

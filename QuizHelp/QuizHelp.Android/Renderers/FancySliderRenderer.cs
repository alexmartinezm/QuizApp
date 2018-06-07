using System.ComponentModel;
using Android.Content;
using QuizHelp.Controls;
using QuizHelp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Java.Lang;

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

            var thumbDrawable = _context.GetDrawable(Resource.Drawable.seekbar_thumb_custom);
            Control.SetThumb(thumbDrawable);

            var progressDrawable = _context.GetDrawable(Resource.Drawable.seekbar_custom);
            Control.ProgressDrawable = progressDrawable;

            // HACK to avoid thumb's split
            Control.SetPadding(90, 0, 90, 0);

            Control.Max = (int)e.NewElement.Maximum;
            Control.ProgressChanged += OnControlProgressChanged;
            Control.SplitTrack = false;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (!(sender is FancySlider slider))
                return;

            if (e.PropertyName == nameof(FancySlider.Maximum))
            {
                Control.Max = (int)slider.Maximum;
            }
            else if (e.PropertyName == nameof(FancySlider.SelectedValue))
            {
                var args = new Android.Widget.SeekBar.ProgressChangedEventArgs(Control, slider.SelectedValue, true);
                OnControlProgressChanged(slider, args);
            }
        }

        void OnControlProgressChanged(object sender, Android.Widget.SeekBar.ProgressChangedEventArgs e)
        {
            Control.Progress = Math.Round(e.Progress / 1) * 1;
            ((FancySlider)Element).SelectedValue = Control.Progress;
        }
    }
}

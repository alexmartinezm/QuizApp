using Android.Content;
using QuizHelp.Controls;
using QuizHelp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.OS;

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

            Control.SplitTrack = false;
        }
    }
}

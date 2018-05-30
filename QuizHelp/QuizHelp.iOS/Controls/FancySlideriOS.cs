using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace QuizHelp.iOS.Controls
{
    public class FancySlideriOS : UISlider
    {
        private double _barHeight;

        public FancySlideriOS(double barHeight)
        {
            _barHeight = barHeight;
            ThumbTintColor = Color.FromHex("#857E7B").ToUIColor();
            MaximumTrackTintColor = Color.FromHex("#8BBF9F").ToUIColor();
            MinimumTrackTintColor = Color.FromHex("#8BBF9F").ToUIColor();
        }

        public override CGRect TrackRectForBounds(CGRect forBounds)
        {
            var rect = base.TrackRectForBounds(forBounds);
            return new CGRect(rect.X, rect.Y, rect.Width, _barHeight);
        }
    }
}

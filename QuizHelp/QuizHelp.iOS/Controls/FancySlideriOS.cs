using CoreGraphics;
using UIKit;

namespace QuizHelp.iOS.Controls
{
    public class FancySlideriOS : UISlider
    {
        private double _barHeight;

        public FancySlideriOS(double barHeight)
        {
            _barHeight = barHeight;
        }

        public override CGRect TrackRectForBounds(CGRect forBounds)
        {
            var rect = base.TrackRectForBounds(forBounds);
            return new CGRect(rect.X, rect.Y, rect.Width, _barHeight);
        }
    }
}

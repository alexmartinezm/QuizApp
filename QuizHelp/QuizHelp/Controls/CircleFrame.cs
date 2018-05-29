using Xamarin.Forms;

namespace QuizHelp.Controls
{
    public class CircleFrame : Frame
    {
        public CircleFrame(double width)
        {
            CornerRadius = Device.RuntimePlatform == Device.Android ? 100 : (float)(width / 2.0);
            HeightRequest = width;
            WidthRequest = width;
            BackgroundColor = Color.White;
            BorderColor = Color.White;
            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;
            Margin = 0;
            Padding = 0;
            HasShadow = false;
        }
    }
}

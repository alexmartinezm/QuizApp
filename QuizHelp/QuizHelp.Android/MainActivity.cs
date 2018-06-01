using Android.App;
using Android.Content.PM;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;

namespace QuizHelp.Droid
{
    [Activity(Label = "Tech Help", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Plugin.Iconize.Iconize.Init(Resource.Id.toolbar, Resource.Id.sliding_tabs);
            ImageCircleRenderer.Init();

            LoadApplication(new App(new AndroidInitializer()));
        }
    }
}


using System;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using QuizHelp.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace QuizHelp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            Plugin.Iconize.Iconize
                  .With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
                  .With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule())
                  .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule());

            NavigationService.NavigateAsync(new Uri($"/{nameof(HomePage)}", UriKind.Absolute));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomePage>();
            containerRegistry.RegisterForNavigation<ResultPage>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

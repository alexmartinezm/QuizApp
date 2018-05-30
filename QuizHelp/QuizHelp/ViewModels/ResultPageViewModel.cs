using Prism.Navigation;
using QuizHelp.Constants;
using QuizHelp.ViewModels.Base;

namespace QuizHelp.ViewModels
{
    public class ResultPageViewModel : ViewModelBase, INavigationAware
    {
        private Result _result;
        private string _backgroundColor;
        private readonly INavigationService _navigationService;

        public Result Result
        {
            get => _result;
            set
            {
                _result = value;
                RaisePropertyChanged();
            }
        }

        public string BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                _backgroundColor = value;
                RaisePropertyChanged();
            }
        }

        public ResultPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            Result = (Result)parameters[ParameterKeys.Result];
            BackgroundColor = (string)parameters[ParameterKeys.BackgroundColor];
        }
    }
}

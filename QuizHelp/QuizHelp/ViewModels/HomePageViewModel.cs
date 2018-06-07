using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Prism.Commands;
using Prism.Navigation;
using QuizHelp.Constants;
using QuizHelp.Extensions;
using QuizHelp.ViewModels.Base;
using QuizHelp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace QuizHelp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private static Random _random;

        private double _maximumValue;
        private bool _canChangeQuestion;
        private Question _currentQuestion;
        private Answer _selectedAnswer;
        private string _backgroundColor;
        private List<string> _colors;
        private int _score;
        private int _selectedValueInt;

        public Quiz QuizData { get; set; }

        public DelegateCommand<object> NewAnswerCommand { get; private set; }

        public Question CurrentQuestion
        {
            get => _currentQuestion;

            set
            {
                _currentQuestion = value;
                RaisePropertyChanged();

                MaximumValue = _currentQuestion.Answers.Count() - 1;
                SelectedValueInt = 0;
            }
        }

        public Answer SelectedAnswer
        {
            get => _selectedAnswer;

            set
            {
                _selectedAnswer = value;
                RaisePropertyChanged();
            }
        }

        public double MaximumValue
        {
            get => _maximumValue;

            set
            {
                _maximumValue = value;
                RaisePropertyChanged();
            }
        }

        public int CurrentPosition { get; set; }

        public bool CanChangeQuestion
        {
            get => _canChangeQuestion;

            set
            {
                _canChangeQuestion = value;
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

        public int SelectedValueInt
        {
            get => _selectedValueInt;
            set
            {
                _selectedValueInt = value;
                RaisePropertyChanged();

                if (CurrentQuestion != null)
                {
                    SelectedAnswer = CurrentQuestion.Answers.ElementAt(_selectedValueInt);
                }
            }
        }

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Title = "Home";

            _random = new Random();
            SelectedValueInt = 0;

            LoadCommands();
            LoadData();

            GenerateQuestion();
            CanChangeQuestion = true;
        }

        private void LoadCommands()
        {
            NewAnswerCommand = new DelegateCommand<object>(OnNewAnswer);
        }

        private void OnNewAnswer(object answer)
        {
            if (answer != null && answer is Answer selectedAnswer)
            {
                SetAnswer(selectedAnswer);
                RemoveQuestion(CurrentQuestion);
                ChangeColors();

                GenerateQuestion();
            }
        }

        private void LoadData()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("QuizHelp.Data.quiz_data.json");
            string jsonData = string.Empty;
            using (var reader = new StreamReader(stream))
            {
                jsonData = reader.ReadToEnd();
            }

            QuizData = Quiz.FromJson(jsonData);

            if (QuizData == null)
                throw new ArgumentNullException();

            _colors = new List<string> { "#d3ece1", "#ffdfba", "#ffffba", "#baffc9", "#cddfda" };
            BackgroundColor = _colors.First();
        }

        private void SetAnswer(Answer answer)
        {
            _score += answer.Points;
        }

        private void RemoveQuestion(Question question)
        {
            var index = QuizData.Questions.IndexOf(question);
            QuizData.Questions.Splice(index, 1);
        }

        private void ChangeColors()
        {
            if (_colors == null || !_colors.Any())
                return;

            _colors.Insert(0, _colors.Last());
            BackgroundColor = _colors.First();
            _colors.RemoveAt(_colors.Count() - 1);
        }

        private void GenerateQuestion()
        {
            if (!QuizData.Questions.Any())
            {
                var result = GetResult(_score);

                var parameters = new NavigationParameters
                {
                    {ParameterKeys.Result, result},
                    {ParameterKeys.BackgroundColor, _colors.ElementAt(_random.Next(0, _colors.Count()))}
                };

                _navigationService.NavigateAsync(new Uri($"/{nameof(ResultPage)}", UriKind.Absolute), parameters);
                return;
            }

            var index = _random.Next(0, QuizData.Questions.Count());
            CurrentQuestion = QuizData.Questions[index];
        }

        private Result GetResult(int score)
        {
            if (QuizData?.Results == null || !QuizData.Results.Any())
                return null;

            Result result = null;

            if (score <= 15)
            {
                result = QuizData.Results.First();
            }
            else if (score <= 30)
            {
                result = QuizData.Results.ElementAt(1);
            }
            else if (score <= 45)
            {
                result = QuizData.Results.ElementAt(2);
            }
            else
            {
                result = QuizData.Results.ElementAt(3);
            }

            return result;
        }
    }
}
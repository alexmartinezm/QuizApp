﻿using System;
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
        private static int MaxValue;

        private double _sliderValue;
        private double _maximumValue;
        private bool _canChangeQuestion;
        private Question _currentQuestion;
        private Answer _selectedAnswer;
        private static Random _random;

        public Quiz QuizData { get; set; }

        private string _backgroundColor;
        private List<string> _colors;
        private int[] _answers;

        public DelegateCommand<object> ValueChangedCommand { get; private set; }
        public DelegateCommand NewAnswerCommand { get; private set; }


        public Question CurrentQuestion
        {
            get => _currentQuestion;

            set
            {
                _currentQuestion = value;
                RaisePropertyChanged();

                MaximumValue = _currentQuestion.Answers.Count() - 1;
                SelectedAnswer = _currentQuestion.Answers.First();
                CanChangeQuestion = false;
                SliderValue = 0;
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

        public double SliderValue
        {
            get => _sliderValue;

            set
            {
                _sliderValue = value;
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
                MaxValue = (int)_maximumValue;
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

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Title = "Home";

            _random = new Random();
            SliderValue = 0;

            LoadCommands();
            LoadData();

            GenerateQuestion();
        }

        private void LoadCommands()
        {
            ValueChangedCommand = new DelegateCommand<object>(OnValueChanged);
            NewAnswerCommand = new DelegateCommand(OnNewAnswer);
        }

        private void OnValueChanged(object oldValue)
        {
            if (oldValue == null)
            {
                SliderValue = 0;
                CanChangeQuestion = false;
            }
            else
            {
                if (Device.RuntimePlatform != Device.Android)
                {
                    var newValue = Math.Round(SliderValue / 1);
                    SliderValue = newValue * 1;
                }

                CanChangeQuestion = true;
            }

            //GetIndex();
            SelectedAnswer = CurrentQuestion.Answers.ElementAt((int)SliderValue);
        }

        private void OnNewAnswer()
        {
            SetAnswer((int)SliderValue);
            RemoveQuestion(CurrentQuestion);
            ChangeColors();

            GenerateQuestion();
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

        private void SetAnswer(int answer)
        {
            if (_answers == null || !_answers.Any())
            {
                _answers = new int[QuizData.Questions.First().Answers.Count()];
                for (int i = 0; i < _answers.Length; i++)
                {
                    _answers[i] = 0;
                }
            }
            _answers[answer]++;
        }

        private void RemoveQuestion(Question question)
        {
            var index = QuizData.Questions.IndexOf(question);
            QuizData.Questions.Splice(index, 1);
        }

        private void ChangeColors()
        {
            _colors.Insert(0, _colors.Last());
            BackgroundColor = _colors.First();
        }

        private void GenerateQuestion()
        {
            if (!QuizData.Questions.Any())
            {
                var selectedAnswer = _answers.IndexOf(_answers.Max());
                var result = QuizData.Results[selectedAnswer];

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
    }
}
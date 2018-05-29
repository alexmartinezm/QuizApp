using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Prism.Commands;
using QuizHelp.Extensions;
using QuizHelp.ViewModels.Base;
using QuizHelp.ViewModels.Interfaces;

namespace QuizHelp.ViewModels
{
    public class HomePageViewModel : ViewModelBase, IHasSlider
    {
        private IEnumerable<Question> _questionList;
        private double _sliderValue;
        private double _maximumValue;
        private bool _canChangeQuesiton;
        private Question _currentQuestion;
        private Answer _selectedAnswer;
        private static Random _random;
        private bool _isQuizCompleted;
        private readonly List<int> _generatedQuestions;

        public DelegateCommand<IEnumerable<Answer>> ValueChangedCommand { get; private set; }
        public DelegateCommand QuestionChangedCommand { get; set; }

        public Question CurrentQuestion
        {
            get => _currentQuestion;

            set
            {
                _currentQuestion = value;
                RaisePropertyChanged();
                MaximumValue = _currentQuestion.Answers.Count() - 1;
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

        public double MinimumValue { get; set; }

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

        public bool CanChangeQuesiton
        {
            get => _canChangeQuesiton;

            set
            {
                _canChangeQuesiton = value;
                RaisePropertyChanged();
            }
        }

        public bool IsQuizCompleted
        {
            get => _isQuizCompleted;
            set
            {
                _isQuizCompleted = value;
                RaisePropertyChanged();
            }
        }

        public HomePageViewModel()
        {
            Title = "Home";

            _random = new Random();
            _generatedQuestions = new List<int>();
            SliderValue = 0;
            CanChangeQuesiton = true;
            LoadCommands();
            LoadData();
        }

        private void LoadCommands()
        {
            ValueChangedCommand = new DelegateCommand<IEnumerable<Answer>>(OnValueChanged, CanChangeValue);
            QuestionChangedCommand = new DelegateCommand(OnQuestionChanged);
        }

        private void OnQuestionChanged()
        {
            CurrentPosition = GenerateQuestion(_questionList);
            if (CurrentPosition == -1)
            {
                IsQuizCompleted = true;
            }
            else
            {
                SliderValue = 0;
                CurrentQuestion = _questionList.ElementAt(CurrentPosition);
                OnValueChanged(CurrentQuestion.Answers);
            }
        }

        private bool CanChangeValue(IEnumerable<Answer> parameter)
        {
            return true;
        }

        private void OnValueChanged(IEnumerable<Answer> parameter)
        {
            var newValue = Math.Round(SliderValue / 1);
            SliderValue = newValue * 1;

            if (parameter == null)
                return;

            SelectedAnswer = parameter.ElementAt((int)SliderValue);
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

            _questionList = Quiz.FromJson(jsonData).Questions.ToObservableCollection();

            if (_questionList == null || !_questionList.Any())
                return;

            CurrentPosition = GenerateQuestion(_questionList);

            if (CurrentPosition == -1)
            {
                IsQuizCompleted = true;
            }
            else
            {
                OnValueChanged(CurrentQuestion.Answers);
            }
        }

        private int GenerateQuestion(IEnumerable<Question> questionList)
        {
            var result = -1;

            int index;

            do
            {
                index = _random.Next(0, questionList.Count());
            } while (_generatedQuestions.Contains(index) && _generatedQuestions.Count() != questionList.Count());
            _generatedQuestions.Add(index);

            if (index != -1)
            {
                CurrentQuestion = questionList.ElementAt(index);
                result = index;
            }

            return result;
        }
    }
}
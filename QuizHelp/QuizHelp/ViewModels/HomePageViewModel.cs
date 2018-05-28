using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using QuizHelp.Extensions;
using QuizHelp.ViewModels.Base;
using QuizHelp.ViewModels.Interfaces;
using System.Linq;
using Prism.Commands;

namespace QuizHelp.ViewModels
{
    public class HomePageViewModel : ViewModelBase, IHasSlider
    {
        private IEnumerable<Question> _questionList;
        private double _sliderValue;
        private double _maximumValue;
        private bool _canChangeQuesiton;
        private string _answerImage;
        private Question _currentQuestion;

        public DelegateCommand<IEnumerable<Answer>> ValueChangedCommand { get; private set; }
        public ICommand QuestionChangedCommand { get; set; }

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

        public string AnswerImage
        {
            get => _answerImage;

            set
            {
                _answerImage = value;
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

        public HomePageViewModel()
        {
            Title = "Home";

            SliderValue = 0;
            CanChangeQuesiton = true;
            LoadCommands();
            LoadData();
        }

        private void LoadCommands()
        {
            ValueChangedCommand = new DelegateCommand<IEnumerable<Answer>>(OnValueChanged, CanChangeValue);
            //QuestionChangedCommand = new Command(OnQuestionChanged);
        }

        private bool CanChangeValue(IEnumerable<Answer> parameter)
        {
            return true;
        }

        private void OnValueChanged(IEnumerable<Answer> parameter)
        {
            var newValue = Math.Round(SliderValue / 1);
            SliderValue = newValue * 1;
            AnswerImage = CurrentQuestion.Answers.ElementAt((int)SliderValue).Image;
        }

        //private void OnQuestionChanged(object obj)
        //{
        //    if (QuestionList == null || !QuestionList.Any())
        //        return;

        //    // TODO Add logic when answering a question
        //    //SelectedAnswer = QuestionList.ElementAt(CurrentPosition).Answers.First();
        //}

        private void LoadData()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("QuizHelp.Data.quiz_data.json");
            string jsonData = string.Empty;
            using (var reader = new StreamReader(stream))
            {
                jsonData = reader.ReadToEnd();
            }

            _questionList = Quiz.FromJson(jsonData).Questions.ToObservableCollection();

            if (_questionList == null || !_questionList.Any())
                return;

            CurrentQuestion = _questionList.First();
        }
    }
}

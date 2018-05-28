using System;
using System.Collections.ObjectModel;
using QuizHelp.Extensions;
using QuizHelp.ViewModels.Base;
using System.Windows.Input;
using Xamarin.Forms;
using QuizHelp.ViewModels.Interfaces;
using System.Reflection;
using System.IO;
using System.Linq;

namespace QuizHelp.ViewModels
{
    public class HomePageViewModel : ViewModelBase, IHasSlider
    {
        private ObservableCollection<Question> _questions;
        private double _sliderValue;
        private double _maximumValue;
        private bool _canChangeQuesiton;

        public ObservableCollection<Question> QuestionList
        {
            get => _questions;

            set
            {
                _questions = value;
                RaisePropertyChanged();
                MaximumValue = QuestionList.Count - 1;
            }
        }

        public ICommand ValueChangedCommand { get; set; }

        public ICommand QuestionChangedCommand { get; set; }

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

        public int StartPosition { get; set; }

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

            SliderValue = 1.5;
            CanChangeQuesiton = false;
            LoadCommands();
            LoadData();
        }

        private void LoadCommands()
        {
            ValueChangedCommand = new Command(OnValueChanged);
            QuestionChangedCommand = new Command(OnQuestionChanged);
        }

        private void OnValueChanged()
        {
            var newValue = Math.Round(SliderValue / 1);
            SliderValue = newValue * 1;
        }

        private void OnQuestionChanged(object obj)
        {
            if (QuestionList == null || !QuestionList.Any())
                return;

            // TODO Add logic when answering a question

        }

        private void LoadData()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("QuizHelp.Data.quiz_data.json");
            string jsonData = string.Empty;
            using (var reader = new StreamReader(stream))
            {
                jsonData = reader.ReadToEnd();
            }

            QuestionList = Quiz.FromJson(jsonData).Questions.ToObservableCollection();
        }
    }
}

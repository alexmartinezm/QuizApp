using System;
using System.Collections.ObjectModel;
using QuizHelp.Data;
using QuizHelp.Extensions;
using QuizHelp.ViewModels.Base;
using System.Windows.Input;
using Xamarin.Forms;
using QuizHelp.ViewModels.Interfaces;

namespace QuizHelp.ViewModels
{
    public class HomePageViewModel : ViewModelBase, IHasSlider
    {
        private ObservableCollection<Question> _questions;
        private double _sliderValue;

        public ObservableCollection<Question> Questions
        {
            get => _questions;

            set
            {
                _questions = value;
                RaisePropertyChanged();
            }
        }

        public ICommand ValueChangedCommand { get; set; }

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

        public double MaximumValue { get; set; } = 3.0;

        public HomePageViewModel()
        {
            Title = "Home";

            SliderValue = 1.5;
            LoadCommands();
            LoadData();
        }

        private void LoadCommands()
        {
            ValueChangedCommand = new Command(OnValueChanged);
        }

        private void OnValueChanged()
        {
            var newValue = Math.Round(SliderValue / 1);
            SliderValue = newValue * 1;
        }

        private void LoadData()
        {
            Questions = Quizz.FromJson(StaticJsonData.GetQuestions()).Questions.ToObservableCollection();
        }
    }
}

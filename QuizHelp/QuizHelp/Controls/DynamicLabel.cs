using Xamarin.Forms;
using System.Collections.Generic;
using Plugin.Iconize;
using System.Linq;
using Prism;

namespace QuizHelp.Controls
{
    public class DynamicLabel : ContentView
    {
        private StackLayout _rootStack;

        public static readonly BindableProperty AnswersListProperty = BindableProperty.Create(nameof(AnswersList), typeof(IEnumerable<Answer>), typeof(DynamicLabel), null, BindingMode.OneWay, null, OnAnswersListChanged);

        public static readonly BindableProperty SelectedAnswerProperty = BindableProperty.Create(nameof(SelectedAnswer), typeof(int), typeof(DynamicLabel), 0, BindingMode.OneWay, null, OnSelectedAnswerChanged);

        public static readonly BindableProperty SingleIconProperty = BindableProperty.Create(nameof(SingleIcon), typeof(bool), typeof(DynamicLabel), false);

        private static void OnAnswersListChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((DynamicLabel)bindable).CreateLabels(newValue as IEnumerable<Answer>);
        }

        private static void OnSelectedAnswerChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((DynamicLabel)bindable).ShowLabels(newValue as int?);
        }

        private void ShowLabels(int? answer)
        {
            if (answer == null || !answer.HasValue || _rootStack == null || !_rootStack.Children.Any())
                return;

            if (SingleIcon)
            {
                foreach (var child in _rootStack.Children)
                {
                    child.IsVisible = false;
                }

                _rootStack.Children.ElementAt(answer.Value).IsVisible = true;
            }
            else
            {
                for (int i = 0; i < _rootStack.Children.Count(); i++)
                {
                    if (i <= answer)
                    {
                        _rootStack.Children.ElementAt(i).IsVisible = true;
                    }
                    else
                    {
                        _rootStack.Children.ElementAt(i).IsVisible = false;
                    }
                }
            }
        }

        public IEnumerable<Answer> AnswersList
        {
            get => (IEnumerable<Answer>)GetValue(AnswersListProperty);
            set => SetValue(AnswersListProperty, value);
        }

        public int SelectedAnswer
        {
            get => (int)GetValue(SelectedAnswerProperty);

            set => SetValue(SelectedAnswerProperty, value);
        }

        public bool SingleIcon
        {
            get => (bool)GetValue(SingleIconProperty);

            set => SetValue(SingleIconProperty, value);
        }

        private void CreateLabels(IEnumerable<Answer> answers)
        {
            if (answers == null)
                return;

            _rootStack = new StackLayout { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.Center, Spacing = 0 };

            for (int i = 0; i < answers.Count(); i++)
            {
                _rootStack.Children.Add(new IconLabel
                {
                    Text = answers.ElementAt(i).Image,
                    FontSize = 36,
                    TextColor = Color.FromHex("#233144"),
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    IsVisible = i == 0
                });
            }

            var roundedFrame = new CircleFrame(160)
            {
                Content = _rootStack
            };

            Content = roundedFrame;
        }
    }
}

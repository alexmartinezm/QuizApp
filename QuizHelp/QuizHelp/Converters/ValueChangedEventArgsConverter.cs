using System;
using System.Globalization;
using Xamarin.Forms;
namespace QuizHelp.Converters
{
    public class ValueChangedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ValueChangedEventArgs eventArgs))
            {
                throw new ArgumentException($"Expected value to be of type {GetType().ToString()}", nameof(value));
            }

            if (parameter != null && parameter is double sliderValue)
            {
                if (IsSwitchedToNewAnswer(eventArgs, sliderValue))
                {
                    return null;
                }
                return eventArgs.NewValue;
            }

            return eventArgs.NewValue;
        }

        /// <summary>
        /// Checks if it switches to a new answer.
        /// To evaluate this, we compare the <paramref name="sliderValue"/> with the oldValue from <paramref name="eventArgs"/>.
        /// If both are equal and the newValue is zero and also is different to oldValue from <paramref name="eventArgs"/>, 
        /// it means the user has switched to a new answer.
        /// </summary>
        /// <returns><c>true</c>, if switched to new answer, <c>false</c> otherwise.</returns>
        /// <param name="eventArgs">Event arguments.</param>
        /// <param name="sliderValue">Slider value.</param>
        private bool IsSwitchedToNewAnswer(ValueChangedEventArgs eventArgs, double sliderValue)
        {
            var newValue = Math.Abs(eventArgs.NewValue) < 0.0001;
            return newValue && (((int)sliderValue == (int)eventArgs.OldValue) && (int)sliderValue != (int)eventArgs.NewValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

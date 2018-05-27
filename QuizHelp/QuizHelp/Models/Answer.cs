using Newtonsoft.Json;

namespace QuizHelp
{
    public class Answer : ModelBase<Answer>
    {
        private double _result;
        private string _title;

        [JsonProperty("result")]
        public double Result
        {
            get => _result;

            set
            {
                _result = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("title")]
        public string Title
        {
            get => _title;

            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }
    }
}

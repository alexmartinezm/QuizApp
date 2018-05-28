using Newtonsoft.Json;

namespace QuizHelp
{
    public class Answer : ModelBase<Answer>
    {
        private double _result;
        private string _title;
        private string _image;

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

        [JsonProperty("image")]
        public string Image
        {
            get => _image;

            set
            {
                _image = value;
                RaisePropertyChanged();
            }
        }
    }
}

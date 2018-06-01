using Newtonsoft.Json;

namespace QuizHelp
{
    public class Answer : ModelBase<Answer>
    {
        private int _result;
        private string _title;
        private string _image;

        [JsonProperty("result")]
        public int Result
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

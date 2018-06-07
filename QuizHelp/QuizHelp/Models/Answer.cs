using Newtonsoft.Json;

namespace QuizHelp
{
    public class Answer : ModelBase<Answer>
    {
        private string _title;
        private string _image;
        private int _points;

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

        [JsonProperty("points")]
        public int Points
        {
            get => _points;
            set
            {
                _points = value;
                RaisePropertyChanged();
            }
        }
    }
}

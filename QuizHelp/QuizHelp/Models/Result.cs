using Newtonsoft.Json;

namespace QuizHelp
{
    public class Result : ModelBase<Result>
    {
        private string _description;
        private string _title;
        private string _image;

        [JsonProperty("description")]
        public string Description
        {
            get => _description;

            set
            {
                _description = value;
            }
        }

        [JsonProperty("title")]
        public string Title
        {
            get => _title;

            set
            {
                _title = value;
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

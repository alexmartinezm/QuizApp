using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuizHelp
{
    public class Quiz : ModelBase<Quiz>
    {
        private List<Question> _questions;
        private List<Result> _results;

        [JsonProperty("questions")]
        public List<Question> Questions
        {
            get => _questions;

            set
            {
                _questions = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty("results")]
        public List<Result> Results
        {
            get => _results;

            set
            {
                _results = value;
                RaisePropertyChanged();
            }
        }
    }
}

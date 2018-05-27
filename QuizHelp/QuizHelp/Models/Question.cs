// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do one of these:
//
//    using QuizHelp;
//
//    var quizz = Quizz.FromJson(jsonString);
//    var question = Question.FromJson(jsonString);
//    var answer = Answer.FromJson(jsonString);
//    var result = Result.FromJson(jsonString);

using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuizHelp
{
    public class Question : ModelBase<Question>
    {
        private List<Answer> _answers;
        private string _title;
        private string _image;

        [JsonProperty("answers")]
        public List<Answer> Answers
        {
            get => _answers;

            set
            {
                _answers = value;
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

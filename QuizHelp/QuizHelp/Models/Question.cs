using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace QuizHelp
{
    public class Question : ModelBase<Question>, IEquatable<Question>
    {
        private IEnumerable<Answer> _answers;
        private string _title;
        private bool _singleIcon;

        [JsonProperty("answers")]
        public IEnumerable<Answer> Answers
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

        [JsonProperty("singleIcon")]
        public bool SingleIcon
        {
            get => _singleIcon;

            set
            {
                _singleIcon = value;
                RaisePropertyChanged();
            }
        }

        public bool Equals(Question other)
        {
            if (other == null)
                return false;

            return Title == other.Title
                                 && SingleIcon == other.SingleIcon
                                 && _answers.Count() == other.Answers.Count();
        }
    }
}

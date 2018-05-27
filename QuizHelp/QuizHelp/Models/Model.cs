// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do one of these:
//
//    using QuizHelp;
//
//    var quizz = Quizz.FromJson(jsonString);
//    var question = Question.FromJson(jsonString);
//    var answer = Answer.FromJson(jsonString);
//    var result = Result.FromJson(jsonString);

using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace QuizHelp
{
    public partial class Quizz
    {
        [JsonProperty("questions")]
        public List<Question> Questions { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }

    public partial class Question
    {
        [JsonProperty("answers")]
        public List<Answer> Answers { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public partial class Answer
    {
        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("result")]
        public double Result { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public partial class Quizz
    {
        public static Quizz FromJson(string json) => JsonConvert.DeserializeObject<Quizz>(json, Converter.Settings);
    }

    public partial class Question
    {
        public static Question FromJson(string json) => JsonConvert.DeserializeObject<Question>(json, Converter.Settings);
    }

    public partial class Answer
    {
        public static Answer FromJson(string json) => JsonConvert.DeserializeObject<Answer>(json, Converter.Settings);
    }

    public partial class Result
    {
        public static Result FromJson(string json) => JsonConvert.DeserializeObject<Result>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Quizz self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this Question self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this Answer self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this Result self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            }
        };
    }
}

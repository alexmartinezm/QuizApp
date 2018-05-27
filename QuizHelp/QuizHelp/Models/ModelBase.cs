using Newtonsoft.Json;
using Prism.Mvvm;

namespace QuizHelp
{
    public class ModelBase<T> : BindableBase
    {
        public static T FromJson(string json) => JsonConvert.DeserializeObject<T>(json, Converter.Settings);
    }
}
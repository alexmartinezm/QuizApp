using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QuizHelp.Extensions
{
    public static class IEnumerableExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            var collection = new ObservableCollection<T>();

            foreach (T item in source)
            {
                collection.Add(item);
            }

            return collection;
        }

        public static List<T> Splice<T>(this List<T> list, int index, int count)
        {
            if (index == -1)
                return null;

            var range = list.GetRange(index, count);
            list.RemoveRange(index, count);
            return range;
        }
    }
}

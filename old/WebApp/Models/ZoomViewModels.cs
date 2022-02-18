using System.Collections.Generic;

namespace WebApp.Models
{
    public class ZoomViewModels
    {
        public string Key { get; set; }
        public string Type { get; set; }
        public ValueDataViewModel ValueData { get; set; }
    }

    public class ValueDataViewModel
    { 

    }

    public class SortedSetWithScoreViewModel : ValueDataViewModel
    {
        /// <summary>
        /// Count, Score, Value
        /// </summary>
        public List<List<string>> Data { get; set; }
    }

    public class StringTypeViewModel : ValueDataViewModel
    {
        public string Value { get; set; }
    }
}

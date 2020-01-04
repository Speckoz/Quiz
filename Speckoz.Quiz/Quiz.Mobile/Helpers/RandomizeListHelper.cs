using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.Mobile.Helpers
{
    public static class RandomizeListHelper
    {
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            var rnd = new Random();
            return source.OrderBy((item) => rnd.Next());
        }
    }
}
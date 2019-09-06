using System;
using System.Collections.Generic;
using System.Linq;

namespace BruteForceBestTableFit
{
    public static class Helpers
    {
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> property) =>
            items.GroupBy(property).Select(x => x.First());

        public static IEnumerable<T[]> GetSubsets<T>(T[] set)
        {
            bool[] state = new bool[set.Length + 1];
            for (int x; !state[set.Length]; state[x] = true)
            {
                yield return Enumerable.Range(0, state.Length)
                    .Where(i => state[i])
                    .Select(i => set[i])
                    .ToArray();
                for (x = 0; state[x]; state[x++] = false) ;
            }
        }
    }
}
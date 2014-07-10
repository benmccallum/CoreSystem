using System;
using System.Collections.Generic;
using System.Linq;

public static class IListExtensions
{
    /// <summary>
    /// Randomly shuffles the items in the IList.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    public static void Shuffle<T>(this IList<T> list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    /// <summary>
    /// Splits a large list into a list of smaller IEnumerable objects of a max list size given.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="listSize"></param>
    /// <returns></returns>
    public static List<IEnumerable<T>> SplitIntoLists<T>(IList<T> list, int listSize)
    {
        var result = new List<IEnumerable<T>>();
        int itemTotal = list.Count;

        if (itemTotal <= listSize)
        {
            result.Add(list);
            return result;
        }

        for (int i = 0; i < itemTotal; i += listSize)
        {
            result.Add(list.Skip(i).Take(listSize));
        }

        return result;
    }
}
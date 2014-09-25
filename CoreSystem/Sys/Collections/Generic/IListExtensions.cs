using System;
using System.Collections.Generic;
using System.Linq;

public static class IListExtensions
{
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

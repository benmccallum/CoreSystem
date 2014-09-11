using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
 
public static class RandomProvider
{    
    private static int seed = Environment.TickCount;
    
    private static ThreadLocal<Random> randomWrapper = new ThreadLocal<Random>(() =>
        new Random(Interlocked.Increment(ref seed))
    );

    public static Random GetThreadRandom()
    {
        return randomWrapper.Value;
    }
}

public static class IEnumerableExtensions
{
    /// <summary>
    /// Returns the first, zero-based index of <paramref name="obj"/> in <paramref name="enumerable"/>, or null if not found.
    /// </summary>
    /// <typeparam name="T">Type of <paramref name="obj"/></typeparam>
    /// <param name="enumerable">Enumerable to look in.</param>
    /// <param name="obj">Object to look for.</param>
    /// <returns>Zero-based index or null.</returns>
    public static int? IndexOf<T>(this IEnumerable<T> enumerable, T obj)
    {
        var indexedObj = enumerable.Select((t, index) => new { t, index }).FirstOrDefault(o => Equals(o.t, obj));
        return indexedObj == null ? (int?)null : indexedObj.index;
    }
    
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
    {
        return enumerable == null || !enumerable.Any();
    }
    
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        return source.Shuffle(RandomProvider.GetThreadRandom());
    }
    
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
    {
        T[] elements = source.ToArray();
        for (int i = elements.Length - 1; i >= 0; i--)
        {
            // Swap element "i" with a random earlier element it (or itself)
            // ... except we don't really need to swap it fully, as we can
            // return it immediately, and afterwards it's irrelevant.
            int swapIndex = rng.Next(i + 1);
            yield return elements[swapIndex];
            elements[swapIndex] = elements[i];
        }
    }
}

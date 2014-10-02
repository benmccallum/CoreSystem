using System;
using System.Linq;
using System.Linq.Expressions;

/// <summary>
/// Extension methods on the IQueryable type.
/// </summary>
public static class IQueryableExtensions
{
    /// <summary>
    /// Orders a queryable by a direction, accepting a boolean to say order by ascending or not.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="queryable"></param>
    /// <param name="keySelector"></param>
    /// <param name="byAscending"></param>
    /// <returns></returns>
    public static IOrderedQueryable<T> OrderBy<T, TKey>(this IQueryable<T> queryable, Expression<Func<T, TKey>> keySelector, bool byAscending)
    {
        return byAscending ? queryable.OrderBy(keySelector) : queryable.OrderByDescending(keySelector);
    }
}

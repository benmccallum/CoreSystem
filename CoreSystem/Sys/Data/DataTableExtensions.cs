using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

public static class DataTableExtensions
{
    public static IEnumerable<DataRow> RowsWhere(this DataTable dt, IDictionary<string, string> filters)
    {
        return dt.AsEnumerable().Where(filters);
    }

    public static IEnumerable<DataRow> Where(this EnumerableRowCollection<DataRow> rows, IDictionary<string, string> filters)
    {
        return rows.Where(BuildPredicate(filters));
    }

    public static IEnumerable<DataRow> Where(this IEnumerable<DataRow> rows, IDictionary<string, IEnumerable<string>> filters)
    {
        return rows.Where(BuildPredicate(filters));
    }

    public static IEnumerable<DataRow> Where(this IEnumerable<DataRow> rows, IDictionary<string, string> filters)
    {
        return rows.Where(BuildPredicate(filters));
    }

    public static bool AnyRows(this DataTable dt, IDictionary<string, string> filters)
    {
        return dt.AsEnumerable().Any(filters);
    }

    public static bool Any(this EnumerableRowCollection<DataRow> rows, IDictionary<string, string> filters)
    {
        return rows.Any(BuildPredicate(filters));
    }

    public static bool Any(this IEnumerable<DataRow> rows, IDictionary<string, string> filters)
    {
        return rows.Any(BuildPredicate(filters));
    }

    private static Func<DataRow, bool> BuildPredicate(IDictionary<string, string> filters)
    {
        var exp = ExpressionExtensions.True<DataRow>();
        foreach (var s in filters)
        {
            exp = exp.And(x => x.Field<string>(s.Key) == s.Value);
        }
        var predicate = exp.Compile();
        return predicate;
    }

    private static Func<DataRow, bool> BuildPredicate(IDictionary<string, IEnumerable<string>> filters)
    {
        var exp = ExpressionExtensions.True<DataRow>();
        foreach (var s in filters)
        {
            var first = s.Value.FirstOrDefault();
            exp = exp.And(x => x.Field<string>(s.Key) == first);
            foreach (var value in s.Value.Skip(1))
            {
                exp = exp.Or(x => x.Field<string>(s.Key) == value);
            }
        }
        var predicate = exp.Compile();
        return predicate;
    }
}

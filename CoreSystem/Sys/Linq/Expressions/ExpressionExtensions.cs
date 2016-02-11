using System;
using System.Linq.Expressions;

public static class ExpressionExtensions
{
    public static Expression<Func<T, bool>> Inverse<T>(this Expression<Func<T, bool>> e)
    {
        return Expression.Lambda<Func<T, bool>>(Expression.Not(e.Body), e.Parameters[0]);
    }
}

using System;
using System.Linq.Expressions;

namespace CoreSystem.Sys.Linq.Expressions
{
    /// <summary>
    /// Helpers class for dealing with System.Linq.Expressions namespace.
    /// </summary>
    public class ExpressionHelper
    {
        /// <summary>
        /// Gets the value of an expression once evaluated.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static object GetValue(Expression expression)
        {
            if (expression is ConstantExpression)
            {
                return ((ConstantExpression)expression).Value;
            }
            else if (expression is MemberExpression)
            {
                return GetValue((MemberExpression)expression);   
            }
            else
            {
                return Expression.Lambda(expression).Compile().DynamicInvoke();
            }
        }

        /// <summary>
        /// Gets the value of an MemberExpression once evaluated.
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static object GetValue(MemberExpression member)
        {
            var objectMember = Expression.Convert(member, typeof(object));
            var getterLambda = Expression.Lambda<Func<object>>(objectMember);
            var getter = getterLambda.Compile();
            return getter();
        }
    }
}
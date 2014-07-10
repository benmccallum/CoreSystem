using System;
using System.Collections.Generic;
using System.Linq;

public static class GenericExtensions
{
    /// <summary>
    /// Is source an item in the list?
    /// </summary>
    public static bool In<T>(this T source, params T[] list)
    {
        if (null == source) throw new ArgumentNullException("source");
        return list.Contains(source);
    }

    /// <summary>
    /// Compare two objects public properties, returning true if all of them have the same value.
    /// Comparison is self.PropertyName.Equals(to.PropertyName) so if a complex comparison is required, use a custom implementation rather than this method.
    /// </summary>
    /// <typeparam name="T">Type of objects to compare.</typeparam>
    /// <param name="self">LHS object.</param>
    /// <param name="to">RHS object.</param>
    /// <param name="include">Property names to include in the comparison.</param>
    /// <param name="exclude">Property names to ignore in the comparison.</param>
    /// <returns>True/False.</returns>
    public static bool PublicInstancePropertiesEqual<T>(this T self, T to, IEnumerable<string> include = null, IEnumerable<string> exclude = null)
        where T : class
    {
        if (self != null && to != null)
        {
            Type type = typeof(T);
            foreach (System.Reflection.PropertyInfo pi in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                if ((include == null || !include.Any() || include.Contains(pi.Name))
                    && (exclude == null || !exclude.Any() || !exclude.Contains(pi.Name)))
                {
                    object selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                    object toValue = type.GetProperty(pi.Name).GetValue(to, null);

                    if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        return self == to;
    }
}
using System.ComponentModel;

namespace CoreSystem.Helpers
{
    /// <summary>
    /// Helper class for dealing with types and type conversions.
    /// </summary>
    public class TypeHelper
    {
        /// <summary>
        /// Converts a string representation of a value into 
        /// a strongly-typed T representation of that value.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="value">The value as a string to convert.</param>
        /// <returns>The value of the string represented as T.</returns>
        public static T GetTValueFromStringValue<T>(string value)
        {
            var typeConverter = TypeDescriptor.GetConverter(typeof(T));
            return (T)(typeConverter.ConvertFromInvariantString(value));
        }
    }
}
using System;
using System.Text;
using System.Text.RegularExpressions;

public static class StringExtensions
{
    /// <summary>
    /// Does the string contain an uppercase character?
    /// </summary>
    /// <param name="value">Value to test.</param>
    /// <returns>True/False.</returns>
    public static bool ContainsUpper(this string value)
    {
        return value != value.ToLower();
    }

    /// <summary>
    /// Does the string contain an lowercase character?
    /// </summary>
    /// <param name="value">Value to test.</param>
    /// <returns>True/False.</returns>
    public static bool ContainsLower(this string value)
    {
        return value != value.ToUpper();
    }

    /// <summary>
    /// Duplicates/multiplies a string the number of times specified.
    /// </summary>
    /// <param name="source">String to multiply.</param>
    /// <param name="multiplier">Times to multiply.</param>
    /// <returns>Resulting string.</returns>
    public static string Multiply(this string source, int multiplier)
    {
        StringBuilder sb = new StringBuilder(multiplier * source.Length);
        for (int i = 0; i < multiplier; i++)
        {
            sb.Append(source);
        }

        return sb.ToString();
    }
    
    /// <summary>
    /// Parse the input string to a valid datetime.
    /// </summary>
    /// <param name="stringToParse"></param>
    /// <returns>A DateTime object if s is a valid datetime string otherwise DateTime.MinValue is returned.</returns>
    public static DateTime ToDateTimeSafe(this string stringToParse)
    {
        DateTime output = DateTime.MinValue;
        DateTime.TryParse(stringToParse, out output);
        return output;
    }

    /// <summary>
    /// Check if a string is an integer
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsInteger(this string value)
    {
        int i;
        return Int32.TryParse(value, out i);
    }

    /// <summary>
    /// Checks whether or not a string value is a valid date.
    /// </summary>
    public static bool IsDate(this string value)
    {
        DateTime dt;
        return DateTime.TryParse(value, out dt);
    }

    /// <summary>
    /// Checks whether or not a string value is a valid bool.
    /// </summary>
    public static bool IsBool(this string value)
    {
        Boolean bl;
        return Boolean.TryParse(value, out bl);
    }

    /// <summary>
    /// Checks whether or not a string value is a valid double.
    /// </summary>
    public static bool IsDouble(this string value)
    {
        Double d;
        return Double.TryParse(value, out d);
    }

    /// <summary>
    /// Converts a camel case string such as OneWord to One Word.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="preserveAcronyms"></param>
    /// <returns></returns>
    public static string SplitCamelCaseWithSpace(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;

        if (text.Length == 1)
        {
            return text.ToUpper();
        }
        else
        {
            var spaceAdded = 0;
            StringBuilder sb = new StringBuilder(text.Length * 2);
            sb.Append(text);

            for (var i = 1; i < text.Length; i++)
            {
                var c = text[i];
                if (c >= 'A' && c <= 'Z')
                {
                    sb.Insert(i + spaceAdded, " ");
                    spaceAdded++;
                }
            }
            return sb.ToString();
        }

    }
}
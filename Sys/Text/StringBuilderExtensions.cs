using System;
using System.Text;

/// <summary>
/// Extensions for the System.Text.StringBuilder type.
/// </summary>
public static class StringBuilderExtensions
{
    /// <summary>
    /// Prepends the string representation of at the start of the StringBuilder content.
    /// </summary>
    /// <param name="builder">The huilder to prepend to.</param>
    /// <param name="value">The value to prepend.</param>
    public static void Prepend(this StringBuilder builder, object value)
    {
        builder.Insert(0, value);
    }

    /// <summary>
    /// Prepends the result of replacing the format item in a specified string
    /// with the string representation of a corresponding object in a specified array
    /// to the start of the StringBuilder content.
    /// </summary>
    /// <param name="builder">The builder to prepend to.</param>
    /// <param name="format">The format that contains placeholders to replace with corresponding objects.</param>
    /// <param name="args">The args that are the object to insert into the format string.</param>
    public static void PrependFormat(this StringBuilder builder, string format, params object[] args)
    {
        if (format == null || args == null)
        {
            throw new ArgumentNullException(format == null ? "format" : "args");
        }
        builder.Insert(0, String.Format(format, args));
    }

    /// <summary>
    /// Appends the result of replacing the format item in a specified string
    /// with the string representation of a corresponding object in a specified array
    /// on a new line at the end of the StringBuilder content.
    /// </summary>
    /// <param name="builder">The builder to append a new line to.</param>
    /// <param name="format">The format that contains placeholders to replace with corresponding objects.</param>
    /// <param name="args">The args that are the object to insert into the format string.</param>
    public static void AppendLineFormat(this StringBuilder builder, string format, params object[] args)
    {
        if (format == null || args == null)
        {
            throw new ArgumentNullException(format == null ? "format" : "args");
        }
        builder.AppendLine(String.Format(format, args));
    }
}
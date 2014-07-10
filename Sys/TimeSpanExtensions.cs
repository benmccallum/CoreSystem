using System;

public static class TimeSpanExtensions
{
    public static string ToReadableAgeString(this TimeSpan span)
    {
        return string.Format("{0:0}", span.Days / 365.25);
    }
    
    /// <summary>
    /// Makes the timespan absolute and formats it as "{0} days {1} hrs {2} mins, {3} secs.
    /// Each part is skipped if value == 0 or optional param says not to render.
    /// </summary>
    public static string ToReadableString(this TimeSpan span, bool showMinutes = true, bool showSeconds = true)
    {
        TimeSpan absSpan = span.Duration();
        string formatted = String.Format("{0}{1}{2}{3}",
            absSpan.Days != 0 ? String.Format("{0:0} day{1}, ", absSpan.Days, absSpan.Days == 1 ? "" : "s") : "",
            absSpan.Hours != 0 ? String.Format("{0:0} hr{1}, ", absSpan.Hours, absSpan.Hours == 1 ? "" : "s") : "",
            absSpan.Minutes != 0 && showMinutes ? String.Format("{0:0} min{1}, ", absSpan.Minutes, absSpan.Minutes == 1 ? "" : "s") : "",
            absSpan.Seconds != 0 && showSeconds ? String.Format("{0:0} sec{1}", absSpan.Seconds, absSpan.Seconds == 1 ? "" : "s") : "");

        if (formatted.EndsWith(", "))
        {
            formatted = formatted.Substring(0, formatted.Length - 2);
        }

        if (String.IsNullOrEmpty(formatted))
        {
            formatted = "0 seconds";
        }

        return formatted;
    }

    /// <summary>
    /// Makes the timespan absolute and takes the first (topmost) value out of days, hours, minutes or seconds that is >0
    /// suffixing with the appropriate unit (days, hrs, mins, secs).
    /// </summary>
    public static string ToReadableTopUnitOnlyString(this TimeSpan span)
    {
        TimeSpan absSpan = span.Duration();
        if (absSpan.Days != 0)
        {
            return String.Format("{0:0} day{1}", absSpan.Days, (absSpan.Days == 1 ? "" : "s"));
        }
        if (absSpan.Hours != 0)
        {
            return String.Format("{0:0} hr{1}", (int)absSpan.Hours, (absSpan.Hours == 1 ? "" : "s"));
        }
        if (absSpan.Minutes != 0)
        {
            return String.Format("{0:0} min{1}", (int)absSpan.Minutes, (absSpan.Minutes == 1 ? "" : "s"));
        }
        if (absSpan.Seconds != 0)
        {
            return String.Format("{0:0} sec{1}", (int)absSpan.Seconds, (absSpan.Seconds == 1 ? "" : "s"));
        }
        return "";
    }
}
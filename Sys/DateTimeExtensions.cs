using System;

public static class DateTimeExtensions
{
    /// <summary>
    /// For a given date, e.g. 2013-04-18, returns 2013-04-18 23:59:59.
    /// </summary>
    /// <param name="d"></param>
    /// <returns>A datetime that includes the last second of the day</returns>
    public static DateTime ToEndDateTime(this DateTime d)
    {
        if (d > DateTime.MinValue)
        {
            return new DateTime(d.Year, d.Month, d.Day, 23, 59, 59);
        }
        return d;
    }

    /// <summary>
    /// Converts datetime to simple xyz ago string for display.
    /// </summary>
    /// <param name="dt">Input datetime </param>
    /// <returns>Examples: "{0} day{1} ago" OR "{0} hour{1} ago" OR "{0} mins ago"</returns>
    public static string ToSimpleAgoString(this DateTime dt)
    {
        var ts = DateTime.Now - dt;
        var mins = ts.TotalMinutes;
        var hours = ts.TotalHours;
        var days = ts.TotalDays;

        if (days > 0)
        {
            return string.Format("{0} day{1} ago", (int)days, (days > 1 ? "s" : ""));
        }

        if (hours > 0)
        {
            return string.Format("{0} hour{1} ago", (int)hours, (hours > 1 ? "s" : ""));
        }

        if (mins > 0)
        {
            return string.Format("{0} mins ago", (int)mins);
        }

        return string.Empty;
    }
}
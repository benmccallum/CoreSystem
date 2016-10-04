using System;

public static class DateTimeExtensions
{
    /// <summary>
    /// Converts a DateTime to the last day of it's financial year.
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static DateTime ToLastDayOfFinancialYear(this DateTime dt)
    {
        return new DateTime((dt.Month > 6) ? dt.Year + 1 : dt.Year, 6, 30, 12, 0, 0, 0, dt.Kind);
    }
    
    /// <summary>
    /// For a given date, e.g. 2013-04-18, returns 2013-04-18 23:59:59.
    /// </summary>
    /// <param name="dt"></param>
    /// <returns>A datetime that includes the last second of the day</returns>
    public static DateTime ToEndDateTime(this DateTime dt)
    {
        if (dt > DateTime.MinValue)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
        }
        return dt;
    }

    /// <summary>
    /// Converts datetime to simple xyz ago string for display.
    /// </summary>
    /// <param name="dt">Input datetime.</param>
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
    
    /// <summary>
    /// Get's the time portion like "6:27pm" or "1:30am".
    /// </summary>
    /// <param name="dt">Input datetime.</param>
    /// <returns></returns>
    public static string GetTwelveHourTime(this DateTime dt)
    {
        return dt.ToString("h:mmtt").ToLower();
    }

    /// <summary>
    /// Get day of month English suffix - e.g. 1 = "st", 3 = "rd", 5 = "th", 22 = "nd".
    /// </summary>
    /// <param name="dt">Input datetime.</param>
    /// <returns>Suffix string.</returns>
    public static string GetDaySuffix(this DateTime dt)
    {
        switch (dt.Day)
        {
            case 1:
            case 21:
            case 31:
                return "st";
            case 2:
            case 22:
                return "nd";
            case 3:
            case 23:
                return "rd";
            default:
                return "th";
        }
    }

    public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>
    /// To JavaScript milliseconds since unix epoch. Great for making Date instances in JavaScript from a .NET DateTime on backend.
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static double ToJavaScriptMilliseconds(this DateTime dt)
    {
        return dt.ToUniversalTime().Subtract(UnixEpoch).TotalMilliseconds;
    }
}

/// <summary>
/// Int32 extensions
/// </summary>
public static class Int32Extensions
{
    /// <summary>
    /// Get the ordinal value of positive integers.
    /// </summary>
    /// <remarks>
    /// Only works for english-based cultures.
    /// Code from: http://stackoverflow.com/questions/20156/is-there-a-quick-way-to-create-ordinals-in-c/31066#31066
    /// With help: http://www.wisegeek.com/what-is-an-ordinal-number.htm
    /// </remarks>
    /// <param name="number">The number.</param>
    /// <returns>Ordinal value of positive integers, or <see cref="int.ToString"/> if less than 1.</returns>
    public static string ToOrdinal(this int number)
    {
        const string TH = "th";
        string s = number.ToString();

        // Negative and zero have no ordinal representation
        if (number < 1)
        {
            return s;
        }

        number %= 100;
        if ((number >= 11) && (number <= 13))
        {
            return s + TH;
        }

        switch (number % 10)
        {
            case 1: return s + "st";
            case 2: return s + "nd";
            case 3: return s + "rd";
            default: return s + TH;
        }
    }
}
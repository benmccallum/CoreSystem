namespace CoreSystem.Constants
{
    /// <summary>
    /// Common regular expression strings.
    /// </summary>
    public static class RegexConstants
    {
        /// <summary>
        /// Matches email addresses.
        /// </summary>
        public static readonly string EmailAddress = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

        /// <summary>
        /// Matches valid image file names (png, jpg, jpeg, bmp and gif).
        /// </summary>
        public static readonly string ImageFormats = @"([^\s]+(\.(jpg|jpeg|png|gif|bmp))$)";
    }
}
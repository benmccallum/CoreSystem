using System;

namespace CoreSystem.Helpers
{
    /// <summary>
    /// Helpers for dealing with urls and uris.
    /// </summary>
    public class UriHelper
    {
        /// <summary>
        /// Determines whether a url is absolute or not.
        /// </summary>
        /// <param name="uri">Url string  to test.</param>
        /// <returns>true/false.</returns>
        /// <remarks>
        /// Examples:
        ///     ?IsAbsoluteUrl("hello")
        ///     false
        ///     ?IsAbsoluteUrl("/hello")
        ///     false
        ///     ?IsAbsoluteUrl("ftp//hello")
        ///     false
        ///     ?IsAbsoluteUrl("//hello")
        ///     true
        ///     ?IsAbsoluteUrl("ftp://hello")
        ///     true
        ///     ?IsAbsoluteUrl("http://hello")
        ///     true
        ///     ?IsAbsoluteUrl("https://hello")
        ///     true
        /// </remarks>
        public static bool IsAbsoluteUri(string uri)
        {
            Uri result;
            return Uri.TryCreate(uri, UriKind.Absolute, out result);
        }
    }
}
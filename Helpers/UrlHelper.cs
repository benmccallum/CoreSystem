using System;
using System.Text;

namespace CoreSystem.Helpers
{
    /// <summary>
    /// A helper class for dealing with Urls.
    /// </summary>
    public class UrlHelper
    {
        /// <summary>
        /// Appends a query string to a raw url string,
        /// appropriately handling whether the url string already has >1 query string values.
        /// </summary>
        /// <param name="url">Raw url string.</param>
        /// <param name="queryStringKey">Key of query string to add.</param>
        /// <param name="queryStringValue">Value of query string to add.</param>
        /// <returns>The resulting url with query string appended.</returns>
        public static string AppendQueryString(string url, string queryStringKey, string queryStringValue)
        {
            return String.Format("{0}{1}{2}={3}",
                url,
                url.Contains("?") ? "&" : "?",
                queryStringKey,
                queryStringValue);
        }

        /// <summary>
        /// Retrieves the subdomain from the specified URL.
        /// </summary>
        /// <param name="url">The URL from which to retrieve the subdomain.</param>
        /// <returns>The subdomain if it exist, otherwise null.</returns>
        public static string GetSubDomain(Uri url)
        {
            if (url.HostNameType == UriHostNameType.Dns)
            {
                string host = url.Host;
                if (host.Split('.').Length > 2)
                {
                    int lastIndex = host.LastIndexOf(".");
                    int index = host.LastIndexOf(".", lastIndex - 1);
                    return host.Substring(0, index);
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the url as a string without the query string.
        /// </summary>
        /// <param name="url">The Uri object.</param>
        /// <returns>The url without the query string.</returns>
        public static string GetWithoutQueryString(Uri url)
        {
            return url.AbsoluteUri.Replace(url.Query, "");
        }

        /// <summary>
        /// Gets the url as a string without the query string.
        /// </summary>
        /// <param name="rawUrl">The raw url as a string.</param>
        /// <returns>The url without the query string.</returns>
        public static string GetWithoutQueryString(string rawUrl)
        {
            if (rawUrl.Contains("?"))
            {
                return rawUrl.Remove(rawUrl.IndexOf("?"));
            }
            else
            {
                return rawUrl;
            }
        }
        
        /// <summary>
        /// Produces optional, URL-friendly version of a title, "like-this-one". 
        /// hand-tuned for speed, reflects performance refactoring contributed
        /// by John Gietzen (user otac0n) 
        /// Source: http://stackoverflow.com/a/25486
        /// </summary>
        public static string URLFriendly(string title)
        {
            if (title == null)
            {
                return "";
            }

            const int maxlen = 80;
            int len = title.Length;
            bool prevdash = false;
            var sb = new StringBuilder(len);
            char c;

            for (int i = 0; i < len; i++)
            {
                c = title[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    sb.Append(c);
                    prevdash = false;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    // tricky way to convert to lowercase
                    sb.Append((char)(c | 32));
                    prevdash = false;
                }
                else if (c == ' ' || c == ',' || c == '.' || c == '/' ||
                    c == '\\' || c == '-' || c == '_' || c == '=')
                {
                    if (!prevdash && sb.Length > 0)
                    {
                        sb.Append('-');
                        prevdash = true;
                    }
                }
                else if ((int)c >= 128)
                {
                    int prevlen = sb.Length;
                    sb.Append(UnicodeHelper.RemapInternationalCharToAscii(c));
                    if (prevlen != sb.Length) prevdash = false;
                }

                if (i == maxlen)
                {
                    break;
                }
            }

            if (prevdash)
            {
                return sb.ToString().Substring(0, sb.Length - 1);
            }
            else
            {
                return sb.ToString();
            }
        }
    }
}
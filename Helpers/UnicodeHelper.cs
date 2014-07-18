using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSystem.Helpers
{
    /// <summary>
    /// Unicode helper.
    /// </summary>
    public class UnicodeHelper
    {
        /// <summary>
        /// Remaps International char to suitable ASCII char if possible, else empty.
        /// Source: http://meta.stackoverflow.com/a/7696
        /// </summary>
        /// <param name="c">Char to remap.</param>
        /// <param name="otherwiseUseSelf">If no mapping found, should it return itself?</param>
        /// <returns>Suitable ascii string or empty string.</returns>
        public static string RemapInternationalCharToAscii(char c, bool? otherwiseUseSelf = true)
        {
            string s = c.ToString().ToLowerInvariant();
            if ("àåáâäãåą".Contains(s))
            {
                return "a";
            }
            else if ("èéêëę".Contains(s))
            {
                return "e";
            }
            else if ("ìíîïı".Contains(s))
            {
                return "i";
            }
            else if ("òóôõöøőð".Contains(s))
            {
                return "o";
            }
            else if ("ùúûüŭů".Contains(s))
            {
                return "u";
            }
            else if ("çćčĉ".Contains(s))
            {
                return "c";
            }
            else if ("żźž".Contains(s))
            {
                return "z";
            }
            else if ("śşšŝ".Contains(s))
            {
                return "s";
            }
            else if ("ñń".Contains(s))
            {
                return "n";
            }
            else if ("ýÿ".Contains(s))
            {
                return "y";
            }
            else if ("ğĝ".Contains(s))
            {
                return "g";
            }
            else if (c == 'ř')
            {
                return "r";
            }
            else if (c == 'ł')
            {
                return "l";
            }
            else if (c == 'đ')
            {
                return "d";
            }
            else if (c == 'ß')
            {
                return "ss";
            }
            else if (c == 'Þ')
            {
                return "th";
            }
            else if (c == 'ĥ')
            {
                return "h";
            }
            else if (c == 'ĵ')
            {
                return "j";
            }
            else if (otherwiseUseSelf.GetValueOrDefault())
            {
                return c.ToString();
            }
            return "";
        }

        /// <summary>
        /// Remaps International chars in a string to suitable ASCII chars if possible, else empty.
        /// </summary>
        /// <param name="value">A string.</param>
        /// <param name="capitaliseFirstLetter">Should the first char be capitalised?</param>
        /// <returns>The string with weird chars normalised to ascii.</returns>
        public static string RemapInternationalCharsToAscii(string value, bool capitaliseFirstLetter = false)
        {
            var firstChar = RemapInternationalCharToAscii(value[0]);
            var sb = new StringBuilder((capitaliseFirstLetter) ? firstChar.ToUpper() : firstChar, value.Length);

            foreach (var ch in value.ToCharArray().Skip(1))
            {
                sb.Append(RemapInternationalCharToAscii(ch));
            }
            return sb.ToString();
        }
    }
}

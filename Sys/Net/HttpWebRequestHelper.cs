using System;
using System.Net;

namespace CoreSystem.Sys.Net
{
    public class HttpWebRequestHelper
    {
        /// <summary>
        /// Makes a fire and forget http request to the given url.
        /// </summary>
        /// <param name="url">Url to hit.</param>
        public static void MakeHttpRequest(string url)
        {
            WebRequest webRequest = null;
            try
            {
                webRequest = HttpWebRequest.Create(url);
                webRequest.GetResponse();
            }
            catch //(Exception ex)
            {
                // TODO: Logging
                //ErrorHandling.LogError("WebRequestHelper::MakeHttpRequest", "Failed trying to hit url: " + url + ".", ex.Message, ErrorHandling.LogOption.All);
            }
        }
    }
}

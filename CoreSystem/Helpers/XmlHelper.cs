using System.IO;
using System.Xml.Serialization;

namespace CoreSystem.Helpers
{
    /// <summary>
    /// Helper class for dealing with XML and serialization to and from objects/xml.
    /// </summary>
    public class XmlHelper
    {
        /// <summary>
        /// Deserializes a string of XML into a strongly-typed object of type T.
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize to.</typeparam>
        /// <param name="xmlString">String of XML to deserialize.</param>
        /// <returns>T Object.</returns>
        public static T Deserialize<T>(string xmlString)
        {
            using (var sr = new StringReader(xmlString))
            {
                return (T)(new XmlSerializer(typeof(T))).Deserialize(sr);
            }
        }

        /// <summary>
        /// Deserializes a string of XML into a strongly-typed object of type T.
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize to.</typeparam>
        /// <param name="xmlString">String of XML to deserialize.</param>
        /// <returns>T Object.</returns>
        public static T Deserialize<T>(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return (T)(new XmlSerializer(typeof(T))).Deserialize(ms);
            }
        }
    }
}

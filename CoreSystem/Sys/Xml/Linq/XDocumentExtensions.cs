using System.Xml;
using System.Xml.Linq;

public static class XDocumentExtensions
{
    /// <summary>
    /// Converts an XDocument into an XmlDocument.
    /// </summary>
    /// <param name="xDocument">The document to convert.</param>
    /// <returns></returns>
    public static XmlDocument ToXmlDocument(this XDocument xDocument)
    {
        var xmlDocument = new XmlDocument();
        using (var xmlReader = xDocument.CreateReader())
        {
            xmlDocument.Load(xmlReader);
        }
        return xmlDocument;
    }
}

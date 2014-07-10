using System.Xml;
using System.Xml.Linq;

/// <summary>
/// Extensions for the System.Xml.XmlDocument type.
/// </summary>
public static class XmlDocumentExtensions
{
    /// <summary>
    /// Converts an XmlDocument into an XDocument.
    /// </summary>
    /// <param name="xmlDocument">The XmlDocument to operate on.</param>
    /// <returns>The converted System.Xml.Linq.XDocument</returns>
    public static XDocument ToXDocument(this XmlDocument xmlDocument)
    {
        using (var nodeReader = new XmlNodeReader(xmlDocument))
        {
            nodeReader.MoveToContent();
            return XDocument.Load(nodeReader);
        }
    }
}
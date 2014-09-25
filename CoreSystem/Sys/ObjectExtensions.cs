using System.Text;

public static class ObjectExtensions
{
    /// <summary>
    /// Uses reflection to output a string dump of all the object's properties and values in a nice readable format.
    /// Should only be used for debug/error dumps as performance of reflection is obviously a concern.
    /// </summary>
    /// <param name="instance">Object instance to dump info for.</param>
    /// <returns>Formatted friendly string of object information.</returns>
    public static string ToStringDump(this object instance)
    {
        var flags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.FlattenHierarchy;
        var propInfos = instance.GetType().GetProperties(flags);

        var sb = new StringBuilder();

        string typeName = instance.GetType().Name;
        sb.AppendLine(typeName);
        sb.AppendLine("".PadRight(typeName.Length + 5, '='));

        foreach (System.Reflection.PropertyInfo propInfo in propInfos)
        {
            sb.Append(propInfo.Name);
            sb.Append(": ");
            if (propInfo.GetIndexParameters().Length > 0)
            {
                sb.Append("Indexed Property cannot be used");
            }
            else
            {
                object value = propInfo.GetValue(instance, null);
                sb.Append(value != null ? value : "null");
            }
            sb.Append(System.Environment.NewLine);
        }
        return sb.ToString();
    }
}
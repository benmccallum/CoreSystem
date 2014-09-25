using System;

public static class TypeExtensions
{
    /// <summary>
    /// Checks if the type is assignable from any of the given types.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="types"></param>
    /// <returns></returns>
    public static bool IsAssignableFromAny(this System.Type type, params Type[] types)
    {
        foreach (var typeToCheck in types)
        {
            if (type.IsAssignableFrom(typeToCheck))
            {
                return true;
            }
        }
        return false;
    }
}
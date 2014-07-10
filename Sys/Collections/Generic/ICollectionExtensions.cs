using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreSystem.Sys.Collections.Generic
{
    public static class ICollectionExtensions
    {
        public static void RemoveAll<T>(this ICollection<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "source cannot be null.");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate", "predicate cannot be null.");
            }

            //http://phejndorf.wordpress.com/2011/03/09/a-removeall-extension-for-the-collection-class/
            source.Where(predicate).ToList().ForEach(e => source.Remove(e));
        }
    }
}

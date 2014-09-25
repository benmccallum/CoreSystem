namespace CoreSystem.Mapping
{
    /// <summary>
    /// Interface for mappers that map a source of <typeparamref name="TSource"/> to a target of <typeparamref name="TTarget"/>.
    /// </summary>
    /// <typeparam name="TSource">Type of the input.</typeparam>
    /// <typeparam name="TTarget">Type of the output.</typeparam>
    /// <remarks>Trying out this approach: http://www.uglybugger.org/software/post/friends_dont_let_friends_use_automapper </remarks>
    public interface IMapToExisting<in TSource, in TTarget>
    {
        /// <summary>
        /// Maps a source of <typeparamref name="TSource"/> to a target of <typeparamref name="TTarget"/>.
        /// </summary>
        /// <param name="source">Source object.</param>
        /// <param name="target">Target object.</param>
        void Map(TSource source, TTarget target);
    }
}
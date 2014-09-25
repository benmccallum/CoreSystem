namespace CoreSystem.Mapping
{
    /// <summary>
    /// Interface for mappers that maps a source of <typeparamref name="TSource"/> to a new <typeparamref name="TTarget"/>.
    /// </summary>
    /// <typeparam name="TSource">Type of the input.</typeparam>
    /// <typeparam name="TTarget">Type of the output.</typeparam>
    /// <remarks>Trying out this approach: http://www.uglybugger.org/software/post/friends_dont_let_friends_use_automapper </remarks>
    public interface IMapToNew<in TSource, out TTarget>
    {
        /// <summary>
        /// Maps a source of <typeparamref name="TSource"/> to a new <typeparamref name="TTarget"/>.
        /// </summary>
        /// <param name="source">Source object.</param>
        /// <returns>New target/mapped object.</returns>
        TTarget Map(TSource source);
    }
}
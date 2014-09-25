using System.Configuration;

namespace CoreSystem.Infrastructure.Config
{
    /// <summary>
    /// Configuration manager interface.
    /// </summary>
    /// <remarks>Testable and injectable.</remarks>
    public interface IConfigurationManager
    {
        /// <summary>
        /// Gets an appSetting.
        /// </summary>
        /// <param name="key">appSetting name/key.</param>
        /// <returns>appSetting value.</returns>
        string GetAppSetting(string key);

        /// <summary>
        /// Gets a connectionString.
        /// </summary>
        /// <param name="key">connectionString name/key.</param>
        /// <returns>connectionString settings.</returns>
        ConnectionStringSettings GetConnectionString(string key);
    }
}
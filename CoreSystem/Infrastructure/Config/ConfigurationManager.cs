using System;
using System.Configuration;
using System.Globalization;

namespace CoreSystem.Infrastructure.Config
{
    /// <summary>
    /// Abstract configuration manager wrapping a .NET Framework ConfigurationManager.
    /// </summary>
    public abstract class ConfigurationManager : IConfigurationManager
    {
        public abstract string GetAppSetting(string key);

        public abstract ConnectionStringSettings GetConnectionString(string key);

        protected string GetWithCheck(string appSettingKey, string defaultValue = null)
        {
            var value = GetAppSetting(appSettingKey);
            if (string.IsNullOrWhiteSpace(value))
            {
                if (defaultValue != null)
                {
                    return defaultValue;
                }
                ThrowAppKeyMissingException(appSettingKey);
            }
            return value;
        }

        protected int GetIntWithCheck(string appSettingKey, int? defaultValue = null)
        {
            var value = GetAppSetting(appSettingKey);

            if (string.IsNullOrEmpty(value))
            {
                if (defaultValue.HasValue)
                {
                    return defaultValue.Value;
                }
                ThrowAppKeyMissingException(appSettingKey);
            }

            int parsedValue;
            if (int.TryParse(value, out parsedValue))
            {
                return parsedValue;
            }
            throw new ApplicationException("Failed to parse to int the value '" + value + "' in appSetting with key: " + appSettingKey + ".");
        }

        protected bool GetBoolWithCheck(string appSettingKey, bool? defaultValue = null)
        {
            var value = GetAppSetting(appSettingKey);

            if (string.IsNullOrEmpty(value))
            {
                if (defaultValue.HasValue)
                {
                    return defaultValue.Value;
                }
                ThrowAppKeyMissingException(appSettingKey);
            }

            bool parsedValue;
            if (bool.TryParse(value, out parsedValue))
            {
                return parsedValue;
            }
            throw new ApplicationException("Failed to parse to bool the value '" + value + "' in appSetting with key: " + appSettingKey + ".");
        }

        protected DateTime GetDateTimeWithCheck(string appSettingKey, DateTime? defaultValue = null)
        {
            var value = GetAppSetting(appSettingKey);

            if (string.IsNullOrEmpty(value))
            {
                if (defaultValue.HasValue)
                {
                    return defaultValue.Value;
                }
                ThrowAppKeyMissingException(appSettingKey);
            }

            DateTime parsedValue;
            if (TryParseUtc(value, out parsedValue))
            {
                return parsedValue;
            }

            throw new ApplicationException("Failed to parse to DateTime the value '" + value + "' in appSetting with key: " + appSettingKey + ".");
        }

        protected static void ThrowAppKeyMissingException(string appSettingKey)
        {
            throw new ApplicationException("Missing/null/empty appSetting with key: " + appSettingKey + ".");
        }

        protected static bool TryParseUtc(string s, out DateTime result)
        {
            return DateTime.TryParseExact(s, "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out result);
        }
    }
}
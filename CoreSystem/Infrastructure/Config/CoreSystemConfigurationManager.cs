using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSystem.Infrastructure.Config
{
    public class CoreSystemConfigurationManager : ConfigurationManager, ICoreSystemConfigurationManager
    {
        /// <summary>
        /// Passphrase to use for encryption.
        /// </summary>
        public string Passphrase
        {
            get { return GetWithCheck("CoreSystem.Passphrase"); }
        }




        // TODO: Move to abstract base
        public override string GetAppSetting(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get(key);
        }

        public override System.Configuration.ConnectionStringSettings GetConnectionString(string key)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[key];
        }
    }
}

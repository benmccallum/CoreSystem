using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSystem.Infrastructure.Config
{
    public interface ICoreSystemConfigurationManager : IConfigurationManager
    {
        /// <summary>
        /// A passphrase to use for encryption.
        /// </summary>
        string Passphrase { get; }
    }
}

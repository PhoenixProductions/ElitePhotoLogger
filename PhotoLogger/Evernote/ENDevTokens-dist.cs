using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoLogger.Evernote
{
    /// <summary>
    /// This is an skeleton implementation of the DevTokens classs that is used to get
    /// *your* Evernote Developer API details into the app.
    /// </summary>
    class ENDevTokens : IENDevTokens
    {

        public string GetConsumerKey()
        {
            return "<insertconsumerkey>";
        }

        public string GetSharedSecret()
        {
            return "<insertsecret>";
        }
    }
}

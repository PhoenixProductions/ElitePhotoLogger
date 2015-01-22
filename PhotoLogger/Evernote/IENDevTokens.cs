using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoLogger.Evernote
{
    interface IENDevTokens
    {
        string GetConsumerKey();
        string GetSharedSecret();
    }
}

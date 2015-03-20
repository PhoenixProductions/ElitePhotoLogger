using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoLogger.Twitter
{
    public interface ITwitter
    {
        string GetConsumerKey();
        string GetSharedSecret();
    }
}

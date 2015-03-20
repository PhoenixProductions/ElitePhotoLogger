using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoLogger.Twitter
{
    class Twitter : ITwitter
    {
        public string GetConsumerKey()
        {
            return @"ConsumerKey";
        }

        public string GetSharedSecret()
        {
            return @"Consumer Sectet";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvernoteSDK;

namespace PhotoLogger.Evernote
{
    /// <summary>
    /// Manages interaction with Evernote
    /// </summary>
    class ENManager
    {
        enum EverNoteMode
        {
            Normal = 0,
            Personal
        }
#if DEBUG
        string _enHost = "sandbox.evernote.com";
#else
        string _enHost = "";
#endif
        public ENManager(EverNoteMode personal)
        {
            if (personal == EverNoteMode.Personal) {
                ENSession.SetSharedSessionDeveloperToken(
                    PhotoLogger.Properties.Settings.Default.ENPersonalToken,
                    PhotoLogger.Properties.Settings.Default.ENNoteStoreUrl
                    );
            }
            else
            {
                IENDevTokens tokenClass = new ENDevTokens();
                ENSession.SetSharedSessionConsumerKey(tokenClass.GetConsumerKey(), tokenClass.GetSharedSecret(), _enHost);
            }
        }
    }
}

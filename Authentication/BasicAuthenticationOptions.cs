// based on Barry Dorans' idunno.Authentication
// https://github.com/blowdart/idunno.Authentication


using System;
using Microsoft.AspNetCore.Authentication;

namespace iCalServer.Authentication
{
    public class BasicAuthenticationOptions : AuthenticationSchemeOptions
    {
        private string _realm;
        public string Realm
        {
            get
            {
                return _realm;
            }

            set
            {
                if (!string.IsNullOrEmpty(value) && !IsAscii(value))
                {
                    throw new ArgumentException("Realm must be US ASCII");
                }

                _realm = value;
            }
        }

        public bool AllowInsecureProtocol { get; set; }

        public new BasicAuthenticationEvents Events

        {
            get { return (BasicAuthenticationEvents)base.Events; }

            set { base.Events = value; }
        }


        private static bool IsAscii(string input)
        {
            foreach (char c in input)
            {
                if (c < 32 || c >= 127)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
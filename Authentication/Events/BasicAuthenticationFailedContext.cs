// based on Barry Dorans' idunno.Authentication
// https://github.com/blowdart/idunno.Authentication

using System;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace iCalServer.Authentication
{
    public class BasicAuthenticationFailedContext : ResultContext<BasicAuthenticationOptions>
    {
        
        public BasicAuthenticationFailedContext(
            HttpContext context,
            AuthenticationScheme scheme,
            BasicAuthenticationOptions options)
            : base(context, scheme, options)
        {

        }

        public Exception Exception { get; set; }
    }
}
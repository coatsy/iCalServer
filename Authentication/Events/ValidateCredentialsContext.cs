// based on Barry Dorans' idunno.Authentication
// https://github.com/blowdart/idunno.Authentication


using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace iCalServer.Authentication
{
    public class ValidateCredentialsContext : ResultContext<BasicAuthenticationOptions>
    {
        
        public ValidateCredentialsContext(
            HttpContext context,
            AuthenticationScheme scheme,
            BasicAuthenticationOptions options)
            : base(context, scheme, options)
        {

        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
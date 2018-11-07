// based on Barry Dorans' idunno.Authentication
// https://github.com/blowdart/idunno.Authentication


using System;
using System.Threading.Tasks;

namespace iCalServer.Authentication
{
    public class BasicAuthenticationEvents
    {
        public Func<BasicAuthenticationFailedContext, Task> OnAuthenticationFailed { get; set; } = context => Task.CompletedTask;

        /// <summary>
        /// A delegate assigned to this property will be invoked when the credentials need validation.
        /// </summary>
        /// <remarks>
        /// You must provide a delegate for this property for authentication to occur.
        /// In your delegate you should construct an authentication principal from the user details,
        /// attach it to the context.Principal property and finally call context.Success();
        /// </remarks>
        public Func<ValidateCredentialsContext, Task> OnValidateCredentials { get; set; } = context => Task.CompletedTask;

        public virtual Task AuthenticationFailed(BasicAuthenticationFailedContext context) => OnAuthenticationFailed(context);

        public virtual Task ValidateCredentials(ValidateCredentialsContext context) => OnValidateCredentials(context);
    }
}
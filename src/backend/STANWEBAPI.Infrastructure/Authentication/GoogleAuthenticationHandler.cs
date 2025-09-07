using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace STANWEBAPI.Infrastructure.Authentication
{
    public class GoogleAuthenticationHandler(
        IOptionsMonitor<GoogleAuthenticationSchemeOptions> options,
        ILoggerFactory loggerFactory,
        UrlEncoder urlEncoder,
        ISystemClock clock) 
        : AuthenticationHandler<GoogleAuthenticationSchemeOptions>(options, loggerFactory, urlEncoder, clock)
    {


        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            throw new NotImplementedException();
        }
    }

    public class GoogleAuthenticationSchemeOptions : AuthenticationSchemeOptions
    { 

    }
}
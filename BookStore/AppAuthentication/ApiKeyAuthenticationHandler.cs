using BookStore.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BookStore.AppAuthentication
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        private readonly IApplicationRepository applicationRepository;

        public ApiKeyAuthenticationHandler(
         IOptionsMonitor<ApiKeyAuthenticationOptions> options,
         ILoggerFactory logger,
         UrlEncoder encoder,
         ISystemClock clock,
         IApplicationRepository applicationRepository) : base(options, logger, encoder, clock)
        {
            this.applicationRepository = applicationRepository;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.NoResult();
            }
            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue headerValue))
            {
                return AuthenticateResult.NoResult();
            }

            if (headerValue.Scheme != Options.Scheme)
            {
                return AuthenticateResult.NoResult();
            }

            var apiKey = headerValue.Parameter;

            var application = applicationRepository.GetByApiKey(apiKey);

            if (application != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, application.Name)
                };

                var identity = new ClaimsIdentity(claims, Options.AuthenticationType);
                var identities = new List<ClaimsIdentity> { identity };
                var principal = new ClaimsPrincipal(identities);
                var ticket = new AuthenticationTicket(principal, Options.Scheme);

                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.Fail("Invalid api key");
        }
    }
}
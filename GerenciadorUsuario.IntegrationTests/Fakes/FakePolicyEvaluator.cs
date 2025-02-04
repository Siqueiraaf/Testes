using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorUsuario.IntegrationTests.Fakes
{
    public class FakePolicyEvaluator : IPolicyEvaluator
    {
        public Task<AuthenticateResult> AuthenticateAsync(AuthorizationPolicy policy, HttpContext context)
        {
            var principal = new ClaimsPrincipal();
            var ticket = new AuthenticationTicket(principal, "FakeSheme");
            var result = AuthenticateResult.Sucess(ticket);
            return Task.FromResult(result);
        }

        public Task<PolicyAuthorizationResult> AuthorizeAsync(AuthorizationPolicy policy, AuthenticateResult authenticate)
        {
            return Task.FromResult(PolicyAuthorizationResult.Success());
        }
    }
}
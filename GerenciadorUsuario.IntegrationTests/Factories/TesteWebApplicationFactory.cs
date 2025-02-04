using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorUsuario.IntegrationTests.Factories
{
    public class TesteWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(service =>
            {
                service.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
            });
        }
    }
}
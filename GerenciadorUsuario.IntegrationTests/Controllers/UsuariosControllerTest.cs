using System;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorUsuario.IntegrationTests.Controllers
{
    public class UsuariosControllerTest : IClassFixture<TestWebApplicationFactory<Program>>
    {
        private readonly TestWebApplicationFactory<Program> _webApplicationfactory;

        public UsuariosControllerTest(TestWebApplicationFactory<Program> webApplicationFactory)
        {
            _webApplicationfactory = webApplicationFactory;
        }

        [Fact]
        public async Task DadoBuscarUsuarios_QuandoSolicitadaUmaBusca_EntaoRetornaUsuarios()
        {
            // Arrange
            HttpClient client = _webApplicationfactory.CreateClient();

            // Act
            var response = await client.GetAsync("api/v1/usuarios");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var usuarios = await response.Content.ReadFromJsonAsync<IEnumerable<Usuario>>();
            usuarios.Should().NotBeEmpty();
            var usuarioParaComparacao = usuarios.ElementAt(0);
            usuarioParaComparacao.Nome.ShouldBe().Be("Usuario 01");
            usuarioParaComparacao.Email.ShouldBe().Be("usuario01@gmail.com");
        }
    }
}
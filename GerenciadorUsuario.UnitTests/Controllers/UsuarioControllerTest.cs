using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorUsuario.Controllers;

namespace GerenciadorUsuario.UnitTests.Controllers
{
    public class UsuarioControllerTest
    {
        [Fact]
        public void DadoBuscarUsuarios_QuandoSolicitadaUmaBusca_EntaoRetornaUsuarios()
        {
            // Arrange
            AutoMocker mocker = new();
            UsuarioController controller = mocker.CreateInstance<UsuarioController>();
            Fixture fixture = new();

            List<Usuario> usuariosFake = fixture.Create<List<Usuario>>();
            mocker.GetMock<IUsuarioRepository>()
            .Setup(repo => repo.ObterUsuarios())
            .Returns(usuariosFake);

            // Act
            var response = controller.BuscarUsuarios() as OkObjectResult;
            IEnumerable<Usuario> usuariosRetornados = response.Value as IEnumerable<Usuario>;

            // Assert
            response.Should().NotBeNull();
            usuariosRetornados.Should().BeEquivalentTo(usuariosFake);
        }
    }
}
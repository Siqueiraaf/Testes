using GerenciadorUsuario.DTOs;
using GerenciadorUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace GerenciadorUsuario.UnitTests.DTOs
{
    public class CadastrarUsuarioDTOTest
    {
        [Fact(DisplayName = "Testa Conversão do Modelo DTO para Modelo")]
        public void DadoConverterParaModelo_QuandoSolicitadaUmaConversao_EntaoConverterParaModeloUsuario()
        {
            // Arrange
            CadastrarUsuarioDTO dto = new ()
            {
                Nome = "Usuario 01",
                Email = "usuario01@gmail.com"
            };

            // Act
            Usuario usuario = dto.ConverterParaModelo();

            // Assert
            usuario.Nome.Should().Be(dto.Nome);
            usuario.Email.Should().Be(dto.Email);
            usuario.Id.Should().NotBeEmpty();

        }
    }
}
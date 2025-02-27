﻿using ControlePessoal.Domain.Commands.Usuario;
using ControlePessoal.Domain.Handlers;
using ControlePessoal.Domain.Tests.Repositories;
using Core.CQRS.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Tests.Handlers
{
    [TestClass]
    public class UsuarioHandlerTests
    {
        private readonly CreateUsuarioCommand _invalidCreateCommand = new("");
        private readonly CreateUsuarioCommand _validCreateCommand = new("RODRIGO ZA");

        private readonly UpdateUsuarioCommand _invalidUpdateCommand = new(0, "");
        private readonly UpdateUsuarioCommand _validUpdateCommand = new(1, "RODRIGO ZA");

        private readonly UsuarioHandler _handler = new(new FakeUsuarioRepository());

        [TestMethod]
        public async Task DadoUmCreateCommandInvalidoDeveInterromperAExecucao()
        {
            var result = (CommandResult)await _handler.Handle(_invalidCreateCommand);

            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public async Task DadoUmCreateCommandValidoDeveCriarOUsuario()
        {
            var result = (CommandResult)await _handler.Handle(_validCreateCommand);

            Assert.AreEqual(result.Success, true);
        }

        [TestMethod]
        public async Task DadoUmUpdateCommandInvalidoDeveInterromperAExecucao()
        {
            var result = (CommandResult)await _handler.Handle(_invalidUpdateCommand);

            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public async Task DadoUmUpdateCommandValidoDeveCriarOUsuario()
        {
            var result = (CommandResult)await _handler.Handle(_validUpdateCommand);

            Assert.AreEqual(result.Success, true);
        }
    }
}

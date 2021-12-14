using ControlePessoal.Domain.Commands.Usuario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Tests.Commands.Usuario
{
    [TestClass]
    public class CreateUsuarioCommandTests
    {
        private readonly CreateUsuarioCommand _invalidCreateCommand = new("");
        private readonly CreateUsuarioCommand _validCreateCommand = new("RODRIGO ZA");

        [TestMethod]
        public void DadoUmCreateCommandInvalido()
        {
            _invalidCreateCommand.Validate();
            Assert.AreEqual(_invalidCreateCommand.IsValid, false);
        }

        [TestMethod]
        public void DadoUmCreateCommandValido()
        {
            _validCreateCommand.Validate();
            Assert.AreEqual(_validCreateCommand.IsValid, true);
        }
    }
}

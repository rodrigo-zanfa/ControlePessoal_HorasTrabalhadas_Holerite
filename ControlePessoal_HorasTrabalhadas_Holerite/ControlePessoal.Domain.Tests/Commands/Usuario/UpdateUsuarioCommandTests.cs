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
    public class UpdateUsuarioCommandTests
    {
        private readonly UpdateUsuarioCommand _invalidUpdateCommand = new(0, "");
        private readonly UpdateUsuarioCommand _validUpdateCommand = new(1, "RODRIGO ZA");

        [TestMethod]
        public void DadoUmUpdateCommandInvalido()
        {
            _invalidUpdateCommand.Validate();
            Assert.AreEqual(_invalidUpdateCommand.IsValid, false);
        }

        [TestMethod]
        public void DadoUmUpdateCommandValido()
        {
            _validUpdateCommand.Validate();
            Assert.AreEqual(_validUpdateCommand.IsValid, true);
        }
    }
}

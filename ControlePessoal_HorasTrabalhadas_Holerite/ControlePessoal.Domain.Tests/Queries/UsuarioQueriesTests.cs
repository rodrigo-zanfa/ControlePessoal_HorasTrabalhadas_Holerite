using ControlePessoal.Domain.Entities;
using ControlePessoal.Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Tests.Queries
{
    [TestClass]
    public class UsuarioQueriesTests
    {
        private IList<Usuario> _usuarios;

        public UsuarioQueriesTests()
        {
            _usuarios = new List<Usuario>();

            for (int i = 1; i <= 10; i++)
            {
                _usuarios.Add(new Usuario(i, $"USUÁRIO {i}"));
            }
        }

        [TestMethod]
        public void DadoUmaQueryDeveRetornarTodosOsUsuario()
        {
            var result = _usuarios;

            Assert.AreEqual(result.Count, 10);
        }

        [TestMethod]
        public void DadoUmaQueryDeveRetornarUmUsuario()
        {
            var exp = UsuarioQueries.GetById(1);

            var result = _usuarios.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(result.IdUsuario, 1);
        }
    }
}

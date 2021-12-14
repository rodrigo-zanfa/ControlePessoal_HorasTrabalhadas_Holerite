using ControlePessoal.Domain.Entities;
using ControlePessoal.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Tests.Repositories
{
    public class FakeUsuarioRepository : IUsuarioRepository
    {
        public void Create(Usuario usuario)
        {

        }

        public void Update(Usuario usuario)
        {

        }

        public Usuario GetById(int idUsuario)
        {
            // TODO: testar se funciona retornando sem Id
            return new Usuario("USUÁRIO FAKE");
        }
    }
}

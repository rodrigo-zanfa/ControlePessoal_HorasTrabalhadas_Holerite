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
        private IList<Usuario> _usuarios;

        public FakeUsuarioRepository()
        {
            _usuarios = new List<Usuario>();

            for (int i = 1; i <= 10; i++)
            {
                _usuarios.Add(new Usuario(i, $"USUÁRIO {i}"));
            }
        }

        public void Create(Usuario usuario)
        {

        }

        public void Update(Usuario usuario)
        {

        }

        public IEnumerable<Usuario> GetAll()
        {
            return _usuarios;
        }

        public Usuario GetById(int idUsuario)
        {
            return _usuarios.Where(x => x.IdUsuario == idUsuario).FirstOrDefault();
        }
    }
}

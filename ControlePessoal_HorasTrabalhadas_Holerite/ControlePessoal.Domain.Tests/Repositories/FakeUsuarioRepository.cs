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

        public async Task CreateAsync(Usuario entity)
        {

        }

        public async Task UpdateAsync(Usuario entity)
        {

        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await Task.Run(() => _usuarios);
        }

        public async Task<Usuario> GetByIdAsync(int idUsuario)
        {
            return await Task.Run(() => _usuarios.Where(x => x.IdUsuario == idUsuario).FirstOrDefault());
        }
    }
}

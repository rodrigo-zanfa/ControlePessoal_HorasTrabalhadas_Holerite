using ControlePessoal.Domain.Entities;
using ControlePessoal.Domain.Queries;
using ControlePessoal.Domain.Repositories;
using ControlePessoal.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(Usuario entity)
        {
            _dataContext.Usuarios.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(Usuario entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _dataContext
                .Usuarios
                .AsNoTracking()
                .OrderBy(x => x.IdUsuario)
                .ToList();
        }

        public Usuario GetById(int id)
        {
            return _dataContext
                .Usuarios
                .AsNoTracking()
                //.FirstOrDefault(x => x.IdUsuario == id);  // TODO: testar para comparar qual dos casos (este ou o de baixo) gera um SQL mais performático
                .Where(UsuarioQueries.GetById(id))  //.Where(x => x.IdUsuario == id)
                .FirstOrDefault();
        }
    }
}

using ControlePessoal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Queries
{
    public static class UsuarioQueries
    {
        public static Expression<Func<Usuario, bool>> GetById(int idUsuario)
        {
            return x => x.IdUsuario == idUsuario;
        }
    }
}

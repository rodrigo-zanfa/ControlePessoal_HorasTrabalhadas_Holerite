using ControlePessoal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Repositories
{
    public interface IParametroUsuarioRepository
    {
        Task<ParametroUsuario> GetParametroUsuarioByDataVigenciaAsync(int idParametro, int idUsuario, DateTime dataVigencia);
    }
}

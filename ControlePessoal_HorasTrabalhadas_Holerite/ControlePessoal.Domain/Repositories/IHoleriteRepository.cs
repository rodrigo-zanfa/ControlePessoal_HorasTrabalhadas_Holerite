using ControlePessoal.Domain.Entities;
using Core.CQRS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Repositories
{
    public interface IHoleriteRepository : IRepository<Holerite>
    {
        Task<IEnumerable<Holerite>> GetAllByUsuarioAsync(int idUsuario, DateTime dataInicial, DateTime dataFinal);
    }
}

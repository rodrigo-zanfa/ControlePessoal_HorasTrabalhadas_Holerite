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
        IEnumerable<Holerite> GetAllByUsuario(int idUsuario, DateTime dataInicial, DateTime dataFinal);
    }
}

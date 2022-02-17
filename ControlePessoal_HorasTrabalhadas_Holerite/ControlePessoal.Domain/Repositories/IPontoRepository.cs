using ControlePessoal.Domain.Entities;
using Core.CQRS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Repositories
{
    public interface IPontoRepository : IRepository<Ponto>
    {
        Task<IEnumerable<Ponto>> GetAllByUsuarioAsync(int idUsuario, DateTime dataInicial, DateTime dataFinal);
    }
}

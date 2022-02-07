using ControlePessoal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Queries
{
    public static class HoleriteQueries
    {
        public static Expression<Func<Holerite, bool>> GetById(int idHolerite)
        {
            return x => x.IdHolerite == idHolerite;
        }

        public static Expression<Func<Holerite, bool>> GetAllByUsuario(int idUsuario, DateTime dataInicial, DateTime dataFinal)
        {
            return x => x.IdUsuario == idUsuario && x.DataPagamento >= dataInicial && x.DataPagamento <= dataFinal;
        }
    }
}

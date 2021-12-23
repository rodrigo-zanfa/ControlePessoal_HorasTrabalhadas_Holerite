using ControlePessoal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Queries
{
    public static class AusenciaQueries
    {
        public static Expression<Func<Ausencia, bool>> GetById(int idAusencia)
        {
            return x => x.IdAusencia == idAusencia;
        }

        public static Expression<Func<Ausencia, bool>> GetAllByUsuario(int idUsuario, DateTime dataInicial, DateTime dataFinal)
        {
            return x => x.IdUsuario == idUsuario && x.DataAusencia >= dataInicial && x.DataAusencia <= dataFinal;
        }
    }
}

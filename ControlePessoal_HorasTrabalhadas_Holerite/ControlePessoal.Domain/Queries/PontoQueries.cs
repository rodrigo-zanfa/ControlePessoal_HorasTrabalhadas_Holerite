using ControlePessoal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Queries
{
    public class GetAllByUsuarioQuery
    {
        public int IdUsuario { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }

    public static class PontoQueries
    {
        public static Expression<Func<Ponto, bool>> GetById(int idPonto)
        {
            return x => x.IdPonto == idPonto;
        }

        public static Expression<Func<Ponto, bool>> GetAllByUsuario(int idUsuario, DateTime dataInicial, DateTime dataFinal)
        {
            return x => x.IdUsuario == idUsuario && x.DataPonto >= dataInicial && x.DataPonto <= dataFinal;
        }
    }
}

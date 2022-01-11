using ControlePessoal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Domain.Queries
{
    public static class SalarioQueries
    {
        public static Expression<Func<Salario, bool>> GetById(int idSalario)
        {
            return x => x.IdSalario == idSalario;
        }

        public static Expression<Func<Salario, bool>> GetAllByUsuario(int idUsuario, DateTime dataInicial, DateTime dataFinal)
        {
            return x => x.IdUsuario == idUsuario && x.DataVigenciaInicial >= dataInicial && x.DataVigenciaInicial <= dataFinal;
        }
    }
}

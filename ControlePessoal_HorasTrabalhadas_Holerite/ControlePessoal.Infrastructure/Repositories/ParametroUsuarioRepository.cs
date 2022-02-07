using ControlePessoal.Domain.Entities;
using ControlePessoal.Domain.Repositories;
using ControlePessoal.Infrastructure.DataAccess;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Infrastructure.Repositories
{
    public class ParametroUsuarioRepository : IParametroUsuarioRepository
    {
        public async Task<ParametroUsuario> GetParametroUsuarioByDataVigenciaAsync(int idParametro, int idUsuario, DateTime dataVigencia)
        {
            using var conn = Connection.GetConnection();

            var parametroUsuario = await conn.QueryFirstOrDefaultAsync<ParametroUsuario>(@"
declare @Sequencia int
declare @IdParametroUsuario int

select top 1
  @Sequencia = row_number() over (order by pu.DataVigenciaInicial desc),
  @IdParametroUsuario = pu.IdParametroUsuario
from dbo.APIParametroUsuario pu
where pu.IdParametro = @IdParametro
  and pu.IdUsuario = @IdUsuario
  and pu.DataVigenciaInicial <= @DataVigencia

select
  pu.IdParametroUsuario, pu.IdParametro, pu.IdUsuario, pu.DataVigenciaInicial, pu.Valor, pu.DataHoraInclusao, pu.DataHoraAlteracao
from dbo.APIParametroUsuario pu
where pu.IdParametroUsuario = @IdParametroUsuario
"
                , new { IdParametro = idParametro, IdUsuario = idUsuario, DataVigencia = dataVigencia });

            return parametroUsuario;
        }
    }
}

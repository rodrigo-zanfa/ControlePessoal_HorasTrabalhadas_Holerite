using ControlePessoal.Domain.Entities;
using ControlePessoal.Domain.Repositories;
using ControlePessoal.Infrastructure.Contexts;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Infrastructure.Repositories
{
    public class ParametroUsuarioRepository : IParametroUsuarioRepository
    {
        private readonly DataContext _dataContext;

        public ParametroUsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ParametroUsuario> GetParametroUsuarioByDataVigenciaAsync(int idParametro, int idUsuario, DateTime dataVigencia)
        {
            var parametroUsuario = await _dataContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<ParametroUsuario>("GetParametroUsuarioByDataVigencia",
                new { p_IdParametro = idParametro, p_IdUsuario = idUsuario, p_DataVigencia = dataVigencia },
                commandType: CommandType.StoredProcedure);

            return parametroUsuario;
        }
    }
}

using ControlePessoal.Domain.Entities;
using ControlePessoal.Domain.Queries;
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
    public class SalarioRepository : ISalarioRepository
    {
        private readonly DataContext _dataContext;

        public SalarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateAsync(Salario entity)
        {
            entity.UpdateDataHoraInclusao(DateTime.Now);

            await _dataContext.Salarios.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Salario entity)
        {
            entity.UpdateDataHoraAlteracao(DateTime.Now);

            _dataContext.Entry(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Salario>> GetAllAsync()
        {
            return await _dataContext
                .Salarios
                .AsNoTracking()
                .OrderBy(x => x.IdSalario)
                .ToListAsync();
        }

        public async Task<Salario> GetByIdAsync(int id)
        {
            return await _dataContext
                .Salarios
                .AsNoTracking()
                //.FirstOrDefaultAsync(x => x.IdSalario == id);  // TODO: testar para comparar qual dos casos (este ou o de baixo) gera um SQL mais performático
                .Where(SalarioQueries.GetById(id))  //.Where(x => x.IdSalario == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Salario>> GetAllByUsuarioAsync(int idUsuario, DateTime dataInicial, DateTime dataFinal)
        {
            dataInicial = new DateTime(dataInicial.Year, dataInicial.Month, dataInicial.Day, 0, 0, 0);
            dataFinal = new DateTime(dataFinal.Year, dataFinal.Month, dataFinal.Day, 23, 59, 59);

            return await _dataContext
                .Salarios
                .AsNoTracking()
                .Where(SalarioQueries.GetAllByUsuario(idUsuario, dataInicial, dataFinal))  //.Where(x => x.IdUsuario == idUsuario && x.DataVigenciaInicial >= dataInicial && x.DataVigenciaInicial <= dataFinal)
                .OrderBy(x => x.DataVigenciaInicial)
                .ToListAsync();
        }

        public async Task<Salario> GetSalarioByDataVigenciaAsync(int idUsuario, DateTime dataVigencia)
        {
            var salario = await _dataContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<Salario>("GetSalarioByDataVigencia",
                new { p_IdUsuario = idUsuario, p_DataVigencia = dataVigencia },
                commandType: CommandType.StoredProcedure);

            return salario;
        }
    }
}

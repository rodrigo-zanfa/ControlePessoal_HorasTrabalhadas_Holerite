using ControlePessoal.Domain.Entities;
using ControlePessoal.Domain.Queries;
using ControlePessoal.Domain.Repositories;
using ControlePessoal.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Infrastructure.Repositories
{
    public class AusenciaRepository : IAusenciaRepository
    {
        private readonly DataContext _dataContext;

        public AusenciaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateAsync(Ausencia entity)
        {
            entity.UpdateDataHoraInclusao(DateTime.Now);

            await _dataContext.Ausencias.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ausencia entity)
        {
            entity.UpdateDataHoraAlteracao(DateTime.Now);

            _dataContext.Entry(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ausencia>> GetAllAsync()
        {
            return await _dataContext
                .Ausencias
                .AsNoTracking()
                .OrderBy(x => x.IdAusencia)
                .ToListAsync();
        }

        public async Task<Ausencia> GetByIdAsync(int id)
        {
            return await _dataContext
                .Ausencias
                .AsNoTracking()
                //.FirstOrDefaultAsync(x => x.IdAusencia == id);  // TODO: testar para comparar qual dos casos (este ou o de baixo) gera um SQL mais performático
                .Where(AusenciaQueries.GetById(id))  //.Where(x => x.IdAusencia == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Ausencia>> GetAllByUsuarioAsync(int idUsuario, DateTime dataInicial, DateTime dataFinal)
        {
            dataInicial = new DateTime(dataInicial.Year, dataInicial.Month, dataInicial.Day, 0, 0, 0);
            dataFinal = new DateTime(dataFinal.Year, dataFinal.Month, dataFinal.Day, 23, 59, 59);

            return await _dataContext
                .Ausencias
                .AsNoTracking()
                .Where(AusenciaQueries.GetAllByUsuario(idUsuario, dataInicial, dataFinal))  //.Where(x => x.IdUsuario == idUsuario && x.DataAusencia >= dataInicial && x.DataAusencia <= dataFinal)
                .OrderBy(x => x.DataAusencia)
                .ThenBy(x => x.HoraInicialAusencia)
                .ToListAsync();
        }
    }
}

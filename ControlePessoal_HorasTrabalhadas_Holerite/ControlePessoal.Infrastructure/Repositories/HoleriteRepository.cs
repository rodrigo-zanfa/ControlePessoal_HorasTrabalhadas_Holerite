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
    public class HoleriteRepository : IHoleriteRepository
    {
        private readonly DataContext _dataContext;

        public HoleriteRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateAsync(Holerite entity)
        {
            entity.UpdateDataHoraInclusao(DateTime.Now);

            await _dataContext.Holerites.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Holerite entity)
        {
            entity.UpdateDataHoraAlteracao(DateTime.Now);

            _dataContext.Entry(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Holerite>> GetAllAsync()
        {
            return await _dataContext
                .Holerites
                .AsNoTracking()
                .OrderBy(x => x.IdHolerite)
                .ToListAsync();
        }

        public async Task<Holerite> GetByIdAsync(int id)
        {
            return await _dataContext
                .Holerites
                .AsNoTracking()
                //.FirstOrDefaultAsync(x => x.IdHolerite == id);  // TODO: testar para comparar qual dos casos (este ou o de baixo) gera um SQL mais performático
                .Where(HoleriteQueries.GetById(id))  //.Where(x => x.IdHolerite == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Holerite>> GetAllByUsuarioAsync(int idUsuario, DateTime dataInicial, DateTime dataFinal)
        {
            dataInicial = new DateTime(dataInicial.Year, dataInicial.Month, dataInicial.Day, 0, 0, 0);
            dataFinal = new DateTime(dataFinal.Year, dataFinal.Month, dataFinal.Day, 23, 59, 59);

            return await _dataContext
                .Holerites
                .AsNoTracking()
                .Where(HoleriteQueries.GetAllByUsuario(idUsuario, dataInicial, dataFinal))  //.Where(x => x.IdUsuario == idUsuario && x.DataPagamento >= dataInicial && x.DataPagamento <= dataFinal)
                .OrderBy(x => x.DataPagamento)
                .ToListAsync();
        }
    }
}

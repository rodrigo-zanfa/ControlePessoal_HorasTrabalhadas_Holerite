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

        public void Create(Ausencia entity)
        {
            entity.UpdateDataHoraInclusao(DateTime.Now);

            _dataContext.Ausencias.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(Ausencia entity)
        {
            entity.UpdateDataHoraAlteracao(DateTime.Now);

            _dataContext.Entry(entity).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public IEnumerable<Ausencia> GetAll()
        {
            return _dataContext
                .Ausencias
                .AsNoTracking()
                .OrderBy(x => x.IdAusencia)
                .ToList();
        }

        public Ausencia GetById(int id)
        {
            return _dataContext
                .Ausencias
                .AsNoTracking()
                //.FirstOrDefault(x => x.IdAusencia == id);  // TODO: testar para comparar qual dos casos (este ou o de baixo) gera um SQL mais performático
                .Where(AusenciaQueries.GetById(id))  //.Where(x => x.IdAusencia == id)
                .FirstOrDefault();
        }

        public IEnumerable<Ausencia> GetAllByUsuario(int idUsuario, DateTime dataInicial, DateTime dataFinal)
        {
            dataInicial = new DateTime(dataInicial.Year, dataInicial.Month, dataInicial.Day, 0, 0, 0);
            dataFinal = new DateTime(dataFinal.Year, dataFinal.Month, dataFinal.Day, 23, 59, 59);

            return _dataContext
                .Ausencias
                .AsNoTracking()
                .Where(AusenciaQueries.GetAllByUsuario(idUsuario, dataInicial, dataFinal))  //.Where(x => x.IdUsuario == idUsuario && x.DataAusencia >= dataInicial && x.DataAusencia <= dataFinal)
                .OrderBy(x => x.DataAusencia)
                .ThenBy(x => x.HoraInicialAusencia)
                .ToList();
        }
    }
}

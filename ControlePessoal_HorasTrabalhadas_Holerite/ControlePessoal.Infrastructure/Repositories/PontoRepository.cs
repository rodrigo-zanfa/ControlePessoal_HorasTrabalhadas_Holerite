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
    public class PontoRepository : IPontoRepository
    {
        private readonly DataContext _dataContext;

        public PontoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(Ponto entity)
        {
            entity.UpdateDataHoraInclusao(DateTime.Now);

            _dataContext.Pontos.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(Ponto entity)
        {
            entity.UpdateDataHoraAlteracao(DateTime.Now);

            _dataContext.Entry(entity).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public IEnumerable<Ponto> GetAll()
        {
            return _dataContext
                .Pontos
                .AsNoTracking()
                .OrderBy(x => x.IdPonto)
                .ToList();
        }

        public Ponto GetById(int id)
        {
            return _dataContext
                .Pontos
                .AsNoTracking()
                //.FirstOrDefault(x => x.IdPonto == id);  // TODO: testar para comparar qual dos casos (este ou o de baixo) gera um SQL mais performático
                .Where(PontoQueries.GetById(id))  //.Where(x => x.IdPonto == id)
                .FirstOrDefault();
        }

        public IEnumerable<Ponto> GetAllByUsuario(int idUsuario, DateTime dataInicial, DateTime dataFinal)
        {
            dataInicial = new DateTime(dataInicial.Year, dataInicial.Month, dataInicial.Day, 0, 0, 0);
            dataFinal = new DateTime(dataFinal.Year, dataFinal.Month, dataFinal.Day, 23, 59, 59);

            return _dataContext
                .Pontos
                .AsNoTracking()
                .Where(PontoQueries.GetAllByUsuario(idUsuario, dataInicial, dataFinal))  //.Where(x => x.IdUsuario == idUsuario && x.DataPonto >= dataInicial && x.DataPonto <= dataFinal)
                .OrderBy(x => x.DataPonto)
                .ThenBy(x => x.HoraPonto)
                .ToList();
        }
    }
}

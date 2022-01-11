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
    public class SalarioRepository : ISalarioRepository
    {
        private readonly DataContext _dataContext;

        public SalarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(Salario entity)
        {
            entity.UpdateDataHoraInclusao(DateTime.Now);

            _dataContext.Salarios.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(Salario entity)
        {
            entity.UpdateDataHoraAlteracao(DateTime.Now);

            _dataContext.Entry(entity).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public IEnumerable<Salario> GetAll()
        {
            return _dataContext
                .Salarios
                .AsNoTracking()
                .OrderBy(x => x.IdSalario)
                .ToList();
        }

        public Salario GetById(int id)
        {
            return _dataContext
                .Salarios
                .AsNoTracking()
                //.FirstOrDefault(x => x.IdSalario == id);  // TODO: testar para comparar qual dos casos (este ou o de baixo) gera um SQL mais performático
                .Where(SalarioQueries.GetById(id))  //.Where(x => x.IdSalario == id)
                .FirstOrDefault();
        }

        public IEnumerable<Salario> GetAllByUsuario(int idUsuario, DateTime dataInicial, DateTime dataFinal)
        {
            dataInicial = new DateTime(dataInicial.Year, dataInicial.Month, dataInicial.Day, 0, 0, 0);
            dataFinal = new DateTime(dataFinal.Year, dataFinal.Month, dataFinal.Day, 23, 59, 59);

            return _dataContext
                .Salarios
                .AsNoTracking()
                .Where(SalarioQueries.GetAllByUsuario(idUsuario, dataInicial, dataFinal))  //.Where(x => x.IdUsuario == idUsuario && x.DataVigenciaInicial >= dataInicial && x.DataVigenciaInicial <= dataFinal)
                .OrderBy(x => x.DataVigenciaInicial)
                .ToList();
        }
    }
}

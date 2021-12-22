using Core.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CQRS.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        void Create(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}

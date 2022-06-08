using Core.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CQRS.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
    }
}

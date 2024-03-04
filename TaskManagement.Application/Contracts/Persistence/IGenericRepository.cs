using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(Guid ID);
        Task<IReadOnlyList<T>> GetAll();
        Task<bool> Exists(Guid ID);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}

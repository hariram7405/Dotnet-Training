using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelManagement.Core.Interfaces
{
    public interface IRepository<T> where T:class

    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);

        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        Task DeleteAsync(T entity);


    }
}

using System.Collections.Generic;

namespace BugTracker.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        T? GetById(int id);
        List<T> GetAll();
    }
}

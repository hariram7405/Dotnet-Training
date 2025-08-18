﻿namespace HostelManagement.Core.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);
        T? GetById(int id);
        IEnumerable<T> GetAll();
        void Delete(int id);
      
    }

}

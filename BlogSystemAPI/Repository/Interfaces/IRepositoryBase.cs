using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystemAPI.Repository.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetFilteredList();
    }
}

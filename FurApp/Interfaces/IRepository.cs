using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Interfaces.IRepository
{
    public interface IRepository<T> where T : AModel
    {
        Task<bool> SalvarAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task<List<T>> GetAll();
        Task<bool> DeleteAsync(Guid id);
    }
}
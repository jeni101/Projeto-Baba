namespace Interfaces.IRepository;

interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task DeleteAsync(int id);
    Task<T> UpdateAsync(T entity);
    Task<T> InsertAsync(T entity);
}
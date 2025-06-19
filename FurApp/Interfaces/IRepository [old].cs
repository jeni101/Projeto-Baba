namespace Interfaces.old.IRepository;

interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T?> GetByNameAsync(string nome);
    Task DeleteAsync(int id);
    Task<T> UpdateAsync(T entity);
    Task<T> InsertAsync(T entity);
}
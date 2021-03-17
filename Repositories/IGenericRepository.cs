using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksWebApiAng.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void Update(T entity);
        Task<T> CreateAsync(T entity);
        void Delete(T entity);
        Task<T> FindByIdAsync(int id);
    }
}

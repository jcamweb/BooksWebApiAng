using System.Threading.Tasks;

namespace BooksWebApiAng.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}

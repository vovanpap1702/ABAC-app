using System.Threading.Tasks;

namespace ABAC.DAL.Repositories.Contracts
{
    public interface IEntityRepository<T>
    {
        Task<T> GetByIdAsync(int id);

        Task CreateOrUpdateAsync(T entity);

        Task DeleteByIdAsync(int id);
    }
}

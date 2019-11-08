using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABAC.DAL.Repositories.Contracts
{
    public interface IEntityRepository<T>
    {
        Task<IEnumerable<T>> GetAsync();

        Task<T> GetByIdAsync(int id);

        Task CreateOrUpdateAsync(T entity);

        Task DeleteByIdAsync(int id);
    }
}

using ABAC.DAL.Entities;
using System.Threading.Tasks;

namespace ABAC.DAL.Repositories.Contracts
{
    public interface IUserRepository : IEntityRepository<User>
    {
        Task<User> GetByLoginAsync(string login);
    }
}
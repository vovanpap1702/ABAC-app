using ABAC.DAL.Entities;
using System.Threading.Tasks;

namespace ABAC.DAL.Repositories.Contracts
{
    public interface ICredentialsRepository
    {
        Task<User> GetAsync(string login);

        Task AddAsync(User credentials);
    }
}
using ABAC.DAL.Entities;
using ABAC.DAL.Repositories.Contracts;
using System;
using System.Threading.Tasks;

namespace ABAC.DAL.Repositories
{
    public class UserRepository : IEntityRepository<User>
    {
        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateOrUpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

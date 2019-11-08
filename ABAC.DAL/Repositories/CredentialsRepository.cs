using ABAC.DAL.Repositories.Contracts;
using ABAC.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace ABAC.DAL.Repositories
{
    public class CredentialsRepository : ICredentialsRepository
    {
        public Task AddAsync(User credentials)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(string login)
        {
            throw new NotImplementedException();
        }
    }
}

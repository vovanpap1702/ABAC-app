using ABAC.DAL.Entities;
using ABAC.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABAC.DAL.Repositories
{
    public class ResourceRepository : IEntityRepository<Resource>
    {
        public Task<IEnumerable<Resource>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Resource> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateOrUpdateAsync(Resource entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

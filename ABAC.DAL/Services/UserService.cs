using ABAC.DAL.Entities;
using ABAC.DAL.Models;
using ABAC.DAL.Repositories.Contracts;
using ABAC.DAL.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attribute = ABAC.DAL.Entities.Attribute;

namespace ABAC.DAL.Services
{
    public class UserService : IService<UserInfo>
    {
        private readonly IEntityRepository<User> repository;

        public UserService(IEntityRepository<User> repository)
        {
            this.repository = repository;
        }

        public async Task<UserInfo> GetAsync(int id)
        {
            var user = await repository.GetByIdAsync(id);

            return new UserInfo { Id = user.Id, Name = user.Name };
        }

        public async Task UpdateAsync(UserInfo model)
        {
            var user = await repository.GetByIdAsync(model.Id);
            if (model == null)
            {
                // get new user from the user factory? or it cannot be created idk
                throw new NotImplementedException();
            }

            user.Name = model.Name;
            await repository.CreateOrUpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Attribute>> GetAttributesAsync(int id)
        {
            var user = await repository.GetByIdAsync(id);

            return user.Attributes;
        }

        public async Task AddAttributesAsync(int id, IEnumerable<Attribute> attributes)
        {
            var user = await repository.GetByIdAsync(id);
            user.Attributes = user.Attributes.Concat(attributes).Distinct(new AttributeEqualityComparer());
            await repository.CreateOrUpdateAsync(user);
        }

        public async Task DeleteAttributeAsync(int id, Attribute attribute)
        {
            var user = await repository.GetByIdAsync(id);
            user.Attributes = user.Attributes.Where(a => !new AttributeEqualityComparer().Equals(a, attribute));
            await repository.CreateOrUpdateAsync(user);
        }
    }
}

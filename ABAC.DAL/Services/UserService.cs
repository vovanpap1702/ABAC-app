using ABAC.DAL.Repositories.Contracts;
using ABAC.DAL.Services.Contracts;
using ABAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attribute = ABAC.DAL.Entities.Attribute;

namespace ABAC.DAL.Services
{
    using ABAC.DAL.Entities;

    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository, ICredentialsRepository credentialsRepository)
        {
            this.repository = repository;
            this.credentialsRepository = credentialsRepository;
        }

        public async Task<IEnumerable<UserInfo>> GetAsync()
        {
            //will be mapped later
            return (await repository.GetAsync()).Select(u => new UserInfo(){ Id = u.Id, Login = u.Login, Name = u.Name });
        }

        public async Task<UserInfo> GetAsync(int id)
        {
            var user = await repository.GetByIdAsync(id);
            if (user == null)
            {
                // throw new NotFoundException
            }
        // will be mapped later
        return new UserInfo { Id = user.Id, Name = user.Name, Login = user.Login };
        }

        public async Task<UserInfo> GetAsync(string login)
        {
            var user = await repository.GetByLoginAsync(login);
            if (user == null)
            {
                // throw new NotFoundException
            }
            // will be mapped later
            return new UserInfo { Id = user.Id, Login = user.Login, Name = user.Name };
        }

        public async Task<UserCredentials> GetCredentialsAsync(string login)
        {
            var credentials = await repository.GetByLoginAsync(login);

            // will be mapped later
            return credentials != null ? new UserCredentials(){ Login = credentials.Login, Password = credentials.Password } : null;
        }

        public async Task CreateAsync(UserInfo user, UserCredentials credentials)
        {
            await repository.CreateOrUpdateAsync(new User());
            // add new user using user factory
        }

        public async Task UpdateAsync(UserInfo model)
        {
            var user = await repository.GetByIdAsync(model.Id);
            if (user == null)
            {
                // throw new NotFoundException
            }

            user.Name = model.Name;
            await repository.CreateOrUpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await repository.GetByIdAsync(id);
            if (user == null)
            {
                // throw new NotFoundException
            }

            await repository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Attribute>> GetAttributesAsync(int id)
        {
            var user = await repository.GetByIdAsync(id);
            if (user == null)
            {
                // throw new NotFoundException
            }

            return user.Attributes;
        }

        public async Task AddAttributesAsync(int id, IEnumerable<Attribute> attributes)
        {
            var user = await repository.GetByIdAsync(id);
            if (user == null)
            {
                // throw new NotFoundException
            }

            user.Attributes = user.Attributes.Concat(attributes).Distinct(new AttributeEqualityComparer());
            await repository.CreateOrUpdateAsync(user);
        }

        public async Task DeleteAttributeAsync(int id, Attribute attribute)
        {
            var user = await repository.GetByIdAsync(id);
            if (user == null)
            {
                // throw new NotFoundException
            }

            user.Attributes = user.Attributes.Where(a => !new AttributeEqualityComparer().Equals(a, attribute));
            await repository.CreateOrUpdateAsync(user);
        }
    }
}

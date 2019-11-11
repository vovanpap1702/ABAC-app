using ABAC.DAL.Entities;
using ABAC.DAL.Exceptions;
using ABAC.DAL.Repositories.Contracts;
using ABAC.DAL.Services.Contracts;
using ABAC.DAL.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABAC.DAL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserInfo>> GetAsync()
        {
            return (await repository.GetAsync()).Select(u => mapper.Map<UserInfo>(u));
        }

        public async Task<UserInfo> GetAsync(int id)
        {
            var user = await repository.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException();
            }

            return mapper.Map<UserInfo>(user);
        }

        public async Task<UserInfo> GetAsync(string login)
        {
            var user = await repository.GetByLoginAsync(login);
            if (user == null)
            {
                throw new NotFoundException();
            }
            
            return mapper.Map<UserInfo>(user);
        }

        public async Task<UserCredentials> GetCredentialsAsync(string login)
        {
            var credentials = await repository.GetByLoginAsync(login);
            if (credentials == null)
            {
                throw new NotFoundException();
            }

            return mapper.Map<UserCredentials>(credentials);
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
                throw new NotFoundException();
            }

            user.Name = model.Name;
            await repository.CreateOrUpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await repository.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException();
            }

            await repository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Attribute>> GetAttributesAsync(int id)
        {
            var user = await repository.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException();
            }

            return user.Attributes;
        }

        public async Task AddAttributesAsync(int id, IEnumerable<Attribute> attributes)
        {
            var user = await repository.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException();
            }

            user.Attributes = user.Attributes.Concat(attributes).Distinct(new AttributeEqualityComparer());
            await repository.CreateOrUpdateAsync(user);
        }

        public async Task DeleteAttributeAsync(int id, Attribute attribute)
        {
            var user = await repository.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException();
            }

            user.Attributes = user.Attributes.Where(a => !new AttributeEqualityComparer().Equals(a, attribute));
            await repository.CreateOrUpdateAsync(user);
        }
    }
}

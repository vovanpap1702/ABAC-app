using ABAC.DAL.ViewModels;

namespace ABAC.DAL.Services.Contracts
{
    using System.Threading.Tasks;

    public interface IUserService : IService<UserInfo>
    {
        Task<UserInfo> GetAsync(string login);

        Task<UserCredentials> GetCredentialsAsync(string login);

        Task CreateAsync(UserInfo info, UserCredentials credentials);
    }
}
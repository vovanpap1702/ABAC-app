using ABAC.DAL.Exceptions;
using ABAC.DAL.Services.Contracts;
using ABAC.DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ABAC.WebApp.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IUserService service;

        public SessionController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost("signup")]
        public async Task SignUp([FromForm] UserCredentials credentials, [FromForm] UserInfo info)
        {
            try
            {
                await service.GetCredentialsAsync(credentials.Login);
            }
            catch (NotFoundException)
            {
                await service.CreateAsync(info, credentials);
                return;
            }

            throw new AlreadyExistsException();
        }

        [HttpPost("login")]
        public async Task LogIn([FromForm] UserCredentials credentials)
        {
            var expected = await service.GetCredentialsAsync(credentials.Login);
            if (expected.Password != credentials.Password)
            {
                throw new InvalidCredentialsException();
            }

            HttpContext.Session.SetString("login", credentials.Login);
            var info = await service.GetAsync(credentials.Login);
            HttpContext.Session.SetInt32("id", info.Id);
            var attributes = await service.GetAttributesAsync(info.Id);
            foreach (var attribute in attributes)
            {
                HttpContext.Session.SetString(attribute.Name, attribute.Value);
            }
        }

        [HttpGet("logout")]
        public void LogOut()
        {
            HttpContext.Session.Clear();
        }
    }
}
using ABAC.DAL.Services.Contracts;
using ABAC.DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ABAC.WebApp.Controllers
{
    using System;

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
                var expected = await service.GetCredentialsAsync(credentials.Login);
            }
            catch (/*NotFound*/Exception)
            {
                await service.CreateAsync(info, credentials);
                // create session
            }

            // throw new AlreadyExistsException
        }

        [HttpPost("login")]
        public async Task LogIn([FromForm] UserCredentials user)
        {
            var expected = await service.GetCredentialsAsync(user.Login);
            if (expected != null && expected.Password == user.Password)
            {
                // create session
            }

            // throw new InvalidCredentialsException
        }

        [HttpGet("logout")]
        public async Task LogOut()
        {
            // terminate session
        }
    }
}
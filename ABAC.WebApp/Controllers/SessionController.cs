using ABAC.DAL.Exceptions;
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
                await service.GetCredentialsAsync(credentials.Login);
            }
            catch (NotFoundException)
            {
                await service.CreateAsync(info, credentials);
                // create session
                return;
            }

            throw new AlreadyExistsException();
        }

        [HttpPost("login")]
        public async Task LogIn([FromForm] UserCredentials user)
        {
            var expected = await service.GetCredentialsAsync(user.Login);
            if (expected.Password == user.Password)
            {
                // create session
                return;
            }

            throw new InvalidCredentialsException();
        }

        [HttpGet("logout")]
        public async Task LogOut()
        {
            // terminate session
        }
    }
}
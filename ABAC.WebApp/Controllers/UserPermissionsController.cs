using ABAC.DAL.Models;
using ABAC.DAL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Attribute = ABAC.DAL.Entities.Attribute;

namespace ABAC.WebApp.Controllers
{
    [Route("api/management")]
    [ApiController]
    public class UserPermissionsController : ControllerBase
    {
        private readonly IService<UserInfo> service;

        public UserPermissionsController(IService<UserInfo> service)
        {
            this.service = service;
        }

        [HttpGet("user/{id}")]
        public async Task<UserInfo> GetUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("user/{id}")]
        public async Task UpdateUserAsync(int id, [FromBody] IList<Attribute> attributes)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("user/{id}")]
        public async Task DeleteUserAttributeAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
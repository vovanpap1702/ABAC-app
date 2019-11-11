using ABAC.DAL.Services.Contracts;
using ABAC.DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Attribute = ABAC.DAL.Entities.Attribute;

namespace ABAC.WebApp.Controllers
{
    [Route("api/management")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IUserService userService;

        private readonly IService<ResourceInfo> resourceService;

        public PermissionsController(IUserService userService, IService<ResourceInfo> resourceService)
        {
            this.userService = userService;
            this.resourceService = resourceService;
        }

        [HttpGet("user/{id}")]
        public async Task<IEnumerable<Attribute>> GetUserAttributesAsync(int id)
        {
            return await userService.GetAttributesAsync(id);
        }

        [HttpPost("user/{id}")]
        public async Task UpdateUserAttributesAsync(int id, [FromBody] IEnumerable<Attribute> attributes)
        {
            await userService.AddAttributesAsync(id, attributes);
        }

        [HttpDelete("user/{id}")]
        public async Task DeleteUserAttributeAsync(int id, [FromBody] Attribute attribute)
        {
            await userService.DeleteAttributeAsync(id, attribute);
        }

        [HttpGet("resource/{id}")]
        public async Task<IEnumerable<Attribute>> GetResourceAttributesAsync(int id)
        {
            return await resourceService.GetAttributesAsync(id);
        }

        [HttpPost("resource/{id}")]
        public async Task UpdateResourceAsync(int id, [FromBody] IEnumerable<Attribute> attributes)
        {
            await resourceService.AddAttributesAsync(id, attributes);
        }

        [HttpDelete("user/{id}")]
        public async Task DeleteResourceAttributeAsync(int id, [FromBody] Attribute attribute)
        {
            await resourceService.DeleteAttributeAsync(id, attribute);
        }
    }
}
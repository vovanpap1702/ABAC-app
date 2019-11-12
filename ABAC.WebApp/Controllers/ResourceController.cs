using ABAC.DAL.Services.Contracts;
using ABAC.DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABAC.WebApp.Controllers
{
    [Route("api/resources")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IService<ResourceInfo> service;

        public ResourceController(IService<ResourceInfo> service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public async Task<IEnumerable<ResourceInfo>> GetResourcesAsync()
        {
            return await service.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<ResourceInfo> GetResourceAsync([FromRoute] int id)
        {
            return await service.GetAsync(id);
        }

        [HttpPost("")]
        public async Task CreateOrUpdateResourceAsync([FromBody] ResourceInfo resource)
        {
            await service.UpdateAsync(resource);
        }

        [HttpDelete("{id}")]
        public async Task DeleteResourceAsync([FromRoute] int id)
        {
            await service.DeleteAsync(id);
        }
    }
}
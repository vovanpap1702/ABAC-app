using ABAC.DAL.Models;
using ABAC.DAL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("{id}")]
        public async Task<ResourceInfo> GetResourceAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("")]
        public async Task CreateOrUpdateResourceAsync([FromBody] ResourceInfo resource)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task DeleteResourceAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
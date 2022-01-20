using Microsoft.AspNetCore.Mvc;
using Spaces.Models;
using Spaces.Repositories;

namespace Spaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : Controller
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantController(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        [HttpPost]
        public IActionResult Post(Tenant tenant)
        {
            _tenantRepository.Add(tenant);
            return CreatedAtAction("Get", new { id = tenant.Id }, tenant);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Tenant tenant)
        {
            var t = _tenantRepository.GetById(id);
            if (t == null)
            {
                return NotFound();
            }

            if (id != tenant.Id)
            {
                return BadRequest();
            }

            _tenantRepository.Update(tenant);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tenant = _tenantRepository.GetById(id);
            if (tenant == null)
            {
                return NotFound();
            }
            return Ok(tenant);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var payment = _tenantRepository.GetById(id);
            //var currentUser = GetCurrentUserProfile();
            //check that ribbon exist and belongs to user
            if (payment == null)
            {
                return NotFound();
            }
            _tenantRepository.Delete(id);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Spaces.Models;
using Spaces.Repositories;
using Spaces.Repository;

namespace Spaces.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public PropertyController(IPropertyRepository propertyRepository, IUserProfileRepository userProfileRepository)
        {
            _propertyRepository = propertyRepository;
            _userProfileRepository = userProfileRepository;

        }

        [HttpPost]
        public IActionResult Post(Property property)
        {
            _propertyRepository.Add(property);
            return CreatedAtAction("Get", new { id = property.Id }, property);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Property property)
        {
            var p = _propertyRepository.GetById(id);
            if (p == null)
            {
                return NotFound();
            }

            if (id != property.Id)
            {
                return BadRequest();
            }

            _propertyRepository.Update(property);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var property = _propertyRepository.GetById(id);
            if (property == null)
            {
                return NotFound();
            }
            return Ok(property);
        }

        [HttpGet("user/{id}")]
        public IActionResult GetByUserId(int id)
        {
            //check that user exist
            var user = _userProfileRepository.GetById(id);
            if (user == null)
            {
                BadRequest();
            }
            var properties = _propertyRepository.GetByUserId(id);
            return Ok(properties);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var payment = _propertyRepository.GetById(id);
            //var currentUser = GetCurrentUserProfile();
            //check that ribbon exist and belongs to user
            if (payment == null)
            {
                return NotFound();
            }
            _propertyRepository.Delete(id);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Spaces.Models;
using Spaces.Repository;

namespace Spaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        //https://localhost:5001/api/userprofile/
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userProfileRepository.GetAll());
        }

        // https://localhost:5001/api/userprofile/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var userProfile = _userProfileRepository.GetById(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserProfile userProfile)
        {
            var up = _userProfileRepository.GetById(id);
            if (up== null)
            {
                return NotFound();
            }

            if (id != up.Id)
            {
                return BadRequest();
            }

            _userProfileRepository.Update(userProfile);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Post(UserProfile userProfile)
        {
            _userProfileRepository.Add(userProfile);
            return CreatedAtAction("Get", new { id = userProfile.Id }, userProfile);
        }

    }
}

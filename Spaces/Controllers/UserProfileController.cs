using Microsoft.AspNetCore.Mvc;
using Spaces.Repository;

namespace Spaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeanVarietyController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public BeanVarietyController(IUserProfileRepository userProfileRepository)
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
            var variety = _userProfileRepository.GetById(id);
            if (variety == null)
            {
                return NotFound();
            }
            return Ok(variety);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Spaces.Models;
using Spaces.Repositories;
using Spaces.Repository;
using System;

namespace Spaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : Controller
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IPropertyRepository _propertyRepository;

        public RequestController(IRequestRepository requestRepository, IUserProfileRepository userProfileRepository, IPropertyRepository propertyRepository)
        {
            _requestRepository = requestRepository;
            _userProfileRepository = userProfileRepository;
            _propertyRepository = propertyRepository;   
        }

        [HttpPost]
        public IActionResult Post(Request request)
        {
            _requestRepository.Add(request);
            return CreatedAtAction("Get", new { id = request.Id }, request);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Request request)
        {
            var c = _requestRepository.GetById(id);
            if (c == null)
            {
                return NotFound();
            }

            if (id != request.Id)
            {
                return BadRequest();
            }

            _requestRepository.Update(request);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var request = _requestRepository.GetById(id);
            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);
        }

        [HttpGet("{id}/user")]
        public IActionResult GetByUserId(int id)
        {
            //check that user exist
            var user = _userProfileRepository.GetById(id);
            if (user == null)
            {
                BadRequest();
            }
            var requests = _requestRepository.GetByUserId(id);
            return Ok(requests);
        }

        [HttpGet("{id}/property")]
        public IActionResult GetByPropertyId(int id)
        {
            //check that user exist
            var user = _propertyRepository.GetById(id);
            if (user == null)
            {
                BadRequest();
            }
            var requests = _requestRepository.GetByUserId(id);
            return Ok(requests);
        }
    }
}

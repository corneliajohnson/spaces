using Microsoft.AspNetCore.Mvc;
using Spaces.Repositories;
using Spaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spaces.Models
{
    public class RequestController : Controller
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IPropertyRepository _propertyRepository;


        public RequestController(IRequestRepository requestRepository, IUserProfileRepository userProfileRepository, IPropertyRepository propertyRepository)
        {
            _requestRepository = requestRepository;
            _propertyRepository = propertyRepository;
            _userProfileRepository = userProfileRepository;
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
            var p = _requestRepository.GetById(id);
            if (p == null)
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

        [HttpGet("user/{id}")]
        public IActionResult GetByUserId(int id)
        {
            //check that user exist
            var user = _userProfileRepository.GetById(id);
            if (user == null)
            {
                BadRequest();
            }
            var properties = _requestRepository.GetByUserId(id);
            return Ok(properties);
        }

        [HttpGet("property/{id}")]
        public IActionResult GetByPropertyId(int id)
        {
            //check that user exist
            var user = _propertyRepository.GetById(id);
            if (user == null)
            {
                BadRequest();
            }
            var requests = _requestRepository.GetByPropertyId(id);
            return Ok(requests);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var payment = _requestRepository.GetById(id);
            //var currentUser = GetCurrentUserProfile();
            //check that ribbon exist and belongs to user
            if (payment == null)
            {
                return NotFound();
            }
            _requestRepository.Delete(id);
            return NoContent();
        }
    }
}

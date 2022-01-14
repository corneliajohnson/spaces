using Microsoft.AspNetCore.Mvc;
using Spaces.Models;
using Spaces.Repositories;
using Spaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : Controller
    {
        private readonly ICalendarRepository _calendarRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public CalendarController( ICalendarRepository calendarRepository,  IUserProfileRepository userProfileRepository)
        {
            _calendarRepository = calendarRepository;
            _userProfileRepository = userProfileRepository;
        }

        [HttpPost]
        public IActionResult Post(Calendar calendar)
        {
            _calendarRepository.Add(calendar);
            return CreatedAtAction("Get", new { id = calendar.Id }, calendar);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Calendar calendar)
        {
            var c = _calendarRepository.GetById(id);
            if (c == null)
            {
                return NotFound();
            }

            if (id != calendar.Id)
            {
                return BadRequest();
            }

            _calendarRepository.Update(calendar);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var calendar = _calendarRepository.GetById(id);
            if (calendar == null)
            {
                return NotFound();
            }
            return Ok(calendar);
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
            var calendars = _calendarRepository.GetByUserId(id);
            return Ok(calendars);
        }

        [HttpGet("tenant/{id}")]
        public IActionResult GetByTenantId(int id)
        {
            //check that tenant exist
            //var user = _userProfileRepository.GetById(id);
            //if (user == null)
            //{
            //    BadRequest();
            //}
            var calendars = _calendarRepository.GetByTenantId(id);
            return Ok(calendars);
        }

        [HttpGet("property/{id}")]
        public IActionResult GetByPropertyId(int id)
        {
            //check that property exist
            //var user = _userProfileRepository.GetById(id);
            //if (user == null)
            //{
            //    BadRequest();
            //}
            var calendars = _calendarRepository.GetByPropertyId(id);
            return Ok(calendars);
        }

        [HttpGet("date")]
        public IActionResult GetBydate(DateTime date)
        {
            var calendars = _calendarRepository.GetByDate(date);
            return Ok(calendars);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var calendar = _calendarRepository.GetById(id);
            //var currentUser = GetCurrentUserProfile();
            //check that ribbon exist and belongs to user
            if (calendar == null)
            {
                return NotFound();
            }
            _calendarRepository.Delete(id);
            return NoContent();
        }
    }
}

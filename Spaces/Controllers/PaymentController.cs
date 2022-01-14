using Microsoft.AspNetCore.Mvc;
using Spaces.Models;
using Spaces.Repositories;
using Spaces.Repository;
using System;

namespace Spaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public PaymentController(IPaymentRepository paymentRepository, IUserProfileRepository userProfileRepository)
        {
            _paymentRepository = paymentRepository;
            _userProfileRepository = userProfileRepository;
        }

        [HttpPost]
        public IActionResult Post(Payment payment)
        {
            payment.Date = DateTime.Now;
            _paymentRepository.Add(payment);
            return CreatedAtAction("Get", new { id = payment.Id }, payment);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Payment payment)
        {
            var p = _paymentRepository.GetById(id);
            if (p == null)
            {
                return NotFound();
            }

            if (id != payment.Id)
            {
                return BadRequest();
            }

            _paymentRepository.Update(payment);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var payment = _paymentRepository.GetById(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
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
            var payments = _paymentRepository.GetByUserId(id);
            return Ok(payments);
        }

        [HttpGet("{id}/tenant")]
        public IActionResult GetByTenantId(int id)
        {
            //check that tenant exist
            //var user = _userProfileRepository.GetById(id);
            //if (user == null)
            //{
            //    BadRequest();
            //}
            var payments = _paymentRepository.GetByTenantId(id);
            return Ok(payments);
        }

        [HttpGet("{id}/property")]
        public IActionResult GetByPropertyId(int id)
        {
            //check that property exist
            //var user = _userProfileRepository.GetById(id);
            //if (user == null)
            //{
            //    BadRequest();
            //}
            var payments = _paymentRepository.GetByPropertyId(id);
            return Ok(payments);
        }

        [HttpGet("bymonth")]
        public IActionResult GetByMonth(DateTime date)
        {
            var payments = _paymentRepository.GetByMonth(date);
            return Ok(payments);
        }

        [HttpGet("daterange")]
        public IActionResult GetByDateRange(DateTime startDate, DateTime endDate)
        {
            var payments = _paymentRepository.GetByDateRange(startDate, endDate);
            return Ok(payments);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var payment = _paymentRepository.GetById(id);
            //var currentUser = GetCurrentUserProfile();
            //check that ribbon exist and belongs to user
            if (payment == null)
            {
                return NotFound();
            }
            _paymentRepository.Delete(id);
            return NoContent();
        }
    }
}

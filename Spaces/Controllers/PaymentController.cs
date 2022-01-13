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
    }
}

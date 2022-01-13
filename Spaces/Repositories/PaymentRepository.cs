using Microsoft.EntityFrameworkCore;
using Spaces.Data;
using Spaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spaces.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Payment GetById(int id)
        {
            return _context.Payment
                .Include(payment => payment.Tenant)
                .FirstOrDefault(payment => payment.Id == id);
        }

        public List<Payment> GetByUserId(int userId)
        {
            return _context.Payment
                .Include(payment => payment.Tenant)
                .OrderByDescending(payment => payment.Date)
                .Where(payment => payment.Property.UserProfileId == userId)
                .ToList();
        }

        public List<Payment> GetByPropertyId(int propertyId)
        {
            return _context.Payment
                .Include(payment => payment.Tenant)
                .OrderByDescending(payment => payment.Date)
                .Where(payment => payment.PropertyId == propertyId)
                .ToList();
        }

        public List<Payment> GetByTenantId(int tenantId)
        {
            return _context.Payment
                .Include(payment => payment.Tenant)
                .OrderByDescending(payment => payment.Date)
                .Where(payment => payment.TenantId == tenantId)
                .ToList();
        }

        public List<Payment> GetByMonth(DateTime date)
        {
            int dateMonth = date.Month;
            int dateYear = date.Year;
            return _context.Payment
                .Include(payment => payment.Tenant)
                .OrderByDescending(payment => payment.Date)
                .Where(payment => payment.Date.Month == dateMonth && payment.Date.Year == dateYear)
                .ToList();
        }

        public List<Payment> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.Payment
                .Include(payment => payment.Tenant)
                .OrderByDescending(payment => payment.Date)
                .Where(payment => payment.Date > startDate && payment.Date < endDate)
                .ToList();
        }

        public void Update(Payment payment)
        {
            var local = _context.Set<Payment>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(payment.Id));

            //check if local is null
            if (local != null)
            {
                //  detach
                _context.Entry(local).State = EntityState.Detached;
            }

            _context.Entry(payment).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var payment = GetById(id);
            _context.Payment.Remove(payment);
            _context.SaveChanges();
        }

        public void Add(Payment payment)
        {
            _context.Add(payment);
            _context.SaveChanges();
        }
    }
}

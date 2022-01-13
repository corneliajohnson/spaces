using Spaces.Models;
using System;
using System.Collections.Generic;

namespace Spaces.Repositories
{
    public interface IPaymentRepository
    {
        void Add(Payment payment);
        void Delete(int id);
        List<Payment> GetByDateRange(DateTime startDate, DateTime endDate);
        Payment GetById(int id);
        List<Payment> GetByMonth(DateTime date);
        List<Payment> GetByPropertyId(int propertyId);
        List<Payment> GetByTenantId(int tenantId);
        List<Payment> GetByUserId(int userId);
        void Update(Payment payment);
    }
}
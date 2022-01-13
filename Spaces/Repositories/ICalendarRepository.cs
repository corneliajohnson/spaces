using Spaces.Models;
using System;
using System.Collections.Generic;

namespace Spaces.Repositories
{
    public interface ICalendarRepository
    {
        void Add(CalendarRepository calendar);
        void Delete(int id);
        List<Calendar> GetByDate(DateTime date);
        Calendar GetById(int id);
        List<Calendar> GetByPropertyId(int propertyId);
        List<Calendar> GetByTenantId(int tentantId);
        List<Calendar> GetByUserId(int userId);
        void Update(Calendar calendar);
    }
}
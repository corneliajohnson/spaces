using Microsoft.EntityFrameworkCore;
using Spaces.Data;
using Spaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Spaces.Repositories
{
    public class CalendarRepository : ICalendarRepository
    {
        private readonly ApplicationDbContext _context;

        public CalendarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Calendar GetById(int id)
        {
            return _context.Calendar
                .Include(calendar => calendar.Tenant)
                .Include(calendar => calendar.Property)
                .FirstOrDefault(calendar => calendar.Id == id);
        }
        public List<Calendar> GetByTenantId(int tentantId)
        {
            return _context.Calendar
                .Include(calendar => calendar.Tenant)
                .Include(calendar => calendar.Property)
                .FirstOrDefault(calendar => calendar.TenantId == tentantId)
                .ToList();
        }

        public List<Calendar> GetByPropertyId(int propertyId)
        {
            return _context.Calendar
                .Include(calendar => calendar.Tenant)
                .Include(calendar => calendar.Property)
                .FirstOrDefault(calendar => calendar.PropertyId == propertyId)
                .ToList();
        }

        public List<Calendar> GetByUserId(int userId)
        {
            return _context.Calendar
                .Include(calendar => calendar.Tenant)
                .Include(calendar => calendar.Property)
                .FirstOrDefault(calendar => calendar.Property.UserProfileId == userId)
                .ToList();
        }

        public List<Calendar> GetByDate(DateTime date)
        {
            DateTime day = date.Date;

            return _context.Calendar
                .Include(calendar => calendar.Tenant)
                .Include(calendar => calendar.Property)
                .FirstOrDefault(calendar => calendar.Date.Date == day)
                .ToList();
        }

        public void Delete(int id)
        {
            var calendar = GetById(id);
            _context.Calendar.Remove(calendar);
            _context.SaveChanges();
        }

        public void Add(Calendar calendar)
        {
            _context.Add(calendar);
            _context.SaveChanges();
        }

        public void Update(Calendar calendar)
        {
            var local = _context.Set<Calendar>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(calendar.Id));

            //check if local is null
            if (local != null)
            {
                //  detach
                _context.Entry(local).State = EntityState.Detached;
            }

            _context.Entry(calendar).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

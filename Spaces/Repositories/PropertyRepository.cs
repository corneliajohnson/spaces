using Microsoft.EntityFrameworkCore;
using Spaces.Data;
using Spaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Spaces.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _context;

        public PropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Property GetById(int id)
        {
            return _context.Property
               // .Include(property => property.Tenant)
               // .Include(property => property.Calendars)
                //.Include(property => property.Payments.OrderBy(property => property.Date))
                //.Include(property => property.Requests.OrderBy(property => property.DateAdded))
                .FirstOrDefault(property => property.Id == id);
        }

        public List<Property> GetByUserId(int userId)
        {
            return _context.Property
                //.Include(property => property.Tenant)
                //.Include(property => property.Calendars)
                //.Include(property => property.Payments.OrderBy(property => property.Date))
                //.Include(property => property.Requests.OrderBy(property => property.DateAdded))
                .Where(property => property.Id == userId)
                .ToList();
        }

        public void Add(Property property)
        {
            _context.Add(property);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var property = GetById(id);
            _context.Property.Remove(property);
            _context.SaveChanges();
        }

        public void Update(Property property)
        {
            var local = _context.Set<Property>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(property.Id));

            //check if local is null
            if (local != null)
            {
                //  detach
                _context.Entry(local).State = EntityState.Detached;
            }

            _context.Entry(property).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

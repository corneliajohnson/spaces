using Microsoft.EntityFrameworkCore;
using Spaces.Data;
using Spaces.Models;
using System.Collections.Generic;
using System.Linq;

namespace Spaces.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Request GetById(int id)
        {
            return _context.Request
                .Include(request => request.Property)
                .FirstOrDefault(request => request.Id == id);
        }
        public void Delete(int id)
        {
            var request = GetById(id);
            _context.Request.Remove(request);
            _context.SaveChanges();
        }

        public void Add(Request request)
        {
            _context.Add(request);
            _context.SaveChanges();
        }

        public void Update(Request request)
        {
            var local = _context.Set<Request>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(request.Id));

            //check if local is null
            if (local != null)
            {
                //  detach
                _context.Entry(local).State = EntityState.Detached;
            }

            _context.Entry(request).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Request> GetByUserId(int userId)
        {
            return _context.Request
                .Include(request => request.Property)
                .FirstOrDefault(request => request.Property.UserProfileId == userId)
                .ToList();
        }

        public List<Request> GetByPropertyId(int propertyId)
        {
            return _context.Request
                .Include(request => request.Property)
                .FirstOrDefault(request => request.PropertyId == propertyId)
                .ToList();
        }
    }
}

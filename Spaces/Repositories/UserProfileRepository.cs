using System.Linq;
using System.Collections.Generic;
using Spaces.Models;
using Spaces.Data;
using Spaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Spaces.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserProfile> GetAll()
        {
            return _context.UserProfile.ToList();
        }

        public UserProfile GetById(int id)
        {
            return _context.UserProfile.FirstOrDefault(p => p.Id == id);
        }

        public void Add(UserProfile userProfile)
        {
            _context.Add(userProfile);
            _context.SaveChanges();
        }

        public void Update(UserProfile userProfile)
        {
            var local = _context.Set<Tenant>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(userProfile.Id));

            //check if local is null
            if (local != null)
            {
                //  detach
                _context.Entry(local).State = EntityState.Detached;
            }

            _context.Entry(userProfile).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

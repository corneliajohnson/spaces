using System.Linq;
using System.Collections.Generic;
using Spaces.Models;
using Spaces.Data;
using Spaces.Repository;

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
    }
}

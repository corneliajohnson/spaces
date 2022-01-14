using Spaces.Models;
using System.Collections.Generic;

namespace Spaces.Repository
{
    public interface IUserProfileRepository
    {
        List<UserProfile> GetAll();
        UserProfile GetById(int id);
        void Update(UserProfile userProfile);
        void Add(UserProfile userProfile);
    }
}
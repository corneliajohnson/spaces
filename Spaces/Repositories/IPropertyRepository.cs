using Spaces.Models;
using System.Collections.Generic;

namespace Spaces.Repositories
{
    public interface IPropertyRepository
    {
        void Add(Property property);
        void Delete(int id);
        Property GetById(int id);
        List<Property> GetByUserId(int userId);
        void Update(Property property);
    }
}
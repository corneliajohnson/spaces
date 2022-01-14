using Spaces.Models;
using System.Collections.Generic;

namespace Spaces.Repositories
{
    public interface IRequestRepository
    {
        void Add(Request request);
        void Delete(int id);
        Request GetById(int id);
        List<Request> GetByPropertyId(int propertyId);
        List<Request> GetByUserId(int userId);
        void Update(Request request);
    }
}
using Spaces.Models;

namespace Spaces.Repositories
{
    public interface ITenantRepository
    {
        void Add(Tenant tenant);
        void Delete(int id);
        Tenant GetById(int id);
        void Update(Tenant tenant);
    }
}
using Microsoft.EntityFrameworkCore;
using Spaces.Data;
using Spaces.Models;
using System.Linq;

namespace Spaces.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly ApplicationDbContext _context;

        public TenantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Tenant GetById(int id)
        {
            return _context.Tenant
                .FirstOrDefault(tenant => tenant.Id == id);
        }
        public void Delete(int id)
        {
            var tenant = GetById(id);
            _context.Tenant.Remove(tenant);
            _context.SaveChanges();
        }

        public void Add(Tenant tenant)
        {
            _context.Add(tenant);
            _context.SaveChanges();
        }

        public void Update(Tenant tenant)
        {
            var local = _context.Set<Tenant>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(tenant.Id));

            //check if local is null
            if (local != null)
            {
                //  detach
                _context.Entry(local).State = EntityState.Detached;
            }

            _context.Entry(tenant).State = EntityState.Modified;
            _context.SaveChanges();
        }


    }
}

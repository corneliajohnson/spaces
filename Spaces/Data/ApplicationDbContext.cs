using Spaces.Models;
using Microsoft.EntityFrameworkCore;

namespace Spaces.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<Calendar> Calendar { get; set; }
    }
}
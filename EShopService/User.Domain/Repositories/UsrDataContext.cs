using Microsoft.EntityFrameworkCore;
using User.Domain.Models.Entities;

namespace User.Domain.Repositories
{
    public class UsrDataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public UsrDataContext(DbContextOptions<UsrDataContext> options) : base(options) { }

        public DbSet<User.Domain.Models.Entities.User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}

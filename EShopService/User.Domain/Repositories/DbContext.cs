using Microsoft.EntityFrameworkCore;
using User.Domain.Models.Entities;

namespace EShop.Domain.Repositories
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options) { }

        public DbSet<User.Domain.Models.Entities.User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}

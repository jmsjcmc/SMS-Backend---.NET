using Microsoft.EntityFrameworkCore;
using SMS_backend.Models.Entities;

namespace SMS_backend
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}

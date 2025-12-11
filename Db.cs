using Microsoft.EntityFrameworkCore;
using SMS_backend.Models;
using SMS_backend.Utils;

namespace SMS_backend
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentLog> DepartmentLogs { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PositionLog> PositionLogs { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserRoleLog> UserRoleLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Db).Assembly);
            modelBuilder.Seed();
        }
    }
}

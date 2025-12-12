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
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleLog> RoleLogs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorLog> AuthorLogs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookLog> BookLogs { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<PublisherLog> PublisherLogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryLog> CategoryLogs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLog> ProductLogs { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Db).Assembly);
            modelBuilder.Seed();
        }
    }
}

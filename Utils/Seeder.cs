using Microsoft.EntityFrameworkCore;
using SMS_backend.Models;

namespace SMS_backend.Utils
{
    public static class Seeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Department>()
                .HasData(
                new Department
                {
                    ID = 1,
                    Name = "Management",
                    RecordStatus = RecordStatus.Active,
                },
                new Department
                {
                    ID = 2,
                    Name = "Research & Community Extension",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    ID = 3,
                    Name = "School Chaplain",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    ID = 4,
                    Name = "Human Resource Department",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    ID = 5,
                    Name = "Admission",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    ID = 6,
                    Name = "Academic Department",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    ID = 7,
                    Name = "Technical/Vocational (TechVoc) Program",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    ID = 8,
                    Name = "Guidance & Counseling",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    ID = 9,
                    Name = "Learning Resource Center (LRC)",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    ID = 10,
                    Name = "Student Affairs & Services Office (OSA)",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    ID = 11,
                    Name = "Pre-School / Elementary / Junior High School",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    ID = 12,
                    Name = "Preschool",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    ID = 13,
                    Name = "Elementary",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    ID = 14,
                    Name = "Junior High School (JHS)",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    ID = 15,
                    Name = "Senior High School (SHS)",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    ID = 16,
                    Name = "Grade 11",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    ID = 17,
                    Name = "Grade 12",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    ID = 18,
                    Name = "Administration Department",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    ID = 19,
                    Name = "ICT / Admin Officer",
                    RecordStatus = RecordStatus.Active
                });
            modelBuilder
                .Entity<Position>()
                .HasData(
                new Position
                {
                    ID = 1,
                    Name = "School Director",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 1
                },
                new Position
                {
                    ID = 2,
                    Name = "Head",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 2
                },
                new Position
                {
                    ID = 3,
                    Name = "Chaplain",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 3
                },
                new Position
                {
                    ID = 4,
                    Name = "HR Dept Head",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 4
                },
                new Position
                {
                    ID = 5,
                    Name = "Admission & External Relations Officer",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 5
                },
                new Position
                {
                    ID = 6,
                    Name = "Registrar",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 6
                },
                new Position
                {
                    ID = 7,
                    Name = "TechVoc Program Head",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 7
                },
                new Position
                {
                    ID = 8,
                    Name = "Guidance & Counseling Center Head",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 8
                },
                new Position
                {
                    ID = 9,
                    Name = "Head",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 9
                },
                new Position
                {
                    ID = 10,
                    Name = "Head",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 10
                },
                new Position
                {
                    ID = 11,
                    Name = "Academic Head, Pre-School / JHS",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 11
                },
                new Position
                {
                    ID = 12,
                    Name = "Preschool Coordinator",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 12
                },
                new Position
                {
                    ID = 13,
                    Name = "Elementary Coordinator",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 13
                },
                new Position
                {
                    ID = 14,
                    Name = "JHS Coordinator",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 14
                },
                new Position
                {
                    ID = 15,
                    Name = "SHS Principal",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 15
                },
                new Position
                {
                    ID = 16,
                    Name = "Grade 11 Coordinator",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 16
                },
                new Position
                {
                    ID = 17,
                    Name = "Grade 12 Coordinator",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 17
                },
                new Position
                {
                    ID = 18,
                    Name = "Administration Dept Head",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 18
                },
                new Position
                {
                    ID = 19,
                    Name = "ICT Admin Officer",
                    RecordStatus = RecordStatus.Active,
                    DepartmentID = 19
                });
        }
        public static async Task SeedSuperAdminAsync(IServiceProvider service)
        {

            var context = service.GetRequiredService<Db>();
            if (!context.Users.Any(U => U.ID == 1))
            {
                var admin = new User
                {
                    ID = 1,
                    FirstName = "Super",
                    LastName = "Admin",
                    Username = "000000",
                    Password = BCrypt.Net.BCrypt.HashPassword("@temp123"),
                    RecordStatus = RecordStatus.Active
                };
                context.Users.Add(admin);
                await context.SaveChangesAsync();
            }
        }
    }
}

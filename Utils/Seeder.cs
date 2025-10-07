using Microsoft.EntityFrameworkCore;
using SMS_backend.Models;
using SMS_backend.Models.Entities;

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
                    Id = 1,
                    Name = "Management",
                    RecordStatus = RecordStatus.Active,
                    DateCreated = DateTimeHelper.GetPhilippineStandardTime(),
                },
                new Department
                {
                    Id = 2,
                    Name = "Research & Community Extension",
                    RecordStatus = RecordStatus.Active,
                    DateCreated = DateTimeHelper.GetPhilippineStandardTime()
                },
                new Department
                {
                    Id = 3,
                    Name = "School Chaplain",
                    RecordStatus = RecordStatus.Active,
                    DateCreated = DateTimeHelper.GetPhilippineStandardTime()
                },
                new Department
                {
                    Id = 4,
                    Name = "Human Resource Department",
                    RecordStatus = RecordStatus.Active,
                    DateCreated = DateTimeHelper.GetPhilippineStandardTime()
                },
                new Department
                {
                    Id = 5,
                    Name = "Admission",
                    RecordStatus = RecordStatus.Active,
                    DateCreated = DateTimeHelper.GetPhilippineStandardTime()
                },
                new Department
                {
                    Id = 6,
                    Name = "Academic Department",
                    RecordStatus = RecordStatus.Active,
                    DateCreated = DateTimeHelper.GetPhilippineStandardTime()
                },
                new Department
                {
                    Id = 7,
                    Name = "Technical/Vocational (TechVoc) Program",
                    RecordStatus = RecordStatus.Active,
                    DateCreated = DateTimeHelper.GetPhilippineStandardTime()
                },
                new Department
                {
                    Id = 8,
                    Name = "Guidance & Counseling",
                    RecordStatus = RecordStatus.Active,
                    DateCreated = DateTimeHelper.GetPhilippineStandardTime()
                },
                new Department
                {
                    Id = 9,
                    Name = "Learning Resource Center (LRC)",
                    RecordStatus = RecordStatus.Active,
                    DateCreated = DateTimeHelper.GetPhilippineStandardTime()
                },
                new Department
                {
                    Id = 10,
                    Name = "Student Affairs & Services Office (OSA)",
                    RecordStatus = RecordStatus.Active,
                    DateCreated = DateTimeHelper.GetPhilippineStandardTime()
                },
                new Department
                {
                    Id = 11,
                    Name = "Pre-School / Elementary / Junior High School",
                    RecordStatus = RecordStatus.Active,
                    DateCreated = DateTimeHelper.GetPhilippineStandardTime()
                });
        }
    }
}

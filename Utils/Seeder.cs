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
                },
                new Department
                {
                    Id = 2,
                    Name = "Research & Community Extension",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    Id = 3,
                    Name = "School Chaplain",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    Id = 4,
                    Name = "Human Resource Department",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    Id = 5,
                    Name = "Admission",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    Id = 6,
                    Name = "Academic Department",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    Id = 7,
                    Name = "Technical/Vocational (TechVoc) Program",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    Id = 8,
                    Name = "Guidance & Counseling",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    Id = 9,
                    Name = "Learning Resource Center (LRC)",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    Id = 10,
                    Name = "Student Affairs & Services Office (OSA)",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    Id = 11,
                    Name = "Pre-School / Elementary / Junior High School",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    Id = 12,
                    Name = "Preschool",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    Id = 13,
                    Name = "Elementary",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    Id = 14,
                    Name = "Junior High School (JHS)",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    Id = 15,
                    Name = "Senior High School (SHS)",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    Id = 16,
                    Name = "Grade 11",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    Id = 17,
                    Name = "Grade 12",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    Id = 18,
                    Name = "Administration Department",
                    RecordStatus = RecordStatus.Active
                },
                new Department
                {
                    Id = 19,
                    Name = "ICT / Admin Officer",
                    RecordStatus = RecordStatus.Active
                });
            modelBuilder
                .Entity<Position>()
                .HasData(
                new Position
                {
                    Id = 1,
                    Name = "School Director",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 1
                },
                new Position
                {
                    Id = 2,
                    Name = "Head",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 2
                },
                new Position
                {
                    Id = 3,
                    Name = "Chaplain",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 3
                },
                new Position
                {
                    Id = 4,
                    Name = "HR Dept Head",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 4
                },
                new Position
                {
                    Id = 5,
                    Name = "Admission & External Relations Officer",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 5
                },
                new Position
                {
                    Id = 6,
                    Name = "Registrar",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 6
                },
                new Position
                {
                    Id = 7,
                    Name = "TechVoc Program Head",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 7
                },
                new Position
                {
                    Id = 8,
                    Name = "Guidance & Counseling Center Head",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 8
                },
                new Position
                {
                    Id = 9,
                    Name = "Head",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 9
                },
                new Position
                {
                    Id = 10,
                    Name = "Head",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 10
                },
                new Position
                {
                    Id = 11,
                    Name = "Academic Head, Pre-School / JHS",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 11
                },
                new Position
                {
                    Id = 12,
                    Name = "Preschool Coordinator",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 12
                },
                new Position
                {
                    Id = 13,
                    Name = "Elementary Coordinator",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 13
                },
                new Position
                {
                    Id = 14,
                    Name = "JHS Coordinator",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 14
                },
                new Position
                {
                    Id = 15,
                    Name = "SHS Principal",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 15
                },
                new Position
                {
                    Id = 16,
                    Name = "Grade 11 Coordinator",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 16
                },
                new Position
                {
                    Id = 17,
                    Name = "Grade 12 Coordinator",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 17
                },
                new Position
                {
                    Id = 18,
                    Name = "Administration Dept Head",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 18
                },
                new Position
                {
                    Id = 19,
                    Name = "ICT Admin Officer",
                    RecordStatus = RecordStatus.Active,
                    DepartmentId = 19
                });
        }
    }
}

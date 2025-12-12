using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SMS_backend.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Departments_Users_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Roles_Users_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UserLogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserLogs_Users_UpdaterID",
                        column: x => x.UpdaterID,
                        principalTable: "Users",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UserLogs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DepartmentLogs_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DepartmentLogs_Users_UpdaterID",
                        column: x => x.UpdaterID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Positions_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Positions_Users_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RoleLogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoleLogs_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RoleLogs_Users_UpdaterID",
                        column: x => x.UpdaterID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    AssignerID = table.Column<int>(type: "int", nullable: true),
                    AssignedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_AssignerID",
                        column: x => x.AssignerID,
                        principalTable: "Users",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PositionLogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PositionLogs_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PositionLogs_Users_UpdaterID",
                        column: x => x.UpdaterID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UserRoleLogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRoleLogs_UserRoles_UserRoleID",
                        column: x => x.UserRoleID,
                        principalTable: "UserRoles",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UserRoleLogs_Users_UpdaterID",
                        column: x => x.UpdaterID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "ID", "CreatedOn", "CreatorID", "Description", "Name", "RecordStatus" },
                values: new object[,]
                {
                    { 1, null, null, null, "Management", 1 },
                    { 2, null, null, null, "Research & Community Extension", 1 },
                    { 3, null, null, null, "School Chaplain", 1 },
                    { 4, null, null, null, "Human Resource Department", 1 },
                    { 5, null, null, null, "Admission", 1 },
                    { 6, null, null, null, "Academic Department", 1 },
                    { 7, null, null, null, "Technical/Vocational (TechVoc) Program", 1 },
                    { 8, null, null, null, "Guidance & Counseling", 1 },
                    { 9, null, null, null, "Learning Resource Center (LRC)", 1 },
                    { 10, null, null, null, "Student Affairs & Services Office (OSA)", 1 },
                    { 11, null, null, null, "Pre-School / Elementary / Junior High School", 1 },
                    { 12, null, null, null, "Preschool", 1 },
                    { 13, null, null, null, "Elementary", 1 },
                    { 14, null, null, null, "Junior High School (JHS)", 1 },
                    { 15, null, null, null, "Senior High School (SHS)", 1 },
                    { 16, null, null, null, "Grade 11", 1 },
                    { 17, null, null, null, "Grade 12", 1 },
                    { 18, null, null, null, "Administration Department", 1 },
                    { 19, null, null, null, "ICT / Admin Officer", 1 }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "ID", "CreatedOn", "CreatorID", "DepartmentID", "Description", "Name", "RecordStatus" },
                values: new object[,]
                {
                    { 1, null, null, 1, null, "School Director", 1 },
                    { 2, null, null, 2, null, "Head", 1 },
                    { 3, null, null, 3, null, "Chaplain", 1 },
                    { 4, null, null, 4, null, "HR Dept Head", 1 },
                    { 5, null, null, 5, null, "Admission & External Relations Officer", 1 },
                    { 6, null, null, 6, null, "Registrar", 1 },
                    { 7, null, null, 7, null, "TechVoc Program Head", 1 },
                    { 8, null, null, 8, null, "Guidance & Counseling Center Head", 1 },
                    { 9, null, null, 9, null, "Head", 1 },
                    { 10, null, null, 10, null, "Head", 1 },
                    { 11, null, null, 11, null, "Academic Head, Pre-School / JHS", 1 },
                    { 12, null, null, 12, null, "Preschool Coordinator", 1 },
                    { 13, null, null, 13, null, "Elementary Coordinator", 1 },
                    { 14, null, null, 14, null, "JHS Coordinator", 1 },
                    { 15, null, null, 15, null, "SHS Principal", 1 },
                    { 16, null, null, 16, null, "Grade 11 Coordinator", 1 },
                    { 17, null, null, 17, null, "Grade 12 Coordinator", 1 },
                    { 18, null, null, 18, null, "Administration Dept Head", 1 },
                    { 19, null, null, 19, null, "ICT Admin Officer", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLogs_DepartmentID",
                table: "DepartmentLogs",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLogs_UpdaterID",
                table: "DepartmentLogs",
                column: "UpdaterID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatorID",
                table: "Departments",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_PositionLogs_PositionID",
                table: "PositionLogs",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_PositionLogs_UpdaterID",
                table: "PositionLogs",
                column: "UpdaterID");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_CreatorID",
                table: "Positions",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DepartmentID",
                table: "Positions",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleLogs_RoleID",
                table: "RoleLogs",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleLogs_UpdaterID",
                table: "RoleLogs",
                column: "UpdaterID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatorID",
                table: "Roles",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogs_UpdaterID",
                table: "UserLogs",
                column: "UpdaterID");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogs_UserID",
                table: "UserLogs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleLogs_UpdaterID",
                table: "UserRoleLogs",
                column: "UpdaterID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleLogs_UserRoleID",
                table: "UserRoleLogs",
                column: "UserRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_AssignerID",
                table: "UserRoles",
                column: "AssignerID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleID",
                table: "UserRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserID",
                table: "UserRoles",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentLogs");

            migrationBuilder.DropTable(
                name: "PositionLogs");

            migrationBuilder.DropTable(
                name: "RoleLogs");

            migrationBuilder.DropTable(
                name: "UserLogs");

            migrationBuilder.DropTable(
                name: "UserRoleLogs");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

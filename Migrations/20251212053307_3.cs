using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS_backend.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorID",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CreatorID",
                table: "Books",
                column: "CreatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_CreatorID",
                table: "Books",
                column: "CreatorID",
                principalTable: "Users",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_CreatorID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CreatorID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CreatorID",
                table: "Books");
        }
    }
}

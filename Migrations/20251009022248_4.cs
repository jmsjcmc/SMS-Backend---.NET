using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS_backend.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_PositionId",
                table: "User",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Position_PositionId",
                table: "User",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Position_PositionId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_PositionId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "User");
        }
    }
}

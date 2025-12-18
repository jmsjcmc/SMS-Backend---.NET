using System;
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
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Categories_Users_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JwtID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryLogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategoryLogs_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CategoryLogs_Users_UpdaterID",
                        column: x => x.UpdaterID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Products_Users_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProductInventories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    DateInventory = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductInventoryStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductInventories_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProductInventories_Users_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProductLogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductLogs_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProductLogs_Users_UpdaterID",
                        column: x => x.UpdaterID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DailyConsumptions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductInventoryID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    BuyerID = table.Column<int>(type: "int", nullable: true),
                    BuyOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApproverID = table.Column<int>(type: "int", nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductConsumptionStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyConsumptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DailyConsumptions_ProductInventories_ProductInventoryID",
                        column: x => x.ProductInventoryID,
                        principalTable: "ProductInventories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DailyConsumptions_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DailyConsumptions_Users_ApproverID",
                        column: x => x.ApproverID,
                        principalTable: "Users",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DailyConsumptions_Users_BuyerID",
                        column: x => x.BuyerID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProductInventoryLogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductInventoryID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventoryLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductInventoryLogs_ProductInventories_ProductInventoryID",
                        column: x => x.ProductInventoryID,
                        principalTable: "ProductInventories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProductInventoryLogs_Users_UpdaterID",
                        column: x => x.UpdaterID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DailyConsumptionLogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyConsumptionID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyConsumptionLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DailyConsumptionLogs_DailyConsumptions_DailyConsumptionID",
                        column: x => x.DailyConsumptionID,
                        principalTable: "DailyConsumptions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DailyConsumptionLogs_Users_UpdaterID",
                        column: x => x.UpdaterID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatorID",
                table: "Categories",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLogs_CategoryID",
                table: "CategoryLogs",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLogs_UpdaterID",
                table: "CategoryLogs",
                column: "UpdaterID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyConsumptionLogs_DailyConsumptionID",
                table: "DailyConsumptionLogs",
                column: "DailyConsumptionID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyConsumptionLogs_UpdaterID",
                table: "DailyConsumptionLogs",
                column: "UpdaterID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyConsumptions_ApproverID",
                table: "DailyConsumptions",
                column: "ApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyConsumptions_BuyerID",
                table: "DailyConsumptions",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyConsumptions_ProductID",
                table: "DailyConsumptions",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyConsumptions_ProductInventoryID",
                table: "DailyConsumptions",
                column: "ProductInventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventories_CreatorID",
                table: "ProductInventories",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventories_ProductID",
                table: "ProductInventories",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventoryLogs_ProductInventoryID",
                table: "ProductInventoryLogs",
                column: "ProductInventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventoryLogs_UpdaterID",
                table: "ProductInventoryLogs",
                column: "UpdaterID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLogs_ProductID",
                table: "ProductLogs",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLogs_UpdaterID",
                table: "ProductLogs",
                column: "UpdaterID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatorID",
                table: "Products",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserID",
                table: "RefreshTokens",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryLogs");

            migrationBuilder.DropTable(
                name: "DailyConsumptionLogs");

            migrationBuilder.DropTable(
                name: "ProductInventoryLogs");

            migrationBuilder.DropTable(
                name: "ProductLogs");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "DailyConsumptions");

            migrationBuilder.DropTable(
                name: "ProductInventories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

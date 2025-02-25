using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillShare.Migrations
{
    /// <inheritdoc />
    public partial class PremiumAndAddOn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddOn",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddOn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PremiumProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremiumProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PremiumProfile_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddOn",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddOnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddOn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddOn_AddOn_AddOnId",
                        column: x => x.AddOnId,
                        principalTable: "AddOn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAddOn_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PremiumProfile_UserId",
                table: "PremiumProfile",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddOn_AddOnId",
                table: "UserAddOn",
                column: "AddOnId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddOn_UserId",
                table: "UserAddOn",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PremiumProfile");

            migrationBuilder.DropTable(
                name: "UserAddOn");

            migrationBuilder.DropTable(
                name: "AddOn");
        }
    }
}

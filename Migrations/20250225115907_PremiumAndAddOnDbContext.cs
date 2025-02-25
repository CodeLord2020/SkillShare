using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillShare.Migrations
{
    /// <inheritdoc />
    public partial class PremiumAndAddOnDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PremiumProfile_AspNetUsers_UserId",
                table: "PremiumProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddOn_AddOn_AddOnId",
                table: "UserAddOn");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddOn_AspNetUsers_UserId",
                table: "UserAddOn");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddOn",
                table: "UserAddOn");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PremiumProfile",
                table: "PremiumProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddOn",
                table: "AddOn");

            migrationBuilder.RenameTable(
                name: "UserAddOn",
                newName: "UserAddOns");

            migrationBuilder.RenameTable(
                name: "PremiumProfile",
                newName: "PremiumProfiles");

            migrationBuilder.RenameTable(
                name: "AddOn",
                newName: "AddOns");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddOn_UserId",
                table: "UserAddOns",
                newName: "IX_UserAddOns_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddOn_AddOnId",
                table: "UserAddOns",
                newName: "IX_UserAddOns_AddOnId");

            migrationBuilder.RenameIndex(
                name: "IX_PremiumProfile_UserId",
                table: "PremiumProfiles",
                newName: "IX_PremiumProfiles_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddOns",
                table: "UserAddOns",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PremiumProfiles",
                table: "PremiumProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddOns",
                table: "AddOns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PremiumProfiles_AspNetUsers_UserId",
                table: "PremiumProfiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddOns_AddOns_AddOnId",
                table: "UserAddOns",
                column: "AddOnId",
                principalTable: "AddOns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddOns_AspNetUsers_UserId",
                table: "UserAddOns",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PremiumProfiles_AspNetUsers_UserId",
                table: "PremiumProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddOns_AddOns_AddOnId",
                table: "UserAddOns");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddOns_AspNetUsers_UserId",
                table: "UserAddOns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddOns",
                table: "UserAddOns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PremiumProfiles",
                table: "PremiumProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddOns",
                table: "AddOns");

            migrationBuilder.RenameTable(
                name: "UserAddOns",
                newName: "UserAddOn");

            migrationBuilder.RenameTable(
                name: "PremiumProfiles",
                newName: "PremiumProfile");

            migrationBuilder.RenameTable(
                name: "AddOns",
                newName: "AddOn");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddOns_UserId",
                table: "UserAddOn",
                newName: "IX_UserAddOn_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddOns_AddOnId",
                table: "UserAddOn",
                newName: "IX_UserAddOn_AddOnId");

            migrationBuilder.RenameIndex(
                name: "IX_PremiumProfiles_UserId",
                table: "PremiumProfile",
                newName: "IX_PremiumProfile_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddOn",
                table: "UserAddOn",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PremiumProfile",
                table: "PremiumProfile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddOn",
                table: "AddOn",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PremiumProfile_AspNetUsers_UserId",
                table: "PremiumProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddOn_AddOn_AddOnId",
                table: "UserAddOn",
                column: "AddOnId",
                principalTable: "AddOn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddOn_AspNetUsers_UserId",
                table: "UserAddOn",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OwnerId",
                table: "ServiceLayers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "ServiceLayers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OwnerId",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceLayers_OwnerId",
                table: "ServiceLayers",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceLayers_UserId1",
                table: "ServiceLayers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OwnerId",
                table: "Products",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId1",
                table: "Products",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_OwnerId",
                table: "Products",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId1",
                table: "Products",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceLayers_Users_OwnerId",
                table: "ServiceLayers",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceLayers_Users_UserId1",
                table: "ServiceLayers",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_OwnerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId1",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceLayers_Users_OwnerId",
                table: "ServiceLayers");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceLayers_Users_UserId1",
                table: "ServiceLayers");

            migrationBuilder.DropIndex(
                name: "IX_ServiceLayers_OwnerId",
                table: "ServiceLayers");

            migrationBuilder.DropIndex(
                name: "IX_ServiceLayers_UserId1",
                table: "ServiceLayers");

            migrationBuilder.DropIndex(
                name: "IX_Products_OwnerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ServiceLayers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ServiceLayers");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Products");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenametableServiceLayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceAuctions_Services_ServiceId",
                table: "ServiceAuctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_UserId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "ServiceLayers");

            migrationBuilder.RenameIndex(
                name: "IX_Services_UserId",
                table: "ServiceLayers",
                newName: "IX_ServiceLayers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceLayers",
                table: "ServiceLayers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceAuctions_ServiceLayers_ServiceId",
                table: "ServiceAuctions",
                column: "ServiceId",
                principalTable: "ServiceLayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceLayers_Users_UserId",
                table: "ServiceLayers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceAuctions_ServiceLayers_ServiceId",
                table: "ServiceAuctions");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceLayers_Users_UserId",
                table: "ServiceLayers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceLayers",
                table: "ServiceLayers");

            migrationBuilder.RenameTable(
                name: "ServiceLayers",
                newName: "Services");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceLayers_UserId",
                table: "Services",
                newName: "IX_Services_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceAuctions_Services_ServiceId",
                table: "ServiceAuctions",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_UserId",
                table: "Services",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

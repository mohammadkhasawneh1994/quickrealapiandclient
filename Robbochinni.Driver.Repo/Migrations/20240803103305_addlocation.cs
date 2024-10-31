using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Robbochinni.Driver.Repo.Migrations
{
    /// <inheritdoc />
    public partial class addlocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FromId",
                table: "Requests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ToId",
                table: "Requests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_FromId",
                table: "Requests",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ToId",
                table: "Requests",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Location_FromId",
                table: "Requests",
                column: "FromId",
                principalTable: "Location",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Location_ToId",
                table: "Requests",
                column: "ToId",
                principalTable: "Location",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Location_FromId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Location_ToId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Requests_FromId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ToId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "FromId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ToId",
                table: "Requests");
        }
    }
}

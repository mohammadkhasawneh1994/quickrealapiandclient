using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Robbochinni.Driver.Repo.Migrations
{
    /// <inheritdoc />
    public partial class AddCarState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AvaialableInId",
                table: "Car",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RideType",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_AvaialableInId",
                table: "Car",
                column: "AvaialableInId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Location_AvaialableInId",
                table: "Car",
                column: "AvaialableInId",
                principalTable: "Location",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Location_AvaialableInId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_AvaialableInId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "AvaialableInId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "RideType",
                table: "Car");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Robbochinni.Driver.Repo.Migrations
{
    /// <inheritdoc />
    public partial class EditTrips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Requests_RequestId",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Trips_RequestId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "Trips",
                newName: "RequesterId");

            migrationBuilder.AddColumn<Guid>(
                name: "FromId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ToId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_FromId",
                table: "Trips",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_RequesterId",
                table: "Trips",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ToId",
                table: "Trips",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Location_FromId",
                table: "Trips",
                column: "FromId",
                principalTable: "Location",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Location_ToId",
                table: "Trips",
                column: "ToId",
                principalTable: "Location",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Users_RequesterId",
                table: "Trips",
                column: "RequesterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Location_FromId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Location_ToId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Users_RequesterId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_FromId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_RequesterId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_ToId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "FromId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ToId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "RequesterId",
                table: "Trips",
                newName: "RequestId");

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RequesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Location_FromId",
                        column: x => x.FromId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_Location_ToId",
                        column: x => x.ToId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_Users_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_RequestId",
                table: "Trips",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_FromId",
                table: "Requests",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequesterId",
                table: "Requests",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ToId",
                table: "Requests",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Requests_RequestId",
                table: "Trips",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

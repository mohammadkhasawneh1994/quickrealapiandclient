using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Robbochinni.Driver.Repo.Migrations
{
    /// <inheritdoc />
    public partial class addlocationwithpresicion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Location",
                type: "decimal(18,16)",
                precision: 18,
                scale: 16,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Location",
                type: "decimal(18,16)",
                precision: 18,
                scale: 16,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Location",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,16)",
                oldPrecision: 18,
                oldScale: 16);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Location",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,16)",
                oldPrecision: 18,
                oldScale: 16);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BemCase.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class healthCheckUrlUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "HealthCheckUrls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "HealthCheckUrls",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "HealthCheckUrls");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "HealthCheckUrls");
        }
    }
}

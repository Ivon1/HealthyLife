using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyLife.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSaleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Sale",
                table: "Courses",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sale",
                table: "Courses");            
        }
    }
}

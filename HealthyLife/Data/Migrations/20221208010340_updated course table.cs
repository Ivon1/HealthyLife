using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyLife.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedcoursetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Course");
        }
    }
}

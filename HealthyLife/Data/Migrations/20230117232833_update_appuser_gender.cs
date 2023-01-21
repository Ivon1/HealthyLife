using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyLife.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateappusergender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genger",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genger",
                table: "AspNetUsers");
        }
    }
}

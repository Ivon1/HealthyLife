using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyLife.Data.Migrations
{
    /// <inheritdoc />
    public partial class BaseUserWishMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NickNameUser2",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PathToPhoto2",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserWishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWishes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWishes_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserWishes_CourseId",
                table: "UserWishes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWishes_UserId",
                table: "UserWishes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserWishes");

            migrationBuilder.DropColumn(
                name: "NickNameUser2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PathToPhoto2",
                table: "AspNetUsers");
        }
    }
}

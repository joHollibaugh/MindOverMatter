using Microsoft.EntityFrameworkCore.Migrations;

namespace MindOverMatter.Migrations
{
    public partial class Change_Field_to_VarChar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Ratings",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Ratings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

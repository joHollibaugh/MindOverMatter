using Microsoft.EntityFrameworkCore.Migrations;

namespace MindOverMatter.Migrations
{
    public partial class FinishedMatterObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Parent",
                table: "Chain",
                newName: "Side");

            migrationBuilder.AddColumn<int>(
                name: "BranchCount",
                table: "Nodes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchCount",
                table: "Nodes");

            migrationBuilder.RenameColumn(
                name: "Side",
                table: "Chain",
                newName: "Parent");
        }
    }
}

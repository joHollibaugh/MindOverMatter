using Microsoft.EntityFrameworkCore.Migrations;

namespace MindOverMatter.Migrations
{
    public partial class FixNode2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Molecules_MoleculeId",
                table: "Nodes");

            migrationBuilder.DropIndex(
                name: "IX_Nodes_MoleculeId",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "MoleculeId",
                table: "Nodes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoleculeId",
                table: "Nodes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_MoleculeId",
                table: "Nodes",
                column: "MoleculeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Molecules_MoleculeId",
                table: "Nodes",
                column: "MoleculeId",
                principalTable: "Molecules",
                principalColumn: "MoleculeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

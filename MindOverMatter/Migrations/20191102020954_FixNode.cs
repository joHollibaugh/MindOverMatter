using Microsoft.EntityFrameworkCore.Migrations;

namespace MindOverMatter.Migrations
{
    public partial class FixNode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Nodes_NodeId1",
                table: "Nodes");

            migrationBuilder.DropIndex(
                name: "IX_Nodes_NodeId1",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "NodeId1",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "Scans",
                table: "Nodes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NodeId1",
                table: "Nodes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Scans",
                table: "Nodes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_NodeId1",
                table: "Nodes",
                column: "NodeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Nodes_NodeId1",
                table: "Nodes",
                column: "NodeId1",
                principalTable: "Nodes",
                principalColumn: "NodeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

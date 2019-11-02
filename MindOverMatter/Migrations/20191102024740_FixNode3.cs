using Microsoft.EntityFrameworkCore.Migrations;

namespace MindOverMatter.Migrations
{
    public partial class FixNode3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NodeNeighborNeighborNodeId",
                table: "Nodes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NodeNeighborNodeId",
                table: "Nodes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NodeNeighbors",
                columns: table => new
                {
                    NeighborNodeId = table.Column<string>(nullable: false),
                    NodeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeNeighbors", x => new { x.NodeId, x.NeighborNodeId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_NodeNeighborNodeId_NodeNeighborNeighborNodeId",
                table: "Nodes",
                columns: new[] { "NodeNeighborNodeId", "NodeNeighborNeighborNodeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_NodeNeighbors_NodeNeighborNodeId_NodeNeighborNeighborNodeId",
                table: "Nodes",
                columns: new[] { "NodeNeighborNodeId", "NodeNeighborNeighborNodeId" },
                principalTable: "NodeNeighbors",
                principalColumns: new[] { "NodeId", "NeighborNodeId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_NodeNeighbors_NodeNeighborNodeId_NodeNeighborNeighborNodeId",
                table: "Nodes");

            migrationBuilder.DropTable(
                name: "NodeNeighbors");

            migrationBuilder.DropIndex(
                name: "IX_Nodes_NodeNeighborNodeId_NodeNeighborNeighborNodeId",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "NodeNeighborNeighborNodeId",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "NodeNeighborNodeId",
                table: "Nodes");
        }
    }
}

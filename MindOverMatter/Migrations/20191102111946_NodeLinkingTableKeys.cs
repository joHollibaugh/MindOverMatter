using Microsoft.EntityFrameworkCore.Migrations;

namespace MindOverMatter.Migrations
{
    public partial class NodeLinkingTableKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Linear",
                table: "Nodes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Outer",
                table: "Nodes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Parent",
                table: "Chain",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "NodeChains",
                columns: table => new
                {
                    ChainId = table.Column<int>(nullable: false),
                    NodeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeChains", x => new { x.ChainId, x.NodeId });
                    table.ForeignKey(
                        name: "FK_NodeChains_Chain_ChainId",
                        column: x => x.ChainId,
                        principalTable: "Chain",
                        principalColumn: "ChainId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NodeChains_Nodes_NodeId",
                        column: x => x.NodeId,
                        principalTable: "Nodes",
                        principalColumn: "NodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NodeChains_ChainId",
                table: "NodeChains",
                column: "ChainId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NodeChains_NodeId",
                table: "NodeChains",
                column: "NodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_NodeNeighbors_Nodes_NodeId",
                table: "NodeNeighbors",
                column: "NodeId",
                principalTable: "Nodes",
                principalColumn: "NodeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NodeNeighbors_Nodes_NodeId",
                table: "NodeNeighbors");

            migrationBuilder.DropTable(
                name: "NodeChains");

            migrationBuilder.DropColumn(
                name: "Linear",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "Outer",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "Parent",
                table: "Chain");
        }
    }
}

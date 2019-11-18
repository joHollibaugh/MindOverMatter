using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MindOverMatter.Migrations
{
    public partial class DropUnusedDbTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NodeChains");

            migrationBuilder.DropTable(
                name: "NodeNeighbors");

            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropTable(
                name: "Chain");

            migrationBuilder.InsertData(
                table: "Atoms",
                columns: new[] { "AtomId", "BondPotential", "Name" },
                values: new object[] { 2, 2, "Oxygen" });

            migrationBuilder.InsertData(
                table: "Atoms",
                columns: new[] { "AtomId", "BondPotential", "Name" },
                values: new object[] { 3, 3, "Nitrogen" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Atoms",
                keyColumn: "AtomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Atoms",
                keyColumn: "AtomId",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "Chain",
                columns: table => new
                {
                    ChainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MoleculeId = table.Column<int>(nullable: true),
                    Parent = table.Column<bool>(nullable: false),
                    Side = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chain", x => x.ChainId);
                    table.ForeignKey(
                        name: "FK_Chain_Molecules_MoleculeId",
                        column: x => x.MoleculeId,
                        principalTable: "Molecules",
                        principalColumn: "MoleculeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    NodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtomId = table.Column<int>(nullable: true),
                    BranchCount = table.Column<int>(nullable: false),
                    ChainId = table.Column<int>(nullable: true),
                    Divergent = table.Column<bool>(nullable: false),
                    Linear = table.Column<bool>(nullable: false),
                    NodeTag = table.Column<string>(nullable: true),
                    Outer = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.NodeId);
                    table.ForeignKey(
                        name: "FK_Nodes_Atoms_AtomId",
                        column: x => x.AtomId,
                        principalTable: "Atoms",
                        principalColumn: "AtomId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nodes_Chain_ChainId",
                        column: x => x.ChainId,
                        principalTable: "Chain",
                        principalColumn: "ChainId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NodeChains",
                columns: table => new
                {
                    ChainId = table.Column<int>(nullable: false),
                    NodeId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "NodeNeighbors",
                columns: table => new
                {
                    NodeId = table.Column<int>(nullable: false),
                    NeighborId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeNeighbors", x => new { x.NodeId, x.NeighborId });
                    table.ForeignKey(
                        name: "FK_NodeNeighbors_Nodes_NodeId",
                        column: x => x.NodeId,
                        principalTable: "Nodes",
                        principalColumn: "NodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chain_MoleculeId",
                table: "Chain",
                column: "MoleculeId");

            migrationBuilder.CreateIndex(
                name: "IX_NodeChains_ChainId",
                table: "NodeChains",
                column: "ChainId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NodeChains_NodeId",
                table: "NodeChains",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_AtomId",
                table: "Nodes",
                column: "AtomId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_ChainId",
                table: "Nodes",
                column: "ChainId");
        }
    }
}

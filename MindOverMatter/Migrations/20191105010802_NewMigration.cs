using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MindOverMatter.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atoms",
                columns: table => new
                {
                    AtomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BondPotential = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atoms", x => x.AtomId);
                });

            migrationBuilder.CreateTable(
                name: "Molecules",
                columns: table => new
                {
                    MoleculeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Molecules", x => x.MoleculeId);
                });

            migrationBuilder.CreateTable(
                name: "Chain",
                columns: table => new
                {
                    ChainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Parent = table.Column<bool>(nullable: false),
                    Side = table.Column<bool>(nullable: false),
                    MoleculeId = table.Column<int>(nullable: true)
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
                    NodeTag = table.Column<string>(nullable: true),
                    AtomId = table.Column<int>(nullable: true),
                    BranchCount = table.Column<int>(nullable: false),
                    Divergent = table.Column<bool>(nullable: false),
                    Outer = table.Column<bool>(nullable: false),
                    Linear = table.Column<bool>(nullable: false),
                    ChainId = table.Column<int>(nullable: true)
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

            migrationBuilder.InsertData(
                table: "Atoms",
                columns: new[] { "AtomId", "BondPotential", "Name" },
                values: new object[] { 1, 4, "Carbon" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NodeChains");

            migrationBuilder.DropTable(
                name: "NodeNeighbors");

            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropTable(
                name: "Atoms");

            migrationBuilder.DropTable(
                name: "Chain");

            migrationBuilder.DropTable(
                name: "Molecules");
        }
    }
}

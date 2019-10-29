using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MindOverMatter.Migrations
{
    public partial class CreateChemicalTables : Migration
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
                name: "Chain",
                columns: table => new
                {
                    ChainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Parent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chain", x => x.ChainId);
                });

            migrationBuilder.CreateTable(
                name: "Node",
                columns: table => new
                {
                    NodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtomId = table.Column<int>(nullable: true),
                    Scans = table.Column<int>(nullable: false),
                    Divergent = table.Column<bool>(nullable: false),
                    ChainId = table.Column<int>(nullable: true),
                    NodeId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Node", x => x.NodeId);
                    table.ForeignKey(
                        name: "FK_Node_Atoms_AtomId",
                        column: x => x.AtomId,
                        principalTable: "Atoms",
                        principalColumn: "AtomId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Node_Chain_ChainId",
                        column: x => x.ChainId,
                        principalTable: "Chain",
                        principalColumn: "ChainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Node_Node_NodeId1",
                        column: x => x.NodeId1,
                        principalTable: "Node",
                        principalColumn: "NodeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Atoms",
                columns: new[] { "AtomId", "BondPotential", "Name" },
                values: new object[] { 1, 4, "Carbon" });

            migrationBuilder.CreateIndex(
                name: "IX_Node_AtomId",
                table: "Node",
                column: "AtomId");

            migrationBuilder.CreateIndex(
                name: "IX_Node_ChainId",
                table: "Node",
                column: "ChainId");

            migrationBuilder.CreateIndex(
                name: "IX_Node_NodeId1",
                table: "Node",
                column: "NodeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Node");

            migrationBuilder.DropTable(
                name: "Atoms");

            migrationBuilder.DropTable(
                name: "Chain");
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MindOverMatter.Migrations
{
    public partial class AddMoleculeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Node_Atoms_AtomId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Chain_ChainId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Node_NodeId1",
                table: "Node");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Node",
                table: "Node");

            migrationBuilder.DropColumn(
                name: "NodeId",
                table: "Node");

            migrationBuilder.RenameTable(
                name: "Node",
                newName: "Nodes");

            migrationBuilder.RenameColumn(
                name: "NodeId1",
                table: "Nodes",
                newName: "MoleculeId");

            migrationBuilder.RenameIndex(
                name: "IX_Node_NodeId1",
                table: "Nodes",
                newName: "IX_Nodes_MoleculeId");

            migrationBuilder.RenameIndex(
                name: "IX_Node_ChainId",
                table: "Nodes",
                newName: "IX_Nodes_ChainId");

            migrationBuilder.RenameIndex(
                name: "IX_Node_AtomId",
                table: "Nodes",
                newName: "IX_Nodes_AtomId");

            migrationBuilder.AddColumn<int>(
                name: "MoleculeId",
                table: "Chain",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdNode",
                table: "Nodes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NodeIdNode",
                table: "Nodes",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nodes",
                table: "Nodes",
                column: "IdNode");

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

            migrationBuilder.CreateIndex(
                name: "IX_Chain_MoleculeId",
                table: "Chain",
                column: "MoleculeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_NodeIdNode",
                table: "Nodes",
                column: "NodeIdNode");

            migrationBuilder.AddForeignKey(
                name: "FK_Chain_Molecules_MoleculeId",
                table: "Chain",
                column: "MoleculeId",
                principalTable: "Molecules",
                principalColumn: "MoleculeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Atoms_AtomId",
                table: "Nodes",
                column: "AtomId",
                principalTable: "Atoms",
                principalColumn: "AtomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Chain_ChainId",
                table: "Nodes",
                column: "ChainId",
                principalTable: "Chain",
                principalColumn: "ChainId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Molecules_MoleculeId",
                table: "Nodes",
                column: "MoleculeId",
                principalTable: "Molecules",
                principalColumn: "MoleculeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Nodes_NodeIdNode",
                table: "Nodes",
                column: "NodeIdNode",
                principalTable: "Nodes",
                principalColumn: "IdNode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chain_Molecules_MoleculeId",
                table: "Chain");

            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Atoms_AtomId",
                table: "Nodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Chain_ChainId",
                table: "Nodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Molecules_MoleculeId",
                table: "Nodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Nodes_NodeIdNode",
                table: "Nodes");

            migrationBuilder.DropTable(
                name: "Molecules");

            migrationBuilder.DropIndex(
                name: "IX_Chain_MoleculeId",
                table: "Chain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nodes",
                table: "Nodes");

            migrationBuilder.DropIndex(
                name: "IX_Nodes_NodeIdNode",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "MoleculeId",
                table: "Chain");

            migrationBuilder.DropColumn(
                name: "IdNode",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "NodeIdNode",
                table: "Nodes");

            migrationBuilder.RenameTable(
                name: "Nodes",
                newName: "Node");

            migrationBuilder.RenameColumn(
                name: "MoleculeId",
                table: "Node",
                newName: "NodeId1");

            migrationBuilder.RenameIndex(
                name: "IX_Nodes_MoleculeId",
                table: "Node",
                newName: "IX_Node_NodeId1");

            migrationBuilder.RenameIndex(
                name: "IX_Nodes_ChainId",
                table: "Node",
                newName: "IX_Node_ChainId");

            migrationBuilder.RenameIndex(
                name: "IX_Nodes_AtomId",
                table: "Node",
                newName: "IX_Node_AtomId");

            migrationBuilder.AddColumn<int>(
                name: "NodeId",
                table: "Node",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Node",
                table: "Node",
                column: "NodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Atoms_AtomId",
                table: "Node",
                column: "AtomId",
                principalTable: "Atoms",
                principalColumn: "AtomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Chain_ChainId",
                table: "Node",
                column: "ChainId",
                principalTable: "Chain",
                principalColumn: "ChainId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Node_NodeId1",
                table: "Node",
                column: "NodeId1",
                principalTable: "Node",
                principalColumn: "NodeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

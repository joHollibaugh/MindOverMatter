using Microsoft.EntityFrameworkCore.Migrations;

namespace MindOverMatter.Migrations
{
    public partial class FixNodeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Nodes_NodeIdNode",
                table: "Nodes");

            migrationBuilder.RenameColumn(
                name: "NodeIdNode",
                table: "Nodes",
                newName: "NodeId1");

            migrationBuilder.RenameColumn(
                name: "IdNode",
                table: "Nodes",
                newName: "NodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Nodes_NodeIdNode",
                table: "Nodes",
                newName: "IX_Nodes_NodeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Nodes_NodeId1",
                table: "Nodes",
                column: "NodeId1",
                principalTable: "Nodes",
                principalColumn: "NodeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Nodes_NodeId1",
                table: "Nodes");

            migrationBuilder.RenameColumn(
                name: "NodeId1",
                table: "Nodes",
                newName: "NodeIdNode");

            migrationBuilder.RenameColumn(
                name: "NodeId",
                table: "Nodes",
                newName: "IdNode");

            migrationBuilder.RenameIndex(
                name: "IX_Nodes_NodeId1",
                table: "Nodes",
                newName: "IX_Nodes_NodeIdNode");

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Nodes_NodeIdNode",
                table: "Nodes",
                column: "NodeIdNode",
                principalTable: "Nodes",
                principalColumn: "IdNode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

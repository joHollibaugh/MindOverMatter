using Microsoft.EntityFrameworkCore.Migrations;

namespace MindOverMatter.Migrations
{
    public partial class addfieldJsonObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Atoms",
                keyColumn: "AtomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Atoms",
                keyColumn: "AtomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Atoms",
                keyColumn: "AtomId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Atoms",
                keyColumn: "AtomId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Atoms",
                keyColumn: "AtomId",
                keyValue: 5);

            migrationBuilder.AddColumn<string>(
                name: "MoleculeJson",
                table: "Molecules",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoleculeJson",
                table: "Molecules");

            migrationBuilder.InsertData(
                table: "Atoms",
                columns: new[] { "AtomId", "BondPotential", "Name" },
                values: new object[,]
                {
                    { 1, 4, "Carbon" },
                    { 2, 2, "Oxygen" },
                    { 3, 3, "Nitrogen" },
                    { 4, 1, "Fluorine" },
                    { 5, 1, "Chlorine" }
                });
        }
    }
}

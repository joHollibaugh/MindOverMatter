using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MindOverMatter.Migrations
{
    public partial class AddPrefixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prefixes",
                columns: table => new
                {
                    PrefixId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ChainLength = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prefixes", x => x.PrefixId);
                });

            migrationBuilder.InsertData(
                table: "Atoms",
                columns: new[] { "AtomId", "BondPotential", "Name" },
                values: new object[] { 4, 1, "Fluorine" });

            migrationBuilder.InsertData(
                table: "Atoms",
                columns: new[] { "AtomId", "BondPotential", "Name" },
                values: new object[] { 5, 1, "Chlorine" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prefixes");

            migrationBuilder.DeleteData(
                table: "Atoms",
                keyColumn: "AtomId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Atoms",
                keyColumn: "AtomId",
                keyValue: 5);
        }
    }
}

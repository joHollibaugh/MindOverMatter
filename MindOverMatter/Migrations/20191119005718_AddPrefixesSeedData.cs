using Microsoft.EntityFrameworkCore.Migrations;

namespace MindOverMatter.Migrations
{
    public partial class AddPrefixesSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Prefixes",
                columns: new[] { "PrefixId", "ChainLength", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Meth" },
                    { 18, 18, "Octadec" },
                    { 17, 17, "Heptadec" },
                    { 16, 16, "Hexadec" },
                    { 15, 15, "Pentadec" },
                    { 14, 14, "Tetradec" },
                    { 13, 13, "Tridec" },
                    { 12, 12, "Dodec" },
                    { 11, 11, "Undec" },
                    { 10, 10, "Dec" },
                    { 9, 9, "Non" },
                    { 8, 8, "Oct" },
                    { 7, 7, "Hept" },
                    { 6, 6, "Hex" },
                    { 5, 5, "Pent" },
                    { 4, 4, "But" },
                    { 3, 3, "Prop" },
                    { 2, 2, "Ethane" },
                    { 19, 19, "Nonadec" },
                    { 20, 20, "Icos" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Prefixes",
                keyColumn: "PrefixId",
                keyValue: 20);
        }
    }
}

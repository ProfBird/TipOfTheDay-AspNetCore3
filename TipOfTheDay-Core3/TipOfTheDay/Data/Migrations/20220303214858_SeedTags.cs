using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TipOfTheDay.Data.Migrations
{
    public partial class SeedTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagID", "Category" },
                values: new object[] { 1, "Cat-A" });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagID", "Category" },
                values: new object[] { 2, "Cat-B" });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagID", "Category" },
                values: new object[] { 3, "Cat-C" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: 3);
        }
    }
}

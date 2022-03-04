using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TipOfTheDay.Data.Migrations
{
    public partial class SeedTips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tip",
                columns: new[] { "TipID", "MemberId", "TipText" },
                values: new object[] { 1, null, "The first tip" });

            migrationBuilder.InsertData(
                table: "Tip",
                columns: new[] { "TipID", "MemberId", "TipText" },
                values: new object[] { 2, null, "Another tip" });

            migrationBuilder.InsertData(
                table: "Tip",
                columns: new[] { "TipID", "MemberId", "TipText" },
                values: new object[] { 3, null, "Yet another tip" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tip",
                keyColumn: "TipID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tip",
                keyColumn: "TipID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tip",
                keyColumn: "TipID",
                keyValue: 3);
        }
    }
}

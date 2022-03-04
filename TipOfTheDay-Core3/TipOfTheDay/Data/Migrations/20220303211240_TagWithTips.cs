using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TipOfTheDay.Data.Migrations
{
    public partial class TagWithTips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Tip_TipID",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_TipID",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "TipID",
                table: "Tag");

            migrationBuilder.CreateTable(
                name: "TagTip",
                columns: table => new
                {
                    TagsTagID = table.Column<int>(type: "int", nullable: false),
                    TipsTipID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagTip", x => new { x.TagsTagID, x.TipsTipID });
                    table.ForeignKey(
                        name: "FK_TagTip_Tag_TagsTagID",
                        column: x => x.TagsTagID,
                        principalTable: "Tag",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagTip_Tip_TipsTipID",
                        column: x => x.TipsTipID,
                        principalTable: "Tip",
                        principalColumn: "TipID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagTip_TipsTipID",
                table: "TagTip",
                column: "TipsTipID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagTip");

            migrationBuilder.AddColumn<int>(
                name: "TipID",
                table: "Tag",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TipID",
                table: "Tag",
                column: "TipID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Tip_TipID",
                table: "Tag",
                column: "TipID",
                principalTable: "Tip",
                principalColumn: "TipID");
        }
    }
}

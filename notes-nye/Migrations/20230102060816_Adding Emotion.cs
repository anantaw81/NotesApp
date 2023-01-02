using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace notes_nye.Migrations
{
    public partial class AddingEmotion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emotion",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "EmotionId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Emotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emotions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_EmotionId",
                table: "Notes",
                column: "EmotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Emotions_EmotionId",
                table: "Notes",
                column: "EmotionId",
                principalTable: "Emotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Emotions_EmotionId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "Emotions");

            migrationBuilder.DropIndex(
                name: "IX_Notes_EmotionId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "EmotionId",
                table: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "Emotion",
                table: "Notes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}

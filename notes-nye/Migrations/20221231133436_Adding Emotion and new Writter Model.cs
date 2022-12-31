using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace notes_nye.Migrations
{
    public partial class AddingEmotionandnewWritterModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Emotion",
                table: "Notes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emotion",
                table: "Notes");
        }
    }
}

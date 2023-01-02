using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace notes_nye.Migrations
{
    public partial class AddingRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Writer",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "WriterId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_WriterId",
                table: "Notes",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_WriterId",
                table: "Notes",
                column: "WriterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_WriterId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_WriterId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "Writer",
                table: "Notes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}

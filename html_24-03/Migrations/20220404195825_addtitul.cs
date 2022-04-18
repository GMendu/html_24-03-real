using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace html_24_03.Migrations
{
    public partial class addtitul : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "noticiaTitulo",
                table: "Noticia",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "noticiaTitulo",
                table: "Noticia");
        }
    }
}

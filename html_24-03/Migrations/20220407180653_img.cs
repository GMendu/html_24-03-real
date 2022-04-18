using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace html_24_03.Migrations
{
    public partial class img : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "noticiaImg",
                table: "Noticia",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "noticiaImg",
                table: "Noticia");
        }
    }
}

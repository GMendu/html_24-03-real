using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace html_24_03.Migrations
{
    public partial class migracaoinicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Noticia",
                columns: table => new
                {
                    noticiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    noticiaTexto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticia", x => x.noticiaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Noticia");
        }
    }
}

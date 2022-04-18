using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace html_24_03.Migrations
{
    public partial class muitos3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    cursoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cursoNome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.cursoId);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    alunoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alunoNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alunoCursoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.alunoId);
                    table.ForeignKey(
                        name: "FK_Aluno_Cursos_alunoCursoId",
                        column: x => x.alunoCursoId,
                        principalTable: "Cursos",
                        principalColumn: "cursoId");
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    ProfessoresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessoresNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessoresCursoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.ProfessoresId);
                    table.ForeignKey(
                        name: "FK_Professores_Cursos_ProfessoresCursoId",
                        column: x => x.ProfessoresCursoId,
                        principalTable: "Cursos",
                        principalColumn: "cursoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_alunoCursoId",
                table: "Aluno",
                column: "alunoCursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_ProfessoresCursoId",
                table: "Professores",
                column: "ProfessoresCursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}

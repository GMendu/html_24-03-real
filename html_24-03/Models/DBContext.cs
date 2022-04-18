using Microsoft.EntityFrameworkCore;

namespace html_24_03.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Noticia>? BancoNoticia { get; set; }
        public DbSet<Cursos>? BancoCursos { get; set; }
        public DbSet<Aluno>? BancoAluno { get; set; }
        public DbSet<Professores>? BancoProfessores { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace html_24_03.Models
{
    [Table("Aluno")]
    public class Aluno
    {
        [Column("alunoId")]
        [Display(Name = "Código")]
        public int alunoId { get; set; }

        [Column("alunoNome")]
        [Display(Name = "Nome")]
        public string? alunoNome { get; set; }

        [Column("alunoCursoId")]
        [Display(Name = "Curso")]
        public int? alunoCursoId { get; set; }
        public Cursos? alunoCurso { get; set; }
    }
}
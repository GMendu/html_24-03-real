using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace html_24_03.Models
{
    [Table("Cursos")]
    public class Cursos
    {
        [Column("cursoId")]
        [Display(Name = "Código")]
        public int cursosId { get; set; }

        [Column("cursoNome")]
        [Display(Name = "Nome")]
        public string? cursoNome { get; set; }

        [Column("cursoAluno")]
        [Display(Name = "Aluno")]
        public List<Aluno>? cursoAluno { get; set; }


        [Column("cursoProfessor")]
        [Display(Name = "Professor")]
        public List<Professores>? cursoProfessor { get; set; }
    }
}
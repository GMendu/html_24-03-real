using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace html_24_03.Models
{
    [Table("Professores")]
    public class Professores
    {
        [Column("ProfessoresId")]
        [Display(Name = "Código")]
        public int ProfessoresId { get; set; }

        [Column("ProfessoresNome")]
        [Display(Name = "Nome")]
        public string? ProfessoresNome { get; set; }

        [Column("ProfessoresCursoId")]
        [Display(Name = "Curso")]
        public int? ProfessoresCursoId { get; set; }
        public Cursos? ProfessoresCurso { get; set; }
    }
}
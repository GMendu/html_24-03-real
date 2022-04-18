using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace html_24_03.Models
{
    [Table("Noticia")]
    public class Noticia
    {
        [Column("noticiaId")]
        [Display(Name = "Código")]
        public int noticiaId { get; set; }

        [Column("noticiaImg")]
        [Display(Name = "Imagem")]
        public string? noticiaImg { get; set; }

        [Column("noticiaTexto")]
        [Display(Name = "Texto")]
        public string? noticiaTexto { get; set; }
        [DataType(DataType.MultilineText)]

        [Column("noticiaTitulo")]
        [Display(Name = "Titulo")]
        public string? noticiaTitulo { get; set; }

        [Column("noticiaDescr")]
        [Display(Name = "Descricao")]
        public string? noticiaDescr { get; set; }
    }
}

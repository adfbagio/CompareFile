using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComparaArquivos.Banco
{
    [Table("FontesProjetos")]
    public class FontesProjetos
    {
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Display(Name = "IdProjeto")]
        public string IDProjeto { get; set; }

        [Display(Name = "Extensao")]
        public string Extensao { get; set; }

        [Display(Name = "Fonte")]
        public string Fonte { get; set; }
    }
}

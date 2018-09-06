using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComparaArquivos.Banco
{
    [Table("Tab_ConBancoBs")]
    public class ConBancoBs
    {
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Display(Name = "NomeClasse")]
        public string NomeClasse { get; set; }

        [Display(Name = "NomeProjeto")]
        public string NomeProjeto { get; set; }

        [Display(Name = "formaconbanco")]
        public string formaconbanco { get; set; }

        [Display(Name = "funcao")]
        public string funcao { get; set; }

        [Display(Name = "LINHAS")]
        public int LINHAS { get; set; }

    }
}

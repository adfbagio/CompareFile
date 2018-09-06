using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComparaArquivos.Banco
{
    [Table("AcessoMultiManager")]
    public class AcessoMultiManager
    {
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
    }
}

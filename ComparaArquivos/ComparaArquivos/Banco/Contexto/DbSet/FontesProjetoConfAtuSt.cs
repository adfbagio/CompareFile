using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComparaArquivos.Banco
{
    [Table("FontesProjetoConfAtuSt")]
    public class FontesProjetoConfAtuSt
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "ProjConfId")]
        public string ProjConfId { get; set; }

        [Display(Name = "TipoConf")]
        public string TipoConf { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Modulo")]
        public string Modulo { get; set; }

        [Display(Name = "Obs")]
        public string Obs { get; set; }
    }
}

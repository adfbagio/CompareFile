using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComparaArquivos.Banco
{
    [Table("Tab_Relatorios_Sise")]
   public class RelatoriosSise
    {
        [Display(Name = "Id")]
        public int ID { get; set; }
        [Display(Name = "NomeRpt")]
        public string NomeRpt { get; set; }
        [Display(Name = "modulo")]
        public string modulo { get; set; }
        [Display(Name = "tipo")]
        public string tipo { get; set; }
        [Display(Name = "form")]
        public string form { get; set; }
        [Display(Name = "chamada11")]
        public string chamada11 { get; set; }
        [Display(Name = "chamada9")]
        public string chamada9 { get; set; }
        [Display(Name = "parametrizado")]
        public string parametrizado { get; set; }
        [Display(Name = "tbgrelatorios")]
        public string tbgrelatorios { get; set; }
        [Display(Name = "cd_relatorio")]
        public string cd_relatorio { get; set; }
        [Display(Name = "texto")]
        public string texto { get; set; }

       
    }
}



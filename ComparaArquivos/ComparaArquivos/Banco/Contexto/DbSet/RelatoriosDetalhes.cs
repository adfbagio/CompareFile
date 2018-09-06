using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComparaArquivos.Banco
{
    [Table("Tab_Relatorios_Detalhes")]
    public class RelatoriosDetalhes
    {
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Display(Name = "Relatorios")]
        public string Relatorios { get; set; }

        [Display(Name = "Procedures")]
        public string Procedures { get; set; }

        [Display(Name = "Subreport")]
        public string Subreport { get; set; }

        [Display(Name = "SubreportProcs")]
        public string SubreportProcs { get; set; }
    }
}

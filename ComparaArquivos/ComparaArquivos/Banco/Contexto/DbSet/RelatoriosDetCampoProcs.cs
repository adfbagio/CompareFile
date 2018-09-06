using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComparaArquivos.Banco
{
    [Table("Tab_Relatorios_Det_Campo_Procs")]
    public  class RelatoriosDetCampoProcs
    {
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Display(Name = "Relatorios")]
        public string Relatorios { get; set; }

        [Display(Name = "Procedures")]
        public string Procedures { get; set; }

        [Display(Name = "Campo")]
        public string Campo { get; set; }

        [Display(Name = "Tipo")]
        public string Tipo { get; set; }
    }
}

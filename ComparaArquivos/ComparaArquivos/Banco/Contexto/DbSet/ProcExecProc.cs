using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComparaArquivos.Banco
{
    [Table("Tab_ProcExecProc1")]
    public class ProcExecProc
    {
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Display(Name = "ProcOrigem")]
        public string ProcOrigem { get; set; }

        [Display(Name = "ProcExec")]
        public string ProcExec { get; set; }

        [Display(Name = "linhacomando")]
        public string linhacomando { get; set; }

        

    }
}

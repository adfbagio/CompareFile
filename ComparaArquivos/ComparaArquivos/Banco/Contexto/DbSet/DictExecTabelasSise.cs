using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComparaArquivos.Banco
{
    [Table("Tab_DictExecTabelasSise")]
  public  class DictExecTabelasSise 
    {
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Display(Name = "Tabelas")]
        public string Tabelas { get; set; }

        [Display(Name = "Procedures")]
        public string Procedures { get; set; }
        [Display(Name = "Linha")]
        public string Linha { get; set; }
    }
}

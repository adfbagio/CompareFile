using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ComparaArquivos.Banco
{
    [Table("Tab_Form_Exec")]
    public class FormExec
    {
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Display(Name = "NomeClasse")]
        public string NomeClasse { get; set; }

        [Display(Name = "NomeProjeto")]
        public string NomeProjeto { get; set; }

        [Display(Name = "Texto")]
        public string Texto { get; set; }

        [Display(Name = "Subfuncform")]
        public string Subfuncform { get; set; }

        [Display(Name = "NomeForm")]
        public string NomeForm { get; set; }

        [Display(Name = "Metodo")]
        public string Metodo { get; set; }

        [Display(Name = "NomeProjetoCall")]
        public string NomeProjetoCall { get; set; }
    }
}

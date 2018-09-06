using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComparaArquivos.Banco
{
    [Table("FontesProjetoConfAtuSt")]
    public class DetalhesProjeto
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "ProjetoId")]
        public string ProjetoId { get; set; }

        [Display(Name = "Fonte")]
        public string Fonte { get; set; }

        [Display(Name = "Datault")]
        public string Datault { get; set; }

        [Display(Name = "Modulo")]
        public string Modulo { get; set; }

        [Display(Name = "PathTfs")]
        public string PathTfs { get; set; }

        [Display(Name = "PathWin")]
        public string PathWin { get; set; }

        [Display(Name = "Versao")]
        public int Versao { get; set; }

        [Display(Name = "Projetos_Id")]
        public Nullable<int> Projetos_Id { get; set; }

        public virtual ProjetosTfs ProjetosTfs { get; set; }
    }
}

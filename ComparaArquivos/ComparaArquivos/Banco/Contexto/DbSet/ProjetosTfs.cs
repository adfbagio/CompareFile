using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComparaArquivos.Banco
{
    [Table("ProjetosTfs")]
    public class ProjetosTfs
    {
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Display(Name = "IdProjeto")]
        public string IDProjeto { get; set; }

        [Display(Name = "NomeProjeto")]
        public string NomeProjeto { get; set; }

        [Display(Name = "GerenteProjeto")]
        public string GerenteProjeto { get; set; }

        [Display(Name = "Ativo")]
        public int Ativo { get; set; }

        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
    }
}


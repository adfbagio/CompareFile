using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComparaArquivos.Banco.Contexto.DbSet
{
    [Table("FontesProjetos")]
    class BancosDeDados
    {
       
        
            [Display(Name = "IdBd")]
            public int ID { get; set; }

            [Display(Name = "IdInstancia")]
            public int IdInstancia { get; set; }

            [Display(Name = "Catalog")]
            public string Catalog { get; set; }

         
    }
}

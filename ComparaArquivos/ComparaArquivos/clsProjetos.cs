using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComparaArquivos.Banco;

namespace ComparaArquivos
{
  public  class clsProjetos
    {

        public Object Get_ProjetosFiltro()
        {
            Object RetornoBDInst;
            //retornado como objeto pois a pesquisa retorna tipo anonimo que nao é queriable
            Contexto contexto = new Contexto();
            RetornoBDInst = (from c in contexto.ProjetosTfs


                             select new { c.IDProjeto , c.NomeProjeto }).ToList();

            return RetornoBDInst;

        }
      
    }
}

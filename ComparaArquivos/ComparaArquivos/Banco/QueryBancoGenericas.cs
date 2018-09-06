using System;
using System.Reflection;

//using ComparaArquivos.Classes;

namespace ComparaArquivos
{
    public class QueryBancoGenericas
    {
        /// <summary>
        /// Apaga todo o conteudo da tabela selecionada
        /// </summary>
        /// <param name="Tabela">Nome da tabela para ser deletada</param>
        public void ApagaTabela(string Tabela)
        {
            try
            {
                Contexto contexto = new Contexto();
                contexto.Database.ExecuteSqlCommand("Delete from " + Tabela);
            }

            catch(Exception e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
//Log.Write(className, funcName, e.Message);
                throw e;
            }
        }
    }
}

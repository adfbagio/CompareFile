using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

//using ComparaArquivos.Classes;

namespace ComparaArquivos.Banco.Contexto
{
   public class ContextoADO : IDisposable
    {
        private readonly SqlConnection _minhaConexao;
        public GenericParametes Generico = new GenericParametes();
        public DataTable Resultado = new DataTable();
        public DataSet ResultadoDs = new DataSet();
        public string hCon;

        public ContextoADO()
        {
            try
            {
                _minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Contexto"].ConnectionString);

                hCon = _minhaConexao.ConnectionString;
            }

            catch (ConfigurationErrorsException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
              //  Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (Exception e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
              //  Log.Write(className, funcName, e.Message);
                throw e;
            }
        }

        public void Dispose()
        {
            try
            {
                if (_minhaConexao.State == ConnectionState.Open) _minhaConexao.Close();
            }

            catch (SqlException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
              //  Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (Exception e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
              //  Log.Write(className, funcName, e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Dados quaisquer parametros retorna um DataTable da procedure executada
        /// </summary>
        /// <param name="StoredProcedure"></param>
        /// <param name="parms"></param>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public DataTable SelectDadosEmTabela2(String StoredProcedure, List<SqlParameter> parms, String connectionName)
        {
            try
            {
                SqlCommand myCommand = null;

                SqlDataAdapter a = new SqlDataAdapter();
                myCommand = Generico.OpenCommand(StoredProcedure, parms, hCon);
                myCommand.CommandText = StoredProcedure;

                a.SelectCommand = myCommand;
                Resultado.Clear();
                a.Fill(Resultado);


            }

            catch (SqlException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
              //  Log.Write(className, funcName, e.Message);
                throw e;
                throw e;
            }

            catch (Exception e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
              //  Log.Write(className, funcName, e.Message);
                throw e;
                throw e;
            }

            return Resultado;
        }

        public DataTable SelecDataTablePorQuery(string strquery)
        {
            try
            {
                //Seleciona o resultado de uma consulta retornando um DataTable
                using (var a = new SqlDataAdapter(strquery, hCon))
                {
                    Resultado.Clear();
                    Resultado.Reset();
                    a.Fill(Resultado);
                }

                return Resultado;
            }

            catch (Exception e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
              //  Log.Write(className, funcName, e.Message);
                throw e;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Reflection;

//using ComparaArquivos.Classes;

namespace ComparaArquivos.Banco.Contexto
{
    public class GenericParametes
    {
        private readonly SqlConnection _minhaConexao;

        public GenericParametes()
        {
            try
            {
                _minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Contexto"].ConnectionString);
            }

            catch (ConfigurationErrorsException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
               // Log.Write(className, funcName, e.Message);
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

        #region OpenSqlCommand
        public SqlCommand OpenCommand(String storedProcedure, List<SqlParameter> sqlParameters, String connectionName)
        {
            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (sqlParameters != null)
                {
                    //  Check on NullValues in the SqlParameter list
                    CheckParameters(sqlParameters);

                    /* after the check change the list to an array and 
                       add to the SqlCommand                           */
                    cmd.Parameters.AddRange(sqlParameters.ToArray());
                }

                cmd.CommandTimeout = 60; // 1 minute
                cmd.Connection = _minhaConexao;

                ConnectionState state = cmd.Connection.State;
                if (state == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Connection.Open();

                return cmd;
            }

            catch (InvalidOperationException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
             //   Log.Write(className, funcName, e.Message);
                throw e;
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
               // Log.Write(className, funcName, e.Message);
                throw e;
            }
        }

        private void CheckParameters(List<SqlParameter> sqlParameters)
        {
            try
            {
                foreach (SqlParameter parm in sqlParameters)
                {
                    /*
                        when a parm.Value is null, the parm is not send to 
                        the database so the stored procedure returns with the error
                        that it misses a parameter
                        it is very possible that the parameter should be null, 
                        so when set it DBNull.Value the parameter
                        is send to the database
                    */

                    if (parm.Value == null) parm.Value = DBNull.Value;
                }
            }

            catch (Exception e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
              //  Log.Write(className, funcName, e.Message);
                throw e;
            }
        }
        #endregion OpenSqlCommand

        #region CloseSqlCommand
        public void CloseCommand(SqlCommand sqlCommand)
        {
            try
            {
                if (sqlCommand != null &&
                    sqlCommand.Connection.State == ConnectionState.Open)
                    sqlCommand.Connection.Close();
            }

            catch (SqlException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
               // Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (Exception e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
             //   Log.Write(className, funcName, e.Message);
                throw e;
            }
        }
        #endregion CloseSqlCommand
    }
}

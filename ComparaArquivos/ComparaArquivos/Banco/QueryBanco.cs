using ComparaArquivos.Banco;
//using ComparaArquivos.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;

namespace ComparaArquivos
{
    public class QueryBanco
    {
        private Contexto db = new Contexto();
        
        /// <summary>
        /// Verifica se o usuario tem acesso aos menus
        /// </summary>
        /// <param name="usuario">Nome do usuario pra busca</param>
        /// <returns>Ilist do resultado</returns>
        public IList<AcessoMultiManager> GetAcesso(string usuario)
        {
            try
            {
                return (from s in db.AcessoMultiManager.AsEnumerable().
                         Where(s => s.Usuario == usuario)
                        select new AcessoMultiManager
                        {
                            Usuario = s.Usuario,
                        }).ToList();
            }

            #region Catch
            catch (ArgumentNullException e)
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
                //Log.Write(className, funcName, e.Message);
                throw e;
            }
            #endregion
        }

        /// <summary>
        /// Oque Possuir na Tabela ProjetosTFS
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>Ilist da tabela ProjetosTfs</returns>
        public IList<ProjetosTfs> GetProjetosTFS()
        {
            try
            {
                return (from s in db.ProjetosTfs.AsEnumerable()
                        select new ProjetosTfs
                        {
                            IDProjeto = s.IDProjeto,
                            NomeProjeto = s.NomeProjeto,
                            GerenteProjeto = s.GerenteProjeto,
                            Ativo = s.Ativo,
                            Usuario = s.Usuario
                        }).ToList();
            }

            #region Catch
            catch (ArgumentNullException e)
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
                //Log.Write(className, funcName, e.Message);
                throw e;
            }
            #endregion
        }

        /// <summary>
        /// Todos os projetos ativos
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>Ilist da tabela ProjetosTfs</returns>
        public IList<ProjetosTfs> GetProjetosTFSAtivos()
        {
            try
            {
                return (from s in db.ProjetosTfs.AsEnumerable().
                        Where(s => s.Ativo == 1)
                        select new ProjetosTfs
                        {
                            IDProjeto = s.IDProjeto,
                            NomeProjeto = s.NomeProjeto,
                            GerenteProjeto = s.GerenteProjeto,
                            Ativo = s.Ativo,
                            Usuario = s.Usuario
                        }).ToList();
            }

            #region Catch
            catch (ArgumentNullException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (Exception e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }
            #endregion
        }

        /// <summary>
        /// Oque Possuir na Tabela FontesProjetos
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>Ilist da tabela ProjetosTfs</returns>
        public IList<FontesProjetos> GetFontesProjeto(string idProjeto)
        {
            try
            {
                return (from fontes in db.FontesProjetos.AsEnumerable().
                        Where(id => id.IDProjeto == idProjeto)
                        select new FontesProjetos
                        {
                            IDProjeto = fontes.IDProjeto,
                            Extensao = fontes.Extensao,
                            Fonte = fontes.Fonte
                        }).ToList();
            }

            #region Catch
            catch (ArgumentNullException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (Exception e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }
            #endregion
        }

        /// <summary>
        /// Pega todos os fontes da tabela FontesProjetos
        /// </summary>
        /// <returns>Retorna a lista do resultado</returns>
        public IList<FontesProjetos> GetFontesProjeto()
        {
            try
            {
                return (from fontes in db.FontesProjetos.AsEnumerable()
                        select new FontesProjetos
                        {
                            IDProjeto = fontes.IDProjeto,
                            Extensao = fontes.Extensao,
                            Fonte = fontes.Fonte
                        }).ToList();
            }

            #region Catch
            catch (ArgumentNullException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (Exception e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }
            #endregion
        }

        /// <summary>
        /// Retorna todos os conflitos dos projetos relevantes com "fontes e extensao" iguais
        /// </summary>
        /// <param name="idProjeto">Codigo do projeto</param>
        /// <param name="fonte">Nome do arquivo</param>
        /// <param name="extensao">De onde vem o arquivo</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>Lista do Resultao</returns>
        public IList<FontesProjetos> GetConflitosProjetos(string idProjeto, string fonte, string extensao)
        {
            try
            {
                return (from conflito in db.FontesProjetos.AsEnumerable().
                        Where(c => c.Fonte == fonte && c.Extensao == extensao && c.IDProjeto != idProjeto)
                        select new FontesProjetos
                        {
                            IDProjeto = conflito.IDProjeto,
                            Extensao = conflito.Extensao,
                            Fonte = conflito.Fonte,
                        }).ToList();
            }

            #region Catch
            catch (ArgumentNullException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (Exception e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }
            #endregion
        }

        /// <summary>
        /// Adiciona um projeto na tabela ProjetosTfs
        /// </summary>
        /// <param name="idProjeto">Codigo do projeto</param>
        /// <param name="nomeProjeto">Nome do projeto</param>
        /// <param name="gerenteProjeto">Gerente do projeto</param>
        /// <exception cref="DbUpdateConcurrencyException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        /// <exception cref="DbEntityValidationException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void AddProjeto(string idProjeto, string nomeProjeto, string gerenteProjeto)
        {
            try
            {
                var pro = new ProjetosTfs() { IDProjeto = idProjeto, NomeProjeto = nomeProjeto,
                                              GerenteProjeto = gerenteProjeto, Ativo = 1, Usuario = Environment.UserName };

                db.ProjetosTfs.Add(pro);
                db.SaveChanges();
            }

            #region Catch
            catch (DbUpdateConcurrencyException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (DbUpdateException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (DbEntityValidationException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (NotSupportedException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (ObjectDisposedException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (InvalidOperationException e)
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
                //Log.Write(className, funcName, e.Message);
                throw e;
            }
            #endregion
        }

        /// <summary>
        /// Adiciona um registro na tabela FontesProjetos
        /// </summary>
        /// <param name="idProjeto">Codigo do projeto</param>
        /// <param name="extensao">De onde vem o arquivo</param>
        /// <param name="fonte">Nome do arquivop</param>
        /// <exception cref="DbUpdateConcurrencyException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        /// <exception cref="DbEntityValidationException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void AddFontesProjeto(string idProjeto, string extensao, string fonte)
        {
            try
            {
                var font = new FontesProjetos() { IDProjeto = idProjeto, Extensao = extensao, Fonte = fonte };
                db.FontesProjetos.Add(font);
                db.SaveChanges();
            }

            #region Catch
            catch (DbUpdateConcurrencyException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (DbUpdateException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (DbEntityValidationException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (NotSupportedException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                ////Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (ObjectDisposedException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                ////Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (InvalidOperationException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (Exception e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }
            #endregion
        }

        /// <summary>
        /// Atualiza um registro na tabela ProjetosTfs
        /// </summary>
        /// <param name="idProjeto">Codigo do projeto</param>
        /// <param name="nomeProjeto">Nome do projeto</param>
        /// <param name="gerenteProjeto">Gerente do projeto</param>
        /// <param name="Ativo">Identificador se esta ativo ou não 0,1</param>
        /// <exception cref="DbUpdateConcurrencyException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        /// <exception cref="DbEntityValidationException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void UpdateProjeto(string idProjeto, string nomeProjeto, string gerenteProjeto, int Ativo)
        {
            try
            {
                var dados = db.ProjetosTfs.Where(x => x.IDProjeto == idProjeto).ToList();

                dados.ForEach(x =>
                {
                    x.IDProjeto = idProjeto;
                    x.NomeProjeto = nomeProjeto;
                    x.GerenteProjeto = gerenteProjeto;
                    x.Ativo = Ativo;
                    x.Usuario = Environment.UserName;
                });

                db.SaveChanges();
            }

            #region Catch
            catch (DbUpdateConcurrencyException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                ///Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (DbUpdateException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                ////Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (DbEntityValidationException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (NotSupportedException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (ObjectDisposedException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                ////Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (InvalidOperationException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (Exception e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }
            #endregion
        }

        /// <summary>
        /// Deleta toda a tabela FontesProjetos
        /// </summary>
        /// <exception cref="DbUpdateConcurrencyException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        /// <exception cref="DbEntityValidationException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void DeleteFontesProjetos()
        {
            try
            {
                var deleteOrderDetails =

                    from details in db.FontesProjetos
                    select details;

                foreach (var detail in deleteOrderDetails)
                {
                    db.FontesProjetos.Remove(detail);
                }

                db.SaveChanges();
            }

            #region Catch
            catch (DbUpdateConcurrencyException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (DbUpdateException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (DbEntityValidationException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (NotSupportedException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (ObjectDisposedException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (InvalidOperationException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                ////Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (Exception e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
//Log.Write(className, funcName, e.Message);
                throw e;
            }
            #endregion
        }

        /// <summary>
        /// Deleta todos os registros referente ao codigo do projeto
        /// </summary>
        /// <param name="idProjeto">Codigo do projeto</param>
        /// <exception cref="DbUpdateConcurrencyException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        /// <exception cref="DbEntityValidationException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void DeleteFontesProjetos(string idProjeto)
        {
            try
            {
                var deleteOrderDetails =

                    from details in db.FontesProjetos
                    where details.IDProjeto == idProjeto
                    select details;

                foreach (var detail in deleteOrderDetails)
                {
                    db.FontesProjetos.Remove(detail);
                }

                db.SaveChanges();
            }

            #region Catch
            catch (DbUpdateConcurrencyException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (DbUpdateException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                ////Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (DbEntityValidationException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                ////Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (NotSupportedException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (ObjectDisposedException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                ///Log.Write(className, funcName, e.Message);
                throw e;
            }

            catch (InvalidOperationException e)
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
                //Log.Write(className, funcName, e.Message);
                throw e;
            }
            #endregion
        }

        /// <summary>
        /// Busca a lista de projetos com o codigo referente
        /// </summary>
        /// <param name="idProjeto">Codigo do projeto</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>Lista do Resultado da busca</returns>
        public IList<ProjetosTfs> VerificarProjeto(string idProjeto)
        {
            try
            {
                var query = db.ProjetosTfs.Where(p => p.IDProjeto.Contains(idProjeto));

                return query.ToList();
            }

            #region Catch
            catch (ArgumentNullException e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e; 
            }

            catch (Exception e)
            {
                string className = MethodBase.GetCurrentMethod().DeclaringType.Name;
                string funcName = MethodBase.GetCurrentMethod().Name;
                //Log.Write(className, funcName, e.Message);
                throw e;
            }
            #endregion
        }
    }
}

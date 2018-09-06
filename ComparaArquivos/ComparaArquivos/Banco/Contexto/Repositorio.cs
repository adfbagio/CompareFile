using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ComparaArquivos.Banco.Contexto
{
    public class Repositorio<T> : IRepositorio<T>, IDisposable where T : class
    {
        private ComparaArquivos.Contexto Contexto;

        protected Repositorio()
        {
            Contexto = new ComparaArquivos.Contexto();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Contexto.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetTodos()
        {
            return Contexto.Set<T>();
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return Contexto.Set<T>().Where(predicate).FirstOrDefault();
        }

        public T Find(params object[] key)
        {
            return Contexto.Set<T>().Find(key);
        }

        public IEnumerable<T> GetAll()
        {
            return Contexto.Set<T>().ToList();
        }

        public IEnumerable<T> GetAllOrderBy(Func<T, object> keySelector)
        {
            return Contexto.Set<T>().OrderBy(keySelector).ToList();
        }

        public IEnumerable<T> GetAllOrderByDescending(Func<T, object> keySelector)
        {
            return Contexto.Set<T>().OrderByDescending(keySelector).ToList();
        }

        public void Commit()
        {
            Contexto.SaveChanges();
        }

        public void Add(T entity)
        {
            Contexto.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            Contexto.Entry(entity).State = EntityState.Modified;
        }

        public void Excluir(Func<T, bool> predicate)
        {
            Contexto.Set<T>()
                .Where(predicate).ToList()
                .ForEach(del => Contexto.Set<T>().Remove(del));
        }
        public void Delete(T entity)
        {
            Contexto.Set<T>().Remove(entity);
        }
        public void Dispose()
        {
            if (Contexto != null)
            {
                Contexto.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}

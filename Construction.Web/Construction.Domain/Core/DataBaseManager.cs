using Construction.Domain.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Construction.Domain.Extensions;
namespace Construction.Domain.Core
{
    public class DataBaseManager<T> where T : class
    {
        private static DataBaseManager<T> databaseManager;
        private static DatabaseContext dataContext = DatabaseContext.Create();
        private readonly IDbSet<T> dbset;

        public DataBaseManager()
        {
            dbset = dataContext.Set<T>();
        }
        public static DataBaseManager<T> Create()
        {
            return databaseManager ?? (databaseManager = new DataBaseManager<T>());
        }
        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        public virtual T GetById(long id)
        {
            return dbset.Find(id);
        }
        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }
        public virtual Result<List<T>> GetAll<TOrder>(Page page, Expression<Func<T, TOrder>> order)
        {
            var data = dbset.OrderBy(order).GetPage(page).ToList();
            int totalRow = dbset.Count();
            var result = new Result<List<T>>
            {
                Results = data,
                TotalRow = totalRow
            };
            return result;
        }
        public virtual Result<List<T>> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order)
        {
            var data = dbset.OrderBy(order).Where(where).GetPage(page).ToList();
            var totalRow = dbset.Count(where);
            var result = new Result<List<T>>
            {
                Results = data,
                TotalRow = totalRow
            };
            return result;
        }

        public int Save()
        {
            return dataContext.SaveChanges();
        }

    }
}

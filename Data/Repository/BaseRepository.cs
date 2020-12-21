using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FProject.Domain.Interfaces;
using LinqToDB;

namespace FProject.Data.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public DataConnection Db { get; set; }
        public BaseRepository(DataConnection db)
        {
            Db = db;
        }
        public T Create(T model)
        {
            return Db.InsertWithIdentity(model) as T;
        }

        public List<T> ReadAll()
        {
            var table = GetQuery(Db);
            return table.ToList();
        }

        public void Update(T model)
        {
            Db.Update(model);
        }

        public void Delete(T model)
        {
            Db.Delete(model);
        }

        protected ITable<T> GetQuery ( DataConnection db )
        {
            return db.GetTable<T>();
        }

        protected T GetOne(Expression<Func<T, bool>> predicate)
        {
            return GetQuery(Db).FirstOrDefault(predicate);
        }

    }
}

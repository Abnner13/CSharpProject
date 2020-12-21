using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
        public async Task<T> Create(T model) => await Db.InsertWithInt32IdentityAsync(model) as T;

        public async Task Update(T model) => await Db.UpdateAsync(model);

        public async Task Delete(T model) => await Db.DeleteAsync(model);
        
        public List<T> ReadAll()
        {
            var table = GetQuery(Db);
            return table.ToList();
        }
        
        protected ITable<T> GetQuery ( DataConnection db )
        {
            return db.GetTable<T>();
        }

        protected async Task<T> GetOne(Expression<Func<T, bool>> predicate)
        {
            return await GetQuery(Db).FirstOrDefaultAsync(predicate);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FProject.Domain.Entities;
using FProject.Domain.Interfaces;
using LinqToDB;

namespace FProject.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataConnection db) : base(db) { }

        public async Task<User> CreateUser(User model)
        {
            var id = Db.User.InsertWithInt32Identity(() => new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
            });

            return await Get(id);
        }
        public async Task<User> Get(int id)
        {
            var dataTable = GetQuery(Db);

            return await GetOne(x => x.Id == id);
        }

        public async Task UpdateUser(int id, User model)
        {
            var dataTable = GetQuery(Db);

            await dataTable
                .Where(x => x.Id == id)
                .Set(t => t.Username, model.Username)
                .Set(t => t.Email, model.Email)
                .UpdateAsync();
        }

        public async Task DeleteUser(int id)
        {
            await GetQuery(Db)
                .Where(x => x.Id == id)
                .DeleteAsync();
        }

        public List<User> SelectAll()
        {
            return ReadAll();
        }
        public async Task<bool> Exists(int id) => await Db.User.AnyAsync(x => x.Id == id);
        public async Task<bool> ExistsUsername(string username) => await Db.User
                                                                .AnyAsync(x => x.Username == username);
    }
}

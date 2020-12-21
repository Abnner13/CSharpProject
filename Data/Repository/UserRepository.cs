using System.Collections.Generic;
using System.Linq;
using FProject.Domain.Entities;
using FProject.Domain.Interfaces;
using LinqToDB;

namespace FProject.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataConnection db) : base(db) { }

        public User CreateUser(User model)
        {
            var id = Db.User.InsertWithInt32Identity(() => new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
            });

            return Get(id);
        }
        public User Get(int id)
        {
            var dataTable = GetQuery(Db);

            return GetOne(x => x.Id == id);
        }

        public void UpdateUser(int id, User model)
        {
            var dataTable = GetQuery(Db);

            dataTable
                .Where(x => x.Id == id)
                .Set(t => t.Username, model.Username)
                .Set(t => t.Email, model.Email)
                .Update();
        }

        public void DeleteUser(int id)
        {
            GetQuery(Db)
                .Where(x => x.Id == id)
                .Delete();
        }

        public List<User> SelectAll()
        {
            return ReadAll();
        }

        public bool Exists(int id)
        {
            return Db.User.Any(x => x.Id == id);
        }
        public bool ExistsUsername(string username)
        {
            return Db.User.Any(x => x.Username == username);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using FProject.Domain.Entities;

namespace FProject.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        List<User> SelectAll();
        Task<User> CreateUser(User model, string salt, string hashPassword);
        Task<User> Get(int id);
        Task UpdateUser(int id, User model);
        Task DeleteUser( int id );
        Task<bool> Exists(int id);
        Task<bool> ExistsUsername(string username);
    }
}

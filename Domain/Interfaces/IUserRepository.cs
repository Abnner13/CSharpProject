using System.Collections.Generic;
using FProject.Domain.Entities;

namespace FProject.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        List<User> SelectAll();
        User CreateUser(User model);
        User Get(int id);
        void UpdateUser(int id, User model);
        void DeleteUser( int id );
        bool Exists(int id);
        bool ExistsUsername(string username);
    }
}

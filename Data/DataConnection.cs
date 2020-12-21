using LinqToDB;
using FProject.Domain.Entities;

namespace FProject.Data
{
    public class DataConnection : LinqToDB.Data.DataConnection
    {
        public DataConnection() : base("FProjectDb") { }

        public ITable<User> User => GetTable<User>();
    }
}

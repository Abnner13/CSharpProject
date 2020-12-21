using LinqToDB.Mapping;

namespace FProject.Domain.Entities
{
    [Table(Name = "User")]
    public class User
    {
        [Column(Name = "Id"), PrimaryKey, Identity]
        public int Id { get; set; }

        [Column(Name = "Username"), NotNull]
        public string Username { get; set; }

        [Column(Name = "Email"), NotNull]
        public string Email { get; set; }

        [Column(Name = "Password"), NotNull]
        public string Password { get; set; }        
    }
}

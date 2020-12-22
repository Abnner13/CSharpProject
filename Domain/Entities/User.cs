using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations;

namespace FProject.Domain.Entities
{
    [Table(Name = "User")]
    public class User
    {
        [Column(Name = "Id"), PrimaryKey, Identity]
        public int Id { get; set; }
        [StringLength(30, MinimumLength=3, ErrorMessage = "Nome deve ter no máximo 30 caracteres. E no minimo 2")]
        [Column(Name = "Username"), NotNull]
        public string Username { get; set; }

        [Column(Name = "Email"), NotNull]
        public string Email { get; set; }

        [Column(Name = "Password"), NotNull]
        [Required(ErrorMessage = "Senha é necessaria")]
        public string Password { get; set; }

        [Column(Name = "Salt"), NotNull]
        public string Salt { get; set; }
    }
}

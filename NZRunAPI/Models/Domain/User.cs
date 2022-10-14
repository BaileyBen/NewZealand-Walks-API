using System.ComponentModel.DataAnnotations.Schema;

namespace NZRunAPI.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string EmailAdress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Roles { get; set; }
        [NotMapped]
        public List<User_Role> UserRoles { get; set; }
    }
}

using NZRunAPI.Models.Domain;

namespace NZRunAPI.Repositories
{
    public interface IUserRepository
    {
       Task<User> AuthenticateAsync(string userName, string Password);
    }
}

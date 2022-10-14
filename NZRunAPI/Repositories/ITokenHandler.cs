using NZRunAPI.Models.Domain;

namespace NZRunAPI.Repositories
{
    public interface ITokenHandler
    {
        Task<string>CreateTokenAsync(User user);
    }
}

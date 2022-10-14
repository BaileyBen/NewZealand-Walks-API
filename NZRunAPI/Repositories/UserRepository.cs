using Microsoft.EntityFrameworkCore;
using NZRunAPI.Data;
using NZRunAPI.Models.Domain;

namespace NZRunAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public UserRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AuthenticateAsync(string userName, string password)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Username.ToLower() == userName.ToLower() && x.Password == password);

            if (user == null)
            {
                return null;
            }
            var userRoles = await _dbContext.Users_Roles.Where(x => x.UserId == user.Id).ToListAsync();

            if (userRoles.Any())
            {
                user.Roles = new List<string>();
                foreach (var userRole in userRoles)
                {
                    var role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
                    if (role != null)
                    {
                        user.Roles.Add(role.Name);
                    }
                }
            }
            user.Password = null;
            return user;
        }
    }
}

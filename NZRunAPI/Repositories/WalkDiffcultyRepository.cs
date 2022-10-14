using Microsoft.EntityFrameworkCore;
using NZRunAPI.Data;
using NZRunAPI.Models.Domain;

namespace NZRunAPI.Repositories
{
    public class WalkDiffcultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDbContext _context;

        public WalkDiffcultyRepository(NZWalksDbContext context)
        {
            _context = context;
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();
            await _context.WalkDifficulty.AddAsync(walkDifficulty);
            await _context.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var existingWalkDifficulty = await _context.WalkDifficulty.FindAsync(id);

            if (existingWalkDifficulty != null)
            {
                _context.WalkDifficulty.Remove(existingWalkDifficulty);
                _context.SaveChangesAsync();
                return existingWalkDifficulty;
            }
            return null;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetallAsync()
        {
            return await _context.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            return await _context.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var existingWalkDifficulty = await _context.WalkDifficulty.FindAsync(id);

            if (walkDifficulty == null)
            {
                return null;
            }

            existingWalkDifficulty.Code = walkDifficulty.Code;

            await _context.SaveChangesAsync();
            return existingWalkDifficulty;
        }
    }
}

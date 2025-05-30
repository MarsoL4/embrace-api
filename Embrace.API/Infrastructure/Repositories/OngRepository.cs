using Embrace.API.Infrastructure.Contexts;
using Embrace.API.Infrastructure.Persistence;
using Embrace.API.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Embrace.API.Infrastructure.Repositories
{
    public class OngRepository : IOngRepository
    {
        private readonly EmbraceDbContext _context;

        public OngRepository(EmbraceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ong>> GetAllAsync()
        {
            return await _context.Ongs.ToListAsync();
        }

        public async Task<Ong?> GetByIdAsync(long id)
        {
            return await _context.Ongs.FindAsync(id);
        }

        public async Task AddAsync(Ong ong)
        {
            await _context.Ongs.AddAsync(ong);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ong ong)
        {
            _context.Ongs.Update(ong);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var ong = await GetByIdAsync(id);
            if (ong != null)
            {
                _context.Ongs.Remove(ong);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using Embrace.API.Infrastructure.Contexts;
using Embrace.API.Infrastructure.Persistence;
using Embrace.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Embrace.API.Repositories
{
    public class VoluntarioRepository : IVoluntarioRepository
    {
        private readonly EmbraceDbContext _context;

        public VoluntarioRepository(EmbraceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Voluntario>> GetAllAsync()
        {
            return await _context.Voluntarios.ToListAsync();
        }

        public async Task<Voluntario?> GetByIdAsync(long id)
        {
            return await _context.Voluntarios.FindAsync(id);
        }

        public async Task AddAsync(Voluntario voluntario)
        {
            await _context.Voluntarios.AddAsync(voluntario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Voluntario voluntario)
        {
            _context.Voluntarios.Update(voluntario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var voluntario = await GetByIdAsync(id);
            if (voluntario != null)
            {
                _context.Voluntarios.Remove(voluntario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
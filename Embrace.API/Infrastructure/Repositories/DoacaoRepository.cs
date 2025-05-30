using Embrace.API.Infrastructure.Contexts;
using Embrace.API.Infrastructure.Persistence;
using Embrace.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Embrace.API.Repositories
{
    public class DoacaoRepository : IDoacaoRepository
    {
        private readonly EmbraceDbContext _context;

        public DoacaoRepository(EmbraceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doacao>> GetAllAsync()
        {
            return await _context.Doacoes.ToListAsync();
        }

        public async Task<Doacao?> GetByIdAsync(long id)
        {
            return await _context.Doacoes.FindAsync(id);
        }

        public async Task AddAsync(Doacao doacao)
        {
            await _context.Doacoes.AddAsync(doacao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Doacao doacao)
        {
            _context.Doacoes.Update(doacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var doacao = await GetByIdAsync(id);
            if (doacao != null)
            {
                _context.Doacoes.Remove(doacao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
using Embrace.API.Infrastructure.Contexts;
using Embrace.API.Infrastructure.Persistence;
using Embrace.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Embrace.API.Repositories
{
    public class PontoDeAlimentoRepository : IPontoDeAlimentoRepository
    {
        private readonly EmbraceDbContext _context;

        public PontoDeAlimentoRepository(EmbraceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PontoDeAlimento>> GetAllAsync()
        {
            return await _context.PontosDeAlimento.ToListAsync();
        }

        public async Task<PontoDeAlimento?> GetByIdAsync(long id)
        {
            return await _context.PontosDeAlimento.FindAsync(id);
        }

        public async Task AddAsync(PontoDeAlimento ponto)
        {
            await _context.PontosDeAlimento.AddAsync(ponto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PontoDeAlimento ponto)
        {
            _context.PontosDeAlimento.Update(ponto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var ponto = await GetByIdAsync(id);
            if (ponto != null)
            {
                _context.PontosDeAlimento.Remove(ponto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
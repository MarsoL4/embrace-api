using Embrace.API.Infrastructure.Contexts;
using Embrace.API.Infrastructure.Persistence;
using Embrace.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Embrace.API.Repositories
{
    public class AcaoSolidariaRepository : IAcaoSolidariaRepository
    {
        private readonly EmbraceDbContext _context;

        public AcaoSolidariaRepository(EmbraceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AcaoSolidaria>> GetAllAsync()
        {
            return await _context.AcoesSolidarias.ToListAsync();
        }

        public async Task<AcaoSolidaria?> GetByIdAsync(long id)
        {
            return await _context.AcoesSolidarias.FindAsync(id);
        }

        public async Task AddAsync(AcaoSolidaria acao)
        {
            await _context.AcoesSolidarias.AddAsync(acao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AcaoSolidaria acao)
        {
            _context.AcoesSolidarias.Update(acao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var acao = await GetByIdAsync(id);
            if (acao != null)
            {
                _context.AcoesSolidarias.Remove(acao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
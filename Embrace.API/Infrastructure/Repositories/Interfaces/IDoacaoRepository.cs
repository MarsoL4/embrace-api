using Embrace.API.Infrastructure.Persistence;

namespace Embrace.API.Repositories.Interfaces
{
    public interface IDoacaoRepository
    {
        Task<IEnumerable<Doacao>> GetAllAsync();
        Task<Doacao?> GetByIdAsync(long id);
        Task AddAsync(Doacao doacao);
        Task UpdateAsync(Doacao doacao);
        Task DeleteAsync(long id);
    }
}
using Embrace.API.Infrastructure.Persistence;

namespace Embrace.API.Repositories.Interfaces
{
    public interface IPontoDeAlimentoRepository
    {
        Task<IEnumerable<PontoDeAlimento>> GetAllAsync();
        Task<PontoDeAlimento?> GetByIdAsync(long id);
        Task AddAsync(PontoDeAlimento ponto);
        Task UpdateAsync(PontoDeAlimento ponto);
        Task DeleteAsync(long id);
    }
}
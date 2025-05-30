using Embrace.API.Infrastructure.Persistence;

namespace Embrace.API.Repositories.Interfaces
{
    public interface IAcaoSolidariaRepository
    {
        Task<IEnumerable<AcaoSolidaria>> GetAllAsync();
        Task<AcaoSolidaria?> GetByIdAsync(long id);
        Task AddAsync(AcaoSolidaria acao);
        Task UpdateAsync(AcaoSolidaria acao);
        Task DeleteAsync(long id);
    }
}
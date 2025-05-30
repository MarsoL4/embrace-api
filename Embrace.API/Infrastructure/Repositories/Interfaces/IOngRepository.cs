using Embrace.API.Infrastructure.Persistence;

namespace Embrace.API.Infrastructure.Repositories.Interfaces
{
    public interface IOngRepository
    {
        Task<IEnumerable<Ong>> GetAllAsync();
        Task<Ong?> GetByIdAsync(long id);
        Task AddAsync(Ong ong);
        Task UpdateAsync(Ong ong);
        Task DeleteAsync(long id);
    }
}

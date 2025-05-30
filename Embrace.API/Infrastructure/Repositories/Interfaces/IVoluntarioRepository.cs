using Embrace.API.Infrastructure.Persistence;

namespace Embrace.API.Repositories.Interfaces
{
    public interface IVoluntarioRepository
    {
        Task<IEnumerable<Voluntario>> GetAllAsync();
        Task<Voluntario?> GetByIdAsync(long id);
        Task AddAsync(Voluntario voluntario);
        Task UpdateAsync(Voluntario voluntario);
        Task DeleteAsync(long id);
    }
}
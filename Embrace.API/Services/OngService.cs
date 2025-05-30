using AutoMapper;
using Embrace.API.DTOs;
using Embrace.API.Infrastructure.Persistence;
using Embrace.API.Infrastructure.Repositories.Interfaces;

namespace Embrace.API.Services
{
    public class OngService
    {
        private readonly IOngRepository _repository;
        private readonly IMapper _mapper;

        public OngService(IOngRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OngDTO>> GetAllAsync()
        {
            var ongs = await _repository.GetAllAsync();
            return _mapper.Map<List<OngDTO>>(ongs);
        }

        public async Task<OngDTO?> GetByIdAsync(long id)
        {
            var ong = await _repository.GetByIdAsync(id);
            return ong == null ? null : _mapper.Map<OngDTO>(ong);
        }

        public async Task AddAsync(OngDTO dto)
        {
            var ong = _mapper.Map<Ong>(dto);
            await _repository.AddAsync(ong);
        }

        public async Task UpdateAsync(OngDTO dto)
        {
            var ong = _mapper.Map<Ong>(dto);
            await _repository.UpdateAsync(ong);
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
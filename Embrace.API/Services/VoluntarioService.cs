using AutoMapper;
using Embrace.API.DTOs;
using Embrace.API.Infrastructure.Persistence;
using Embrace.API.Repositories.Interfaces;

namespace Embrace.API.Services
{
    public class VoluntarioService
    {
        private readonly IVoluntarioRepository _repository;
        private readonly IMapper _mapper;

        public VoluntarioService(IVoluntarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<VoluntarioDTO>> GetAllAsync()
        {
            var voluntarios = await _repository.GetAllAsync();
            return _mapper.Map<List<VoluntarioDTO>>(voluntarios);
        }

        public async Task<VoluntarioDTO?> GetByIdAsync(long id)
        {
            var voluntario = await _repository.GetByIdAsync(id);
            return voluntario == null ? null : _mapper.Map<VoluntarioDTO>(voluntario);
        }

        public async Task AddAsync(VoluntarioDTO dto)
        {
            var voluntario = _mapper.Map<Voluntario>(dto);
            await _repository.AddAsync(voluntario);
        }

        public async Task UpdateAsync(VoluntarioDTO dto)
        {
            var voluntario = _mapper.Map<Voluntario>(dto);
            await _repository.UpdateAsync(voluntario);
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
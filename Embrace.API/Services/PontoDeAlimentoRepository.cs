using AutoMapper;
using Embrace.API.DTOs;
using Embrace.API.Infrastructure.Persistence;
using Embrace.API.Repositories.Interfaces;

namespace Embrace.API.Services
{
    public class PontoDeAlimentoService
    {
        private readonly IPontoDeAlimentoRepository _repository;
        private readonly IMapper _mapper;

        public PontoDeAlimentoService(IPontoDeAlimentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PontoDeAlimentoDTO>> GetAllAsync()
        {
            var pontos = await _repository.GetAllAsync();
            return _mapper.Map<List<PontoDeAlimentoDTO>>(pontos);
        }

        public async Task<PontoDeAlimentoDTO?> GetByIdAsync(long id)
        {
            var ponto = await _repository.GetByIdAsync(id);
            return ponto == null ? null : _mapper.Map<PontoDeAlimentoDTO>(ponto);
        }

        public async Task AddAsync(PontoDeAlimentoDTO dto)
        {
            var ponto = _mapper.Map<PontoDeAlimento>(dto);
            await _repository.AddAsync(ponto);
        }

        public async Task UpdateAsync(PontoDeAlimentoDTO dto)
        {
            var ponto = _mapper.Map<PontoDeAlimento>(dto);
            await _repository.UpdateAsync(ponto);
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
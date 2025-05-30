using AutoMapper;
using Embrace.API.DTOs;
using Embrace.API.Infrastructure.Persistence;
using Embrace.API.Repositories.Interfaces;

namespace Embrace.API.Services
{
    public class DoacaoService
    {
        private readonly IDoacaoRepository _repository;
        private readonly IMapper _mapper;

        public DoacaoService(IDoacaoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<DoacaoDTO>> GetAllAsync()
        {
            var doacoes = await _repository.GetAllAsync();
            return _mapper.Map<List<DoacaoDTO>>(doacoes);
        }

        public async Task<DoacaoDTO?> GetByIdAsync(long id)
        {
            var doacao = await _repository.GetByIdAsync(id);
            return doacao == null ? null : _mapper.Map<DoacaoDTO>(doacao);
        }

        public async Task AddAsync(DoacaoDTO dto)
        {
            var doacao = _mapper.Map<Doacao>(dto);
            await _repository.AddAsync(doacao);
        }

        public async Task UpdateAsync(DoacaoDTO dto)
        {
            var doacao = _mapper.Map<Doacao>(dto);
            await _repository.UpdateAsync(doacao);
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
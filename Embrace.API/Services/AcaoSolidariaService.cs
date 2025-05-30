using AutoMapper;
using Embrace.API.DTOs;
using Embrace.API.Infrastructure.Persistence;
using Embrace.API.Repositories.Interfaces;

namespace Embrace.API.Services
{
    public class AcaoSolidariaService
    {
        private readonly IAcaoSolidariaRepository _repository;
        private readonly IMapper _mapper;

        public AcaoSolidariaService(IAcaoSolidariaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AcaoSolidariaDTO>> GetAllAsync()
        {
            var acoes = await _repository.GetAllAsync();
            return _mapper.Map<List<AcaoSolidariaDTO>>(acoes);
        }

        public async Task<AcaoSolidariaDTO?> GetByIdAsync(long id)
        {
            var acao = await _repository.GetByIdAsync(id);
            return acao == null ? null : _mapper.Map<AcaoSolidariaDTO>(acao);
        }

        public async Task AddAsync(AcaoSolidariaDTO dto)
        {
            var acao = _mapper.Map<AcaoSolidaria>(dto);
            await _repository.AddAsync(acao);
        }

        public async Task UpdateAsync(AcaoSolidariaDTO dto)
        {
            var acao = _mapper.Map<AcaoSolidaria>(dto);
            await _repository.UpdateAsync(acao);
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
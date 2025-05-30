using AutoMapper;
using Embrace.API.DTOs;
using Embrace.API.Infrastructure.Persistence;
using Microsoft.CodeAnalysis;

namespace Embrace.API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ong, OngDTO>().ReverseMap();
            CreateMap<AcaoSolidaria, AcaoSolidariaDTO>().ReverseMap();
            CreateMap<Doacao, DoacaoDTO>().ReverseMap();
            CreateMap<Voluntario, VoluntarioDTO>().ReverseMap();
            CreateMap<VoluntarioAcao, VoluntarioAcaoDTO>().ReverseMap();
            CreateMap<PontoDeAlimento, PontoDeAlimentoDTO>().ReverseMap();
        }
    }
}
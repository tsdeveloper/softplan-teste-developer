using API.CalcularJuros.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Specification.TaxaJuros.SpecParams;

namespace API.CalcularJuros.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TaxaJuro, TaxaJuroToReturnDto>()
                .ReverseMap();

            CreateMap<TaxaJuro, TaxaJuroSpecParams>()
                .ReverseMap();

            CreateMap<TaxaJuroToReturnDto, TaxaJuroSpecParams>()
                .ReverseMap();
        }
    }
}
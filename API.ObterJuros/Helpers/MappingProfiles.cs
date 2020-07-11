using API.ObterJuros.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Specification.TaxaJuros.SpecParams;

namespace API.ObterJuros.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
          CreateMap<TaxaJuro, TaxaJuroToReturnDto>()
                .ReverseMap();
          
          CreateMap<TaxaJuroToReturnDto, TaxaJuroSpecParams>()
              .ReverseMap();
          
        }
    }
}
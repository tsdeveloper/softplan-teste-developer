using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Specification.TaxaJuros.SpecParams;

namespace API.Helpers
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
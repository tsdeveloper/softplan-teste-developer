using API.ObterJuros.Dtos;
using API.ObterJuros.Errors;
using AutoMapper;
using Core.Specification.TaxaJuros.SpecParams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.ObterJuros.Controllers
{
 
    public class TaxaJurosController : BaseApiController
    {
     
        private readonly IMapper _mapper;
       
        public TaxaJurosController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Route("taxajuros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<TaxaJuroToReturnDto> GetTaxaJuros()
        {
            var data = _mapper.Map<TaxaJuroToReturnDto>(new TaxaJuroSpecParams());
            
        return Ok(data);
        }

       

    }
}
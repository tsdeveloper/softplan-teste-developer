using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification.TaxaJuros.SpecParams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
 
    public class TaxaJurosController : BaseApiController
    {
     
        private readonly IMapper _mapper;
        private readonly ITaxaJuroService _taxaJuroService;


        public TaxaJurosController(IMapper mapper, ITaxaJuroService taxaJuroService)
        {
            _mapper = mapper;
            _taxaJuroService = taxaJuroService;
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

        [HttpGet]
        [Route("calculajuros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public  ActionResult<TaxaJuroToReturnDto> GetCalculaJuros([FromQuery] TaxaJuroSpecParams taxaJuroParams)
        {
            var data = _mapper.Map<TaxaJuroToReturnDto>(_taxaJuroService.CalcularJuros(_mapper.Map<TaxaJuro>(taxaJuroParams)));
            
            return Ok(data);
        }

    }
}
using API.ObterJuros.Errors;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.ObterJuros.Controllers
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
        public ActionResult GetTaxaJuros()
        {
            var data = _taxaJuroService.ValorTaxaJuros();

            return Ok(data);
        }
    }
}
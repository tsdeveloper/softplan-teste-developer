using System.Threading.Tasks;
using API.CalcularJuros.Dtos;
using API.CalcularJuros.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification.TaxaJuros.SpecParams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace API.CalcularJuros.Controllers
{
    public class TaxaJurosController : BaseApiController
    {
        private const string BASE_URL_API = "https://localhost:5001/api";

        private readonly IMapper _mapper;
        private readonly ITaxaJuroService _taxaJuroService;


        public TaxaJurosController(IMapper mapper, ITaxaJuroService taxaJuroService)
        {
            _mapper = mapper;
            _taxaJuroService = taxaJuroService;
        }

        [HttpGet]
        [Route("calculajuros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TaxaJuroToReturnDto>> GetCalculaJuros([FromQuery] TaxaJuroSpecParams taxaJuroParams)
        {
            var client = new RestClient($"{BASE_URL_API}/taxajuros/taxajuros");
            var request = new RestRequest(Method.GET) {RequestFormat = DataFormat.Json};
            var result = await client.ExecuteGetAsync(request);
            var response = JsonConvert.DeserializeObject<decimal?>(result.Content);
            if (response != null && response > 0)
            {
                taxaJuroParams.ValorJuro = response.Value;
                var data = _mapper.Map<TaxaJuroToReturnDto>(
                    _taxaJuroService.CalcularJuros(_mapper.Map<TaxaJuro>(taxaJuroParams)));

                return Ok(data);
            }

            return new EmptyResult();
        }
    }
}
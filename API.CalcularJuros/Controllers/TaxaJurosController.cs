using System;
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
     
        private readonly IMapper _mapper;
        private readonly ITaxaJuroService _taxaJuroService;
        private const string BASE_URL_API = "https://localhost:5001/api";


        public TaxaJurosController(IMapper mapper, ITaxaJuroService taxaJuroService)
        {
            _mapper = mapper;
            _taxaJuroService = taxaJuroService;
        }

       [HttpGet]
        [Route("calculajuros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public  ActionResult<TaxaJuroToReturnDto> GetCalculaJuros([FromQuery] TaxaJuroSpecParams taxaJuroParams)
        {
            var client = new RestClient($"{BASE_URL_API}/taxajuros/taxajuros");
            var request = new RestRequest(Method.GET) {RequestFormat =  DataFormat.Json};
            var response = JsonConvert.DeserializeObject<TaxaJuroToReturnDto>(client.Execute(request).Content);
            if (response != null)
            {
                taxaJuroParams.ValorJuro = response.ValorJuro;
                var data = _mapper.Map<TaxaJuroToReturnDto>(_taxaJuroService.CalcularJuros(_mapper.Map<TaxaJuro>(taxaJuroParams)));
            
                return Ok(data);    
            }

            return Ok(new TaxaJuroToReturnDto());

        }

    }
}
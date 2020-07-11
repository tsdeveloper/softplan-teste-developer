using System;
using System.Web.Http;
using System.Web.Http.Results;
using Common.Factory;
using Core.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace API.ObterJuros.Tests
{
  
    public class TaxaJuroTests
    {
        [Theory]
        [Trait("Developer", "Taxa Juros Trait Test")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(0)]
        [InlineData(null)]
        public void TaxaJuro_ObterTempo_DeveSerMaiorQueZero(int? tempo)
        {
            #region Arrange

            var taxaJuro = new TaxaJuro().BuildFactory(100, 0.01M, tempo.Value);

            #endregion

            #region Act

            var resultado = taxaJuro.Tempo;

            #endregion

            #region Assert

            resultado.Should().BeGreaterOrEqualTo(1);

            #endregion
        }
        
        [Fact]
        [Trait("Developer", "Taxa Juros Trait Test")]
        public void TaxaJuro_ObterValorTaxaJuro_DeveSerMaiorQueZero()
        {
            #region Arrange

            var taxaJuro = new TaxaJuro().BuildFactory();

            #endregion

            #region Act

            var resultado = taxaJuro.ValorJuro;

            #endregion

            #region Assert

            resultado.Should().BeGreaterOrEqualTo(0.01M);

            #endregion
        }
    }
}
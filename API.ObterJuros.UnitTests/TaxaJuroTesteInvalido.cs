using System;
using System.Web.Http;
using System.Web.Http.Results;
using API.ObterJuros.UnitTests.Fixture;
using Common.Factory;
using Core.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace API.ObterJuros.UnitTests
{
    [Collection(nameof(TaxaJuroCollection))]
    public class TaxaJuroTesteInvalido
    {
        [Collection(nameof(TaxaJuroCollection))]
        public class TaxaJuroTesteInValido
        {
            private readonly TaxaJuroTestsFixture _taxaJuroTestsFixture;

            public TaxaJuroTesteInValido(TaxaJuroTestsFixture taxaJuroTestsFixture)
            {
                _taxaJuroTestsFixture = taxaJuroTestsFixture;
            }

            [Theory]
            [Trait("Developer", "Taxa Juros Trait Test")]
            [InlineData(0)]
            [InlineData(null)]
            public void TaxaJuro_ObterTempo_DeveEstaInvalido(int? tempo)
            {
                #region Arrange

                var taxaJuro = _taxaJuroTestsFixture.GerarTaxaJuroComTempoInValido(tempo);

                #endregion

                #region Act

                var resultado = taxaJuro.EhValido();

                #endregion

                #region Assert

                resultado.Should().BeFalse();
                taxaJuro.ValidationResult.Errors.Count.Should().Equals(1);

                #endregion
            }

            [Fact]
            [Trait("Developer", "Taxa Juros Trait Test")]
            public void TaxaJuro_ObterValorTaxaJuro_DeveEstaInvalido()
            {
                #region Arrange

                var taxaJuro = _taxaJuroTestsFixture.GerarTaxaJuroComValorJuroInvalido();

                #endregion

                
                #region Act

                var resultado = taxaJuro.EhValido();

                #endregion

                #region Assert

                resultado.Should().BeFalse();
                taxaJuro.ValidationResult.Errors.Count.Should().Equals(1);

                #endregion
            }
        }

    }
}
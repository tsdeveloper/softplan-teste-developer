using API.ObterJuros.UnitTests.Fixture;
using Common.Factory;
using Core.Entities;
using FluentAssertions;
using Xunit;

namespace API.ObterJuros.UnitTests
{
    [Collection(nameof(TaxaJuroCollection))]
    public class TaxaJuroTesteValido
    {
        private readonly TaxaJuroTestsFixture _taxaJuroTestsFixture;

        public TaxaJuroTesteValido(TaxaJuroTestsFixture taxaJuroTestsFixture)
        {
            _taxaJuroTestsFixture = taxaJuroTestsFixture;
        }
       
        [Theory]
        [Trait("Developer", "Taxa Juros Trait Test")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void TaxaJuro_ObterTempo_DeveEstaValido(int? tempo)
        {
            #region Arrange

            var taxaJuro = _taxaJuroTestsFixture.GerarTaxaJuroComTempoValido(tempo);

            #endregion

            #region Act

            var resultado = taxaJuro.EhValido();

            #endregion

            #region Assert

            resultado.Should().BeTrue();    
            taxaJuro.ValidationResult.Errors.Count.Should().Equals(0);

            #endregion
        }
        
        [Fact]
        [Trait("Developer", "Taxa Juros Trait Test")]
        public void TaxaJuro_ObterValorTaxaJuro_DeveEstaValido()
        {
            #region Arrange

            var taxaJuro = _taxaJuroTestsFixture.GerarTaxaJuroComValorJuroValido();

            #endregion

            #region Act

            var resultado = taxaJuro.EhValido();

            #endregion

            #region Assert

            resultado.Should().BeTrue();    
            taxaJuro.ValidationResult.Errors.Count.Should().Equals(0);

            #endregion
        }
    }
}
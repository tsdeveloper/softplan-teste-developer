using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using API.CalcularJuros.Dtos;
using FluentAssertions;
using Xunit;

namespace API.CalcularJuros.IntegrationTests
{
    [Collection(nameof(IntegrationApiTestFixtureCollection))]
    public class TaxaJurosApiTest
    {
        private readonly IntegrationTestFixture<API.CalcularJuros.StartupApiTest> _testFixture;

        public TaxaJurosApiTest(IntegrationTestFixture<API.CalcularJuros.StartupApiTest> testFixture)
        {
            _testFixture = testFixture;
        }
        [Fact(DisplayName = "Calcular o valor dos juros")]
        [Trait("Developer", "Integração API - TaxaJuros")]
        public async Task TaxaJuro_CalcularJuros_ValorFinalDeveSerMaiorQueZero()
        {
            var getResponse = await _testFixture.Client.GetAsync("api/taxajuros/calculajuros?ValorInicial=100&Tempo=5");

            var responseString = await getResponse.Content.ReadAsAsync<TaxaJuroToReturnDto>();
            getResponse.EnsureSuccessStatusCode();
            getResponse.StatusCode.Should().Equals(HttpStatusCode.OK);
            responseString.Should().NotBeNull().And.BeOfType<TaxaJuroToReturnDto>();
            responseString.ValorFinal.Should().BeGreaterThan(0);
        }
    }
}
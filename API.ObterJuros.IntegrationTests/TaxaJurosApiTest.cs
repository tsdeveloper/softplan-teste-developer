using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using API.ObterJuros.Dtos;
using FluentAssertions;
using Xunit;

namespace API.ObterJuros.IntegrationTests
{
    [Collection(nameof(IntegrationApiTestFixtureCollection))]
    public class TaxaJurosApiTest
    {
        private readonly IntegrationTestFixture<StartupApiTest> _testFixture;

        public TaxaJurosApiTest(IntegrationTestFixture<StartupApiTest> testFixture)
        {
            _testFixture = testFixture;
        }
        [Fact(DisplayName = "Obter valor juros")]
        [Trait("Developer", "Integração API - TaxaJuros")]
        public async Task TaxaJuro_ObterValorJuros_ValorJurosDeveSerMaiorQueZero()
        {
            var getResponse = await _testFixture.Client.GetAsync("api/taxajuros/taxajuros");

            var response = await getResponse.Content.ReadAsAsync<decimal>();
            getResponse.EnsureSuccessStatusCode();
            getResponse.StatusCode.Should().Equals(HttpStatusCode.OK);
            response.Should().BeGreaterThan(0);
        }
    }
}
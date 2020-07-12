using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace API.ObterJuros.IntegrationTests
{
    [CollectionDefinition(nameof(IntegrationApiTestFixtureCollection))]
    public class
        IntegrationApiTestFixtureCollection : ICollectionFixture<
            IntegrationTestFixture<StartupApiTest>>
    {
    }
    public class IntegrationTestFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly TaxaJuroAppFactory<TStartup> Factory;
        public HttpClient Client;

        public IntegrationTestFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions
            {
            };
            Factory = new TaxaJuroAppFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);
        }

        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}
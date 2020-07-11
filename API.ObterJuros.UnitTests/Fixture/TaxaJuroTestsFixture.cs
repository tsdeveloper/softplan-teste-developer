using System;
using Common.Factory;
using Core.Entities;
using Xunit;

namespace API.ObterJuros.UnitTests.Fixture
{
    [CollectionDefinition(nameof(TaxaJuroCollection))]
   public class TaxaJuroCollection : ICollectionFixture<TaxaJuroTestsFixture>
    {
        
    }
    public class TaxaJuroTestsFixture : IDisposable
    {
        

        public TaxaJuro GerarTaxaJuroComTempoValido(int? tempo)
        {
           return  new TaxaJuro().BuildFactory(100, 0.01M, tempo);
        }
        
        public TaxaJuro GerarTaxaJuroComValorJuroValido()
        {
            return  new TaxaJuro().BuildFactory(200, 0.01M, 1);
        }
        
        public TaxaJuro GerarTaxaJuroComValorJuroInvalido()
        {
            return  new TaxaJuro().BuildFactory(0, 0.01M, 1);
        }
        
        public TaxaJuro GerarTaxaJuroComTempoInValido(int? tempo)
        {
            return  new TaxaJuro().BuildFactory(100, 0.01M, tempo);
        }


        public void Dispose()
        {
            
        }
    }
}
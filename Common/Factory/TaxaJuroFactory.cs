using Core.Entities;

namespace Common.Factory
{
    public static class TaxaJuroFactory
    {
        public static TaxaJuro BuildFactory(this TaxaJuro taxaJuro)
        {
            return new TaxaJuro
            {
                ValorInicial = 100,
                ValorJuro = 0.01M,
                Tempo = 5
            };
        }

        public static TaxaJuro BuildFactory(this TaxaJuro taxaJuro, decimal valorInicial, decimal valorJuro, int? tempo)
        {
            return new TaxaJuro
            {
                ValorInicial = valorInicial,
                ValorJuro = valorJuro,
                Tempo = tempo ?? 0
            };
        }
    }
}
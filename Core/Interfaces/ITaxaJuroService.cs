using Core.Entities;

namespace Core.Interfaces
{
    public interface ITaxaJuroService
    {
        decimal ValorTaxaJuros();
        TaxaJuro CalcularJuros(TaxaJuro taxaJuro);
    }
}
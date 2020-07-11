using Core.Entities;

namespace Core.Interfaces
{
    public interface ITaxaJuroService
    {
        TaxaJuro CalcularJuros(TaxaJuro taxaJuro);
    }
}
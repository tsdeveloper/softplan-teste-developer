using System.Threading.Tasks;
using Core.Entities;
using Core.Specification.TaxaJuros.SpecParams;

namespace Core.Interfaces
{
    public interface ITaxaJuroService
    {
        TaxaJuro CalcularJuros(TaxaJuro taxaJuro);
    }
}
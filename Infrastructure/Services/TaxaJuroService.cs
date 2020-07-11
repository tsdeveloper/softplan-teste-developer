using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specification.TaxaJuros.SpecParams;

namespace Infrastructure.Services
{
    public class TaxaJuroService : ITaxaJuroService
    {
        
        public TaxaJuro CalcularJuros(TaxaJuro taxaJuro)
        {
            
            if (taxaJuro.ValorInicial > 0 && taxaJuro.Tempo > 0)
            {
                taxaJuro.TotalValorJuroComposto  = Convert.ToDecimal(Math.Pow(Convert.ToDouble(taxaJuro.ValorInicial * (1 + taxaJuro.ValorJuro)),taxaJuro.Tempo));
                
                return  taxaJuro;
            }
            
            return null;
        }
    }
}
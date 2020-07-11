using System;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class TaxaJuroService : ITaxaJuroService
    {
        public decimal ValorTaxaJuros()
        {
            return 0.01M;
        }

        public TaxaJuro CalcularJuros(TaxaJuro taxaJuro)
        {
            
            if (taxaJuro.ValorInicial > 0 && taxaJuro.Tempo > 0)
            {
                var resultTotalPotenciacao  =  Convert.ToDecimal(Math.Pow((1D + Convert.ToDouble(taxaJuro.ValorJuro)),taxaJuro.Tempo));

                taxaJuro.ValorFinal = Convert.ToDecimal(taxaJuro.ValorInicial * resultTotalPotenciacao).ToString("N2");
                return  taxaJuro;
            }
            
            return null;
        }
    }
}
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
                var resultTotalPotenciacao =
                    Convert.ToDecimal(Math.Pow(1D + Convert.ToDouble(taxaJuro.ValorJuro), taxaJuro.Tempo));

                var result = (taxaJuro.ValorInicial * resultTotalPotenciacao).ToString("N2");
                taxaJuro.ValorFinal = Convert.ToDecimal(result);
                return taxaJuro;
            }

            return null;
        }
    }
}
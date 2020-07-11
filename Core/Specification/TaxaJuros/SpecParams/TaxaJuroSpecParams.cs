using Core.Entities;

namespace Core.Specification.TaxaJuros.SpecParams
{
    public class TaxaJuroSpecParams : BaseSpecParams
    {
        private decimal _valorJuro = 0.01M;
        public decimal ValorJuro { get => _valorJuro;  }
        public decimal ValorInicial { get; set; }
        public int Tempo { get; set; }
      
    }
}
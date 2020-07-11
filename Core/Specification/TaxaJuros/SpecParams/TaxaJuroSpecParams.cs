using Core.Entities;

namespace Core.Specification.TaxaJuros.SpecParams
{
    public class TaxaJuroSpecParams : BaseSpecParams
    {
        public decimal ValorJuro { get; set; } = 0.01M;

        public decimal ValorInicial { get; set; }
        public int Tempo { get; set; }
    }
}
using Core.Entities;

namespace API.ObterJuros.Dtos
{
    public class TaxaJuroToReturnDto : BaseEntity
    {
        public decimal ValorJuro { get; set; }
        public decimal ValorInicial { get; set; }
        public int Tempo { get; set; }
        
    }
}
using Core.Entities;

namespace API.CalcularJuros.Dtos
{
    public class TaxaJuroToReturnDto : BaseEntity
    {
        public decimal ValorJuro { get; set; }
        public decimal ValorInicial { get; set; }
        public int Tempo { get; set; }
        public string ValorFinal { get; set; }
    }
}
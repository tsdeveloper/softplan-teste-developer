using FluentValidation;

namespace Core.Entities
{
    public class TaxaJuro : BaseEntity
    {
        public decimal ValorJuro { get; set; }
        public decimal ValorInicial { get; set; }
        public int Tempo { get; set; }
        public string ValorFinal { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new TaxaJuroValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class TaxaJuroValidacao : AbstractValidator<TaxaJuro>
    {
        public TaxaJuroValidacao()
        {
            RuleFor(j => j.Tempo)
                .GreaterThanOrEqualTo(1).WithMessage("Tempo não pode ser menor que 1");
            
            RuleFor(j => j.ValorInicial)
                .GreaterThan(0).WithMessage("Tempo não pode ser menor que 1");
        }
    }
}
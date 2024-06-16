using CorsiFormazione.Application.Models.Requests;
using FluentValidation;

namespace CorsiFormazione.Application.Validators
{
    public class EliminaCorsoValidator : AbstractValidator<EliminaCorsoRequest>
    {
        public EliminaCorsoValidator()
        {
            RuleFor(r => r.Nome)
                .NotNull()
                .WithMessage("Il nome del corso è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il nome del corso è obbligatorio (vuoto)");
        }
    }
}
